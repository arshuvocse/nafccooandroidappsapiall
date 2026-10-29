using Newtonsoft.Json;
using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Models;
using SalesSolutionWebAPI.Repository;
using System.Data;
using System.Web.Http;

namespace SalesSolutionWebAPI.Controllers
{
    public class AttendanceApiController : ApiController
    {

        private readonly iAttendance _aRepo = new AttendanceDAL();
        AttendanceDAL aDal = new AttendanceDAL();



       
        [HttpGet]
        [Route("api/AttendanceApi/GetAttendanceInformation")]
         
        public IHttpActionResult GetAttendanceInformation(string pram, string emprole)
        {
            return Json(_aRepo.GetAttendanceInformation(pram, emprole));
        }


        [HttpGet]
        [Route("api/AttendanceApi/GetAttendanceInformation_New")]

        public IHttpActionResult GetAttendanceInformation_New(string pram, string Role, string AppStatus, string AttType, string FromDt, string ToDt, string EmpId)
        {
            return Json(_aRepo.GetAttendanceInformation_New(pram, Role, AppStatus, AttType, FromDt, ToDt, EmpId));
        }


        [HttpPost]
        [Route("api/AttendanceApi/SaveAttendanceLog")]
        public IHttpActionResult SaveAttendanceLog(AttendanceLog attendance)
        {
            return Json(_aRepo.SaveAttandaceAppLog(attendance));
        }

    }
}
