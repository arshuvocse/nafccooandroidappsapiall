using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Models
{
    public class UserTracking
    {
       public int EmpInfoId { get; set; }
        public string LatValue { get; set; }
        public string LongValue { get; set; }
        public string AddressName { get; set; }
        public string Time { get; set; }
        public DateTime TrackDate { get; set; }

    }
}