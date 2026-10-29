using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Repository
{
    public class CustDemoDAL
    {
        private DataAccessManager accessManager = new DataAccessManager();

        public DataTable GetCustomerOrderList(string customerCode)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@customerCode", customerCode));
                DataTable dt = accessManager.GetDataTable("sp_Get_Order_Info_WebAPI_NEw", aSqlParameterlist);
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


        public OrderMaster GetOrderData(int orderId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                OrderMaster master = new OrderMaster();
                List<SqlParameter> aSqlParameters = new List<SqlParameter>();
                aSqlParameters.Add(new SqlParameter("@orderId", orderId));

                SqlDataReader dr = accessManager.GetSqlDataReader("sp_WebAPI_Get_OrderinfoData_ById", aSqlParameters);

                while (dr.Read())
                {
                    master.OrderId = (int)dr["OrderId"];
                    master.OrderCode = dr["OrderCode"].ToString();
                    master.MIOName = dr["MIOName"].ToString();
                    master.CustomerCode = dr["CustomerCode"].ToString();
                    master.CustomerName = dr["CustomerName"].ToString();
                    master.SubmDate = dr["SubmissionDate"].ToString();
                    master.GrossValue = dr["GrossValue"].ToString();
                    master.IsFromCustomer = dr["IsFromCustomer"].ToString();
                    master.IsPending = (int)(dr["IsPending"]);
                    master.IsConfirm = (int)(dr["IsConfirm"]);
                    master.IsInvoiced = (int)(dr["IsInvoiced"]);
                    master.IsPayment = (int)(dr["IsPayment"]);
                    master.IsDelivered = (int)(dr["IsDelivered"]);
                    master.OrderDetails = GetOrder_details(orderId);

                }

                return master;

            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }


        }


        public List<OrderDetails> GetOrder_details(int orderId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<OrderDetails> aMasters = new List<OrderDetails>();
                List<SqlParameter> aSqlParameters = new List<SqlParameter>();
                aSqlParameters.Add(new SqlParameter("@orderId", orderId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_WebAPi_GetOrderDetails_New", aSqlParameters);

                while (dr.Read())
                {
                    OrderDetails master = new OrderDetails();
                    master.ProductName = dr["ProductName"].ToString();
                    master.Quantity = (int)dr["Quantity"];
                    master.TotalVatAmount = (decimal)dr["TotalVatAmount"];
                    master.NetAmount = (decimal)dr["NetAmount"];
                    master.UnitPrice = (decimal)dr["TotalTradePrice"];


                    aMasters.Add(master);
                }

                return aMasters;

            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }

        public IList<Total_Net_Amount> GetOrderList_ForMIO(int? empId, string FromDate, string ToDate, string AppStatus, string GroupId, string ZoneId, string AreaId, string TerritoryId, string SubTerritoryId, string MarketId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@FromDate", FromDate ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@ToDate", ToDate ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@AppStatus", AppStatus ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@GroupId_", GroupId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@ZoneId_", ZoneId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@AreaId_", AreaId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@TerritoryId", TerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@SubTerritoryId", SubTerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@MarketId", MarketId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_GetOrder_TrackingList", aSqlParameterlist);

                DataTable dtDoctor = accessManager.GetDataTable("sp_Webapi_GetOrder_TrackingListSummary", aSqlParameterlist, true);

              

                List<Total_Net_Amount> aDetailsList = new List<Total_Net_Amount>();
                Total_Net_Amount aDetails;

                if (dtDoctor.Rows[0]["GrossValue"] != DBNull.Value)
                {
                    aDetails = new Total_Net_Amount();
                    aDetails.TotalNetAmount = (dtDoctor.Rows[0]["GrossValue"].ToString());


                    List<Total_Net_Amount> aList = new List<Total_Net_Amount>();


                    List<Order_List> aDetailsListDD = new List<Order_List>();
                    Order_List aChemberDetails;
                    for (var ch = 0; ch < dt.Rows.Count; ch++)

                    {

                        aChemberDetails = new Order_List();
                        if (dt.Rows[ch]["ApprovalStatus"] != DBNull.Value)
                        {
                            aChemberDetails.ApprovalStatus = (dt.Rows[ch]["ApprovalStatus"].ToString());
                        }

                        if (dt.Rows[ch]["GrossValue"] != DBNull.Value)
                        {
                            aChemberDetails.GrossValue = (dt.Rows[ch]["GrossValue"].ToString());
                        }


                        if (dt.Rows[ch]["OrderStatus"] != DBNull.Value)
                        {
                            aChemberDetails.OrderStatus = (dt.Rows[ch]["OrderStatus"].ToString());
                        }


                        if (dt.Rows[ch]["OrderCode"] != DBNull.Value)
                        {
                            aChemberDetails.OrderCode = (dt.Rows[ch]["OrderCode"].ToString());
                        }


                        if (dt.Rows[ch]["CustomerName"] != DBNull.Value)
                        {
                            aChemberDetails.CustomerName = (dt.Rows[ch]["CustomerName"].ToString());
                        }

                        if (dt.Rows[ch]["OrderId"] != DBNull.Value)
                        {
                            aChemberDetails.OrderId = Convert.ToInt32(dt.Rows[ch]["OrderId"].ToString());
                        }


                        if (dt.Rows[ch]["SubmissionDate"] != DBNull.Value)
                        {
                            aChemberDetails.SubmissionDate = (dt.Rows[ch]["SubmissionDate"].ToString());
                        }


                        if (dt.Rows[ch]["OrderType"] != DBNull.Value)
                        {
                            aChemberDetails.OrderType = (dt.Rows[ch]["OrderType"].ToString());
                        }


                        if (dt.Rows[ch]["CreatedBy"] != DBNull.Value)
                        {
                            aChemberDetails.CreatedBy = (dt.Rows[ch]["CreatedBy"].ToString());
                        }


                        if (dt.Rows[ch]["CustomerType"] != DBNull.Value)
                        {
                            aChemberDetails.CustomerType = (dt.Rows[ch]["CustomerType"].ToString());
                        }


                        if (dt.Rows[ch]["CreatedAt"] != DBNull.Value)
                        {
                            aChemberDetails.CreatedAt = (dt.Rows[ch]["CreatedAt"].ToString());
                        }
                        aDetailsListDD.Add(aChemberDetails);
                    }
                    aDetails.Order_Lists = aDetailsListDD;

                    aDetailsList.Add(aDetails);

                }






                return aDetailsList;

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

        //public DataTable GetOrderList_ForMIO(int? empId, string FromDate, string ToDate, string AppStatus, string GroupId, string ZoneId, string AreaId, string TerritoryId, string SubTerritoryId, string MarketId)
        //{
        //    try
        //    {
        //        accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
        //        List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
        //        aSqlParameterlist.Add(new SqlParameter("@empId", empId ?? (object)DBNull.Value ?? (object)DBNull.Value));
        //        aSqlParameterlist.Add(new SqlParameter("@FromDate", FromDate ?? (object)DBNull.Value ?? (object)DBNull.Value));
        //        aSqlParameterlist.Add(new SqlParameter("@ToDate", ToDate ?? (object)DBNull.Value ?? (object)DBNull.Value));
        //        aSqlParameterlist.Add(new SqlParameter("@AppStatus", AppStatus ?? (object)DBNull.Value ?? (object)DBNull.Value));
        //        aSqlParameterlist.Add(new SqlParameter("@GroupId_", GroupId ?? (object)DBNull.Value ?? (object)DBNull.Value));
        //        aSqlParameterlist.Add(new SqlParameter("@ZoneId_", ZoneId ?? (object)DBNull.Value ?? (object)DBNull.Value));
        //        aSqlParameterlist.Add(new SqlParameter("@AreaId_", AreaId ?? (object)DBNull.Value ?? (object)DBNull.Value));
        //        aSqlParameterlist.Add(new SqlParameter("@TerritoryId", TerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));
        //        aSqlParameterlist.Add(new SqlParameter("@SubTerritoryId", SubTerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));
        //        aSqlParameterlist.Add(new SqlParameter("@MarketId", MarketId ?? (object)DBNull.Value ?? (object)DBNull.Value));
        //        DataTable dt = accessManager.GetDataTable("sp_Webapi_GetOrder_TrackingList", aSqlParameterlist);
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



        public ResultInfo ApproveCustomerOrder_ByMio(int orderId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                ResultInfo master = new ResultInfo();
                List<SqlParameter> aSqlParameters = new List<SqlParameter>();
                aSqlParameters.Add(new SqlParameter("@orderId", orderId));
                master.isSuccess = accessManager.UpdateData("sp_Approve_Customer_Order", aSqlParameters);
                return master;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }

        }

        public ResultInfo RejectCustomerOrder_byMio(int orderId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                ResultInfo master = new ResultInfo();
                List<SqlParameter> aSqlParameters = new List<SqlParameter>();
                aSqlParameters.Add(new SqlParameter("@orderId", orderId));
                master.isSuccess = accessManager.UpdateData("sp_Reject_Customer_Order", aSqlParameters);
                return master;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }

        }



        public DataTable Get_AppTopBarData(int empId,DateTime currentDate)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                aSqlParameterlist.Add(new SqlParameter("@currentDate", currentDate));
                DataTable dt = accessManager.GetDataTable("sp_WebAPI_Get_MioDashboardTopBarData_New", aSqlParameterlist);
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


        public DataTable GetEmpAppAttendance(int empId,DateTime fromDate,DateTime toDate)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                aSqlParameterlist.Add(new SqlParameter("@fromDate", fromDate));
                aSqlParameterlist.Add(new SqlParameter("@toDate", toDate));
                DataTable dt = accessManager.GetDataTable("sp_WebAPI_GetAttendanceData_New", aSqlParameterlist);
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




        public DataTable GetOrderList_ForMIO_ByMonthYear(int empId, int month, int year)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                aSqlParameterlist.Add(new SqlParameter("@month", month));
                aSqlParameterlist.Add(new SqlParameter("@year", year));
                DataTable dt = accessManager.GetDataTable("sp_Get_Order_Info_WebAPI_NEw_MIo_ByMonthYear", aSqlParameterlist);
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