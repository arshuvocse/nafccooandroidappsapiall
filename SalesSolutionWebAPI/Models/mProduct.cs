using System.Collections.Generic;

namespace SalesSolutionWebAPI.Models
{
    public class mProduct
    {

        public int ProductId { get; set; }
        public decimal qty { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductDes { get; set; }
        public string PackSize { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal QuotedPrice { get; set; }

        public decimal VatPercentage { get; set; }
        public decimal VatAmountPerunit { get; set; }

        public int CustomerMasterId { get; set; }




    }

    public class daorxBrand
    {

        public string ProductId { get; set; }
         




    }
    public class ModelCallPriorityProduct
    {

         
        public string priority;
        public int? BrandId;
  

        public List<BrandWisePromo> BrandWisePromoList { get; set; }


    }


    public class BrandWisePromo
    {


    
        public int? promoId;


    }
    }