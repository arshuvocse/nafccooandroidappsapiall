/* =====================================================================
   Customer Category Request (MBE -> category select -> 4 documents -> approval)
   Run on SalesDisDB. Safe to re-run.
   ===================================================================== */

/* 1. Per-category limit on Customer Type
      NULL = not requestable from the app, 0 = no limit, >0 = max customers per MBE */
IF COL_LENGTH('dbo.tblCustomerType', 'RequestLimit') IS NULL
    ALTER TABLE dbo.tblCustomerType ADD RequestLimit INT NULL;
GO

-- Starting values (taken from the mockup); change these from the Customer Type page later.
UPDATE dbo.tblCustomerType SET RequestLimit = 5  WHERE CustomerType = 'PRITI' AND RequestLimit IS NULL;
UPDATE dbo.tblCustomerType SET RequestLimit = 10 WHERE CustomerType = 'DOSTI' AND RequestLimit IS NULL;
UPDATE dbo.tblCustomerType SET RequestLimit = 0  WHERE CustomerType = 'PRIME' AND RequestLimit IS NULL;
GO

-- Customer Type page SPs: new optional @RequestLimit. Existing callers keep working unchanged.
ALTER PROCEDURE [dbo].[sp_Save_CustomerTypeInfo]
    @id INT = 0,
    @CustomerType NVARCHAR(MAX),
    @EntryBy INT,
    @IsActive BIT,
    @IsCampaign BIT,
    @IsDefault BIT,
    @RequestLimit INT = NULL
AS
BEGIN
    IF NOT EXISTS (SELECT CustomerType FROM tblCustomerType WHERE CustomerType = @CustomerType)
    BEGIN
        DECLARE @DepartmentCode NVARCHAR(MAX)
        SELECT @DepartmentCode = 'CUS-' + CONVERT(NVARCHAR(MAX), COUNT(CustomerTypeId) + 10001) FROM tblCustomerType

        INSERT INTO tblCustomerType (CustTypeCode, CustomerType, EntryBy, EntryDate, IsActive, IsOrderApproval, IsDefault, RequestLimit)
        VALUES (@DepartmentCode, @CustomerType, @EntryBy, GETDATE(), @IsActive, @IsCampaign, @IsDefault, @RequestLimit)

        SELECT SCOPE_IDENTITY()
    END
    ELSE RETURN 0
END
GO

ALTER PROCEDURE [dbo].[sp_UD_CustomerTypeInfo]
    @id INT = 0,
    @CustomerType NVARCHAR(MAX),
    @UpdateBy INT,
    @IsActive BIT,
    @IsCampaign BIT,
    @IsDefault BIT,
    @RequestLimit INT = -1   -- -1 = leave unchanged (old callers do not send it)
AS
BEGIN
    UPDATE tblCustomerType
    SET IsDefault = @IsDefault, CustomerType = @CustomerType, UpdateBy = @UpdateBy, UpdateDate = GETDATE(),
        IsActive = @IsActive, IsOrderApproval = @IsCampaign,
        RequestLimit = CASE WHEN @RequestLimit = -1 THEN RequestLimit ELSE @RequestLimit END
    WHERE CustomerTypeId = @id
END
GO

/* 2. Approval menu. Set its role chain in the Approval Step setup page, same as Customer Approval (302). */
IF NOT EXISTS (SELECT 1 FROM dbo.tblMainMenuNew WHERE SL = 35900006)
    INSERT INTO dbo.tblMainMenuNew (SL, ManuName, URL, ParantId, IsApprovalPage, IsApp)
    VALUES (35900006, 'Customer Category Approval List', '#', 347, 1, 1);
GO

/* 3. Document image folder. Point the 'My' URL at the same site that serves the other app images. */
IF NOT EXISTS (SELECT 1 FROM dbo.tbl_ImagePath_Setting WHERE ImageType = 'CategoryRequest')
    INSERT INTO dbo.tbl_ImagePath_Setting (ImageType, ImagePreName, IsActive, ImagePath, Remarks)
    VALUES ('CategoryRequest', 'CatReq-', 1, 'D:\UBL_Apps_Images\CategoryRequest', 'CatReq-RequestId-DocType');
