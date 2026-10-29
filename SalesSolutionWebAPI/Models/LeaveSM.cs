using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Models
{
    public class LeaveSM
    {

        public int LeaveApplicationId { get; set; }
        public int LeaveBalanceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Reason { get; set; }
        public int EmpId { get; set; }

        public DateTime? DateOfReturnsToDuty { get; set; }
        public string LeaveAddress { get; set; }
        public string EmergencyContactNo { get; set; }
        public string Comments { get; set; }
        public string ImageBase64String { get; set; }

    }
}