using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Models
{
    public class DocTourPlanMaster
    {
       public int DocTPMaster { get; set; }
       public int MonthValue { get; set; }
       public int YearValue { get; set; }
       public int EmpInfoId { get; set; }
       public int DoctorId { get; set; }
       public DateTime TourPlanDate { get; set; }

    }



    public class DSRDAO
    {
        public int empid { get; set; }
        public int teri_id { get; set; }
        public string date { get; set; } 
        public string Reason { get; set; } 

    }

    public class DWSPMasterDAO
    {
        public int DWSPMasterId { get; set; }
        public int? MonthValue { get; set; }
        public int? YearValue { get; set; }
        public int? EmpInfoId { get; set; } 
        public decimal? FCBAmount { get; set; } 
        public decimal? GeneralAmount { get; set; } 
        public decimal? CampaignAmount { get; set; }
        public DateTime? DWSPDate { get; set; }
        public string MonthName { get; set; } 
        public bool IsFinalSubmit { get; set; } 
        public string ApprovalStatus { get; set; }
        public string TargetAmount { get; set; }

        public List<DWSPDtlsDAODate> aDWSPDate { get; set; }

    }


    public class SynchronizationInfoDAO
    {
       
        public int? EmpInfoId { get; set; }
        
    }
}