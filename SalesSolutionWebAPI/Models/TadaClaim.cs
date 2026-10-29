using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Models
{
    public class TadaClaim
    {
        public DateTime TadaDate { get; set; }
        public int EmpInfoId { get; set; }
        public int id { get; set; }
        public int? NewTourTypeId { get; set; }
        public decimal TaAmt { get; set; }
        public decimal DaAmt { get; set; }
        public string Remarks { get; set; }
        public string TourType { get; set; }
        public string HotelName { get; set; }
        public string HotelPhone { get; set; }
        public string ImageString { get; set; }

    }
}