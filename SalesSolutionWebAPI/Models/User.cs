namespace SalesSolutionWebAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int EmpInfoId { get; set; }
        public string UserName { get; set; }
        public string EmpMasterCode { get; set; }
        public string UserType { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string UserEmail { get; set; }
        public string ContactInfo { get; set; }
        public string UserCo { get; set; }
        public int RoleTypeId { get; set; }
        public bool IsApprove { get; set; }
        public bool IsForward { get; set; }
        public string RoleType { get; set; }

        public int IsImeiMatched { get; set; }

        public string VersionName { get; set; }

        public string ShiftStartTime { get; set; }
        public string ShiftEndTime { get; set; }

        public bool IsTrackEnable { get; set; }
        public string EmpRole { get; set; }
        public string DesigName { get; set; }
        public string TwoDeviceMsg { get; set; }


    }
}