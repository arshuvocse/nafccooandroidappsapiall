using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using SalesSolutionWebAPI.Repository;
using SalesSolutionWebAPI.Models;
using System.Globalization;
using System.Linq;

namespace SalesSolutionWebAPI.Repository
{
    public class AttendanceDAL : iAttendance
    {
        private DataAccessManager accessManager = new DataAccessManager();

        public IList<AttendanceDAO> GetAttendanceInformation(string pram, string emprole)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@param", pram));
                gSqlParameterList.Add(new SqlParameter("@Role", emprole));


                SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_Get_AttendanceInformation", gSqlParameterList);
                List<AttendanceDAO> aList = new List<AttendanceDAO>();

                while (dr.Read())
                {
                    AttendanceDAO aInfo = new AttendanceDAO();

                    if (dr["AttendanceId"] != DBNull.Value)
                    {
                        aInfo.AttendanceId = Convert.ToInt32(dr["AttendanceId"]);
                    }
                    if (dr["MIOId"] != DBNull.Value)
                    {
                        aInfo.MIOId = Convert.ToInt32(dr["MIOId"].ToString());
                    }
                    if (dr["EmpInfoId"] != DBNull.Value)
                    {
                        aInfo.EmpInfoId = Convert.ToInt32(dr["EmpInfoId"].ToString());

                    }
                    if (dr["PunchInTime"] != DBNull.Value)
                    {
                        aInfo.PunchInTime = dr["PunchInTime"].ToString();
                    }
                    if (dr["PInLat"] != DBNull.Value)
                    {
                        aInfo.PInLat = dr["PInLat"].ToString();
                    }

                    if (dr["PInLog"] != DBNull.Value)
                    {
                        aInfo.PInLog =  (dr["PInLog"].ToString());
                    }



                    if (dr["PunchOutTime"] != DBNull.Value)
                    {
                        aInfo.PunchOutTime = dr["PunchOutTime"].ToString();
                    }





                    if (dr["POutLat"] != DBNull.Value)
                    {
                        aInfo.POutLat = dr["POutLat"].ToString();
                    }


                    if (dr["POutLong"] != DBNull.Value)
                    {
                        aInfo.POutLong = dr["POutLong"].ToString();
                    }

                    if (dr["EntryDate"] != DBNull.Value)
                    {
                        aInfo.EntryDate = dr["EntryDate"].ToString();
                    }



                    if (dr["POutRemarks"] != DBNull.Value)
                    {
                        aInfo.POutRemarks = dr["POutRemarks"].ToString();
                    }
                    if (dr["AttendanceDate"] != DBNull.Value)
                    {
                        aInfo.AttendanceDate = dr["AttendanceDate"].ToString();
                    }
                    if (dr["PINCreatedDateTime"] != DBNull.Value)
                    {
                        aInfo.PINCreatedDateTime = dr["PINCreatedDateTime"].ToString();
                    }
                    if (dr["POUTCreatedDateTime"] != DBNull.Value)
                    {
                        aInfo.POUTCreatedDateTime = dr["POUTCreatedDateTime"].ToString();
                    }
                    if (dr["Status"] != DBNull.Value)
                    {
                        aInfo.Status = dr["Status"].ToString();
                    }
                    if (dr["ShiftId"] != DBNull.Value)
                    {
                        aInfo.ShiftId = Convert.ToInt32(dr["ShiftId"].ToString());
                    }


                    if (dr["ApprovalId"] != DBNull.Value)
                    {
                        aInfo.ShiftId = Convert.ToInt32(dr["ApprovalId"].ToString());
                    }


                    if (dr["Date"] != DBNull.Value)
                    {
                        aInfo.Status = dr["Date"].ToString();
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
                        aInfo.Step = dr["Step"].ToString();
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




                    if (dr["RoleTypeId"] != DBNull.Value)
                    {
                        aInfo.AttType = Convert.ToInt32(dr["AttType"].ToString());
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

                    if (dr["ImageString"] != DBNull.Value)
                    {
                        aInfo.ImageString = dr["ImageString"].ToString();
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

        public IList<AttendanceDAO> GetAttendanceInformation_New(string pram, string Role, string AppStatus, string AttType, string FromDt, string ToDt, string EmpId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                 gSqlParameterList.Add(new SqlParameter("@Role", Role ?? (object)DBNull.Value ?? (object)DBNull.Value));
                pram = NewMethod(pram, Role, gSqlParameterList);

                gSqlParameterList.Add(new SqlParameter("@AppStatus", AppStatus ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@AttType", AttType ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@FromDt", FromDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ToDt", ToDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EmpId", EmpId ?? (object)DBNull.Value ?? (object)DBNull.Value));



                SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_Get_AttendanceInformation2", gSqlParameterList);
                List<AttendanceDAO> aList = new List<AttendanceDAO>();

                while (dr.Read())
                {
                    AttendanceDAO aInfo = new AttendanceDAO();

                    if (dr["AttendanceId"] != DBNull.Value)
                    {
                        aInfo.AttendanceId = Convert.ToInt32(dr["AttendanceId"]);
                    }
                    //if (dr["MIOId"] != DBNull.Value)
                    //{
                    //    aInfo.MIOId = Convert.ToInt32(dr["MIOId"].ToString());
                    //}
                    if (dr["EmpInfoId"] != DBNull.Value)
                    {
                        aInfo.EmpInfoId = Convert.ToInt32(dr["EmpInfoId"].ToString());

                    }
                    if (dr["PunchInTime"] != DBNull.Value)
                    {
                        aInfo.PunchInTime = dr["PunchInTime"].ToString();
                    }
                    if (dr["PInLat"] != DBNull.Value)
                    {
                        aInfo.PInLat = dr["PInLat"].ToString();
                    }

                    if (dr["PInLog"] != DBNull.Value)
                    {
                        aInfo.PInLog = (dr["PInLog"].ToString());
                    }

                    if (dr["ApprovalStatus"] != DBNull.Value)
                    {
                        aInfo.ApprovalStatus = (dr["ApprovalStatus"].ToString());
                    }

                    if (dr["AttAddress"] != DBNull.Value)
                    {
                        aInfo.AttAddress = (dr["AttAddress"].ToString());
                    }

                    //if (dr["PunchOutTime"] != DBNull.Value)
                    //{
                    //    aInfo.PunchOutTime = dr["PunchOutTime"].ToString();
                    //}





                    //if (dr["POutLat"] != DBNull.Value)
                    //{
                    //    aInfo.POutLat = dr["POutLat"].ToString();
                    //}


                    //if (dr["POutLong"] != DBNull.Value)
                    //{
                    //    aInfo.POutLong = dr["POutLong"].ToString();
                    //}

                    //if (dr["EntryDate"] != DBNull.Value)
                    //{
                    //    aInfo.EntryDate = dr["EntryDate"].ToString();
                    //}



                    if (dr["POutRemarks"] != DBNull.Value)
                    {
                        aInfo.POutRemarks = dr["POutRemarks"].ToString();
                    }
                    if (dr["AttendanceDate"] != DBNull.Value)
                    {
                        aInfo.AttendanceDate = dr["AttendanceDate"].ToString();
                    }
                    if (dr["PINCreatedDateTime"] != DBNull.Value)
                    {
                        aInfo.PINCreatedDateTime = dr["PINCreatedDateTime"].ToString();
                    }
                    if (dr["POUTCreatedDateTime"] != DBNull.Value)
                    {
                        aInfo.POUTCreatedDateTime = dr["POUTCreatedDateTime"].ToString();
                    }
                    if (dr["Status"] != DBNull.Value)
                    {
                        aInfo.Status = dr["Status"].ToString();
                    }
                    if (dr["ShiftId"] != DBNull.Value)
                    {
                        aInfo.ShiftId = Convert.ToInt32(dr["ShiftId"].ToString());
                    }


                    if (dr["ApprovalId"] != DBNull.Value)
                    {
                        aInfo.ApprovalId = Convert.ToInt32(dr["ApprovalId"].ToString());
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
                        aInfo.Step = dr["Step"].ToString();
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
                      
                    if (dr["RoleTypeId"] != DBNull.Value)
                    {
                        aInfo.AttType = Convert.ToInt32(dr["AttType"].ToString());
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


                    if (dr["ImageString"] != DBNull.Value)
                    {
                        aInfo.ImageString = dr["ImageString"].ToString();
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

        public ResultInfo SaveAttandaceAppLog(AttendanceLog atten)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;
               
                gSqlParameterList.Add(new SqlParameter("@ApprovalId",  atten.ApprovalId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Date",  atten.Date ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@FromEmpId",  atten.FromEmpId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ToEmpId",  atten.ToEmpId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@TableId",  atten.TableId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Status",  atten.Status ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Comments",  atten.Comments ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Type",  atten.Type ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Step",  atten.Step ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@GroupId",  atten.GroupId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@RegionId",  atten.RegionId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@AreaId",  atten.AreaId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@TerritoryId",  atten.TerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@ToGroupId",  atten.ToGroupId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ToRegionId",  atten.ToRegionId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ToAreaId",  atten.ToAreaId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ToTerritoryId",  atten.ToTerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@EntryByS",  atten.EntryByS ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EntryDateS",  atten.EntryDateS ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EntryTimeS",  atten.EntryTimeS ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ApproveByS",    atten.ApproveByS ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ApproveDateS",  atten.ApproveDateS ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ApproveTimeS",  atten.ApproveTimeS ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@EntryByApp",  atten.EntryByApp ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EntryDateApp",  atten.EntryDateApp ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EntryTimeApp",  atten.EntryTimeApp ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ApproveByApp",  atten.ApproveByApp ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ApproveDateApp",  atten.ApproveDateApp ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ApproveTimeApp",  atten.ApproveTimeApp ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@MenuId",  atten.MenuId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                aInformation.isSuccess = accessManager.SaveData("sp_webapi_SaveAppLog", gSqlParameterList);

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

       

        public ResultInfo SavePunchIn(Attendance atten)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;
                gSqlParameterList.Add(new SqlParameter("@attendaceDate", atten.AttendanceDate));
                gSqlParameterList.Add(new SqlParameter("@pInTime", atten.PunchInTime));
                gSqlParameterList.Add(new SqlParameter("@pInLat", atten.PInLat));
                gSqlParameterList.Add(new SqlParameter("@pInLong", atten.PInLog));
                gSqlParameterList.Add(new SqlParameter("@empId", atten.EmpInfoId));
                gSqlParameterList.Add(new SqlParameter("@EntryDate", entryDtae));
                aInformation.isSuccess = accessManager.SaveData("@sp_webapi_SavePunchInInfo", gSqlParameterList);

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


        public ResultInfo SavePunchIn_PunchOut(Attendance atten)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;
                gSqlParameterList.Add(new SqlParameter("@attendaceDate", atten.AttendanceDate));
                gSqlParameterList.Add(new SqlParameter("@pInTime", atten.PunchInTime));
                gSqlParameterList.Add(new SqlParameter("@pInLat", atten.PInLat));
                gSqlParameterList.Add(new SqlParameter("@pInLong", atten.PInLog));
                 
                gSqlParameterList.Add(new SqlParameter("@remarks", atten.POutRemarks));
                gSqlParameterList.Add(new SqlParameter("@empId", atten.EmpInfoId));
                gSqlParameterList.Add(new SqlParameter("@EntryDate", entryDtae));
                gSqlParameterList.Add(new SqlParameter("@AttType", atten.AttType));
                gSqlParameterList.Add(new SqlParameter("@AttAddress", atten.AttAddress));

                gSqlParameterList.Add(new SqlParameter("@WorkPlace", atten.WorkPlace));
                gSqlParameterList.Add(new SqlParameter("@TourTypeId", atten.TourType));
                gSqlParameterList.Add(new SqlParameter("@WorkSession", atten.WorkSession));



                int pk = 0;

                pk = accessManager.SaveDataReturnPrimaryKey("sp_webapi_SavePunchTotalInfo", gSqlParameterList);
                


                if (pk>0)
                {
                     
                        try
                        {
                            AppPrimaryDAL app = new AppPrimaryDAL();
                            ImagePath _path = new ImagePath();
                            string type = "Attendance";
                            _path = app.GetImagePath(type);



                            string targetPath = @"" + _path.ImagePathValue + "";


                            if (!System.IO.Directory.Exists(targetPath))
                            {
                                System.IO.Directory.CreateDirectory(targetPath);
                            }

                            string filePath = targetPath + "/" + _path.ImagePreName + pk + "." + "jpg";
                            File.WriteAllBytes(filePath, Convert.FromBase64String(atten.AttImg));
                        }
                        catch(Exception ex) { }
                    
                    if (atten.AttType == 1)
                    {
                        TimeSpan timespan;
                        TimeSpan? shiftTime = null;
                        List<SqlParameter> gSqlPunch = new List<SqlParameter>();
                        gSqlPunch.Add(new SqlParameter("@empId", atten.EmpInfoId));
                        gSqlPunch.Add(new SqlParameter("@AttType", atten.AttType));
                        gSqlPunch.Add(new SqlParameter("@pInTime", atten.PunchInTime));
                        gSqlPunch.Add(new SqlParameter("@WorkSession", atten.WorkSession));

                        try
                        {
                            DataTable dtPunch = accessManager.GetDataTable("sp_Webapi_Get_PunchInOutStatus", gSqlPunch);
                            if (dtPunch.Rows.Count > 0)
                            {
                                if (dtPunch.Rows[0]["TextField"] != DBNull.Value)
                                {
                                    aInformation.Msd = "Your punch in successful.  You are " + dtPunch.Rows[0]["TextField"]+".";
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            aInformation.Msd = "Your punch in successful.  You are Early IN." ;
                            aInformation.isSuccess = true;
                        }
                        //timespan = shiftTime - atten.AttType;

             //           DateTime dt1 = DateTime.ParseExact(dtPunch.Rows[0]["ShiftInTime"].ToString(), "HH:mm:ss", new DateTimeFormatInfo());
                        //DateTime dt2 = DateTime.ParseExact(atten.AttendanceDate.ToString(), "HH:mm:ss", new DateTimeFormatInfo());
                        //TimeSpan ts = dt1.Subtract(dt2);
                    }
                    if (atten.AttType ==2)
                    {
                        List<SqlParameter> gSqlPunch = new List<SqlParameter>();
                        gSqlPunch.Add(new SqlParameter("@empId", atten.EmpInfoId));
                        gSqlPunch.Add(new SqlParameter("@AttType", atten.AttType));
                        gSqlPunch.Add(new SqlParameter("@pInTime", atten.PunchInTime));

                        gSqlPunch.Add(new SqlParameter("@WorkSession", atten.WorkSession));
                        try
                        {
                            DataTable dtPunch = accessManager.GetDataTable("sp_Webapi_Get_PunchInOutStatus", gSqlPunch);
                            if (dtPunch.Rows.Count > 0)
                            {
                                if (dtPunch.Rows[0]["TextField"] != DBNull.Value)
                                {
                                    aInformation.Msd = "Your punch out successful.  You are " + dtPunch.Rows[0]["TextField"] + ".";
                                }
                            }
                        }
                        catch (Exception ex)
            {
                aInformation.Msd = "Your punch out successful.  You are Early OUT.";

            }

        }


                    aInformation.isSuccess = true;
                   

                    
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
        public ResultInfoNew GetInOutInfo(int EmpInfoId, string WorkSession)
        {
            ResultInfoNew aInformation = new ResultInfoNew();
            try
            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);




                List<SqlParameter> gsql = new List<SqlParameter>();

                gsql.Add(new SqlParameter("@empId", EmpInfoId));
                gsql.Add(new SqlParameter("@WorkSession", WorkSession));
               
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_AttendanceInfo", gsql);

                if (dt.Rows.Count > 0)
                {
                    aInformation.PunchInBtn = (dt.Rows[0]["PunchInBtn"].ToString());
                    aInformation.PunchOUTBtn = (dt.Rows[0]["PunchOUTBtn"].ToString());

                }
                else
                {
                    aInformation.PunchInBtn = "ON";
                    aInformation.PunchOUTBtn = "OFF";
                }





            }
            catch (Exception exception)
            {
                accessManager.SqlConnectionClose(true);

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }

            return aInformation;
        }

        public DataTable GetAttandenceReport(string empId, string Month, string Year)
        {



            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                aSqlParameterlist.Add(new SqlParameter("@Month", Month));
                aSqlParameterlist.Add(new SqlParameter("@Year", Year));

                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_AttendanceInfoRPT", aSqlParameterlist);
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

        //public IList<AttendanceRpt> GetAttandenceReport(string empId, string Month, string Year)
        //{



        //    try
        //    {
        //        accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
        //        List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
        //        aSqlParameterlist.Add(new SqlParameter("@empId", empId));
        //        aSqlParameterlist.Add(new SqlParameter("@Month", Month));
        //        aSqlParameterlist.Add(new SqlParameter("@Year", Year));

        //        DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_AttendanceInfoRPT", aSqlParameterlist);
        //        List<AttendanceRpt> aList = new List<AttendanceRpt>();
        //        for (var i = 0; i < dt.Rows.Count; i++)

        //        {
        //            AttendanceRpt aInfo = new AttendanceRpt();




        //            if (dt.Rows[i]["AttendanceDate"] != DBNull.Value)
        //            {
        //                aInfo.AttendanceDate = (dt.Rows[i]["AttendanceDate"].ToString());
        //            }

        //            if (dt.Rows[i]["Territory"] != DBNull.Value)
        //            {
        //                aInfo.Territory = (dt.Rows[i]["Territory"].ToString());
        //            }
        //            if (dt.Rows[i]["WorkSession"] != DBNull.Value)
        //            {
        //                aInfo.WorkSession = (dt.Rows[i]["WorkSession"].ToString());
        //            }
        //            if (dt.Rows[i]["MP_TourType"] != DBNull.Value)
        //            {
        //                aInfo.MP_TourType = (dt.Rows[i]["MP_TourType"].ToString());
        //            }

        //            if (dt.Rows[i]["MP_ReportingPlace"] != DBNull.Value)
        //            {
        //                aInfo.MP_ReportingPlace = (dt.Rows[i]["MP_ReportingPlace"].ToString());
        //            }




        //            if (dt.Rows[i]["MP_GeoStamp"] != DBNull.Value)
        //            {
        //                aInfo.MP_GeoStamp = (dt.Rows[i]["MP_GeoStamp"].ToString());
        //            }








        //            if (dt.Rows[i]["MP_GeoCode"] != DBNull.Value)
        //            {
        //                aInfo.MP_GeoCode = (dt.Rows[i]["MP_GeoCode"].ToString());
        //            }




        //            if (dt.Rows[i]["MP_GeoAddress"] != DBNull.Value)
        //            {
        //                aInfo.MP_GeoAddress = (dt.Rows[i]["MP_GeoAddress"].ToString());
        //            }




        //            if (dt.Rows[i]["MO_TourType"] != DBNull.Value)
        //            {
        //                aInfo.MO_TourType = (dt.Rows[i]["MO_TourType"].ToString());
        //            }

        //            if (dt.Rows[i]["MO_ReportingPlace"] != DBNull.Value)
        //            {
        //                aInfo.MO_ReportingPlace = (dt.Rows[i]["MO_ReportingPlace"].ToString());
        //            }




        //            if (dt.Rows[i]["MO_GeoStamp"] != DBNull.Value)
        //            {
        //                aInfo.MO_GeoStamp = (dt.Rows[i]["MO_GeoStamp"].ToString());
        //            }








        //            if (dt.Rows[i]["MO_GeoCode"] != DBNull.Value)
        //            {
        //                aInfo.MO_GeoCode = (dt.Rows[i]["MO_GeoCode"].ToString());
        //            }




        //            if (dt.Rows[i]["MO_GeoAddress"] != DBNull.Value)
        //            {
        //                aInfo.MO_GeoAddress = (dt.Rows[i]["MO_GeoAddress"].ToString());
        //            }



        //            ////
        //            ///

        //            if (dt.Rows[i]["E_WorkSession"] != DBNull.Value)
        //            {
        //                aInfo.E_WorkSession = (dt.Rows[i]["E_WorkSession"].ToString());
        //            }
        //            if (dt.Rows[i]["EP_TourType"] != DBNull.Value)
        //            {
        //                aInfo.EP_TourType = (dt.Rows[i]["EP_TourType"].ToString());
        //            }

        //            if (dt.Rows[i]["EP_ReportingPlace"] != DBNull.Value)
        //            {
        //                aInfo.EP_ReportingPlace = (dt.Rows[i]["EP_ReportingPlace"].ToString());
        //            }




        //            if (dt.Rows[i]["EP_GeoStamp"] != DBNull.Value)
        //            {
        //                aInfo.EP_GeoStamp = (dt.Rows[i]["EP_GeoStamp"].ToString());
        //            }








        //            if (dt.Rows[i]["EP_GeoCode"] != DBNull.Value)
        //            {
        //                aInfo.EP_GeoCode = (dt.Rows[i]["EP_GeoCode"].ToString());
        //            }




        //            if (dt.Rows[i]["EP_GeoAddress"] != DBNull.Value)
        //            {
        //                aInfo.EP_GeoAddress = (dt.Rows[i]["EP_GeoAddress"].ToString());
        //            }




        //            if (dt.Rows[i]["EO_TourType"] != DBNull.Value)
        //            {
        //                aInfo.EO_TourType = (dt.Rows[i]["EO_TourType"].ToString());
        //            }

        //            if (dt.Rows[i]["EO_ReportingPlace"] != DBNull.Value)
        //            {
        //                aInfo.EO_ReportingPlace = (dt.Rows[i]["EO_ReportingPlace"].ToString());
        //            }




        //            if (dt.Rows[i]["EO_GeoStamp"] != DBNull.Value)
        //            {
        //                aInfo.EO_GeoStamp = (dt.Rows[i]["EO_GeoStamp"].ToString());
        //            }








        //            if (dt.Rows[i]["EO_GeoCode"] != DBNull.Value)
        //            {
        //                aInfo.EO_GeoCode = (dt.Rows[i]["EO_GeoCode"].ToString());
        //            }




        //            if (dt.Rows[i]["EO_GeoAddress"] != DBNull.Value)
        //            {
        //                aInfo.EO_GeoAddress = (dt.Rows[i]["EO_GeoAddress"].ToString());
        //            }


        //            if (dt.Rows[i]["MP_Status"] != DBNull.Value)
        //            {
        //                aInfo.MP_Status = (dt.Rows[i]["MP_Status"].ToString());
        //            }


        //            if (dt.Rows[i]["MO_Status"] != DBNull.Value)
        //            {
        //                aInfo.MO_Status = (dt.Rows[i]["MO_Status"].ToString());
        //            }


        //            if (dt.Rows[i]["EP_Status"] != DBNull.Value)
        //            {
        //                aInfo.EP_Status = (dt.Rows[i]["EP_Status"].ToString());
        //            }


        //            if (dt.Rows[i]["EO_Status"] != DBNull.Value)
        //            {
        //                aInfo.EO_Status = (dt.Rows[i]["EO_Status"].ToString());
        //            }



        //            aList.Add(aInfo);
        //        }
        //        return aList;

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


        //public ResultInfo SavePunchOut(Attendance atten)
        //{
        //    ResultInfo aInformation = new ResultInfo();
        //    try
        //    {

        //        accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
        //        List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
        //        DateTime entryDtae = DateTime.Now;
        //        gSqlParameterList.Add(new SqlParameter("@attendaceDate", atten.AttendanceDate));
        //        gSqlParameterList.Add(new SqlParameter("@pOutTime", atten.PunchOutTime));
        //        gSqlParameterList.Add(new SqlParameter("@pOutLat", atten.POutLat));
        //        gSqlParameterList.Add(new SqlParameter("@pOutLong", atten.POutLong));
        //        gSqlParameterList.Add(new SqlParameter("@remarks", atten.POutRemarks));
        //        gSqlParameterList.Add(new SqlParameter("@empId", atten.EmpInfoId));
        //        gSqlParameterList.Add(new SqlParameter("@EntryDate", entryDtae));

        //        aInformation.isSuccess = accessManager.SaveData("@sp_webapi_SavePunchoutInfo", gSqlParameterList);

        //    }
        //    catch (Exception exception)
        //    {
        //        accessManager.SqlConnectionClose(true);
        //        aInformation.isSuccess = false;
        //        aInformation.ErrorMessage = exception.Message;

        //        throw exception;
        //    }
        //    finally
        //    {
        //        accessManager.SqlConnectionClose();
        //    }

        //    return aInformation;

        //}

    }
}