IF NOT EXISTS (SELECT 1 FROM dbo.tbl_ImagePath_Setting WHERE ImageType = 'CategoryRequestMy')
    INSERT INTO dbo.tbl_ImagePath_Setting (ImageType, ImagePreName, IsActive, ImagePath, Remarks)
    VALUES ('CategoryRequestMy', 'CatReq-', 1, 'http://103.244.247.93:93/CategoryRequest', NULL);
GO

/* 4. Tables */
IF OBJECT_ID('dbo.tblCustCategoryRequest') IS NULL
CREATE TABLE dbo.tblCustCategoryRequest (
    RequestId          INT IDENTITY(1,1) PRIMARY KEY,
    CustomerMasterId   INT NOT NULL,
    FromCustomerTypeId INT NULL,
    ToCustomerTypeId   INT NOT NULL,
    RequestBy          INT NOT NULL,                      -- EmpInfoId of the MBE
    RequestDate        DATETIME NOT NULL DEFAULT GETDATE(),
    FromRoleTypeId     INT NULL,                          -- requester role, picks the approval chain
    CurrentOrder       INT NOT NULL DEFAULT 1,            -- tblApprovalMapDetail.[Order] now waiting
    ToRoleTypeId       INT NULL,                          -- role that must act next
    Status             NVARCHAR(20) NOT NULL DEFAULT 'Pending'   -- Pending / Approved / Rejected
);
GO
IF OBJECT_ID('dbo.tblCustCategoryRequestLog') IS NULL
CREATE TABLE dbo.tblCustCategoryRequestLog (
    LogId      INT IDENTITY(1,1) PRIMARY KEY,
    RequestId  INT NOT NULL,
    EmpInfoId  INT NOT NULL,
    RoleTypeId INT NULL,
    Status     NVARCHAR(20) NOT NULL,                     -- Submitted / Approved / Rejected
    Comments   NVARCHAR(MAX) NULL,
    EntryDate  DATETIME NOT NULL DEFAULT GETDATE()
);
GO

/* 5. Stored procedures */

-- Category tiles: limit and used count (approved customers + own pending requests) per category
CREATE OR ALTER PROCEDURE dbo.sp_Webapi_CatReq_GetSummary
    @EmpId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT t.CustomerTypeId, t.CustomerType, t.RequestLimit,
           (SELECT COUNT(*) FROM dbo.tblCustMaster c
              JOIN dbo.View_CustomerMaster cv ON cv.CustomerMasterId = c.CustomerMasterId
             WHERE cv.MBEEmpInfoId = @EmpId AND c.IsActive = 1 AND c.CustomerTypeId = t.CustomerTypeId)
         + (SELECT COUNT(*) FROM dbo.tblCustCategoryRequest r
             WHERE r.RequestBy = @EmpId AND r.Status = 'Pending' AND r.ToCustomerTypeId = t.CustomerTypeId) AS UsedCount
    FROM dbo.tblCustomerType t
    WHERE t.IsActive = 1 AND t.RequestLimit IS NOT NULL
    ORDER BY t.CustomerTypeId;
END
GO

-- MBE's customers with current type and any pending request
CREATE OR ALTER PROCEDURE dbo.sp_Webapi_CatReq_GetCustomers
    @EmpId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT c.CustomerMasterId, c.CustomerCode, c.CustomerName, c.Address, c.CellNo,
           ISNULL(cv.MarketCode, '') + ' : ' + ISNULL(cv.MarketName, '') AS Market,
           c.CustomerTypeId, ct.CustomerType,
           pt.CustomerType AS PendingType
    FROM dbo.tblCustMaster c
    JOIN dbo.View_CustomerMaster cv ON cv.CustomerMasterId = c.CustomerMasterId
    LEFT JOIN dbo.tblCustomerType ct ON ct.CustomerTypeId = c.CustomerTypeId
    LEFT JOIN dbo.tblCustCategoryRequest r ON r.CustomerMasterId = c.CustomerMasterId AND r.Status = 'Pending'
    LEFT JOIN dbo.tblCustomerType pt ON pt.CustomerTypeId = r.ToCustomerTypeId
    WHERE cv.MBEEmpInfoId = @EmpId AND c.IsActive = 1
    ORDER BY c.CustomerName;
END
GO

