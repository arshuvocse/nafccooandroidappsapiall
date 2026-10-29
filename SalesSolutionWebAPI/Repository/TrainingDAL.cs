using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SalesSolutionWebAPI.Repository
{
    public class TrainingDAL : iTraining
    {
        private DataAccessManager accessManager = new DataAccessManager();

        public IList<TrainingDAO> GetTraining(int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                aSqlParameterList.Add(new SqlParameter("@empId", empId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_webapi_GetTraning_ByEmpId", aSqlParameterList);
                List<TrainingDAO> aList = new List<TrainingDAO>();

                while (dr.Read())
                {
                    TrainingDAO aInfo = new TrainingDAO();

                    if (dr["TrainningId"] != DBNull.Value)
                    {
                        aInfo.TrainningId = Convert.ToInt32(dr["TrainningId"]);
                    }
                    if (dr["Title"] != DBNull.Value)
                    {
                        aInfo.Title = dr["Title"].ToString();
                    }
                    if (dr["Description"] != DBNull.Value)
                    {
                        aInfo.Description = dr["Description"].ToString();

                    }

                    if (dr["TrainningMeterial"] != DBNull.Value)
                    {
                        aInfo.TrainningMeterial = dr["TrainningMeterial"].ToString();

                    }
                    if (dr["FromDate"] != DBNull.Value)
                    {
                        aInfo.FromDate = dr["FromDate"].ToString();
                    }
                    if (dr["CreateAt"] != DBNull.Value)
                    {
                        aInfo.CreateAt = dr["CreateAt"].ToString();
                    }

                    if (dr["CreatedBy"] != DBNull.Value)
                    {
                        aInfo.CreatedBy = dr["CreatedBy"].ToString();
                    }

                    if (dr["IsAppCheck"] != DBNull.Value)
                    {
                        aInfo.IsAppCheck = Convert.ToBoolean(dr["IsAppCheck"].ToString());
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



        public ResultInfo UpdateTrainingReadByEmpIdDAL(int id, int EmpId)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@id", id));
                gSqlParameterList.Add(new SqlParameter("@EmployeeId", EmpId));
                aInformation.isSuccess = accessManager.DeleteData("sp_Webapi_UpdateTraining_EmployeeReadByEmpIdMasterId", gSqlParameterList);
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