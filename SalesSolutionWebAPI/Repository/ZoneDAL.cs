using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Repository
{
    public class ZoneDAL : iZoneSetup
    {
        private DataAccessManager accessManager = new DataAccessManager();

        public DataTable GetZoneList()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.DB_ClickPharma);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Get_ZoneList");
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

        public ResultInfo SaveZoneInfo(Zone zone)
        {

            ResultInfo aInformation = new ResultInfo();
            try
            {

                accessManager.SqlConnectionOpen(DataBase.DB_ClickPharma);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;
                gSqlParameterList.Add(new SqlParameter("@zoneName", zone.ZoneName));
                gSqlParameterList.Add(new SqlParameter("@createdBy", zone.CreatedBy));
                gSqlParameterList.Add(new SqlParameter("@remarks", zone.ActiveReason));
                gSqlParameterList.Add(new SqlParameter("@isActive", zone.IsActive));
                int pk = accessManager.SaveDataReturnPrimaryKey("sp_Save_ZoneInfo", gSqlParameterList);

                if(pk > 0)
                {
                    int[] divisionId = zone.DivisionId.Split(',').Select(Int32.Parse).ToArray();

                    for (int i = 0;i< divisionId.Length; i++)
                    {

                        int divId = divisionId[i];
                        List<SqlParameter> aSQL = new List<SqlParameter>();
                        aSQL.Add(new SqlParameter("@zoneId", pk));
                        aSQL.Add(new SqlParameter("@divisionId", divId));
                        aInformation.isSuccess = accessManager.SaveData("sp_Save_DivisionZoneRelation", aSQL);

                    }


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

        public ResultInfo UpdateActiveStatus(int zoneId,DateTime acDate, string reason, string loginUser,bool isActive)
        {

            ResultInfo aInformation = new ResultInfo();
            try
            {

                accessManager.SqlConnectionOpen(DataBase.DB_ClickPharma);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;
                gSqlParameterList.Add(new SqlParameter("@zoneId", acDate));
                gSqlParameterList.Add(new SqlParameter("@acDate", acDate));
                gSqlParameterList.Add(new SqlParameter("@reason", reason));
                gSqlParameterList.Add(new SqlParameter("@loginUser", loginUser));
                gSqlParameterList.Add(new SqlParameter("@isActive", isActive));
                //aInformation.isSuccess = accessManager.UpdateData("sp_Save_ZoneInfo", gSqlParameterList);

             
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

        public ResultInfo UpdateZoneInfo(Zone zone)
        {
            throw new NotImplementedException();
        }
    }
}