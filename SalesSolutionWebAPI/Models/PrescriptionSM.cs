using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Models
{
    public class PrescriptionSM
    {
      
       public string submitby { get; set; }
       public string submitDate { get; set; }
       public string rxDate { get; set; }
       public string rxOtherDoctor { get; set; }
       public string rxDoctor { get; set; }
      
        public string rxImg { get; set; }
        public List<daorxBrand> rxBrand { get; set; }
    }
}