using Newtonsoft.Json;
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
    public class NotificationController : ApiController
    {

        NotificationDAL aDal = new NotificationDAL();


        [HttpGet]
        public IHttpActionResult GetNotificationCount(int id)
        {
            return Json(aDal.GetNotificationCount(id));
        }

        [HttpGet]
        [Route("api/Notification/GetNotification")]
        public IHttpActionResult GetNotification(int empId)
        {
            DataTable dt = aDal.GetNotification(empId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }


        [HttpGet]
        [Route("api/Notification/UpdateNotificationRead")]

        public IHttpActionResult UpdateFinalTourSubmit(int id)
        {
            return Json(aDal.UpdateReadStatus(id));
        }
    }
}
