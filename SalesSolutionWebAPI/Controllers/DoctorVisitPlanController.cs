using Newtonsoft.Json;
using SalesSolutionWebAPI.Models;
using SalesSolutionWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SalesSolutionWebAPI.Controllers
{
    public class DoctorVisitPlanController : ApiController
    {

        DoctorVisitPlanDAL aDal = new DoctorVisitPlanDAL();

        [HttpPost]

        [Route("api/TourPlan/SaveDoctorVisitPlanList")]
        public IHttpActionResult AddDoctorVisit(TourPlanInfoMaster ainfo)
        {
            return Json(aDal.AddTourPlan(ainfo));
        }

        [HttpGet]
        [Route("api/TourPlan/GetDoctorVisitPlanList")]
        public IHttpActionResult Get_TourPlanData(int month, int year, int empId)
        {
            DataTable dt = aDal.Get_TourPlanData(month, year, empId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }


        [HttpDelete]
        [Route("api/TourPlan/DelDoctorVisitPlan")]
        public IHttpActionResult DelDoctorVisitPlan(int id)
        {
            return Json(aDal.DeleteTourPlan(id));
        }

        [HttpGet]
        [Route("api/TourPlan/UpdateDoctorVisitPlan")]

        public IHttpActionResult UpdateFinalTourSubmit(int empId, int month, int year, String remarks)
        {
            return Json(aDal.FinalSubmitTour(empId, month, year, remarks));
        }


        [HttpGet]
        [Route("api/TourPlan/GetDoctorVisitPlanMasterData")]
        public IHttpActionResult GetTourPlanMasterData(int month, int year, int empId)
        {
            DataTable dt = aDal.Get_TourPlanMasterData(month, year, empId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);

            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }
    }
}
