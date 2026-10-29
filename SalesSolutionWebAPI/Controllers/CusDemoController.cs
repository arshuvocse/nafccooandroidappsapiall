using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using SalesSolutionWebAPI.Repository;

namespace SalesSolutionWebAPI.Controllers
{
    public class CusDemoController : ApiController
    {

        CustDemoDAL aCusDal = new CustDemoDAL();

        [HttpGet]
        public IHttpActionResult GetOrderInfo_ByCustomer(string customerCode)
        {
            DataTable dt = aCusDal.GetCustomerOrderList(customerCode);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }




        [HttpGet]
        [Route("api/CusDemo/GetOrderInfo")]
        public IHttpActionResult GetCustomerOrder_ById(int orderId)
        {
            return Json(aCusDal.GetOrderData(orderId));

        }



        [HttpGet]
        [Route("api/CusDemo/GetMioOrderList")]
        public IHttpActionResult GetMioOrderList(int empId, string FromDate, string ToDate, string AppStatus, string GroupId, string ZoneId, string AreaId, string TerritoryId, string SubTerritoryId, string MarketId)
        {
            //DataTable dt = aCusDal.GetOrderList_ForMIO(empId, FromDate, ToDate, AppStatus, GroupId, ZoneId, AreaId, TerritoryId, SubTerritoryId, MarketId);
            //string JSONresult;
            //JSONresult = JsonConvert.SerializeObject(dt);
            //dynamic json = JsonConvert.DeserializeObject(JSONresult);
            //return Json(json);


            return Json(aCusDal.GetOrderList_ForMIO(empId, FromDate, ToDate, AppStatus, GroupId, ZoneId, AreaId, TerritoryId, SubTerritoryId, MarketId));
        }


        [HttpGet]
        [Route("api/CusDemo/ApproveOrderMio")]
        public IHttpActionResult ApproveOrderMio(int orderId)
        {
            return Json(aCusDal.ApproveCustomerOrder_ByMio(orderId));
        }


        [HttpGet]
        [Route("api/CusDemo/RejectOrderMio")]
        public IHttpActionResult RejectOrderMio(int orderId)
        {
            return Json(aCusDal.RejectCustomerOrder_byMio(orderId));
        }


        [HttpGet]
        [Route("api/CusDemo/GetAttendanceData")]
        public IHttpActionResult GetAttendanceData(int empId,DateTime startDate,DateTime endDate)
        {
            DataTable dt = aCusDal.GetEmpAppAttendance(empId, startDate, endDate);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }


        [HttpGet]
        [Route("api/CusDemo/GetMioOrderListByMonth")]
        public IHttpActionResult GetMioOrderList_ByMonth(int empId,int month,int year)
        {
            DataTable dt = aCusDal.GetOrderList_ForMIO_ByMonthYear(empId,month, year);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }

    }
}
