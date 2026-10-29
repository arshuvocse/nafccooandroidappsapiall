using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Models
{
    public class AttendanceLog
    {

        public int? ApprovalId { get; set; }
        public DateTime? Date { get; set; }
        public int? FromEmpId { get; set; }
        public int? ToEmpId { get; set; }
        public int? TableId { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string Type { get; set; }
        public int? Step { get; set; }
        public int? GroupId { get; set; }
        public int? RegionId { get; set; }
        public int? AreaId { get; set; }
        public int ?TerritoryId { get; set; }
        public int? ToGroupId { get; set; }
        public int? ToRegionId { get; set; }
        public int? ToAreaId { get; set; }
        public int? ToTerritoryId { get; set; }
        public string EntryByS { get; set; }
        public DateTime? EntryDateS { get; set; }
        public TimeSpan? EntryTimeS { get; set; }
        public String ApproveByS { get; set; }
        public DateTime? ApproveDateS { get; set; }
        public TimeSpan? ApproveTimeS { get; set; }
        public String EntryByApp { get; set; }
        public DateTime? EntryDateApp { get; set; }
        public TimeSpan? EntryTimeApp { get; set; }
        public String ApproveByApp { get; set; }
        public DateTime? ApproveDateApp { get; set; }
        public TimeSpan? ApproveTimeApp { get; set; }
        public int ?MenuId { get; set; }

    }


    public class LeaveApplo_Save
    {

        public int? LeaveApprovalId { get; set; }
        public DateTime? Date { get; set; }
        public int? FromEmpId { get; set; }
        public int? ToEmpId { get; set; }
        public int? TableId { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string Type { get; set; }
        public int? Step { get; set; }
        public int? GroupId { get; set; }
        public int? RegionId { get; set; }
        public int? AreaId { get; set; }
        public int? TerritoryId { get; set; }
        public int? ToGroupId { get; set; }
        public int? ToRegionId { get; set; }
        public int? ToAreaId { get; set; }
        public int? ToTerritoryId { get; set; }
        public string EntryByS { get; set; }
        public DateTime? EntryDateS { get; set; }
        public TimeSpan? EntryTimeS { get; set; }
        public String ApproveByS { get; set; }
        public DateTime? ApproveDateS { get; set; }
        public TimeSpan? ApproveTimeS { get; set; }
        public String EntryByApp { get; set; }
        public DateTime? EntryDateApp { get; set; }
        public TimeSpan? EntryTimeApp { get; set; }
        public String ApproveByApp { get; set; }
        public DateTime? ApproveDateApp { get; set; }
        public TimeSpan? ApproveTimeApp { get; set; }
        public int? MenuId { get; set; }

    }
    public class MileageClaimAppLog_DAO
    {

        public int MileageClaimId { get; set; }
        public int? ApprovalId { get; set; }
        public int? EmpInfoId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? AllowedMilagePerKM { get; set; }
        public decimal? MeterReading { get; set; }
        public decimal? MileageInKM { get; set; }
        public decimal? MileageAmount { get; set; }
        public string MileageDate { get; set; }
        public string TransportName { get; set; }
        public string MarketName { get; set; }
        public int? FromEmpId { get; set; }
        public int? ToEmpId { get; set; }
        public int? TableId { get; set; }
         
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string ApprovalStatus { get; set; }
    public string Comments { get; set; }
        public string Type { get; set; }
        public int? Step { get; set; }
        public int? GroupId { get; set; }
        public int? RegionId { get; set; }
        public int? AreaId { get; set; }
        public int? TerritoryId { get; set; }
        public int? RoleTypeId { get; set; }
        public int? ToRoleTypeId { get; set; }
        public string EmpMasterCode { get; set; }
        public string EmpName { get; set; }
        public int? ToGroupId { get; set; }
        public int? ToRegionId { get; set; }
        public int? ToAreaId { get; set; }
        public int? ToTerritoryId { get; set; }
        public string EntryByS { get; set; }
        public DateTime? EntryDateS { get; set; }
        public TimeSpan? EntryTimeS { get; set; }
        public String ApproveByS { get; set; }
        public DateTime? ApproveDateS { get; set; }
        public TimeSpan? ApproveTimeS { get; set; }
        public String EntryByApp { get; set; }
        public DateTime? EntryDateApp { get; set; }
        public TimeSpan? EntryTimeApp { get; set; }
        public String ApproveByApp { get; set; }
        public DateTime? ApproveDateApp { get; set; }
        public TimeSpan? ApproveTimeApp { get; set; }
        public int? MenuId { get; set; }

        public string TerritoryName { get; set; }
        public string TerritoryCode { get; set; }
        public string AreaCode { get; set; }
        public string AreaName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }

        public string ImageString { get; set; }

        public string ImagePreName { get; set; }


        public int MIOEmpId { get; set; }
        public int ASMEMPId { get; set; }
        public int RSMEMPId { get; set; }
        public int NSMEMPId { get; set; }

    }



    public class SaveMileageClaimAppLog_DAO
    {
        public int? MileageApprovalId { get; set; }

        public DateTime? Date { get; set; }

        public int? FromEmpId { get; set; }

        public int? ToEmpId { get; set; }

        public int? TableId { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }

        public string Type { get; set; }

        public int? Step { get; set; }

        public int? GroupId { get; set; }

        public int? RegionId { get; set; }

        public int? AreaId { get; set; }

        public int? TerritoryId { get; set; }

        public int? ToGroupId { get; set; }

        public int? ToRegionId { get; set; }

        public int? ToAreaId { get; set; }

        public int? ToTerritoryId { get; set; }

        public int? EntryByS { get; set; }

        public DateTime? EntryDateS { get; set; }

        public TimeSpan? EntryTimeS { get; set; }

        public int? ApproveByS { get; set; }

        public DateTime? ApproveDateS { get; set; }

        public TimeSpan? ApproveTimeS { get; set; }

        public int? EntryByApp { get; set; }

        public DateTime? EntryDateApp { get; set; }

        public TimeSpan? EntryTimeApp { get; set; }

        public int? ApproveByApp { get; set; }

        public DateTime? ApproveDateApp { get; set; }

        public TimeSpan? ApproveTimeApp { get; set; }

        public int? RoleTypeId { get; set; }

        public int? ToRoleTypeId { get; set; }
        public int? MenuId { get; set; }

    }
}