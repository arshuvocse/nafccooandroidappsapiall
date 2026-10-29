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
    public class TourPlanController : ApiController
    {
        TourPlanDAL aDal = new TourPlanDAL();
        [HttpGet]
        [Route("api/TourPlan/GetTerritory")]
        public IHttpActionResult Get_TerritoryByEmpId(int empId)
        {
            DataTable dt = aDal.Get_TerritoryByEmpId(empId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }


        [HttpGet]
        [Route("api/TourPlan/GetMarket")]
        public IHttpActionResult Get_marketByTerritoryId(int territoryId)
        {
            DataTable dt = aDal.Get_marketByTerritoryId(territoryId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }

        [HttpGet]
        [Route("api/TourPlan/GetSubmarket")]
        public IHttpActionResult Get_SubmarketByTerritoryId(int marketId)
        {
            DataTable dt = aDal.Get_SubmarketByTerritoryId(marketId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }

        [HttpGet]
        [Route("api/TourPlan/GetCustomer")]
        public IHttpActionResult Get_CustomerByMarketId(int marketId)
        {
            DataTable dt = aDal.Get_CustomerByMarketId(marketId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }

        [HttpGet]
        [Route("api/TourPlan/GetShift")]
        public IHttpActionResult Get_Shift(int empId)
        {
            DataTable dt = aDal.Get_Shift(empId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }

        [HttpGet]
        [Route("api/TourPlan/GetType")]
        public IHttpActionResult Get_TourPlanType(int empId)
        {
            DataTable dt = aDal.Get_TourPlanType(empId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }

        [HttpPost]

        [Route("api/TourPlan/SaveTourPlanList_vThree")]
        public IHttpActionResult SaveTourPlanList_vThree(TourPlanInfoMasterDAO ainfo)
        {
            return Json(aDal.SaveTourPlanList_vThree(ainfo));
        }


        [HttpGet]
        [Route("api/TourPlan/GetPurpose")]
        public IHttpActionResult Get_TourPlanPurpose(int empId)
        {
            DataTable dt = aDal.Get_TourPlanPurpose(empId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }

        [HttpPost]
        
        [Route("api/TourPlan/SaveTourPlanList")]
        public IHttpActionResult AddTourPlan(TourPlanInfoMaster ainfo)
        {
            return Json(aDal.AddTourPlan(ainfo));
        }

        [HttpPost]

        [Route("api/TourPlan/SaveTWWP")]
        public IHttpActionResult SaveTWWP(TWWWPMaster ainfo)
        {
            return Json(aDal.SaveTWWP(ainfo));
        }


        [HttpGet]
        [Route("api/TourPlan/GetTwwp")]
        public IHttpActionResult GetTwwp(int empId)
        {

            return Json(aDal.GetTwwpList(empId));

        }


        [HttpPost]
        [Route("api/TourPlan/TwwpFinalSubmit")]

        public IHttpActionResult TwwpFinalSubmit(int empId)
        {
            return Json(aDal.TwwpFinalSubmit(empId));
        }


        [HttpGet]
        [Route("api/TourPlan/GetTwwpMaster")]
        public IHttpActionResult GetTwwpMaster( int empId)
        {
            return Json(aDal.GetTwwpMaster( empId));

        }


        [HttpGet]
        [Route("api/TourPlan/GetTwwp_Applog")]

        public IHttpActionResult GetTwwp_Applog(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, int? MonthValue, int? YearValue)
        {
            return Json(aDal.GetTwwp_ApplogDAL(pram, Role, AppStatus, FromDt, ToDt, EmpId, MonthValue, YearValue));
        }

        [HttpPost]
        [Route("api/TourPlan/SaveTwwp_Applog")]
        public IHttpActionResult SaveTwwp_Applog(SaveTWWP_Applog_DAO attendance)
        {
            return Json(aDal.SaveTwwp_ApplogDAL(attendance));
        }



        [HttpPost]

        [Route("api/TourPlan/SaveWorkSchedule")]
        public IHttpActionResult SaveWorkSchedule(List<WSS_Master> ainfo)
        {
            return Json(aDal.SaveWorkSchedule(ainfo));
        }



        [HttpPost]

        [Route("api/TourPlan/UpdateWorkSchedule")]
        public IHttpActionResult UpdateWorkSchedule(WSS_Master_Update ainfo)
        {
            return Json(aDal.UpdateWorkSchedule(ainfo));
        }



        [HttpGet]
        [Route("api/TourPlan/GetWS_Applog")]

        public IHttpActionResult GetWS_Applog(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, int? MonthValue, int? YearValue)
        {
            return Json(aDal.GetWS_ApplogDAL(pram, Role, AppStatus, FromDt, ToDt, EmpId, MonthValue, YearValue));
        }

        [HttpPost]
        [Route("api/TourPlan/SaveWS_Applog")]
        public IHttpActionResult SaveWS_Applog(SaveWS_Applog_DAO attendance)
        {
            return Json(aDal.SaveWS_ApplogDAL(attendance));
        }




        [HttpPost]

        [Route("api/TourPlan/SaveWorkScheduleABM")]
        public IHttpActionResult SaveWorkScheduleABM(WSMaster ainfo)
        {
            return Json(aDal.SaveWorkScheduleABM(ainfo));
        }



        [HttpGet]
        [Route("api/TourPlan/GetTourPlanData")]
        public IHttpActionResult Get_TourPlanData(int month,int year,int empId)
        {
            //return Json(aDal.Get_TourPlanData(month, year, empId));
            DataTable dt = aDal.Get_TourPlanData(month, year, empId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }
        
        [HttpGet]
        [Route("api/TourPlan/GetTourPlanDataDetail")]
        public IHttpActionResult GetTourPlanDataDetail(string month, string year, int empId, string Date)
        {
            //return Json(aDal.Get_TourPlanData(month, year, empId));

            return Json(aDal.Get_TourPlanDataDetail(month, year, empId, Date));
            
        }




       

       


        [HttpGet]
        [Route("api/TourPlan/GetWorkSchedule")]
        public IHttpActionResult GetWorkSchedule(string empId, string month, string Year, string Type)
        {

            return Json(aDal.GetWorkSchedule(empId, month, Year, Type));

        }



        [HttpGet]
        [Route("api/TourPlan/GetWorkScheduleAfterSave")]
        public IHttpActionResult GetWorkScheduleAfterSave(string empId, string month, string Year)
        {

            return Json(aDal.GetWorkScheduleAfterSave(empId, month, Year));

        }


        [HttpPost]
        [Route("api/TourPlan/ValidateTimeInRange")]
        public IHttpActionResult ValidateTimeInRange(string MainTime, string ShiftInfo)
        {
            try
            {
                // Ensure the request contains valid data
                if (string.IsNullOrEmpty(MainTime) || string.IsNullOrEmpty(ShiftInfo))
                {
                    return BadRequest("MainTime or ShiftInfo cannot be null or empty.");
                }

                // Call the data access layer method to validate time range
                DataTable dt = aDal.ValidateTimeInRange(MainTime, ShiftInfo);

                // Check if the DataTable has any rows
                if (dt != null && dt.Rows.Count > 0)
                {
                    // Assuming the stored procedure returns IsValid and Message columns
                    bool isValid = Convert.ToBoolean(dt.Rows[0]["IsValid"]);
                    string message = dt.Rows[0]["Message"].ToString();

                    // Return the result as a JSON object
                    return Json(new
                    {
                        IsValid = isValid,
                        Message = message
                    });
                }
                else
                {
                    // Return an error message if no data is returned
                    return Json(new
                    {
                        IsValid = false,
                        Message = "No data returned or invalid time range."
                    });
                }
            }
            catch (Exception ex)
            {
                // Return an internal server error message in case of an exception
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/TourPlan/GetMorningEveningTime")]
        public IHttpActionResult GetMorningEveningTime(string ShiftInfo)
        {
            //return Json(aDal.Get_TourPlanData(month, year, empId));
            DataTable dt = aDal.GetMorningEveningTime(ShiftInfo);
            if (dt == null || dt.Rows.Count == 0)
            {
                // Return an empty JSON object
                return Json(new { });
            }
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json[0]);
        }


        [HttpGet]
        [Route("api/TourPlan/GetTourPlanForWorkedwithCopy")]
        public IHttpActionResult GetTourPlanForWorkedwithCopy(int empId, string tDate, string morEve)
        {
            //return Json(aDal.Get_TourPlanData(month, year, empId));
            DataTable dt = aDal.GetTourPlanForWorkedwithCopy(empId, tDate, morEve);
            if (dt == null || dt.Rows.Count == 0)
            {
                // Return an empty JSON object
                return Json(new { });
            }

            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json[0]);
        }
        [HttpGet]
        [Route("api/TourPlan/GetTourPlanEditbyId")]
        public IHttpActionResult GetTourPlanEditbyId(int TourPlanId, string tDate)
        {
            //return Json(aDal.Get_TourPlanData(month, year, empId));
            DataTable dt = aDal.GetTourPlanEditbyId(TourPlanId, tDate);
            if (dt == null || dt.Rows.Count == 0)
            {
                // Return an empty JSON object
                return Json(new { });
            }

            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json[0]);
        }

        [HttpGet]
        [Route("api/TourPlan/GetTourPlanForWorkedwith")]
        public IHttpActionResult GetTourPlanForWorkedwith(int empId, string tDate)
        {
            //return Json(aDal.Get_TourPlanData(month, year, empId));
            DataTable dt = aDal.GetTourPlanForWorkedwith(empId, tDate);
            if (dt == null || dt.Rows.Count == 0)
            {
                // Return an empty JSON object
                return Json(new { });
            }
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json[0]);
        }

        [HttpGet]
        [Route("api/TourPlan/GetWorkScheduleABM")]
        public IHttpActionResult GetWorkScheduleABM(int empId, string MonthVal, string YearVal)
        {

            return Json(aDal.GetWorkScheduleABM(empId, MonthVal, YearVal));

        }
       


        [HttpPost]
        [Route("api/TourPlan/DelTourPlan")]
        public IHttpActionResult DelTourPlan(int id)
        {
            return Json(aDal.DeleteTourPlan(id));
        }

        [HttpGet]
        [Route("api/TourPlan/UpdateTourPlan")]

        public IHttpActionResult UpdateFinalTourSubmit(int empId, int month, int year, String remarks)
        {
            return Json(aDal.FinalSubmitTour(empId,month,year,remarks));
        }

        [HttpGet]
        [Route("api/TourPlan/GetTourPlanDataDetailNew")]
        public IHttpActionResult GetTourPlanDataDetailNew(string month, string year, int empId, string Date)
        {
            //return Json(aDal.Get_TourPlanData(month, year, empId));

            return Json(aDal.Get_TourPlanDataDetailNew(month, year, empId, Date));

        }
        [HttpGet]
        [Route("api/TourPlan/GetTourPlanData_new")]
        public IHttpActionResult Get_TourPlanData_new(int month, int year, int empId)
        {
            //return Json(aDal.Get_TourPlanData(month, year, empId));
            DataTable dt = aDal.Get_TourPlanData_New(month, year, empId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }

        [HttpGet]
        [Route("api/TourPlan/GetTourPlanMasterData")]
        public IHttpActionResult GetTourPlanMasterData(int month, int year, int empId)
        {
            return Json( aDal.Get_TourPlanMasterData(month, year, empId));
            
        }



        [HttpGet]
        [Route("api/Doctor/GetTourPlan_Applog")]

        public IHttpActionResult GetTourPlan_Applog(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, int? MonthValue, int?  YearValue)
        {
            return Json(aDal.GetTourPlan_ApplogDAL(pram, Role, AppStatus, FromDt, ToDt, EmpId, MonthValue,YearValue));
        }

        [HttpPost]
        [Route("api/Doctor/SaveTourPlan_Applog")]
        public IHttpActionResult SaveTourPlan_Applog(SaveTourPlan_Applog_DAO attendance)
        {
            return Json(aDal.SaveTourPlan_ApplogDAL(attendance));
        }



        [HttpGet]
        [Route("api/TourPlan/GetDWSP_Applog")]

        public IHttpActionResult GetDWSP_Applog(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, int? MonthValue, int? YearValue)
        {
            return Json(aDal.GetDWSP_ApplogDAL(pram, Role, AppStatus, FromDt, ToDt, EmpId, MonthValue, YearValue));
        }

        [HttpPost]
        [Route("api/TourPlan/SavetDWSP_Applog")]
        public IHttpActionResult SavetDWSP_Applog(SaveDWSP_Applog_DAO attendance)
        {
            return Json(aDal.SaveDWSP_ApplogDAL(attendance));
        }


        [HttpPost]
        [Route("api/TourPlan/FinalSubmitDWSP")]

        public IHttpActionResult UpdateFinalDWSPSubmit(int empId, int month, int year, String remarks)
        {
            return Json(aDal.FinalSubmitDWSP(empId, month, year, remarks));
        }
    }
}
