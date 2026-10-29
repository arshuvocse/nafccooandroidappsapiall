using System;

namespace SalesSolutionWebAPI.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        //public int MIOId { get; set; }

        public int EmpInfoId { get; set; }

        public String PunchInTime { get; set; }

        public string PInLat { get; set; }

        public string PInLog { get; set; }

        //public String PunchOutTime { get; set; }

        //public string POutLat { get; set; }

        //public string POutLong { get; set; }

        public DateTime EntryDate { get; set; }

        public string POutRemarks { get; set; }

        public string AttendanceDate { get; set; }

        public int AttType { get; set; }
        public String AttAddress { get; set; }
        public String AttImg { get; set; }


        public String WorkPlace { get; set; }
        public String TourType { get; set; }
        public String WorkSession { get; set; }


    }



    public class AttendanceRpt
    {



        public String AttendanceDate { get; set; }

        public string Territory { get; set; }

        public string WorkSession { get; set; }

        public String MP_TourType { get; set; }
        public String MP_ReportingPlace { get; set; }

        public string MP_GeoStamp { get; set; }

        public string MP_GeoCode { get; set; }
        public string MP_GeoAddress { get; set; }
        public string MP_Status { get; set; }

        public String MO_TourType { get; set; }
        public String MO_ReportingPlace { get; set; }

        public string MO_GeoStamp { get; set; }

        public string MO_GeoCode { get; set; }
        public string MO_GeoAddress { get; set; }
        public string MO_Status { get; set; }


        public string E_WorkSession { get; set; }

        public String EP_TourType { get; set; }
        public String EP_ReportingPlace { get; set; }

        public string EP_GeoStamp { get; set; }

        public string EP_GeoCode { get; set; }
        public string EP_GeoAddress { get; set; }
        public string EP_Status { get; set; }
        public String EO_TourType { get; set; }
        public String EO_ReportingPlace { get; set; }

        public string EO_GeoStamp { get; set; }

        public string EO_GeoCode { get; set; }
        public string EO_GeoAddress { get; set; }
        public string EO_Status { get; set; }







    }
}