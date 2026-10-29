using SalesSolutionWebAPI.Models;
using SalesSolutionWebAPI.Repository;
using System.Collections.Generic;
using System.Data;

namespace SalesSolutionWebAPI.Interface
{
    interface iAttendance
    {
        ResultInfo SavePunchIn(Attendance atten);
        //ResultInfo SavePunchOut(Attendance atten);
        ResultInfo SavePunchIn_PunchOut(Attendance atten);
       

        IList<AttendanceDAO> GetAttendanceInformation(string pram, string emprole);
        IList<AttendanceDAO> GetAttendanceInformation_New(string pram, string Role, string AppStatus, string AttType, string FromDt, string ToDt, string EmpId);
        ResultInfo SaveAttandaceAppLog(AttendanceLog atten);

    }
}
