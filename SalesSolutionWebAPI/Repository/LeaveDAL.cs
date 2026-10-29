using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Repository
{
    public class LeaveDAL
    {
        private DataAccessManager accessManager = new DataAccessManager();

        public DataTable GetLeaveType(int empId,int year)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter> { 
                new SqlParameter("@empId",empId),
                new SqlParameter("@year",year),
                };
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_LeaveType", aSqlParameterlist);
                return dt;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }

        public ResultInfo SaveLeaveInfo(LeaveSM aSM)
        {

            ResultInfo aInformation = new ResultInfo();
            try
            {
                bool isOKtoSubmit = true;
  int pk = 0;
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                //List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                //aSqlParameterlist.Add(new SqlParameter("@typeId", aSM.LeaveBalanceId));
                //aSqlParameterlist.Add(new SqlParameter("@startDate", aSM.StartDate));
                //aSqlParameterlist.Add(new SqlParameter("@endDate", aSM.EndDate));
                //DataTable dt = accessManager.GetDataTable("sp_Webapi_Chk_MaxAllowLeaveDay", aSqlParameterlist);
                //if (dt.Rows.Count > 0)
                //{
                    List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                    DateTime entryDtae = DateTime.Now;
                    gSqlParameterList.Add(new SqlParameter("@leaveAppId", aSM.LeaveApplicationId));
                    gSqlParameterList.Add(new SqlParameter("@typeId", aSM.LeaveBalanceId));
                    gSqlParameterList.Add(new SqlParameter("@startDate", aSM.StartDate));
                    gSqlParameterList.Add(new SqlParameter("@endDate", aSM.EndDate));
                    gSqlParameterList.Add(new SqlParameter("@reason", aSM.Reason));

                    gSqlParameterList.Add(new SqlParameter("@empId", aSM.EmpId));

                    gSqlParameterList.Add(new SqlParameter("@DateOfReturnsToDuty", aSM.DateOfReturnsToDuty ?? (object)DBNull.Value ?? (object)DBNull.Value));

                    gSqlParameterList.Add(new SqlParameter("@LeaveAddress", aSM.LeaveAddress ?? (object)DBNull.Value ?? (object)DBNull.Value));

                    gSqlParameterList.Add(new SqlParameter("@EmergencyContactNo", aSM.EmergencyContactNo ?? (object)DBNull.Value ?? (object)DBNull.Value));

                    gSqlParameterList.Add(new SqlParameter("@Comments", aSM.Comments ?? (object)DBNull.Value ?? (object)DBNull.Value));
                    if (aSM.LeaveApplicationId > 0)
                    {
                        aInformation.isSuccess = accessManager.UpdateData("sp_Webapi_UD_LeaveInfo", gSqlParameterList);
                        if (aInformation.isSuccess)
                        {
                            pk = aSM.LeaveApplicationId;
                        }

                    }
                    else
                    {



                        pk = accessManager.SaveDataReturnPrimaryKey("sp_Webapi_Save_LeaveInfo", gSqlParameterList);

                        if (pk > 0)
                        {
                            aInformation.isSuccess = true;
                        }

                    }
                    //else
                    //{
                    //    aInformation.isSuccess = false;
                    //    aInformation.ErrorMessage = "The leave has already been approved. Can't edit right now";
                    //}

                    if (aInformation.isSuccess)
                    {
                        if (!string.IsNullOrEmpty(aSM.ImageBase64String))
                        {
                            AppPrimaryDAL app = new AppPrimaryDAL();
                            ImagePath _path = new ImagePath();
                            string type = "Leave";
                            _path = app.GetImagePath(type);
                            string targetPath = @"" + _path.ImagePathValue + "";
                            if (!Directory.Exists(targetPath))
                            {
                                Directory.CreateDirectory(targetPath);
                            }

                            string filePath = targetPath + "/" + _path.ImagePreName + pk + "." + "jpg";
                            File.WriteAllBytes(filePath, Convert.FromBase64String(aSM.ImageBase64String));
                        }
                    }
                    else
                    {
                        aInformation.isValiCheck = true;
                        aInformation.ErrorMessage = "The leave has already been Pending!!";
                    }
                //}

                //else
                //{

                //    try
                //    {
                        
                //        aInformation.isValiCheck = true;
                //        DataTable dtCheck = accessManager.GetDataTable("sp_Webapi_Chk_MaxAllowLeaveDay_kk", aSqlParameterlist);

                //        aInformation.ErrorMessage = dtCheck.Rows[0]["MessageBox"].ToString();
                //    }
                //    catch
                //    {

                //    }
                //}





            }
            catch (Exception exception)
            {
                accessManager.SqlConnectionClose(true);
                aInformation.isSuccess = false;
                aInformation.ErrorMessage = exception.Message;

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }

            return aInformation;
        }



        public LvMaster GetLeaveRecords(int? empId, string Month, int? year)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                aSqlParameterlist.Add(new SqlParameter("@Month", Month ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@year", year ?? (object)DBNull.Value ?? (object)DBNull.Value));

                
           
                DataTable dtDoctor = new DataTable();
                DataTable dt = new DataTable();
                
                    dtDoctor = accessManager.GetDataTable("sp_Webapi_Get_LeaveAllocation", aSqlParameterlist);

                    dt = accessManager.GetDataTable("sp_Webapi_Get_LeaveRecords", aSqlParameterlist);

                LvMaster aDetails = new LvMaster();

                //if (dtDoctor.Rows[0]["Sick"] != DBNull.Value)
                //{
                    aDetails = new LvMaster();
                    //aDetails.Sick = (dtDoctor.Rows[0]["Sick"].ToString());
                    //aDetails.Casual = (dtDoctor.Rows[0]["Casual"].ToString());
                    //aDetails.Anual  = (dtDoctor.Rows[0]["Anual"].ToString());




                    List<Leave_List> aDetailsListDD = new List<Leave_List>();
                    Leave_List aChemberDetails;
                    for (var ch = 0; ch < dt.Rows.Count; ch++)

                    {

                        aChemberDetails = new Leave_List();
                        aChemberDetails.LeaveApplicationId = (dt.Rows[ch]["LeaveApplicationId"].ToString());
                        aChemberDetails.UserName = (dt.Rows[ch]["UserName"].ToString());
                        aChemberDetails.LeaveTypeName = (dt.Rows[ch]["LeaveTypeName"].ToString());
                        aChemberDetails.LeaveFromDate = (dt.Rows[ch]["LeaveFromDate"].ToString());
                        aChemberDetails.LeaveToDate = (dt.Rows[ch]["LeaveToDate"].ToString());
                        aChemberDetails.CreatedAt = (dt.Rows[ch]["CreatedAt"].ToString());
                        aChemberDetails.Days = (dt.Rows[ch]["Days"].ToString());
                        aChemberDetails.Reason = (dt.Rows[ch]["Reason"].ToString());
                        aChemberDetails.ApprovalStatus = (dt.Rows[ch]["ApprovalStatus"].ToString());

                        aDetailsListDD.Add(aChemberDetails);
                    }
                    aDetails.LeaveList = aDetailsListDD;


                    aDetails.LeaveList = aDetailsListDD;




                List<LeaveType_List> aLeaveTypeDD = new List<LeaveType_List>();
                LeaveType_List aLeaveTypeDetails;
                for (var ch = 0; ch < dtDoctor.Rows.Count; ch++)

                {

                    aLeaveTypeDetails = new LeaveType_List();
                    aLeaveTypeDetails.Type = (dtDoctor.Rows[ch]["LeaveTypeName"].ToString());
                    aLeaveTypeDetails.Value = (dtDoctor.Rows[ch]["LValue"].ToString());


                    aLeaveTypeDD.Add(aLeaveTypeDetails);
                }
                aDetails.LeaveTypeList = aLeaveTypeDD;


                aDetails.LeaveTypeList = aLeaveTypeDD;
                //}






                return aDetails;

            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
        //public DataTable GetLeaveRecords(int? empId, string Month, int? year)
        //{
        //    try
        //    {
        //        accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
        //        List<SqlParameter> aSqlParameterlist = new List<SqlParameter>{ 
        //        new SqlParameter("empId",empId ?? (object)DBNull.Value ?? (object)DBNull.Value),
        //        new SqlParameter("Month",Month?? (object)DBNull.Value ?? (object)DBNull.Value),
        //        new SqlParameter("year",year?? (object)DBNull.Value ?? (object)DBNull.Value)
        //        };
        //        DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_LeaveRecords", aSqlParameterlist);
        //        return dt;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        accessManager.SqlConnectionClose();
        //    }
        //}



        public DataTable GetAllLeaveRecords(string empCode = null, DateTime? fromDate = null, DateTime? toDate = null, int? leaveTypeId = null)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>{
                new SqlParameter("@empCode",empCode),
                new SqlParameter("@leaveTypeId",leaveTypeId)
                };
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_AllLeaveRecords", aSqlParameterlist);
                return dt;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }


        public bool IsEditable(int id)
        {
            bool result = true;
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_Get_LeaveApproveById", gSqlParameterList);
                if (dr.HasRows)
                {
                    result = false;
                }




            }
            catch (Exception ex)
            {

            }

            finally
            {
                accessManager.SqlConnectionClose();
            }

            return result;

        }



        public ResultInfo DeleteLeave(int id)
        {

            ResultInfo aInformation = new ResultInfo();
            try
            {

            



                if (IsEditable(id))
                {
                    accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                    List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                    gSqlParameterList.Add(new SqlParameter("@id", id));
                    aInformation.isSuccess = accessManager.DeleteData("sp_Webapi_Delete_LeaveInfo", gSqlParameterList);

                }
                else
                {

                    aInformation.isSuccess = false;
                    aInformation.ErrorMessage = "Leave has already been approved. Unable to delete";

                }



            }
            catch (Exception exception)
            {
                accessManager.SqlConnectionClose(true);
                aInformation.isSuccess = false;
                aInformation.ErrorMessage = exception.Message;

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }

            return aInformation;
        }


        public DataTable GetLeaveEditData(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>{
                new SqlParameter("id",id)
                };
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_LeaveEditData", aSqlParameterlist);
                return dt;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }


        public ResultInfo ApproveLeave(int id,String approvalType,int EmpId)
        {

            ResultInfo aInformation = new ResultInfo();
            try
            {



                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@id", id));
                gSqlParameterList.Add(new SqlParameter("@approvalType", approvalType));
                gSqlParameterList.Add(new SqlParameter("@empId", EmpId));
                aInformation.isSuccess = accessManager.UpdateData("sp_Webapi_Update_LeaveData", gSqlParameterList);




            }
            catch (Exception exception)
            {
                accessManager.SqlConnectionClose(true);
                aInformation.isSuccess = false;
                aInformation.ErrorMessage = exception.Message;

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }

            return aInformation;
        }


        public string NewMethod(string pram, string Role, List<SqlParameter> gSqlParameterList)
        {
            if (Role == "AM")
            {

                string pramArr = pram.Trim();
                if (pramArr.Contains('='))
                {
                    string[] emp = pramArr.Split('=');

                    string AreId = emp[1].Trim();


                    List<SqlParameter> gSqlEmp = new List<SqlParameter>();

                    gSqlEmp.Add(new SqlParameter("@AreId", AreId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                    DataTable dtEmp = accessManager.GetDataTable("sp_Webapi_Get_AMMultipleArea", gSqlEmp);

                    string ArrAreaId = "";
                    string MainArrAreaId = "";
                    for (var i = 0; i < dtEmp.Rows.Count; i++)

                    {
                        if (dtEmp.Rows[i]["AreaId"] != DBNull.Value)
                        {
                            ArrAreaId = ArrAreaId + (dtEmp.Rows[i]["AreaId"].ToString()) + ',';

                        }
                    }
                    MainArrAreaId = ArrAreaId.TrimEnd(',');

                    pram = " AND View_Webapi_EmployeeFieldForceInfo.EmpAreaId in (" + MainArrAreaId + ")";
                    gSqlParameterList.Add(new SqlParameter("@param", pram ?? (object)DBNull.Value ?? (object)DBNull.Value));

                }
            }

            else if (Role == "DZSM")
            {

                string pramArr = pram.Trim();
                if (pramArr.Contains('='))
                {
                    string[] emp = pramArr.Split('=');

                    string AreId = emp[1].Trim();


                    List<SqlParameter> gSqlEmp = new List<SqlParameter>();

                    gSqlEmp.Add(new SqlParameter("@AreId", AreId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                    DataTable dtEmp = accessManager.GetDataTable("sp_Webapi_Get_DZSMMultipleArea", gSqlEmp);

                    string ArrAreaId = "";
                    string MainArrAreaId = "";
                    for (var i = 0; i < dtEmp.Rows.Count; i++)

                    {
                        if (dtEmp.Rows[i]["RegionId"] != DBNull.Value)
                        {
                            ArrAreaId = ArrAreaId + (dtEmp.Rows[i]["RegionId"].ToString()) + ',';

                        }
                    }
                    MainArrAreaId = ArrAreaId.TrimEnd(',');

                    pram = " AND View_Webapi_EmployeeFieldForceInfo.EmpRegionId in (" + MainArrAreaId + ")";
                    gSqlParameterList.Add(new SqlParameter("@param", pram ?? (object)DBNull.Value ?? (object)DBNull.Value));

                }
            }
            else
            {
                gSqlParameterList.Add(new SqlParameter("@param", pram ?? (object)DBNull.Value ?? (object)DBNull.Value));

            }

            return pram;
        }

        public IList<LeaveAppLogDAO> GetLeave_AppLogDAL(string pram, string Role, string AppStatus,  string FromDt, string ToDt, string EmpId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>(); 
                gSqlParameterList.Add(new SqlParameter("@Role", Role ?? (object)DBNull.Value ?? (object)DBNull.Value));
                pram = NewMethod(pram, Role, gSqlParameterList);
                gSqlParameterList.Add(new SqlParameter("@AppStatus", AppStatus ?? (object)DBNull.Value ?? (object)DBNull.Value));
               
                gSqlParameterList.Add(new SqlParameter("@FromDt", FromDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ToDt", ToDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EmpId", EmpId ?? (object)DBNull.Value ?? (object)DBNull.Value));



                SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_Get_Leave_AppLog", gSqlParameterList);
                List<LeaveAppLogDAO> aList = new List<LeaveAppLogDAO>();

                while (dr.Read())
                {
                    LeaveAppLogDAO aInfo = new LeaveAppLogDAO();

                    if (dr["LeaveApplicationId"] != DBNull.Value)
                    {
                        aInfo.LeaveApplicationId = Convert.ToInt32(dr["LeaveApplicationId"]);
                    }





                    if (dr["EmployeeId"] != DBNull.Value)
                    {
                        aInfo.EmpInfoId = Convert.ToInt32(dr["EmployeeId"].ToString());

                    }


                    if (dr["EmpMasterCode"] != DBNull.Value)
                    {
                        aInfo.EmpMasterCode =  (dr["EmpMasterCode"].ToString());
                    }



                    if (dr["EmpName"] != DBNull.Value)
                    {
                        aInfo.EmpName = (dr["EmpName"].ToString());
                    }



                    if (dr["LeaveFromDate"] != DBNull.Value)
                    {
                        aInfo.LeaveFromDate = (dr["LeaveFromDate"].ToString());
                    }



                    if (dr["LeaveToDate"] != DBNull.Value)
                    {
                        aInfo.LeaveToDate = (dr["LeaveToDate"].ToString());
                    }



                    if (dr["Days"] != DBNull.Value)
                    {
                        aInfo.Days = (dr["Days"].ToString());
                    }

                    if (dr["Reason"] != DBNull.Value)
                    {
                        aInfo.Reason = (dr["Reason"].ToString());
                    }


                    if (dr["DateOfReturnsToDuty"] != DBNull.Value)
                    {
                        aInfo.DateOfReturnsToDuty = (dr["DateOfReturnsToDuty"].ToString());
                    }

                    if (dr["LeaveAddress"] != DBNull.Value)
                    {
                        aInfo.LeaveAddress = (dr["DateOfReturnsToDuty"].ToString());
                    }
                    if (dr["EmergencyContactNo"] != DBNull.Value)
                    {
                        aInfo.EmergencyContactNo = (dr["EmergencyContactNo"].ToString());
                    }

                    if (dr["Remarks"] != DBNull.Value)
                    {
                        aInfo.Remarks = (dr["Remarks"].ToString());
                    }

                    if (dr["ApprovalStatus"] != DBNull.Value)
                    {
                        aInfo.ApprovalStatus = (dr["ApprovalStatus"].ToString());
                    }


                    if (dr["EntryDate"] != DBNull.Value)
                    {
                        aInfo.EntryDate = (dr["EntryDate"].ToString());
                    }

                    if (dr["Status"] != DBNull.Value)
                    {
                        aInfo.Status = dr["Status"].ToString();
                    }
                 

                    if (dr["LeaveApprovalId"] != DBNull.Value)
                    {
                        aInfo.LeaveApprovalId = Convert.ToInt32(dr["LeaveApprovalId"].ToString());
                    }


                    if (dr["Date"] != DBNull.Value)
                    {
                        aInfo.Date = dr["Date"].ToString();
                    }


                    if (dr["FromEmpId"] != DBNull.Value)
                    {
                        aInfo.FromEmpId = Convert.ToInt32(dr["FromEmpId"].ToString());
                    }
                    if (dr["ToEmpId"] != DBNull.Value)
                    {
                        aInfo.ToEmpId = Convert.ToInt32(dr["ToEmpId"].ToString());
                    }


                    if (dr["TableId"] != DBNull.Value)
                    {
                        aInfo.TableId = Convert.ToInt32(dr["TableId"].ToString());
                    }

                    if (dr["Comments"] != DBNull.Value)
                    {
                        aInfo.Comments = dr["Comments"].ToString();
                    }

                    if (dr["Type"] != DBNull.Value)
                    {
                        aInfo.Type = dr["Type"].ToString();
                    }

                    if (dr["Step"] != DBNull.Value)
                    {
                        aInfo.Step = Convert.ToInt32(dr["Step"].ToString());
                    }



                    if (dr["GroupId"] != DBNull.Value)
                    {
                        aInfo.GroupId = Convert.ToInt32(dr["GroupId"].ToString());
                    }

                    if (dr["RegionId"] != DBNull.Value)
                    {
                        aInfo.RegionId = Convert.ToInt32(dr["RegionId"].ToString());
                    }


                    if (dr["AreaId"] != DBNull.Value)
                    {
                        aInfo.AreaId = Convert.ToInt32(dr["AreaId"].ToString());
                    }


                    if (dr["TerritoryId"] != DBNull.Value)
                    {
                        aInfo.TerritoryId = Convert.ToInt32(dr["TerritoryId"].ToString());
                    }


                    if (dr["RoleTypeId"] != DBNull.Value)
                    {
                        aInfo.RoleTypeId = Convert.ToInt32(dr["RoleTypeId"].ToString());
                    }


                    if (dr["EmpMasterCode"] != DBNull.Value)
                    {
                        aInfo.EmpMasterCode = dr["EmpMasterCode"].ToString();
                    }


                    if (dr["EmpName"] != DBNull.Value)
                    {
                        aInfo.EmpName = dr["EmpName"].ToString();
                    }


                    if (dr["TerritoryName"] != DBNull.Value)
                    {
                        aInfo.TerritoryName = dr["TerritoryName"].ToString();
                    }

                    if (dr["TerritoryCode"] != DBNull.Value)
                    {
                        aInfo.TerritoryCode = dr["TerritoryCode"].ToString();
                    }

                    if (dr["AreaCode"] != DBNull.Value)
                    {
                        aInfo.AreaCode = dr["AreaCode"].ToString();
                    }

                     
                    if (dr["ToRoleTypeId"] != DBNull.Value)
                    {
                        aInfo.ToRoleTypeId = Convert.ToInt32(dr["ToRoleTypeId"].ToString());
                    }

                    if (dr["MIOEmpId"] != DBNull.Value)
                    {
                        aInfo.MIOEmpId = Convert.ToInt32(dr["MIOEmpId"].ToString());
                    }

                    if (dr["ASMEMPId"] != DBNull.Value)
                    {
                        aInfo.ASMEMPId = Convert.ToInt32(dr["ASMEMPId"].ToString());
                    }

                    if (dr["RSMEMPId"] != DBNull.Value)
                    {
                        aInfo.RSMEMPId = Convert.ToInt32(dr["RSMEMPId"].ToString());
                    }
                    if (dr["NSMEMPId"] != DBNull.Value)
                    {
                        aInfo.NSMEMPId = Convert.ToInt32(dr["NSMEMPId"].ToString());
                    }




                    string imagefullpath = (dr["ImagePreName"].ToString() + ((int)dr["TableId"]).ToString() + ".jpg");


                    try
                    {
                        byte[] imageArray = System.IO.File.ReadAllBytes(@imagefullpath);
                        aInfo.ImageString = Convert.ToBase64String(imageArray);
                        aInfo.ImagePreName = imagefullpath;

                    }
                    catch (Exception ex)
                    {
                    }
                        aList.Add(aInfo);

                }
                return aList;
                //DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_AttendanceInformation", gSqlParameterList);
                //return dt;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }

        }

        public ResultInfo SaveLeave_AppLog(LeaveApplo_Save atten)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@LeaveApprovalId", atten.LeaveApprovalId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Date", atten.Date ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@FromEmpId", atten.FromEmpId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ToEmpId", atten.ToEmpId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@TableId", atten.TableId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Status", atten.Status ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Comments", atten.Comments ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Type", atten.Type ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Step", atten.Step ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@GroupId", atten.GroupId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@RegionId", atten.RegionId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@AreaId", atten.AreaId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@TerritoryId", atten.TerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@ToGroupId", atten.ToGroupId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ToRegionId", atten.ToRegionId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ToAreaId", atten.ToAreaId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ToTerritoryId", atten.ToTerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@EntryByS", atten.EntryByS ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EntryDateS", atten.EntryDateS ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EntryTimeS", atten.EntryTimeS ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ApproveByS", atten.ApproveByS ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ApproveDateS", atten.ApproveDateS ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ApproveTimeS", atten.ApproveTimeS ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@EntryByApp", atten.EntryByApp ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EntryDateApp", atten.EntryDateApp ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EntryTimeApp", atten.EntryTimeApp ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ApproveByApp", atten.ApproveByApp ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ApproveDateApp", atten.ApproveDateApp ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ApproveTimeApp", atten.ApproveTimeApp ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@MenuId", atten.MenuId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                aInformation.isSuccess = accessManager.SaveData("sp_webapi_SaveLeaveAppLog", gSqlParameterList);

            }
            catch (Exception exception)
            {
                accessManager.SqlConnectionClose(true);
                aInformation.isSuccess = false;
                aInformation.ErrorMessage = exception.Message;

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }

            return aInformation;
        }

    }
}