namespace SalesSolutionWebAPI.Models
{
    public class Division
    {
        public int DivisionId { get; set; }

        public string DivisionCode { get; set; }

        public string DivisionName { get; set; }

        public bool? IsActive { get; set; }

        public string CreatedBy { get; set; }
    }
}