-- Submit a request. Returns one row: RequestId (0 on failure), Msg
CREATE OR ALTER PROCEDURE dbo.sp_Webapi_CatReq_Save
    @EmpId INT,
    @CustomerMasterId INT,
    @ToCustomerTypeId INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @MenuId INT = 35900006, @RoleTypeId INT, @FromTypeId INT, @Limit INT, @Used INT,
            @NextRole INT, @NextOrder INT, @RequestId INT;

    IF NOT EXISTS (SELECT 1 FROM dbo.View_CustomerMaster WHERE CustomerMasterId = @CustomerMasterId AND MBEEmpInfoId = @EmpId)
        BEGIN SELECT 0 RequestId, 'This customer is not in your market.' Msg; RETURN; END

    SELECT @FromTypeId = CustomerTypeId FROM dbo.tblCustMaster WHERE CustomerMasterId = @CustomerMasterId;
    IF @FromTypeId = @ToCustomerTypeId
        BEGIN SELECT 0 RequestId, 'Customer is already in this category.' Msg; RETURN; END

    IF EXISTS (SELECT 1 FROM dbo.tblCustCategoryRequest WHERE CustomerMasterId = @CustomerMasterId AND Status = 'Pending')
        BEGIN SELECT 0 RequestId, 'A request for this customer is already pending.' Msg; RETURN; END

    SELECT @Limit = RequestLimit FROM dbo.tblCustomerType WHERE CustomerTypeId = @ToCustomerTypeId AND IsActive = 1;
    IF @Limit IS NULL
        BEGIN SELECT 0 RequestId, 'This category cannot be requested.' Msg; RETURN; END

    -- shortcut: limit is checked at submit only; two simultaneous submits can both pass
    IF @Limit > 0
    BEGIN
        SELECT @Used = UsedCount FROM (
            SELECT (SELECT COUNT(*) FROM dbo.tblCustMaster c JOIN dbo.View_CustomerMaster cv ON cv.CustomerMasterId = c.CustomerMasterId
                     WHERE cv.MBEEmpInfoId = @EmpId AND c.IsActive = 1 AND c.CustomerTypeId = @ToCustomerTypeId)
                 + (SELECT COUNT(*) FROM dbo.tblCustCategoryRequest
                     WHERE RequestBy = @EmpId AND Status = 'Pending' AND ToCustomerTypeId = @ToCustomerTypeId) AS UsedCount) x;
        IF @Used >= @Limit
            BEGIN SELECT 0 RequestId, 'Category limit is full.' Msg; RETURN; END
    END

    SELECT TOP 1 @RoleTypeId = ur.RoleTypeId
    FROM dbo.tblUser u JOIN dbo.tbl_UserRoleInfo ur ON ur.UserRoleID = u.UserRoleID
    WHERE u.EmpInfoId = @EmpId;

    -- Order 1 is the submitter (same convention as Customer Approval); first approver is the next order
    SELECT TOP 1 @NextRole = d.ToRoleId, @NextOrder = d.[Order]
    FROM dbo.tblApprovalMapMaster m JOIN dbo.tblApprovalMapDetail d ON d.ApprovalMapMasterId = m.ApprovalMapMasterId
    WHERE m.MenuId = @MenuId AND m.FromRoleId = @RoleTypeId AND d.[Order] > 1 AND d.ToRoleId IS NOT NULL
    ORDER BY d.[Order];

    IF @NextRole IS NULL
        BEGIN SELECT 0 RequestId, 'Approval step is not set up for your role.' Msg; RETURN; END

    BEGIN TRAN;
        INSERT INTO dbo.tblCustCategoryRequest (CustomerMasterId, FromCustomerTypeId, ToCustomerTypeId, RequestBy, FromRoleTypeId, CurrentOrder, ToRoleTypeId)
        VALUES (@CustomerMasterId, @FromTypeId, @ToCustomerTypeId, @EmpId, @RoleTypeId, @NextOrder, @NextRole);
        SET @RequestId = SCOPE_IDENTITY();
        INSERT INTO dbo.tblCustCategoryRequestLog (RequestId, EmpInfoId, RoleTypeId, Status) VALUES (@RequestId, @EmpId, @RoleTypeId, 'Submitted');
    COMMIT;

    SELECT @RequestId RequestId, 'Request submitted.' Msg;
END
GO

