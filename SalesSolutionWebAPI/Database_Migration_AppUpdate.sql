-- ============================================================================
-- Migration: add download-link / force-update support to the app version check
-- Target: whichever database DataBase.SalesDisDB currently points to
--         (SalesSolutionWebAPI/DataManager/DataBase.cs) -- e.g. SalesDisDB_UniWorld_DB
-- Consumed by: SalesSolutionWebAPI/Repository/AppPrimaryDAL.cs -> GetActiveVersion()
--              (reads columns "DownloadUrl" and "IsForceUpdate" defensively --
--              missing columns are simply ignored, so this migration is safe to
--              apply after the code deploy too, not just before)
-- ============================================================================

-- STEP 1: Find the real procedure body first -- do NOT skip this.
-- This tells you the actual source table/columns behind sp_WebApi_GetVersion,
-- since that was not visible from the application source tree.
--
--   EXEC sp_helptext 'sp_WebApi_GetVersion';
--
-- Use the table name it selects FROM in place of dbo.AppVersion below if it differs.

-- STEP 2: Add the two new columns to the version table (adjust table name if needed).
IF NOT EXISTS (
    SELECT 1 FROM sys.columns
    WHERE object_id = OBJECT_ID('dbo.AppVersion') AND name = 'DownloadUrl'
)
BEGIN
    ALTER TABLE dbo.AppVersion ADD DownloadUrl NVARCHAR(500) NULL;
END
GO

IF NOT EXISTS (
    SELECT 1 FROM sys.columns
    WHERE object_id = OBJECT_ID('dbo.AppVersion') AND name = 'IsForceUpdate'
)
BEGIN
    ALTER TABLE dbo.AppVersion ADD IsForceUpdate BIT NOT NULL CONSTRAINT DF_AppVersion_IsForceUpdate DEFAULT (0);
END
GO

-- STEP 3: Update sp_WebApi_GetVersion to also SELECT DownloadUrl and IsForceUpdate.
-- Paste the real procedure body from STEP 1 here and add the two columns to its
-- SELECT list, then run it as an ALTER PROCEDURE. Example shape (adjust to match
-- what STEP 1 actually returned -- table/column names, WHERE/ORDER BY, TOP 1, etc.):
--
-- ALTER PROCEDURE sp_WebApi_GetVersion
-- AS
-- BEGIN
--     SELECT TOP 1
--         AppVersionId,
--         Version,
--         VersionName,
--         IsActive,
--         DownloadUrl,
--         IsForceUpdate
--     FROM dbo.AppVersion
--     WHERE IsActive = 1
--     ORDER BY AppVersionId DESC
-- END
-- GO

-- STEP 4: Set the values for the current release, e.g.:
-- UPDATE dbo.AppVersion
-- SET Version = <new versionCode from app/build.gradle>,
--     VersionName = '<new versionName>',
--     DownloadUrl = 'https://play.google.com/store/apps/details?id=<applicationId>',
--     IsForceUpdate = 0   -- set to 1 only when this update must be mandatory
-- WHERE AppVersionId = <the active row's id>;
