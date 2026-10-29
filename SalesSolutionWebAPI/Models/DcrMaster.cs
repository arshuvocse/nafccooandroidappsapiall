using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Models
{
    public class DcrMaster
    {
       public string empId { get; set; }
       public string date { get; set; }
       public string drId { get; set; } 
       public string callTime { get; set; }
       public string callType { get; set; }
       public string drcallType { get; set; }
        public string callWith { get; set; }
        public string planned { get; set; }
        public string DCPDetailId { get; set; }

        public List<ModelCallPriorityProduct> callpriorityProducts { get; set; }
         

    }



    public class ChemistCallMaster
    {
        public int? CustomerMasterId { get; set; }
         
        public int? empId { get; set; }
        public DateTime? ChemistCallDate { get; set; }

        public bool? IsGivenOrder { get; set; }

        public string LatVal { get; set; }

        public string LongVal { get; set; }
        public string Address { get; set; }


        public int? ReasonId { get; set; }

        public string Comments { get; set; }
        public string CallTime { get; set; }



    }






    public class DCPMaster
    {
        public string DoctorId { get; set; } 
        
        public string WorkSession { get; set; }
        public string empId { get; set; }
        public string DCPDate { get; set; }
       // public List<ModelDCPDateDAO> dateList { get; set; }

    }

    public class DCPMaster_App
    {
        public string empId { get; set; }

        public string DCPMasterId { get; set; }
        public string approvalStatus { get; set; }
        public string Remarks { get; set; }
        public string RoleType { get; set; }


    }


    public class DCRMaster_App_New
    {
        public string empId { get; set; }

        public string dcrId { get; set; }
        public string approvalStatus { get; set; }
        public string Remarks { get; set; }
        public string RoleType { get; set; }


    }
    public class ModelDCPDateDAO
    {

        public string  DCPDate { get; set; }

    }
}