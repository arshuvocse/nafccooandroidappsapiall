using System;
using System.Collections.Generic;

namespace SalesSolutionWebAPI.Models
{
    public class TourPlanViewModel
    {
        public int TourPlanId { get; set; } = 0;
        public int TPMaster { get; set; } = 0;
        public int TourTypeId { get; set; } = 0;
        public int DocTPDetailsId { get; set; } = 0;
        public string Comment { get; set; } = "";
        public string Objective { get; set; } = "";
        public bool IsMarketWise { get; set; } = false;
        public bool IsApproved { get; set; } = false;
        public int SMId { get; set; } = 0;
        public int GroupId { get; set; } = 0;
        public int RegionId { get; set; } = 0;
        public int AreaId { get; set; } = 0;
        public int TerritoryId { get; set; } = 0;
        public int SubTerritoryId { get; set; } = 0;
        public int MarketId { get; set; } = 0;
        public int MarketIdEnd { get; set; } = 0;
        public string GroupName { get; set; } = "";
        public string RegionName { get; set; } = "";
        public string AreaName { get; set; } = "";
        public string TerritoryName { get; set; } = "";
        public string SubTerritoryName { get; set; } = "";
        public string MarketName { get; set; } = "";
        public string MarketNameEnd { get; set; } = "";
        public int CustomerMasterId { get; set; } = 0;
        public string CustomerName { get; set; } = "";
        public string DoctorName { get; set; } = "";
        public string ShiftText { get; set; } = "";
        public string TourTypeName { get; set; } = "";
        public int TPId { get; set; } = 0;
        public string TPName { get; set; } = "";
        public int MonthValue { get; set; } = 0;
        public int YearValue { get; set; } = 0;
        public int DayValue { get; set; } = 0;
        public int EmpInfoId { get; set; }
        public string TourPlanDate { get; set; }
        public bool IsFinalSubmit { get; set; }
        public int SerialNo { get; set; } = 0;
        public List<Customer> aCustomerMasterList { get; set; }
        public string CreatedBy { get; set; } = "";
        public string CreatedDate { get; set; } = "";
        public string UpdateBy { get; set; } = "";
        public string UpdateDate { get; set; } = "";
        public string ApprovedBy { get; set; } = "";
        public string ApprovedDate { get; set; } = "";
        public string details { get; set; } = "";
        public string ApprovalStatus { get; set; } = "";
        public string IsMorning { get; set; } = "0";
        public string IsEvening { get; set; } = "0";
        public string IsStartTime { get; set; } = "";
        public string Starttime { get; set; } = "";
        public string IsEndtime { get; set; } = "0";
        public string Endtime { get; set; } = "";
        public string IsMarketVisit { get; set; } = "0";
        public string IsOtherVisit { get; set; } = "0";
        public string VisitedWithEmpName { get; set; } = "";
        public int VisitedWithEmpInfoId { get; set; } = 0;
        public List<Market> aVisitedMarketList { get; set; }
    }

    public class Customer
    {

        public int CustomerMasterId;

        public string CustomerName;
        public string CustomerCode;
    }

    public class Market
    {
        public int MarketId;
        public string MarketName;
    }




    public class TourPlanInfoMasterDAO
    {
        public List<TourPlanInfoNewDAO> aTourPlanInfo { get; set; }
    }

    public class VisitedMarketDao
    {
        public int marketId { get; set; }
    }

    public class TourPlanInfoNewDAO
    {
        public int TourPlanId { get; set; }

        //public int? TerritoryId { get; set; }

        public int? MarketId { get; set; }
        public int? MarketIdEnd { get; set; }

        public string marketName { get; set; }
        public string marketNameEnd { get; set; }

        public int? TPId { get; set; }

        public System.DateTime? TourPlanDate { get; set; }

        public int? EmpInfoId { get; set; }
        public int? VisitedWithEmpInfoId { get; set; }
        public int? SerialNo { get; set; }


        public string ApprovedBy { get; set; }
        public string IsMorning { get; set; } = "0";
        public string IsEvening { get; set; } = "0";

        public string Starttime { get; set; }

        public string Endtime { get; set; }

        public string IsMarketVisit { get; set; } = "0";
        public string IsOtherVisit { get; set; } = "0";
        public string CreatedBy { get; set; }
        public string Objective { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public List<VisitedMarketDao> aVisitedMarketList { get; set; }

    }
}