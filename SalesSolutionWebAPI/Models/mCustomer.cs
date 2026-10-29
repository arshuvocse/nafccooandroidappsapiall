using System;

namespace SalesSolutionWebAPI.Models
{
    public class mCustomer
    {

        public int CustomerMasterId { get; set; }

        public string CustomerCode { get; set; }

        public int? CategoryId { get; set; }

        public string CustomerName { get; set; }

        public string Address { get; set; }

        public string CellNo { get; set; }

 

        public string Addrees2 { get; set; }

        public string City { get; set; }

        public string ConPerson { get; set; }

        public string ShippingCond { get; set; }

        public string MarketCode { get; set; }

        public string MarketName { get; set; }

        public string MIACode { get; set; }

        public string MIAName { get; set; }

        public string AreaCode { get; set; }

        public string DisCode { get; set; }

        public string FEName { get; set; }

        public string ComUnitCode { get; set; }

        public string ComUnitName { get; set; }

        public string RegionCode { get; set; }

        public string DZSMName { get; set; }

        public string TermOfPayment { get; set; }

        public string CustomerCodeOld { get; set; }

        public DateTime? UploadDate { get; set; }

        public bool? ExcelUpload { get; set; }

        public bool? FixedCustomer { get; set; }



        public string Type { get; set; }

        public int ComUnitId { get; set; }

        public bool IsActive { get; set; }

        public string InActiveDate { get; set; }

        public string CustomerStation { get; set; }

        public string Division { get; set; }

        public string District { get; set; }

        public string Thana { get; set; }

        public string Upazila { get; set; }

        public string CustomerType { get; set; }

        public string CreditLimit { get; set; }
        public string Balance { get; set; }
        public string Route { get; set; }

        public string GroupId { get; set; }
        public string RegionId { get; set; }
        public string AreaId { get; set; }
        public string TerritoryId { get; set; }
        public string SubTerritoryId { get; set; }
        public string MarketId { get; set; }
        public string Note { get; set; }
        public int CustomerCheck { get; set; }



    }


    public class ModelCustomerDue
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string DueAmount { get; set; }
        public string MarketName { get; set; }
        public string CellNo { get; set; }
        public string Address { get; set; }
    }

    public class mCustomerListDAO
    {

        public int CustomerMasterId { get; set; }

        public string CustomerName { get; set; }

        public int? CustomerCode { get; set; }

        public string Address { get; set; }

        public string MarketName { get; set; }

        public string MarketId { get; set; }

        public int? AreaName { get; set; }

        public string TerritoryName { get; set; }

       

        public string CellNo { get; set; }

        public string CustomerTypeId { get; set; }

        public string IsVatApplicable { get; set; }

        public string VoterID { get; set; }

        public string CustomerType { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string StreetAddress { get; set; }

        public string ProgramTypeId { get; set; }

        public string ProgramTypeName { get; set; }

        public string TermOfPayment { get; set; }

        public string OwnerName { get; set; }

        public string CustomerImagePreName { get; set; }

        public string TradeLicenseImagePreName { get; set; }

        

    }


}