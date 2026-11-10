using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Models
{
    public class CustomerSM
    {
        public int CustomerMasterId { get; set; }
        public string CustomerName { get; set; }
        public string ImageBase64String { get; set; }
        public string TradeLicenseImg { get; set; }
        public string Address { get; set; }
        public string CellNo { get; set; }
        public string ConPerson { get; set; }
        public string TermOfPayment { get; set; }
        public bool IsFromApp { get; set; }
        public int MarketId { get; set; }
        public int? ProgramTypeId { get; set; }
        public int? SMCTypeId { get; set; }
        //public int ThanaId { get; set; }
        //public int DistrictId { get; set; }
        //public int DivisionId { get; set; }
        //    public int CustomerTypeId { get; set; }
        // public int StationTypeId { get; set; }
        public int EmpId { get; set; }


        public string VoterID { get; set; }
        public string TradeLicense { get; set; }
        public string Reamrks { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string StreetAddress { get; set; }


    }

    public class CustomerSMListDao
    {
        public int CustomerMasterId { get; set; }
        public string CustomerName { get; set; }
         
        public string ImageBase64String { get; set; }
        public string TradeLicenseImg { get; set; }
        public string Address { get; set; }
        public string CellNo { get; set; }
        public string ConPerson { get; set; }
        public string TermOfPayment { get; set; }
        public bool IsFromApp { get; set; }
        public int MarketId { get; set; }
        public int SubTerritoryId { get; set; }
        public int TerritoryId { get; set; }
        public int AreaId { get; set; }
        public int RegionId { get; set; }
        public int GroupId { get; set; }
      
        public int ProgramTypeId { get; set; }
        //public int ThanaId { get; set; }
        //public int DistrictId { get; set; }
        //public int DivisionId { get; set; }
        //    public int CustomerTypeId { get; set; }
        // public int StationTypeId { get; set; }
        public int EmpId { get; set; }


        public string VoterID { get; set; }
        public string TradeLicense { get; set; }
        public string Reamrks { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string StreetAddress { get; set; }

        public string CustomerCode { get; set; }
       
        public string MarketName { get; set; }
        public string SMCTypeName { get; set; }
        public int SMCTypeId { get; set; }


        public string AreaName { get; set; }
      
        public int CustomerTypeId { get; set; }
      
        //public bool IsVatApplicable { get; set; }
        //public int ThanaId { get; set; }
        //public int DistrictId { get; set; }
        //public int DivisionId { get; set; }
        //    public int CustomerTypeId { get; set; }
        // public int StationTypeId { get; set; }
        //public int EmpId { get; set; }


       
        public string CustomerType { get; set; }
        
       
       
        public string ProgramTypeName { get; set; }
     
       
        public string CustomerImagePreName { get; set; }
       
        public string TradeLicenseImagePreName { get; set; }
      



    }

    public class CampaingDtls
    {
        
        public string OfferTypeName { get; set; }

        public string ProductName { get; set; }
        public string Qty { get; set; }
        
         


    }

    public class CustomerPenDao
    {
        public int CustomerMasterId { get; set; }
        public string CustomerName { get; set; }

        public string ActionStatus { get; set; } 
        public string Address { get; set; }
        public string MarketName { get; set; }
        public string CellNo { get; set; }
        public string OwnerName { get; set; }
        public string ProgramTypeName { get; set; }
        public string CustomerImagePreName { get; set; }
        public string ImageBase64String { get; set; }
        public string WaitingRole { get; set; }
        public string WatingEmployee { get; set; }
        public string CustomerStatus { get; set; }

        public string GroupId { get; set; }
        public string RegionId { get; set; }
        public string AreaId { get; set; }
        public string TerritoryId { get; set; }
        public string SubTerritoryId { get; set; }
        public string MarketId { get; set; }
        public int BtnupdateInfo { get; set; }
        public string ImageString { get; set; }

        public string GroupName { get; set; }
        public string RegionName { get; set; }
        public string AreaName { get; set; }
        public string TerritoryName { get; set; }
        public string SubTerritoryName { get; set; }

    }

    public class CustomerSaveAppLog_DAO
    {

        public int? CustomerApprovalId { get; set; }
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


    public class CustomerMArket_DAO
    {

        public string empId { get; set; }
        
        public int? GroupId { get; set; }
        public int? CustomerId { get; set; }

        public int? ZoneId { get; set; }

        public int? AreaId { get; set; }

        public int? TerritoryId { get; set; }
        public int? STeritoryId { get; set; }
        public int? MarketId { get; set; }
    


    }


    public class DoctorMArket_DAO
    {

        public string empId { get; set; }

        public int? GroupId { get; set; }
        public int? DoctorId { get; set; }

        public int? ZoneId { get; set; }

        public int? AreaId { get; set; }

        public int? TerritoryId { get; set; }
        public int? STeritoryId { get; set; }
        public int? MarketId { get; set; }



    }


    public class CustomerAppLog_DAO
    {

        public int? CustomerApprovalId { get; set; }
        public int? CustomerMasterId { get; set; }
        public int? EmpInfoId { get; set; }

        public string Date { get; set; }

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



        public int? RoleTypeId { get; set; }

        public int? ToRoleTypeId { get; set; }

        public int? MenuId { get; set; }

        public string TerritoryName { get; set; }
        public string TerritoryCode { get; set; }
        public string AreaCode { get; set; }




        public string ApprovalStatus { get; set; }
        public string EmpMasterCode { get; set; }
        public string EmpName { get; set; }



        public int MIOEmpId { get; set; }
        public int ASMEMPId { get; set; }
        public int RSMEMPId { get; set; }
        public int NSMEMPId { get; set; }
        public string WaitingRole { get; set; }
        public string WatingEmployee { get; set; }
        public CustomerSMListDao CustomerSMListDao { get; set; }

    }



    public class CampaingDAO
    {

        public int CampgainMasterId { get; set; }
        public string CampaignCode { get; set; }
        public string CampaignDesc { get; set; }

        public string CampaignName { get; set; }

        public string FromDate { get; set; }

        public string Todate { get; set; }



        public List<CampaingDtls> CampaingDetails { get; set; }
    }

    public class CategoryRequestSave
    {
        public int EmpId { get; set; }
        public int CustomerMasterId { get; set; }
        public int CustomerTypeId { get; set; }
        // base64 jpg, all four mandatory
        public string ShopPhoto { get; set; }
        public string NID { get; set; }
        public string TradeLicense { get; set; }
        public string DrugLicense { get; set; }
    }

    public class CategoryApprovalSave
    {
        public int RequestId { get; set; }
        public int EmpId { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }
}