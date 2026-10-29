using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Models;
using SalesSolutionWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SalesSolutionWebAPI.Controllers
{
    public class ZoneController : ApiController
    {
        private readonly iZoneSetup _aRepo = new ZoneDAL();

        [HttpPost]
        public IHttpActionResult SaveZone(Zone zone)
        {
            return Json(_aRepo.SaveZoneInfo(zone));
        }

        [HttpGet]

        public IHttpActionResult GetZoneList()
        {
            return Json(_aRepo.GetZoneList());
        }
    }
}
