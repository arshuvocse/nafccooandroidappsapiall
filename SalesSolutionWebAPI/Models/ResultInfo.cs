namespace SalesSolutionWebAPI.Models
{
    public class ResultInfo
    {

        public bool isSuccess { get; set; }
        public bool isValiCheck { get; set; }
        public bool isError { get; set; }
        public string ErrorMessage { get; set; }
        public string Msd { get; set; }


    }

    public class ResultInfoNew
    {



        public string PunchInBtn { get; set; }
        public string PunchOUTBtn { get; set; }

    }


    public class OnOffButtonForCustomerDAO
    {



        public int btnCustProvider { get; set; }
        public int btnCustMS   { get; set; }
        public int btnDocProvider { get; set; }
        public int btnDocMS   { get; set; }

    }



    public class PotentialStatusDao
    {

         
        public string PotentialStatus { get; set; }
        public string Color { get; set; }


    }


    public class DCPMasterDataDao
    {

        public int DCPMasterId { get; set; }
        public int MonthValue { get; set; }
        public int YearValue { get; set; }
        public int EmpInfoId { get; set; }
        public bool IsFinalSubmit { get; set; }
        public string ApprovalStatus { get; set; }
        public string FinalSubmitRemarks { get; set; }
        public string CoutPlan { get; set; }


    }


    public class TwwpMasterDataDao
    {

        public int TWWWPMasterId { get; set; }
        
        public int EmpInfoId { get; set; }
        public bool IsFinalSubmit { get; set; }
        public string ApprovalStatus { get; set; }
      


    }

}