namespace SalesSolutionWebAPI.Models
{
    public class AttendanceDAO
    {
        public int AttendanceId { get; set; }
        public int  MIOId { get; set; }
        public int  EmpInfoId { get; set; }
        public string PunchInTime { get; set; }
        public string PInLat { get; set; }
        public string PInLog { get; set; }
        public string ApprovalStatus { get; set; }
        public string AttAddress { get; set; }
        public string PunchOutTime { get; set; }
        public string POutLat { get; set; }
        public string POutLong { get; set; }
        public string EntryDate { get; set; }
        public string POutRemarks { get; set; }
        public string AttendanceDate { get; set; }
        public string PINCreatedDateTime { get; set; }
        public string POUTCreatedDateTime { get; set; }
        public string Status { get; set; }
        public int ShiftId { get; set; }
        public int ApprovalId { get; set; }
        public string Date { get; set; }
        public int FromEmpId { get; set; }
        public int ToEmpId { get; set; }
        public int TableId { get; set; }
        public string Comments { get; set; }
        public string Type { get; set; }
        public string Step { get; set; }
        public int GroupId { get; set; }
        public int RegionId { get; set; }
        public int AreaId { get; set; }
        public int TerritoryId { get; set; }
        public int RoleTypeId { get; set; }
        public int AttType { get; set; }
        public string EmpMasterCode { get; set; }
        public string EmpName { get; set; }
        public string TerritoryName { get; set; }
        public string TerritoryCode { get; set; }
        public string AreaCode { get; set; }
        public string ImageString { get; set; }

        public string ImagePreName { get; set; }
        public int ToRoleTypeId { get; set; }

        public int MIOEmpId { get; set; }
        public int ASMEMPId { get; set; }
        public int RSMEMPId { get; set; }
        public int NSMEMPId { get; set; }

    }




    public class LeaveAppLogDAO
    {
        public int LeaveApplicationId { get; set; }
        public int MIOId { get; set; }
        public int EmpInfoId { get; set; }
        public string LeaveFromDate { get; set; }
        public string Remarks { get; set; }
        public string EmergencyContactNo { get; set; }
        public string LeaveAddress { get; set; }
        public string DateOfReturnsToDuty { get; set; }
        public string Reason { get; set; }
        public string LeaveToDate { get; set; }
        public string Days { get; set; }
        public string EntryDate { get; set; }

        public string ApprovalStatus { get; set; }
       
        public string Status { get; set; }
        public int ShiftId { get; set; }
        public int LeaveApprovalId { get; set; }
        public string Date { get; set; }
        public int FromEmpId { get; set; }
        public int ToEmpId { get; set; }
        public int TableId { get; set; }
        public string Comments { get; set; }
        public string Type { get; set; }
        public int Step { get; set; }
        public int GroupId { get; set; }
        public int RegionId { get; set; }
        public int AreaId { get; set; }
        public int TerritoryId { get; set; }
        public int RoleTypeId { get; set; }
        public int AttType { get; set; }
        public string EmpMasterCode { get; set; }
        public string EmpName { get; set; }
        public string TerritoryName { get; set; }
        public string TerritoryCode { get; set; }
        public string AreaCode { get; set; }
        public string ImageString { get; set; }

        public string ImagePreName { get; set; }
        public int ToRoleTypeId { get; set; }

        public int MIOEmpId { get; set; }
        public int ASMEMPId { get; set; }
        public int RSMEMPId { get; set; }
        public int NSMEMPId { get; set; }

    }
}


