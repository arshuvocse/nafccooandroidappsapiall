namespace SalesSolutionWebAPI.Models
{
    public class Notice
    {
        public int NoticeId { get; set; }
        public string NoticeTitle { get; set; }
        public string CreatedBy { get; set; }

        public string Announcement { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string FileLocation { get; set; }
        public bool IsAppCheck { get; set; }
        public string ImageString { get; set; }
        public string ImagePreName { get; set; }

    }
}