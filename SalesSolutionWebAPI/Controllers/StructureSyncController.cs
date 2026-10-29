using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Models;
using SalesSolutionWebAPI.Repository;
using System.Web.Http;

namespace SalesSolutionWebAPI.Controllers
{
    public class StructureSyncController : ApiController
    {

        private readonly iFieldForceMarket _aRepo = new StructureSyncDal();
        StructureSyncDal aDal = new StructureSyncDal();




        [HttpGet]
        [Route("api/StructureSync/GetEmpTeamList")]

        public IHttpActionResult GetEmpTeamList(string role, string id, string aparam)
        {
            return Json(aDal.GetEmpTeamList(role, id, aparam));
        }


        [HttpGet]
        [Route("api/StructureSync/GetFieldForceMarket")]

        public IHttpActionResult GetFieldForceMarket(string empcode, string emprole)
        {
            return Json(aDal.GetFieldForceMarket(empcode, emprole));
        }
        
        [HttpGet]
        [Route("api/StructureSync/GetFieldForceSubTerritory")]

        public IHttpActionResult GetFieldForceSubTerritory(string empcode, string emprole)
        {
            return Json(aDal.GetFieldForceSubTerritory(empcode, emprole));
        }

        [HttpGet]
        [Route("api/StructureSync/GetFieldForceTerritory")]

        public IHttpActionResult GetFieldForceTerritory(string empcode, string emprole)
        {
            return Json(aDal.GetFieldForceTerritory(empcode, emprole));
        }

        [HttpGet]
        [Route("api/StructureSync/GetFieldForceArea")]

        public IHttpActionResult GetFieldForceArea(string empcode, string emprole)
        {
            return Json(aDal.GetFieldForceArea(empcode, emprole));
        }

        [HttpGet]
        [Route("api/StructureSync/GetFieldForceRegion")]

        public IHttpActionResult GetFieldForceRegion(string empcode, string emprole)
        {
            return Json(aDal.GetFieldForceRegion(empcode, emprole));
        }

        [HttpGet]
        [Route("api/StructureSync/GetFieldForceGroup")]

        public IHttpActionResult GetFieldForceGroup(string empcode, string emprole)
        {
            return Json(aDal.GetFieldForceGroup(empcode, emprole));
        }

        [HttpGet]
        [Route("api/StructureSync/GetFieldForceMio")]

        public IHttpActionResult GetFieldForceMio(string empcode, string emprole)
        {
            return Json(aDal.GetFieldForceMio(empcode, emprole));
        }

        [HttpGet]
        [Route("api/StructureSync/GetFieldForceMBE")]

        public IHttpActionResult GetFieldForceMBE(string empcode, string emprole)
        {
            return Json(aDal.GetFieldForceMBE(empcode, emprole));
        }


        [HttpGet]
        [Route("api/StructureSync/GetFieldForceAsm")]

        public IHttpActionResult GetFieldForceAsm(string empcode, string emprole)
        {
            return Json(aDal.GetFieldForceAsm(empcode, emprole));
        }

        [HttpGet]
        [Route("api/StructureSync/GetFieldForceRsm")]

        public IHttpActionResult GetFieldForceRsm(string empcode, string emprole)
        {
            return Json(aDal.GetFieldForceRsm(empcode, emprole));
        }


        [HttpGet]
        [Route("api/StructureSync/GetFieldForceNsm")]

        public IHttpActionResult GetFieldForceNsm(string empcode, string emprole)
        {
            return Json(aDal.GetFieldForceNsm(empcode, emprole));
        }


        [HttpPost]
        [Route("api/StructureSync/LastSynchronizationInfo")]
        public IHttpActionResult SaveLastSynchronizationInfo(SynchronizationInfoDAO _aDao)
        {
            return Json(aDal.SaveLastSynchronizationInfo(_aDao));
        }

    }
}
