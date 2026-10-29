using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Models
{
    public class MileageClaimViewModel
    {
        public string MileageDate { get; set; }
        public string TransportName { get; set; }
        public string MileageInKM { get; set; }
        public string MeterReading { get; set; }
        public string SMName { get; set; }
        public string MarketName { get; set; }
        public string TerritoryName { get; set; }
        public string AreaName { get; set; }
        public string Remarks { get; set; }
        public string ApprovalStatus { get; set; }
        public string ImageBase64SValue { get; set; }
    }
}