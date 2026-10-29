using System;

namespace SalesSolutionWebAPI.Models
{
    public class Zone
    {
        public int ZoneId { get; set; }

        public string ZoneCode { get; set; }

        public string ZoneName { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? InActiveDate { get; set; }

        public DateTime? ActiveDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string ActiveReason { get; set; }

        public string InActiveReason { get; set; }

        public string DivisionId { get; set; }
    }
}