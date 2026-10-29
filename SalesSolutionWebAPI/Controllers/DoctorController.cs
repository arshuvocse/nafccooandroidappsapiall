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
    public class DoctorController : ApiController
    {
        private readonly DoctorDAL _aRepo = new DoctorDAL();
        [HttpGet]
        [Route("api/Doctor/GetDoctorDegree")]
        public IHttpActionResult GetDoctorDegree()
        {

            return Json(_aRepo.GetDoctorDegree());
        }


        [HttpGet]
        [Route("api/Doctor/GetDoctorSpecialDay")]
        public IHttpActionResult GetDoctorSpecialDay()
        {

            return Json(_aRepo.GetDoctorSpecialDayDAL());
        }


        [HttpGet]
        [Route("api/Doctor/GetDoctorSpeciality")]
        public IHttpActionResult GetDoctorSpeciality()
        {

            return Json(_aRepo.GetDoctorSpeciality());
        }

        [HttpGet]
        [Route("api/Doctor/GetDoctorType")]
        public IHttpActionResult GetDoctorType()
        {

            return Json(_aRepo.GetDoctorType());
        }

        [HttpGet]
        [Route("api/Doctor/GetDoctorProgramType")]
        public IHttpActionResult GetDoctorProgramType()
        {

            return Json(_aRepo.GetProgramType());
        }


        [HttpGet]
        [Route("api/Doctor/GetProviderType")]
        public IHttpActionResult GetProviderType()
        {

            return Json(_aRepo.GetProviderType());
        }


        [HttpGet]
        [Route("api/Doctor/GetSMCType")]
        public IHttpActionResult GetSMCType()
        {

            return Json(_aRepo.GetSMCType());
        }


        [HttpGet]
        [Route("api/Doctor/GetNonEffectiveReason")]
        public IHttpActionResult GetNonEffectiveReason()
        {

            return Json(_aRepo.GetNonEffectiveReason());
        }

        [HttpGet]
        [Route("api/Doctor/GetDoctorBrand")]
        public IHttpActionResult GetDoctorBrand()
        {

            return Json(_aRepo.GetDoctorBrand());
        }


        [HttpGet]
        [Route("api/Doctor/GeDoctorCategory")]
        public IHttpActionResult GeDoctorCategory()
        {

            return Json(_aRepo.GetDoctorCategory());
        }

        [HttpGet]
        [Route("api/Doctor/GetDoctorInstitution")]
        public IHttpActionResult GetDoctorInstitution()
        {

            return Json(_aRepo.GetDoctorInstitution());
        }

        [HttpGet]
        [Route("api/Doctor/GetDoctorChemberType")]
        public IHttpActionResult GetDoctorChemberType()
        {

            return Json(_aRepo.GetDoctorChemberType());
        }

        [HttpGet]
        [Route("api/Doctor/GetDoctorChemberName")]
        public IHttpActionResult GetDoctorChemberName(int empId)
        {

            return Json(_aRepo.GetDoctorChemberName(empId));
        }

        [HttpGet]
        [Route("api/Doctor/GetDoctorContactType")]
        public IHttpActionResult GetDoctorContactType()
        {

            return Json(_aRepo.GetDoctorContactType());
        }


        [HttpPost]

        [Route("api/Doctor/SaveDoctorInfo")]
        public IHttpActionResult SaveDoctorInfo(DoctorSM aDoc)
        {
            return Json(_aRepo.SaveDoctor(aDoc));
        }

        [HttpGet]
        [Route("api/Doctor/GetDoctorList")]
        public IHttpActionResult GetDoctorList(int empId)
        {

            return Json(_aRepo.GetDoctorList(empId));
        }


        [HttpGet]
        [Route("api/Doctor/GetPlannedDoctorList")]
        public IHttpActionResult GetPlannedDoctorList(int empId,string date)
        {

            return Json(_aRepo.GetPlannedDoctorList(empId, date));
        }


        [HttpPost]
        [Route("api/Doctor/UpdateDoctorProvider")]

        public IHttpActionResult UpdateDoctorProvider(string empId, string DoctorId, string ProviderTypeId)
        {
            return Json(_aRepo.UpdateDoctorProviderDAL(empId, DoctorId, ProviderTypeId));
        }

        [HttpPost]
        [Route("api/Doctor/UpdateDoctorMarket")]

        public IHttpActionResult UpdateDoctorMarket(DoctorMArket_DAO aDao)
        {
            return Json(_aRepo.UpdateDoctorMarketDAL(aDao));
        }


        [HttpGet]
        [Route("api/Doctor/GetDoctorEdtMode")]

        public IHttpActionResult GetDoctorEdtMode(int doctorId)
        {
            return Json(_aRepo.GetDoctorEdtMode(doctorId));
        }

        [HttpGet]
        [Route("api/Doctor/GetDoctor_Applog")]

        public IHttpActionResult GetDoctor_Applog(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId,string ProgramTypeId, string DoctorTypeId)
        {
            return Json(_aRepo.GetDoctor_ApplogDAL(pram, Role, AppStatus, FromDt, ToDt, EmpId,  ProgramTypeId, DoctorTypeId));
        }

        [HttpPost]
        [Route("api/Doctor/SaveDoctor_Applog")]
        public IHttpActionResult SaveDoctor_Applog(SaveDoctorAppLog_DAO attendance)
        {
            return Json(_aRepo.SaveDoctor_ApplogDAL(attendance));
        }


        [HttpGet]
        [Route("api/Doctor/GetDoctorDesignation")]
        public IHttpActionResult GetDoctorDesignation()
        {

            return Json(_aRepo.GetDoctorDesignation());
        }


        [HttpGet]
        [Route("api/Doctor/GetDWSPTotals")]
        public IHttpActionResult GetDWSPTotals(int month, int year, int empId)
        {

            return Json(_aRepo.GetDWSPTotalsDAL(month, year, empId));
        }


        [HttpPost]
        [Route("api/Doctor/DeleteTourPlan")]
        public IHttpActionResult DeleteDoctorTourPlan(int id)
        {
            return Json(_aRepo.DeleteDoctorTourPlan(id));
        }


        [HttpPost]
        [Route("api/Doctor/UpdateDoctorTourPlan")]

        public IHttpActionResult UpdateFinalTourSubmit(int empId, int month, int year, String remarks)
        {
            return Json(_aRepo.FinalSubmitDoctorTour(empId, month, year, remarks));
        }


        [HttpGet]
        [Route("api/Doctor/GetDoctorVisitPlanMaster")]
        public IHttpActionResult GetDoctorVisitPlanMaster(int month, int year, int empId)
        {
            DataTable dt = _aRepo.Get_TourPlanMasterData(month, year, empId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);

            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }




        [HttpGet]
        [Route("api/Doctor/GetDoctorVisitPlan_Applog")]

        public IHttpActionResult GetTourPlan_Applog(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, int? MonthValue, int? YearValue)
        {
            return Json(_aRepo.GetDoctorVisit_ApplogDAL(pram, Role, AppStatus, FromDt, ToDt, EmpId, MonthValue, YearValue));
        }

        [HttpPost]
        [Route("api/Doctor/SaveDoctorVisit_Applog")]
        public IHttpActionResult SaveDoctorVisitPlan_Applog(SaveDoctorVisit_Applog_DAO attendance)
        {
            return Json(_aRepo.SaveDoctorVisitPlan_ApplogDAL(attendance));
        }


        #region prescription

        [HttpGet]
        [Route("api/Doctor/GetPrescriptionType")]
        public IHttpActionResult GetPrescriptionType(int empId)
        {

            return Json(_aRepo.GetPrescriptionTYpe(empId));
        }


        [HttpPost]
        [Route("api/Doctor/SavePrescription")]

        public IHttpActionResult SavePrescription(PrescriptionSM aPres)
        {
            return Json(_aRepo.SavePrescritpion(aPres));
        }


         



        [HttpGet]
        [Route("api/Doctor/GetPrescriptionList")]
        public IHttpActionResult GetPrescriptionList(int empId, string FromDt, string ToDt)
        {

            return Json(_aRepo.GetPrescriptionList(empId, FromDt, ToDt));
        }



        [HttpGet]
        [Route("api/Doctor/GetPrescription_Applog")]

        public IHttpActionResult GetPrescription_Applog(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, string GroupId, string ZoneId, string AreaId, string TerritoryId)
        {
            return Json(_aRepo.GetPrescription_ApplogDAL(pram, Role, AppStatus, FromDt, ToDt, EmpId, GroupId, ZoneId, AreaId, TerritoryId));
        }

        [HttpPost]
        [Route("api/Doctor/SavePrescription_Applog")]
        public IHttpActionResult SavePrescription_Applog(SavePrescription_Applog_DAO attendance)
        {
            return Json(_aRepo.SavePrescription_ApplogDAL(attendance));
        }

        #endregion



        #region DCR

        [HttpGet]
        [Route("api/Doctor/GetVisitType")]
        public IHttpActionResult GetVisitType()
        {

            return Json(_aRepo.GetVisitTYpe());
        }


        [HttpGet]
        [Route("api/Doctor/GetBrandWisePromo")]
        public IHttpActionResult GetBrandWisePromo()
        {

            return Json(_aRepo.GetBrandWisePromo());
        }


        [HttpGet]
        [Route("api/Doctor/GetDoctorChamberForDCR")]
        public IHttpActionResult GetDoctorChamberDCR(int doctorId)
        {

            return Json(_aRepo.GetDoctorChamberForDcr(doctorId));
        }

        [HttpGet]
        [Route("api/Doctor/GetProductForDcrByType")]
        public IHttpActionResult GetProductForDcrByType(int empId, string type)
        {

            return Json(_aRepo.GetProductForDcrByType(empId,type));
        }


        [HttpPost]
        [Route("api/Doctor/SaveDcr")]
        public IHttpActionResult SaveDcr(DcrMaster aInfo)
        {
            return Json(_aRepo.SaveDcr(aInfo));
        }

        [HttpGet]
        [Route("api/Doctor/GetDcrList")]
        public IHttpActionResult GetDcrList(string empId, string FromDt, string ToDt)
        {

            return Json(_aRepo.GetDcrList(empId, FromDt, ToDt));
        }

        [HttpDelete]
        [Route("api/Doctor/DeleteDCR")]
        public IHttpActionResult DeleteDCR(int id)
        {

            return Json(_aRepo.DeleteDCR(id));
        }
        [HttpGet]
        [Route("api/Doctor/GetDCR_Applog")]

        public IHttpActionResult GetDCR_Applog(string pram, string Role, string AppStatus, string Month, string Year, string EmpId)
        {
            return Json(_aRepo.GetDCR_ApplogDAL(pram, Role, AppStatus, Month, Year, EmpId));
        }


        [HttpPost]
        [Route("api/Doctor/SaveDCR_Applog")]
        public IHttpActionResult SaveDCR_Applog(DCRMaster_App_New aInfo)
        {

            return Json(_aRepo.SaveDCR_Applog(aInfo));
        }


        //[HttpPost]
        //[Route("api/Doctor/SaveDCR_Applog")]
        //public IHttpActionResult SaveDCR_Applog(SaveDCRAppLog_DAO attendance)
        //{
        //    return Json(_aRepo.SaveDCR_ApplogDAL(attendance));
        //}


        [HttpGet]
        [Route("api/Doctor/GetUserRole")]
        public IHttpActionResult GetUserRole()
        {
            return Json(_aRepo.GetUserRole());
        }


        [HttpGet]
        [Route("api/Doctor/GetEmpInfoRoleID")]
        public IHttpActionResult GetEmpInfoRoleID(int empId)
        {
            return Json(_aRepo.GetEmpInfoRoleID(empId));
        }



        [HttpGet]
        [Route("api/Doctor/GetUserRoleByRoleId")]
        public IHttpActionResult GetUserRoleByRoleId(int id,int empId)
        {
            return Json(_aRepo.GetUserByRoleId(id, empId));
        }


        #endregion
        #region DWSP
        [HttpPost]
        [Route("api/Doctor/SaveDWSP")]
        public IHttpActionResult SaveDWSP(DWSPMasterDAO aInfo)
        {
            return Json(_aRepo.SaveDWSPDAL(aInfo));
        }



        [HttpGet]
        [Route("api/Doctor/GetDWSPDetail")]
        public IHttpActionResult GetDWSPDetail(int month, int year, int empId)
        {
            DataTable dt = _aRepo.GetDWSPDetailDAL(month, year, empId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }


        [HttpGet]
        [Route("api/Doctor/GetDWSPByDate")]
        public IHttpActionResult GetDWSPByDate(DateTime DWSPDate, int empId)
        {

            return Json(_aRepo.GetDWSPByDateDAL(DWSPDate, empId));
        }


        #endregion
        #region DoctorTourPLan

        [HttpPost]
        [Route("api/Doctor/SaveDoctorVisitPlan")]
        public IHttpActionResult SaveDoctorTourPlan(List<DocTourPlanMaster> aInfo)
        {
            return Json(_aRepo.SaveDocTourPlan(aInfo));
        }

        [HttpPost]
        [Route("api/Doctor/SaveDCPInfo")]
        public IHttpActionResult SaveDCPInfo(DCPMaster aInfo)
        {
            return Json(_aRepo.SaveDCPInfo(aInfo));
        }


        [HttpPost]
        [Route("api/Doctor/DCPFinalSubmit")]

        public IHttpActionResult DCPFinalSubmit(int empId, int month, int year, String remarks)
        {
            return Json(_aRepo.DCPFinalSubmit(empId, month, year, remarks));
        }



        [HttpGet]
        [Route("api/Doctor/GetDCPList")]
        public IHttpActionResult GetDCPList(int month, int year, int empId)
        {
            return Json(_aRepo.GetDCPList(month, year, empId));
             
        }

        [HttpGet]
        [Route("api/Doctor/GetDCPMaster")]
        public IHttpActionResult GetDCPMaster(int month, int year, int empId)
        {
            return Json(_aRepo.GetDCPMaster(month, year, empId));

        }


        [HttpGet]
        [Route("api/Doctor/GetDCP_Applog")]

        public IHttpActionResult GetDCP_Applog(string pram, string Role, string AppStatus, string Month, string Year, string EmpId)
        {
            return Json(_aRepo.GetDCP_Applog(pram, Role, AppStatus, Month, Year, EmpId));
        }

        [HttpPost]
        [Route("api/Doctor/DeleteDCP")]
        public IHttpActionResult DeleteDCP(string DCPDetailId )
        {

            return Json(_aRepo.DeleteDCP(DCPDetailId));
        }
        [HttpPost]
        [Route("api/Doctor/SaveDCP_Applog")]
        public IHttpActionResult SaveDCP_Applog(DCPMaster_App aInfo)
        {

            return Json(_aRepo.SaveDCP_Applog(aInfo));
        }

        [HttpGet]
        [Route("api/Doctor/GetDoctorVisitPlanDetail")]
        public IHttpActionResult GetDoctorTourPlanDetail(int month, int year, int empId)
        {
            DataTable dt = _aRepo.Get_DoctorTourPLanDetails(month, year, empId);
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            dynamic json = JsonConvert.DeserializeObject(JSONresult);
            return Json(json);
        }


        [HttpGet]
        [Route("api/Doctor/GetDoctorVisitPlanByDate")]
        public IHttpActionResult GetDoctorTourPlanByDate(DateTime tourPlanDate,int empId)
        {

            return Json(_aRepo.GetTodaysDoctorPlan(tourPlanDate,empId));
        }


        [HttpGet]
        [Route("api/Doctor/TodaysTask")]
        public IHttpActionResult GetTodaysTask(int empId)
        {

            return Json(_aRepo.GetTodaysTask( empId));
        }



        #endregion



        [HttpGet]
        [Route("api/Doctor/GetDar")]
        public IHttpActionResult GetDar(string empid, string teri_id, string date)
        {

            return Json(_aRepo.GetDarDAL(empid, teri_id, date));
        }


        [HttpGet]
        [Route("api/Doctor/GetDailySalesReport")]
        public IHttpActionResult GetDailySalesReport(string empid, string teri_id, string date)
        {

            return Json(_aRepo.GetDailySalesReportDAL(empid, teri_id, date));
        }


        [HttpPost]
        [Route("api/Doctor/SaveDailySalesReport")]
        public IHttpActionResult SaveDailySalesReport(List<DSRDAO> aInfo)
        {
            return Json(_aRepo.SaveDailySalesReportDAL(aInfo));
        }
    }
}
