using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SalesSolutionWebAPI.Repository
{
    public class ProductDAL : iProduct
    {
        private DataAccessManager accessManager = new DataAccessManager();

        public void AddProduct(mProduct aProduct)
        {
            throw new NotImplementedException();
        }

        public IList<mProduct> GetAllProducts(int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                aSqlParameterList.Add(new SqlParameter("@empId", empId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_webapi_GetAllProducts", aSqlParameterList);
                List<mProduct> aList = new List<mProduct>();

                while (dr.Read())
                {
                    mProduct aInfo = new mProduct();

                    if (dr["ProductId"] != DBNull.Value)
                    {
                        aInfo.ProductId = Convert.ToInt32(dr["ProductId"]);
                    }
                    if (dr["ProductCode"] != DBNull.Value)
                    {
                        aInfo.ProductCode = dr["ProductCode"].ToString();
                    }
                    if (dr["ProductName"] != DBNull.Value)
                    {
                        aInfo.ProductName = dr["ProductName"].ToString();

                    }
                    if (dr["Description"] != DBNull.Value)
                    {
                        aInfo.ProductDes = dr["Description"].ToString();
                    }
                    if (dr["PackSize"] != DBNull.Value)
                    {
                        aInfo.PackSize = dr["PackSize"].ToString();
                    }

                    aInfo.UnitPrice = Convert.ToDecimal(dr["UnitPrice"]);
                    aInfo.VatPercentage = Convert.ToDecimal(dr["VATPercentage"]);
                    aInfo.VatAmountPerunit = Convert.ToDecimal(dr["VATAmountPerUnit"]);

                    aInfo.QuotedPrice = Convert.ToDecimal(dr["QuotedPrice"]);
                    aInfo.CustomerMasterId = (int)(dr["CustomerMasterId"]);
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

        public IList<mProduct> GetSampleProduct(int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                aSqlParameterList.Add(new SqlParameter("@empId", empId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_webapi_GetAllSampleProducts", aSqlParameterList);
                List<mProduct> aList = new List<mProduct>();

                while (dr.Read())
                {
                    mProduct aInfo = new mProduct();

                    if (dr["ProductId"] != DBNull.Value)
                    {
                        aInfo.ProductId = Convert.ToInt32(dr["ProductId"]);
                    }
                    if (dr["ProductCode"] != DBNull.Value)
                    {
                        aInfo.ProductCode = dr["ProductCode"].ToString();
                    }
                    if (dr["ProductName"] != DBNull.Value)
                    {
                        aInfo.ProductName = dr["ProductName"].ToString();

                    }
                    if (dr["Description"] != DBNull.Value)
                    {
                        aInfo.ProductDes = dr["Description"].ToString();
                    }
                    if (dr["PackSize"] != DBNull.Value)
                    {
                        aInfo.PackSize = dr["PackSize"].ToString();
                    }

                    aInfo.UnitPrice = Convert.ToDecimal(dr["UnitPrice"]);
                    aInfo.VatPercentage = Convert.ToDecimal(dr["VATPercentage"]);
                    aInfo.VatAmountPerunit = Convert.ToDecimal(dr["VATAmountPerUnit"]);

                    aInfo.QuotedPrice = Convert.ToDecimal(dr["QuotedPrice"]);
                    aInfo.CustomerMasterId = (int)(dr["CustomerMasterId"]);
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
    }
}