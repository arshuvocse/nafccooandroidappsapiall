using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SalesSolutionWebAPI.Repository
{
    public class UserDAL : iUser
    {
        private DataAccessManager accessManager = new DataAccessManager();
        public void AddUser(User aUser)
        {
            throw new NotImplementedException();
        }

        public User doLogin(string UserName, string password,string Imei, string DeviceToken, string Device, string AppVersion, string OS, string OS_Version)
        {

            User UserInfoList = new User();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);


                //string passwordEncrpt = EncryptDecrypt.EncryptText(password);

                List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                aSqlParameterList.Add(new SqlParameter("@username", UserName));
                aSqlParameterList.Add(new SqlParameter("@password", password));
                aSqlParameterList.Add(new SqlParameter("@Imei", Imei));
                aSqlParameterList.Add(new SqlParameter("@DeviceInfo", Device));
                aSqlParameterList.Add(new SqlParameter("@OS", OS));
       
                aSqlParameterList.Add(new SqlParameter("@OS_Version", OS_Version));
                aSqlParameterList.Add(new SqlParameter("@AppVersion", AppVersion));
                DataTable dr = accessManager.GetDataTable("sp_SalesAPI_doLogin_New", aSqlParameterList);
                //DataTable dt = accessManager.GetDataTable("sp_SalesAPI_doLoginCheckEMI", aSqlParameterList);
                DataTable dtMatch = accessManager.GetDataTable("sp_SalesAPI_doLoginMatch", aSqlParameterList);
              
                    if (dr.Rows.Count > 0)
                {

                    UserInfoList.UserId = (int)dr.Rows[0]["UserId"];
                    UserInfoList.EmpInfoId = (int)dr.Rows[0]["EmpInfoId"];
                    if(dr.Rows[0]["IsImeiMatched"] != DBNull.Value)
                    {
                        UserInfoList.IsImeiMatched = (int)dr.Rows[0]["IsImeiMatched"];

                    }
                    else
                    {
                        UserInfoList.IsImeiMatched = 0;
                    }
         
                    UserInfoList.UserName = dr.Rows[0]["UserName"].ToString();
                    UserInfoList.EmpMasterCode = dr.Rows[0]["EmpMasterCode"].ToString();
                    UserInfoList.LoginName = dr.Rows[0]["LoginName"].ToString();
                    UserInfoList.UserType = dr.Rows[0]["UserType"].ToString();
                    UserInfoList.UserEmail = dr.Rows[0]["Email"].ToString();
                    UserInfoList.ContactInfo = dr.Rows[0]["ContactNo"].ToString();
                    UserInfoList.UserCo = dr.Rows[0]["UserCo"].ToString();
                    UserInfoList.Password = dr.Rows[0]["Password"].ToString();
                    UserInfoList.VersionName = dr.Rows[0]["VersionName"].ToString();
                    UserInfoList.EmpRole = dr.Rows[0]["EmpRole"].ToString();
                    UserInfoList.DesigName = dr.Rows[0]["DesigName"].ToString();


                    if (dr.Rows[0]["RoleTypeId"] != DBNull.Value)
                    {
                        UserInfoList.RoleTypeId = Convert.ToInt32(dr.Rows[0]["RoleTypeId"].ToString());
                    }

                    if (dr.Rows[0]["IsApprove"] != DBNull.Value)
                    {
                        UserInfoList.IsApprove = Convert.ToBoolean(dr.Rows[0]["IsApprove"].ToString());
                    }

                    if (dr.Rows[0]["IsForward"] != DBNull.Value)
                    {
                        UserInfoList.IsForward = Convert.ToBoolean(dr.Rows[0]["IsForward"].ToString());
                    }

                    UserInfoList.RoleType = dr.Rows[0]["RoleType"].ToString();


                    //UserInfoList.ShiftStartTime = dr["ShiftStartTime"].ToString();
                    //UserInfoList.ShiftEndTime = dr["ShiftEndTime"].ToString();
                    //UserInfoList.VersionName = dr["VersionName"].ToString();
                    //UserInfoList.IsTrackEnable = Convert.ToBoolean(dr["TrackEnable"]);


                    List<SqlParameter> gSqlParameterList = new List<SqlParameter>();

                    gSqlParameterList.Add(new SqlParameter("@userName", UserName));
                    gSqlParameterList.Add(new SqlParameter("@password", password));
                    gSqlParameterList.Add(new SqlParameter("@DeviceToken", DeviceToken));
                    gSqlParameterList.Add(new SqlParameter("@Device", Device));


                    int pk = 0;
                    int pk2 = 0;




                    pk = accessManager.SaveDataReturnPrimaryKey("sp_Webapi_Save_UserDeviceToken", gSqlParameterList);



                    List<SqlParameter> gSqlapp = new List<SqlParameter>();

                    gSqlapp.Add(new SqlParameter("@EmpInfoId", UserInfoList.EmpInfoId));
                    gSqlapp.Add(new SqlParameter("@AppVersion", AppVersion));
                    pk2 = accessManager.SaveDataReturnPrimaryKey("sp_Webapi_Save_EmpAppVersion", gSqlapp);



                }

                if (dtMatch.Rows.Count == 0)
                {
                    UserInfoList.TwoDeviceMsg = "";
                }


                
 

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
            //SaveDeviceToken(UserName, password, DeviceToken);
            return UserInfoList;



        }




        public void RemoveUser(string userId)
        {
            throw new NotImplementedException();
        }

        public ResultInfo SaveTracking(UserTracking tracking)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@empId", tracking.EmpInfoId));
                gSqlParameterList.Add(new SqlParameter("@latv", tracking.LatValue));
                gSqlParameterList.Add(new SqlParameter("@longv", tracking.LongValue));
                gSqlParameterList.Add(new SqlParameter("@addressName", tracking.AddressName));
       

                int pk = 0;
                pk = accessManager.SaveDataReturnPrimaryKey("sp_Webapi_Save_UserTracking", gSqlParameterList);
                if (pk > 0)
                {
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



        public ResultInfo SaveDeviceToken(string userName, string password, string DeviceToken, string Device)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB); 
                DateTime entryDtae = DateTime.Now;

                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();

                gSqlParameterList.Add(new SqlParameter("@userName", userName));
                gSqlParameterList.Add(new SqlParameter("@password", password));
                gSqlParameterList.Add(new SqlParameter("@DeviceToken", DeviceToken));


                int pk = 0;


                 
                 
                    pk = accessManager.SaveDataReturnPrimaryKey("sp_Webapi_Save_UserDeviceToken", gSqlParameterList);

                 
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