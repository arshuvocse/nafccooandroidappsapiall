using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Models
{
    public class ExpenseClaimDetails
    {
        public int ExpenseClaimID { get; set; }
        public int ExpenseTypDetailsId { get; set; }
        public string ValueText { get; set; }
        public string FieldName { get; set; }
    }

    public class ExpenseClaimDetailsDAO
    {
        public int ExpenseTypDetailsId { get; set; }

        public string ValueText { get; set; }
        public string FieldName { get; set; }
    }


}