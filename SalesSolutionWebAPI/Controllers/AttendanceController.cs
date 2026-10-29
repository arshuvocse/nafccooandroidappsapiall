using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesSolutionWebAPI.Models;
using SalesSolutionWebAPI.Repository;
using System.Data;
using System.Web.Http;


namespace SalesSolutionWebAPI.Controllers
{
    public class AttendanceController : ApiController
    {
        AttendanceDAL aDal = new AttendanceDAL();


        //[HttpPost]
        //public IHttpActionResult SavePunInInfo(Attendance aInfo)
        //{
        //    return Json(aDal.SavePunchIn(aInfo));

        //}

        //[HttpPost]
        //public IHttpActionResult SavePunOutInfo(Attendance aInfo)
        //{
        //    return Json(aDal.SavePunchOut(aInfo));

        //}

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Attendance/SavePunch")]
     
        public IHttpActionResult SavePunchTotalInfo(Attendance aInfo)
        {
            return Json(aDal.SavePunchIn_PunchOut(aInfo));
             
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Attendance/GetPunchInOutInfo")]
        public IHttpActionResult GetPunchInOutInfo(int EmpInfoId, string WorkSession)
        {
            return Json(aDal.GetInOutInfo(EmpInfoId, WorkSession));

        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Reports/GetAttandenceReport")]
        public IHttpActionResult GetAttandenceReport(string empId, string Month, string Year)
        {


            DataTable dt = (aDal.GetAttandenceReport(empId, Month, Year));
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);

        }

    }
}
