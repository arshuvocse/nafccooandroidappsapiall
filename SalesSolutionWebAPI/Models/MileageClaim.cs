using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Models
{
    public class MileageClaim
    {

        public int MileageClaimId { get; set; }
        public DateTime? MileageDate { get; set; }
        public int? TransportId { get; set; }
        public int? MarketId { get; set; }
    
        public decimal? MileageInKM { get; set; }
        public double? MeterReading { get; set; }
        public string Remarks { get; set; }
        public string ImageBase64String { get; set; }
        public int EmpInfoId { get; set; }
    }
}