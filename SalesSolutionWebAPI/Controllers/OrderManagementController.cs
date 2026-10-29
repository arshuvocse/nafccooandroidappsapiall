using Newtonsoft.Json;
using SalesSolutionWebAPI.Models;
using SalesSolutionWebAPI.Repository;
using System;
using System.Data;
using System.Web.Http;

namespace SalesSolutionWebAPI.Controllers
{
    public class OrderManagementController : ApiController
    {
        OrderManagerDAL aCusDal = new OrderManagerDAL();
        [HttpPost]
        public IHttpActionResult MakeOrder(OrderMaster aOrder)
        {
            return Json(aCusDal.MakeOrder(aOrder));
        }


        [HttpPost]
        [Route("api/Order/SaveDoctorrequirement")]
        public IHttpActionResult SaveDoctorrequirement(SaveDoctorrequirementMasterDAO aOrder)
        {
            return Json(aCusDal.SaveDoctorrequirement(aOrder));
        }

        [HttpGet]
        public IHttpActionResult GetCompanyUnitById(int empId)
        {
            return Json(aCusDal.GetCompanyUnitListByEmpId(empId));

        }


        [HttpGet]
        [Route("api/Order/GetMioDashboardQuickSummery")]
        public IHttpActionResult GetMioDashboardQuickSummery(int empId, DateTime currenDate)
        {
            DataTable dt = aCusDal.Get_AppTopBarData(empId, currenDate);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json[0]);
        }


        [HttpGet]
        [Route("api/Order/GetOrder_Applog")]

       

        public IHttpActionResult GetOrder_Applog(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, string GroupId, string ZoneId, string AreaId, string TerritoryId, string SubTerritoryId, string MarketId)
        {
            return Json(aCusDal.GetOrder_Applog_DAL(pram, Role, AppStatus, FromDt, ToDt, EmpId , GroupId, ZoneId, AreaId, TerritoryId, SubTerritoryId, MarketId));
        }

        [HttpPost]
        [Route("api/Order/SaveOrder_Applog")]
        public IHttpActionResult SaveOrder_Applog(OrderSaveApprovalLogDAO attendance)
        {
            return Json(aCusDal.SaveOrder_ApplogDAL(attendance));
        }



    }
}
