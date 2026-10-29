using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SalesSolutionWebAPI.Repository
{
    public class StructureSyncDal:iFieldForceMarket
    {
        private DataAccessManager accessManager = new DataAccessManager();

        public DataTable GetFieldForceMarket(string empId, string emprole)
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@EmpRole", emprole ));
                gSqlParameterList.Add(new SqlParameter("@EmpMasterCode", empId));
                DataTable dt = accessManager.GetDataTable("sp_SalesAPI_FieldForceMarket", gSqlParameterList);
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




        public DataTable GetEmpTeamList(string role, string id, string  aparam)
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@role", role));
                gSqlParameterList.Add(new SqlParameter("@id", id));
                if (aparam == null)
                {
                    gSqlParameterList.Add(new SqlParameter("@aparam", string.Empty));

                }
                else
                {
                    gSqlParameterList.Add(new SqlParameter("@aparam", aparam));

                }
                DataTable dt = accessManager.GetDataTable("sp_Webapi_GetTeamList", gSqlParameterList);
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

        public DataTable GetFieldForceSubTerritory(string empId, string emprole)
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@EmpRole", emprole));
                gSqlParameterList.Add(new SqlParameter("@EmpMasterCode", empId));
                DataTable dt = accessManager.GetDataTable("sp_SalesAPI_FieldForceSubTerritory", gSqlParameterList);
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

        public DataTable GetFieldForceTerritory(string empId, string emprole)
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@EmpRole", emprole ));
                gSqlParameterList.Add(new SqlParameter("@EmpMasterCode", empId));
                DataTable dt = accessManager.GetDataTable("sp_SalesAPI_FieldForceTerritory", gSqlParameterList);
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

        public DataTable GetFieldForceArea(string empId, string emprole)
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@EmpRole", emprole));
                gSqlParameterList.Add(new SqlParameter("@EmpMasterCode", empId));
                DataTable dt = accessManager.GetDataTable("sp_SalesAPI_FieldForceArea", gSqlParameterList);
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


        public DataTable GetFieldForceRegion(string empId, string emprole)
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@EmpRole", emprole));
                gSqlParameterList.Add(new SqlParameter("@EmpMasterCode", empId));
                DataTable dt = accessManager.GetDataTable("sp_SalesAPI_FieldForceRegion", gSqlParameterList);
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

        public DataTable GetFieldForceGroup(string empId, string emprole)
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@EmpRole", emprole));
                gSqlParameterList.Add(new SqlParameter("@EmpMasterCode", empId));
                DataTable dt = accessManager.GetDataTable("sp_SalesAPI_FieldForceGroup", gSqlParameterList);
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
        
        public DataTable GetFieldForceMio(string empId, string emprole)
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@EmpRole", emprole));
                gSqlParameterList.Add(new SqlParameter("@EmpMasterCode", empId));
                DataTable dt = accessManager.GetDataTable("sp_SalesAPI_FieldForceMio", gSqlParameterList);
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

        public DataTable GetFieldForceMBE(string empId, string emprole)
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@EmpRole", emprole));
                gSqlParameterList.Add(new SqlParameter("@EmpMasterCode", empId));
                DataTable dt = accessManager.GetDataTable("sp_SalesAPI_FieldForceMBE", gSqlParameterList);
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
        public DataTable GetFieldForceAsm(string empId, string emprole)
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@EmpRole", emprole));
                gSqlParameterList.Add(new SqlParameter("@EmpMasterCode", empId));
                DataTable dt = accessManager.GetDataTable("sp_SalesAPI_FieldForceAsm", gSqlParameterList);
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

        public DataTable GetFieldForceRsm(string empId, string emprole)
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@EmpRole", emprole));
                gSqlParameterList.Add(new SqlParameter("@EmpMasterCode", empId));
                DataTable dt = accessManager.GetDataTable("sp_SalesAPI_FieldForceRsm", gSqlParameterList);
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

        public DataTable GetFieldForceNsm(string empId, string emprole)
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@EmpRole", emprole));
                gSqlParameterList.Add(new SqlParameter("@EmpMasterCode", empId));
                DataTable dt = accessManager.GetDataTable("sp_SalesAPI_FieldForceNsm", gSqlParameterList);
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


        public ResultInfo SaveLastSynchronizationInfo(SynchronizationInfoDAO _aDao)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                DateTime entryDtae = DateTime.Now;


                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@EmpInfoId", _aDao.EmpInfoId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                

                aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_SynchronizationInfo", gSqlParameterList);








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