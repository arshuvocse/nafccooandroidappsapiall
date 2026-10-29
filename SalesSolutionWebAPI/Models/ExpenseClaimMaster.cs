using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Models
{
    public class ExpenseClaimMaster
    {
       
        public int ExpenseTypeId { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string ExpDate { get; set; }

        public int EmpInfoId { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public string ImageBase64String { get; set; }
        public Boolean IsFromApp { get; set; }
        public int ExpenseClaimID { get; set; }
        public List<ExpenseClaimDetails> aDetailList { get; set; }
    }


    public class ExpenseClaimMasterDAO
    {
        public string ExpenseClaimID { get; set; }
        public string ExpenseTypeId { get; set; }
        public string ExpDate { get; set; }
        public string EmpName { get; set; }
        public string ExpenseTypeName { get; set; }
        public string ApprovalStatus { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }

 
        public string ImageString { get; set; }
        public string ImagePreName { get; set; }

        public List<ExpenseClaimDetailsDAO> aDetailListDAO { get; set; }
    }
}