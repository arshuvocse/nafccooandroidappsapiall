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
    public class LeaveController : ApiController
    {
        private readonly LeaveDAL aRepo = new LeaveDAL();


        [HttpGet]
        [Route("api/Leave/GetLeaveType")]
        public IHttpActionResult GetEmpLeaveType(int empId, int year)
        {
            return Json(aRepo.GetLeaveType(empId,year));

        }


        [HttpPost]
        [Route("api/Leave/SaveLeave")]
        public IHttpActionResult Save(LeaveSM aInfo)
        {
            return Json(aRepo.SaveLeaveInfo(aInfo));

        }

        [HttpGet]
        [Route("api/Leave/GetLeaveRecords")]
        public IHttpActionResult Get(int empId, string Month, int year)
        {
            return Json(aRepo.GetLeaveRecords(empId, Month, year));

        }

        // empId ,date range,leave type

        [HttpGet]
        [Route("api/Leave/GetAllLeaveRecords")]
        public IHttpActionResult GetAllLeaveRecords(string empCode=null,DateTime? fromDate = null,DateTime? toDate=null,int? leaveTypeId=null)
        {
            return Json(aRepo.GetAllLeaveRecords(empCode, fromDate,toDate,leaveTypeId));

        }

        [HttpDelete]
        [Route("api/Leave/DeleteLeave")]
        public IHttpActionResult DeleteLeave(int id)
        {
            return Json(aRepo.DeleteLeave(id));
        }


        [HttpGet]
        [Route("api/Leave/GetLeaveEditData")]
        public IHttpActionResult GetLeaveEditData(int id)
        {
            return Json(aRepo.GetLeaveEditData(id));

        }



        [HttpGet]
        [Route("api/Leave/LeaveApprovalStatusChange")]
        public IHttpActionResult LeaveApprovalStatusChange(int id, String approvalText, int empId)
        {
            return Json(aRepo.ApproveLeave(id,approvalText,empId));

        }


        [HttpGet]
        [Route("api/Leave/GetLeave_AppLog")]

        public IHttpActionResult GetLeave_AppLog(string pram, string Role, string AppStatus,   string FromDt, string ToDt, string EmpId)
        {
            return Json(aRepo.GetLeave_AppLogDAL(pram, Role, AppStatus,  FromDt, ToDt, EmpId));
        }


        [HttpPost]
        [Route("api/Leave/SaveLeave_AppLog")]
        public IHttpActionResult SaveLeave_AppLog(LeaveApplo_Save attendance)
        {
            return Json(aRepo.SaveLeave_AppLog(attendance));
        }
    }
}