-- Approver list. @Status: Pending (waiting on me) / Approved / Rejected (acted on by me)
CREATE OR ALTER PROCEDURE dbo.sp_Webapi_CatReq_GetApprovalList
    @EmpId INT,
    @Status NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RoleTypeId INT, @Url NVARCHAR(500);
    SELECT TOP 1 @RoleTypeId = ur.RoleTypeId
    FROM dbo.tblUser u JOIN dbo.tbl_UserRoleInfo ur ON ur.UserRoleID = u.UserRoleID
    WHERE u.EmpInfoId = @EmpId;
    SELECT @Url = LTRIM(RTRIM(ImagePath)) + '/' + LTRIM(RTRIM(ImagePreName)) FROM dbo.tbl_ImagePath_Setting WHERE ImageType = 'CategoryRequestMy';

    SELECT TOP 300 r.RequestId, c.CustomerCode, c.CustomerName, c.Address, c.CellNo,
           ISNULL(cv.MarketCode, '') + ' : ' + ISNULL(cv.MarketName, '') AS Market,
           ft.CustomerType AS FromType, tt.CustomerType AS ToType,
           e.EmpName AS RequestBy, FORMAT(r.RequestDate, 'dd MMM yyyy') AS RequestDate, r.Status,
           cv.MBEEmpName AS MBEName, cv.MBEEmpMasterCode AS MBECode, tt.RequestLimit,
           (SELECT COUNT(*) FROM dbo.tblCustMaster c2 JOIN dbo.View_CustomerMaster cv2 ON cv2.CustomerMasterId = c2.CustomerMasterId
             WHERE cv2.MBEEmpInfoId = cv.MBEEmpInfoId AND c2.IsActive = 1 AND c2.CustomerTypeId = r.ToCustomerTypeId)
         + (SELECT COUNT(*) FROM dbo.tblCustCategoryRequest r2
             WHERE r2.RequestBy = cv.MBEEmpInfoId AND r2.Status = 'Pending' AND r2.ToCustomerTypeId = r.ToCustomerTypeId) AS UsedCount,
           @Url + CAST(r.RequestId AS NVARCHAR(20)) + '-ShopPhoto.jpg'    AS ShopPhotoUrl,
           @Url + CAST(r.RequestId AS NVARCHAR(20)) + '-NID.jpg'          AS NIDUrl,
           @Url + CAST(r.RequestId AS NVARCHAR(20)) + '-TradeLicense.jpg' AS TradeLicenseUrl,
           @Url + CAST(r.RequestId AS NVARCHAR(20)) + '-DrugLicense.jpg'  AS DrugLicenseUrl
    FROM dbo.tblCustCategoryRequest r
    JOIN dbo.tblCustMaster c ON c.CustomerMasterId = r.CustomerMasterId
    JOIN dbo.View_CustomerMaster cv ON cv.CustomerMasterId = r.CustomerMasterId
    LEFT JOIN dbo.tblCustomerType ft ON ft.CustomerTypeId = r.FromCustomerTypeId
    LEFT JOIN dbo.tblCustomerType tt ON tt.CustomerTypeId = r.ToCustomerTypeId
    LEFT JOIN dbo.tblEmpGeneralInfo e ON e.EmpInfoId = r.RequestBy
    WHERE (@Status = 'Pending'
           AND r.Status = 'Pending' AND r.ToRoleTypeId = @RoleTypeId
           AND (@RoleTypeId = 5 OR @EmpId IN (cv.MIOEmpInfoId, cv.ASMEmpInfoId, cv.RSMEmpInfoId, cv.NSMEmpInfoId)))
       OR (@Status <> 'Pending'
           AND EXISTS (SELECT 1 FROM dbo.tblCustCategoryRequestLog l WHERE l.RequestId = r.RequestId AND l.EmpInfoId = @EmpId AND l.Status = @Status))
    ORDER BY r.RequestId DESC;
END
GO

