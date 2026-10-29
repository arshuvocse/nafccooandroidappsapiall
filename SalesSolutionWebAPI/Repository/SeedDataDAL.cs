using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SalesSolutionWebAPI.Repository
{
    public class SeedDataDAL
    {
        private DataAccessManager accessManager = new DataAccessManager();
        public DataTable GetDivisions_All()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DivisionAll");
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


        public DataTable GetChemistCallReason()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_ChemistCallReason");
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
        public DataTable GetDistrict()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
              
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_District");
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
        public DataTable GetThana()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
              

                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_Thana");
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
        public DataTable GetPracticeShift()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();


                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_PracticeShift");
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
        public DataTable GetGender()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();


                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_Gender");
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


        public DataTable GetDayName()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();


                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DayName");
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

        public DataTable GetWorkType()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();


                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_WorkType");
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
        public DataTable DeliveryDayName()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();


                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DeliveryDayName");
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

        public DataTable GetPatientPriority()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();


                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_PatientPriority");
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


        public DataTable GetStation()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_Sation");
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
        public PotentialStatusDao GetPotentialStatus(string NoofPatient, string NoofRX)
        {
            PotentialStatusDao aInformation = new PotentialStatusDao();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@NoofPatient", NoofPatient ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@NoofRX", NoofRX ?? (object)DBNull.Value ?? (object)DBNull.Value));

                DataTable dt = accessManager.GetDataTable("sp_Webapi_GetPotentialStatus", aSqlParameterlist);
                if (dt.Rows.Count > 0)
                {
                    aInformation.PotentialStatus = dt.Rows[0]["PotentialStatus"].ToString();
                    aInformation.Color = dt.Rows[0]["Color"].ToString();

                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
            return aInformation;

        }


        public DataTable GetDCStoreStockList(string CustomerMasterId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();

                aSqlParameterlist.Add(new SqlParameter("@CustomerMasterId", CustomerMasterId));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_GetDCStoreStockList", aSqlParameterlist);
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
    }
}