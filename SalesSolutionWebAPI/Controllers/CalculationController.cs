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
    public class CalculationController : ApiController
    {
        CalculationDAL _repo = new CalculationDAL();

        [HttpGet]
        [Route("api/Calculation/GetTourPlanForTada")]
        public IHttpActionResult GetTourPlanForTada(int empId,DateTime tourDate)
        {
   
            return Json(_repo.Get_TourPlanForTadaClaim(empId, tourDate));
        }

        [HttpGet]
        [Route("api/Calculation/GetTadaAmount")]
        public IHttpActionResult GetTadaAmount(int userId)
        {

            return Json(_repo.GetTadaAmount(userId));
        }


        [HttpPost]
        [Route("api/Calculation/SaveTadaClaim")]
        public IHttpActionResult SaveTadaClaim(TadaClaim ainfo)
        {
            return Json(_repo.SaveTadaClaim(ainfo));
        }


       
        [HttpGet]
        [Route("api/Calculation/GetTADA_Applog")]

        public IHttpActionResult GetTADA_Applog(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, string Month, string Year)
        {
            return Json(_repo.GetTADA_Applog_DAL(pram, Role, AppStatus, FromDt, ToDt, EmpId, Month, Year));
        }

        [HttpPost]
        [Route("api/Calculation/SaveTADA_Applog")]
        public IHttpActionResult SaveTADA_Applog(TADASaveApprovalLogDAO attendance)
        {
            return Json(_repo.SaveTADAClaim_ApplogDAL(attendance));
        }

        #region Expense Claim

        [HttpGet]
        [Route("api/Calculation/Get_ExpenseType")]
        public IHttpActionResult Get_ExpenseType()
        {

            return Json(_repo.Get_ExpenseType());
        }

        [HttpGet]
        [Route("api/Calculation/Get_ExpenseTypeDetails")]
        public IHttpActionResult Get_ExpenseTypeDetails(int id)
        {

            return Json(_repo.Get_ExpenseTypeDetails(id));
        }


        [HttpPost]
        [Route("api/Calculation/SaveExpenseClaim")]
        public IHttpActionResult SaveExpenseClaim(ExpenseClaimMaster ainfo)
        {
            return Json(_repo.SaveExpenseClaim(ainfo));
        }

        [HttpGet]
        [Route("api/Calculation/Get_ExpenseClaimList")]
        public IHttpActionResult Get_ExpenseCLaimList(string monthValue, string yearValue, string statusTxt, string empId)
        {

            return Json(_repo.GetExpenseList( monthValue,  yearValue,  statusTxt, empId));
        }



        [HttpGet]
        [Route("api/Calculation/GetExpenseClaim_Applog")]

        public IHttpActionResult GetExpenseClaim_Applog(string pram, string Role, string AppStatus,  string FromDt, string ToDt, string EmpId)
        {
            return Json(_repo.GetExpenseClaim_Applog_DAL(pram, Role, AppStatus,  FromDt, ToDt, EmpId));
        }

        [HttpPost]
        [Route("api/Calculation/SaveExpenseClaim_Applog")]
        public IHttpActionResult SaveExpenseClaim_Applog(ExpanseSaveApprovalLogDAO attendance)
        {
            return Json(_repo.SaveExpenseClaim_ApplogDAL(attendance));
        }

        [HttpGet]
        [Route("api/Calculation/ExpenseClaim_del")]
        public IHttpActionResult ExpenseClaim_del(int id)
        {

            return Json(_repo.DeleteExpeseClaim(id));
        }



        #endregion



        #region Mileage Claim
        [HttpGet]
        [Route("api/Calculation/GetTransportList")]
        public IHttpActionResult GetTransportList()
        {

            return Json(_repo.Get_TransportList());
        }




        [HttpPost]
        [Route("api/Calculation/SaveMileageClaim")]
        public IHttpActionResult SaveMileageClaim(MileageClaim ainfo)
        {
            return Json(_repo.SaveMileageClaim(ainfo));
        }

        [HttpGet]
        [Route("api/Calculation/GetMileageClaim_Applog")]

        public IHttpActionResult GetMileageClaim_Applog(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, string Month, string Year)
        {
            return Json(_repo.GetMileageClaim_Applog_DAL(pram, Role, AppStatus, FromDt, ToDt, EmpId, Month, Year));
        }

        [HttpPost]
        [Route("api/Calculation/SaveMileageClaim_Applog")]
        public IHttpActionResult SaveMileageClaim_Applog(SaveMileageClaimAppLog_DAO attendance)
        {
            return Json(_repo.SaveMileageClaim_Applog_DAL(attendance));
        }


        [HttpGet]
        [Route("api/Calculation/GetMileageCLaimList")]
        public IHttpActionResult GetMileageCLaimList(string monthValue, string yearValue, string statusTxt, string empId)
        {
            return Json(_repo.Get_MileageCLaimList(monthValue, yearValue, statusTxt, empId));
        }


        [HttpGet]
        [Route("api/Calculation/GetMileageCLaimDetailsById")]
        public IHttpActionResult GetMileageCLaimDetailsById(int id)
        {

            AppPrimaryDAL appDal = new AppPrimaryDAL();
            ImagePath _path = new ImagePath();
            _path = appDal.GetImagePath("Mileage");

            MileageClaimViewModel mileageClaimViewModel = new MileageClaimViewModel();
            mileageClaimViewModel = _repo.GetMileageCLaimDetailsById(id);

            string fPath = _path.ImagePathValue+"/"+ _path.ImagePreName + id + ".jpg";
            byte[] imageArray = System.IO.File.ReadAllBytes(@fPath);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            mileageClaimViewModel.ImageBase64SValue = base64ImageRepresentation;

            return Json(mileageClaimViewModel);
        }

        #endregion


        [HttpGet]
        [Route("api/Calculation/GetBonusCampaign")]
        public IHttpActionResult GetBonusCampaign(int customerId,int empId,double totalAmt,string productCodeMultiple)
        {

            return Json(_repo.GetBonusCampaign(customerId,empId,totalAmt, productCodeMultiple));
        }


        [HttpGet]
        [Route("api/Calculation/GetTadaList")]
        public IHttpActionResult GetTadaList(string monthValue, string yearValue, string statusTxt, string userId, string FromDt, string ToDt)
        {

            return Json(_repo.GetTadaList(monthValue, yearValue, statusTxt, userId, FromDt, ToDt));
        }

    }
}
