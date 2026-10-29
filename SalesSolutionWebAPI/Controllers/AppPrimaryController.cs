using SalesSolutionWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SalesSolutionWebAPI.Controllers
{
    public class AppPrimaryController : ApiController
    {
        AppPrimaryDAL aCusDal = new AppPrimaryDAL();
        [HttpPost]
        public IHttpActionResult GetAppVersion()
        {
            return Json(aCusDal.GetActiveVersion());
        }
    }
}