-- Approve / reject one step. Returns one row: Success, Msg
CREATE OR ALTER PROCEDURE dbo.sp_Webapi_CatReq_Approve
    @RequestId INT,
    @EmpId INT,
    @Status NVARCHAR(20),     -- Approved / Rejected
    @Comments NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @MenuId INT = 35900006, @RoleTypeId INT, @FromRole INT, @CurOrder INT, @NextRole INT, @NextOrder INT;

    IF @Status NOT IN ('Approved', 'Rejected')
        BEGIN SELECT 0 Success, 'Invalid status.' Msg; RETURN; END

    SELECT TOP 1 @RoleTypeId = ur.RoleTypeId
    FROM dbo.tblUser u JOIN dbo.tbl_UserRoleInfo ur ON ur.UserRoleID = u.UserRoleID
    WHERE u.EmpInfoId = @EmpId;

    SELECT @FromRole = r.FromRoleTypeId, @CurOrder = r.CurrentOrder
    FROM dbo.tblCustCategoryRequest r
    JOIN dbo.View_CustomerMaster cv ON cv.CustomerMasterId = r.CustomerMasterId
    WHERE r.RequestId = @RequestId AND r.Status = 'Pending' AND r.ToRoleTypeId = @RoleTypeId
      AND (@RoleTypeId = 5 OR @EmpId IN (cv.MIOEmpInfoId, cv.ASMEmpInfoId, cv.RSMEmpInfoId, cv.NSMEmpInfoId));

    IF @CurOrder IS NULL
        BEGIN SELECT 0 Success, 'This request is not waiting for your approval.' Msg; RETURN; END

    IF @Status = 'Approved'
        SELECT TOP 1 @NextRole = d.ToRoleId, @NextOrder = d.[Order]
        FROM dbo.tblApprovalMapMaster m JOIN dbo.tblApprovalMapDetail d ON d.ApprovalMapMasterId = m.ApprovalMapMasterId
        WHERE m.MenuId = @MenuId AND m.FromRoleId = @FromRole AND d.[Order] > @CurOrder AND d.ToRoleId IS NOT NULL
        ORDER BY d.[Order];

    -- Final approval: re-check the MBE limit (it may have been lowered after submit)
    IF @Status = 'Approved' AND @NextRole IS NULL
    BEGIN
        DECLARE @Limit INT, @Approved INT;
        SELECT @Limit = t.RequestLimit,
               @Approved = (SELECT COUNT(*) FROM dbo.tblCustMaster c2 JOIN dbo.View_CustomerMaster cv2 ON cv2.CustomerMasterId = c2.CustomerMasterId
                             WHERE cv2.MBEEmpInfoId = cv.MBEEmpInfoId AND c2.IsActive = 1 AND c2.CustomerTypeId = r.ToCustomerTypeId)
        FROM dbo.tblCustCategoryRequest r
        JOIN dbo.View_CustomerMaster cv ON cv.CustomerMasterId = r.CustomerMasterId
        JOIN dbo.tblCustomerType t ON t.CustomerTypeId = r.ToCustomerTypeId
        WHERE r.RequestId = @RequestId;

        IF @Limit IS NULL
            BEGIN SELECT 0 Success, 'This category can no longer be requested.' Msg; RETURN; END
        IF @Limit > 0 AND @Approved >= @Limit
            BEGIN SELECT 0 Success, 'Category limit is full for this MBE.' Msg; RETURN; END
    END

    BEGIN TRAN;
        IF @Status = 'Rejected'
            UPDATE dbo.tblCustCategoryRequest SET Status = 'Rejected' WHERE RequestId = @RequestId;
        ELSE IF @NextRole IS NOT NULL
            UPDATE dbo.tblCustCategoryRequest SET CurrentOrder = @NextOrder, ToRoleTypeId = @NextRole WHERE RequestId = @RequestId;
        ELSE
        BEGIN
            UPDATE dbo.tblCustCategoryRequest SET Status = 'Approved', ToRoleTypeId = NULL WHERE RequestId = @RequestId;
            UPDATE c SET c.CustomerTypeId = r.ToCustomerTypeId
            FROM dbo.tblCustMaster c JOIN dbo.tblCustCategoryRequest r ON r.CustomerMasterId = c.CustomerMasterId
            WHERE r.RequestId = @RequestId;
        END
        INSERT INTO dbo.tblCustCategoryRequestLog (RequestId, EmpInfoId, RoleTypeId, Status, Comments)
        VALUES (@RequestId, @EmpId, @RoleTypeId, @Status, @Comments);
    COMMIT;

    SELECT 1 Success, CASE WHEN @Status = 'Rejected' THEN 'Request rejected.'
                           WHEN @NextRole IS NOT NULL THEN 'Approved, sent to next step.'
                           ELSE 'Approved, customer category updated.' END Msg;
END
GO
