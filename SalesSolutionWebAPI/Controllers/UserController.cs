using SalesSolutionWebAPI.Models;
using SalesSolutionWebAPI.Repository;
using System.Web.Http;

namespace SalesSolutionWebAPI.Controllers
{
    public class UserController : ApiController
    {
        UserDAL aUserDal = new UserDAL();

        [HttpGet]
        public IHttpActionResult userLogin(string UserName, string password, string Imei, string DeviceToken, string Device, string AppVersion, string OS, string OS_Version)
        {
            return Json(aUserDal.doLogin(UserName, password, Imei, DeviceToken, Device, AppVersion, OS, OS_Version));
        }

        [HttpPost]
        public IHttpActionResult userLogin(string userName, string password, string DeviceToken, string Device)
        {
            return Json(aUserDal.SaveDeviceToken(userName, password, DeviceToken, Device));
        }

        [HttpPost]
        public IHttpActionResult userLogin(UserTracking tracking)
        {
            return Json(aUserDal.SaveTracking(tracking));
        }


    }
}
