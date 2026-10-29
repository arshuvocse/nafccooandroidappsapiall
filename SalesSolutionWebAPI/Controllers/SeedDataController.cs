using Newtonsoft.Json;
using SalesSolutionWebAPI.Models;
using SalesSolutionWebAPI.Repository;
using System.Data;
using System.Web.Http;

namespace SalesSolutionWebAPI.Controllers
{
    public class SeedDataController : ApiController
    {
        private readonly SeedDataDAL _aRepo = new SeedDataDAL();

        [HttpGet]
        [Route("api/SeedData/GetDivisionAll")]
        public IHttpActionResult GetDivision()
        {
            return Json(_aRepo.GetDivisions_All());
        }


        [HttpGet]
        [Route("api/SeedData/GetChemistCallReason")]
        public IHttpActionResult GetChemistCallReason()
        {
            return Json(_aRepo.GetChemistCallReason());
        }


        [HttpGet]
        [Route("api/SeedData/GetDistrict")]
        public IHttpActionResult GetDistrict()
        {
            return Json(_aRepo.GetDistrict());
        }
        [HttpGet]
        [Route("api/SeedData/GetThana")]
        public IHttpActionResult GetThana()
        {
            return Json(_aRepo.GetThana());
        }

        [HttpGet]
        [Route("api/SeedData/GetPracticeShift")]
        public IHttpActionResult GetPracticeShift()
        {
            return Json(_aRepo.GetPracticeShift());
        }

        [HttpGet]
        [Route("api/SeedData/GetGender")]
        public IHttpActionResult GetGender()
        {
            return Json(_aRepo.GetGender());
        }

        [HttpGet]
        [Route("api/SeedData/DayName")]
        public IHttpActionResult GetDayName()
        {
            return Json(_aRepo.GetDayName());
        }



        [HttpGet]
        [Route("api/SeedData/WorkType")]
        public IHttpActionResult GetWorkType()
        {
            return Json(_aRepo.GetWorkType());
        }

        [HttpGet]
        [Route("api/SeedData/DeliveryDayName")]
        public IHttpActionResult GetDeliveryDayName()
        {
            return Json(_aRepo.DeliveryDayName());
        }

        [HttpGet]
        [Route("api/SeedData/GetPatientPriority")]
        public IHttpActionResult GetPatientPriority()
        {
            return Json(_aRepo.GetPatientPriority());
        }

        [HttpGet]
        [Route("api/SeedData/GetStation")]
        public IHttpActionResult GetStation()
        {
            return Json(_aRepo.GetStation());
        }


        [HttpGet]
        [Route("api/SeedData/GetPotentialStatus")]
        public IHttpActionResult GetPotentialStatus(string NoofPatient, string NoofRX)
        { 
            return Json(_aRepo.GetPotentialStatus(NoofPatient, NoofRX));

        }

        [HttpGet]
        [Route("api/SeedData/GetDCStoreStockList")]
        public IHttpActionResult GetDCStoreStockList(string CustomerMasterId)
        {
            DataTable dt= _aRepo.GetDCStoreStockList(CustomerMasterId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }
    }
}
