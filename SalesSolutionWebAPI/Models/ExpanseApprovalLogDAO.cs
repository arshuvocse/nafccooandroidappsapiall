using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Models
{
    public class ExpanseApprovalLogDAO
    {

        public int ExpenseClaimID { get; set; }

        public int? ExpenseTypeId { get; set; }

       
        public string ExpenseDate { get; set; }

        public int? EmpInfoId { get; set; }

        public decimal? Amount { get; set; }

        public string Remarks { get; set; }

        public string ImageName { get; set; }

        public string ImagePath { get; set; }

        public string EntryBy { get; set; }

        public DateTime? EntryDate { get; set; }

        public string ApprovalStatus { get; set; }
        public string ExpenseTypeName { get; set; }

        public bool? IsFromApp { get; set; }

        public int? ApprovedBy { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }
        public int? ExpanseApprovalId { get; set; }
        public int? MenuId { get; set; }

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
        public string EmpMasterCode { get; set; }
        public string EmpName { get; set; }
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
        public List<ExpenseClaimDetailsDAO> aDetailListDAO { get; set; }
    }


    public class TADA_ApplogDAO
    {

        public int ApprovalId { get; set; }

       


        public string TadaDate { get; set; }

        public int? EmpInfoId { get; set; }

     
 

        public string ApprovalStatus { get; set; }
 
 
        public int? MenuId { get; set; }

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
        public string EmpMasterCode { get; set; }
        public string EmpName { get; set; }
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
        public  DAMasterDAO  aTADAMasterDAO { get; set; }
    }


    public class DAMasterDAO
    {
        public int? TadaID { get; set; }
        public int EmpInfoId { get; set; }
        public string TadaDate { get; set; }
        public string EmpName { get; set; }
        public decimal DaAmt { get; set; }


        public string Remarks { get; set; }
        public string MarketName { get; set; }
        public string ApprovalStatus { get; set; }
        public string ImageString { get; set; }




    }

    public class TADAMasterDAO
    {
        public int ExpenseTypDetailsId { get; set; }

        public string ValueText { get; set; }
        public string FieldName { get; set; }
    }

    public class GetExpanseDAO
    {

        public int MileageClaimId { get; set; }

        public string MileageDate { get; set; }


        public string TransportName { get; set; }

        public string EmpName { get; set; }
        public string Remarks { get; set; }

        public decimal? MileageInKM { get; set; }
        public decimal? MeterReading { get; set; }

        public string MarketName { get; set; }

        public string ApprovalStatus { get; set; }
        public string ImagePreName { get; set; }
        public string ImageString { get; set; }

        

    }


    public class ExpanseSaveApprovalLogDAO
    {

        public int? ExpanseApprovalId { get; set; }
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


    public class TADASaveApprovalLogDAO
    {

        public int? TADAApprovalId { get; set; }
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
}