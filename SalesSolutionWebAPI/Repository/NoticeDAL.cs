using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SalesSolutionWebAPI.Repository
{
    public class NoticeDAL : iNotice
    {
        private DataAccessManager accessManager = new DataAccessManager();

        public IList<Notice> GetNotices(int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                aSqlParameterList.Add(new SqlParameter("@empId", empId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_webapi_GetmarketNotice_ByEmpId", aSqlParameterList);
                List<Notice> aList = new List<Notice>();

                while (dr.Read())
                {
                    Notice aInfo = new Notice();

                    if (dr["NoticeId"] != DBNull.Value)
                    {
                        aInfo.NoticeId = Convert.ToInt32(dr["NoticeId"]);
                    }
                    if (dr["NoticeTitle"] != DBNull.Value)
                    {
                        aInfo.NoticeTitle = dr["NoticeTitle"].ToString();
                    }

                    if (dr["CreatedBy"] != DBNull.Value)
                    {
                        aInfo.CreatedBy = dr["CreatedBy"].ToString();
                    }

                    if (dr["Announcement"] != DBNull.Value)
                    {
                        aInfo.Announcement = dr["Announcement"].ToString();

                    }
                    if (dr["FromDate"] != DBNull.Value)
                    {
                        aInfo.FromDate = dr["FromDate"].ToString();
                    }
                    if (dr["ToDate"] != DBNull.Value)
                    {
                        aInfo.ToDate = dr["ToDate"].ToString();
                    }

                    if (dr["IsAppCheck"] != DBNull.Value)
                    {
                        aInfo.IsAppCheck = Convert.ToBoolean(dr["IsAppCheck"].ToString());
                    }
                    string imagefullpath = (dr["ImagePreName"].ToString() + ((int)dr["NoticeId"]).ToString() + ".jpg");


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

            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                accessManager.SqlConnectionClose();
            }


        }



        public ResultInfo UpdateNoticeBoardReadByEmpIdDAL(int id, int EmpId, string AppSeenDate)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@id", id));
                gSqlParameterList.Add(new SqlParameter("@EmployeeId", EmpId));
                gSqlParameterList.Add(new SqlParameter("@Apps_SeenDate", AppSeenDate));
                aInformation.isSuccess = accessManager.DeleteData("sp_Webapi_UpdateNotice_EmployeeReadByEmpIdMasterId", gSqlParameterList);
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