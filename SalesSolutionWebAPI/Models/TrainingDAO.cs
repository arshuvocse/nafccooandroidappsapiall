namespace SalesSolutionWebAPI.Models
{
    public class TrainingDAO
    {
        public int TrainningId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TrainningMeterial { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }
        
        public string CreateAt { get; set; }
        public string CreatedBy { get; set; }


        public bool IsAppCheck { get; set; }
        public string FileLocation { get; set; }

    }
}