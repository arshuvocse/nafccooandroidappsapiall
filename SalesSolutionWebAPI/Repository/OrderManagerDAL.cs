using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SalesSolutionWebAPI.Repository
{
    public class OrderManagerDAL : iOrderManagement
    {
        private DataAccessManager accessManager = new DataAccessManager();
        private TourPlanDAL aTourPlanDAL = new TourPlanDAL();

        public void DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyUnit> GetCompanyUnitListByEmpId(int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                aSqlParameterList.Add(new SqlParameter("@empId", empId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_webapi_GetCompanyUnitByEmp", aSqlParameterList);
                List<CompanyUnit> aList = new List<CompanyUnit>();
                while (dr.Read())
                {
                    CompanyUnit aInfo = new CompanyUnit();
                    if (dr["ComUnitId"] != DBNull.Value)
                    {
                        aInfo.ComUnitId = Convert.ToInt32(dr["ComUnitId"]);
                    }
                    if (dr["ComUnitName"] != DBNull.Value)
                    {
                        aInfo.ComUnitName = dr["ComUnitName"].ToString();
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

        public IList<OrderMaster> GetOrderList(string userid)
        {
            throw new NotImplementedException();
        }

        public ResultInfo MakeOrder(OrderMaster aOrder)
        {


            ResultInfo aInformation = new ResultInfo();
            try

            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();

                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@empId", aOrder.EmpId));
                gSqlParameterList.Add(new SqlParameter("@comUnitId", aOrder.ComunitId));
                gSqlParameterList.Add(new SqlParameter("@CustomerCode", aOrder.CustomerCode));
                gSqlParameterList.Add(new SqlParameter("@SubmittedDate", aOrder.SubmittedDate));
                gSqlParameterList.Add(new SqlParameter("@CollectionDate", aOrder.CollectionDate));
                gSqlParameterList.Add(new SqlParameter("@EntryDate", entryDtae));
                gSqlParameterList.Add(new SqlParameter("@Remarks", aOrder.Remarks));
                gSqlParameterList.Add(new SqlParameter("@orderType", aOrder.OrderType));
                int pk = 0;

                pk = accessManager.SaveDataReturnPrimaryKey("sp_webapi_SaveOrderMaster", gSqlParameterList);

                if (pk > 0)
                {
                    aInformation.isSuccess = true;

                }
                foreach (OrderDetails item in aOrder.OrderDetails)
                {
                    List<SqlParameter> aSqlParameterList = new List<SqlParameter>();

                    aSqlParameterList.Add(new SqlParameter("@orderid", pk));
                    aSqlParameterList.Add(new SqlParameter("@productid", item.ProductId));
                    aSqlParameterList.Add(new SqlParameter("@quantity", item.Quantity));
                    aSqlParameterList.Add(new SqlParameter("@unitprice", item.UnitPrice));
                    aSqlParameterList.Add(new SqlParameter("@unitvatPercentage", item.VatPercentage));

                    aSqlParameterList.Add(new SqlParameter("@IsGiftProduct", item.IsGiftProduct));
                    aSqlParameterList.Add(new SqlParameter("@IsCampaignProduct", item.IsCampaignProduct));
                    aSqlParameterList.Add(new SqlParameter("@DiscountPercentage", item.DiscountPercentage));
                    aSqlParameterList.Add(new SqlParameter("@CampaingName", item.CampaingName));
                    aSqlParameterList.Add(new SqlParameter("@CampaignType", item.CampaignType));
                    aSqlParameterList.Add(new SqlParameter("@DiscountValue", item.DiscountValue));
                    bool result = accessManager.SaveData("sp_webapi_SaveOrderDetail", aSqlParameterList);

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


        public ResultInfo SaveDoctorrequirement(SaveDoctorrequirementMasterDAO aOrder)
        {


            ResultInfo aInformation = new ResultInfo();
            try

            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();

                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@empId", aOrder.EmpId));
                gSqlParameterList.Add(new SqlParameter("@DoctorId", aOrder.DoctorId));


                gSqlParameterList.Add(new SqlParameter("@SubmittedDate", aOrder.SubmittedDate));
                gSqlParameterList.Add(new SqlParameter("@CollectionDate", aOrder.CollectionDate));
                gSqlParameterList.Add(new SqlParameter("@EntryDate", entryDtae));
                gSqlParameterList.Add(new SqlParameter("@Remarks", aOrder.Remarks));
               
                int pk = 0;

                pk = accessManager.SaveDataReturnPrimaryKey("sp_webapi_SaveOrderMaster_Doctor", gSqlParameterList);

                if (pk > 0)
                {
                    aInformation.isSuccess = true;

                }
                foreach (SaveDoctorrequirementDetailsDAO item in aOrder.OrderSampleDetails)
                {
                    List<SqlParameter> aSqlParameterList = new List<SqlParameter>();

                    aSqlParameterList.Add(new SqlParameter("@orderid", pk));
                    aSqlParameterList.Add(new SqlParameter("@productid", item.ProductId));
                    aSqlParameterList.Add(new SqlParameter("@quantity", item.Quantity));
                   
                    bool result = accessManager.SaveData("sp_webapi_SaveOrderDetail_Doctor", aSqlParameterList);

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


        public DataTable Get_AppTopBarData(int empId, DateTime currentDate)
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


        public IList<Order_ApplogDAO> GetOrder_Applog_DAL(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, string GroupId, string ZoneId, string AreaId, string TerritoryId, string SubTerritoryId, string MarketId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
             
                gSqlParameterList.Add(new SqlParameter("@Role", Role ?? (object)DBNull.Value ?? (object)DBNull.Value));
                pram =  NewMethod(pram, Role, gSqlParameterList);

                gSqlParameterList.Add(new SqlParameter("@AppStatus", AppStatus ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@FromDt", FromDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ToDt", ToDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EmpId", EmpId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@GroupId_", GroupId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ZoneId_", ZoneId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@AreaId_", AreaId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@TerritoryId", TerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@SubTerritoryId", SubTerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@MarketId", MarketId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_OrderApp", gSqlParameterList);


                List<Order_ApplogDAO> aList = new List<Order_ApplogDAO>();

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    Order_ApplogDAO aInfo = new Order_ApplogDAO();

                    if (dt.Rows[i]["OrderApprovalId"] != DBNull.Value)
                    {
                        aInfo.OrderApprovalId = Convert.ToInt32(dt.Rows[i]["OrderApprovalId"]);
                    }

                    if (dt.Rows[i]["EmpInfoId"] != DBNull.Value)
                    {
                        aInfo.EmpInfoId = Convert.ToInt32(dt.Rows[i]["EmpInfoId"].ToString());

                    }


                    if (dt.Rows[i]["EntryDate"] != DBNull.Value)
                    {
                        aInfo.EntryDate = (dt.Rows[i]["EntryDate"].ToString());
                    }


                    if (dt.Rows[i]["ApprovalStatus"] != DBNull.Value)
                    {
                        aInfo.ApprovalStatus = dt.Rows[i]["ApprovalStatus"].ToString();
                    }


                    if (dt.Rows[i]["MarketId"] != DBNull.Value)
                    {
                        aInfo.MarketId = Convert.ToInt32(dt.Rows[i]["MarketId"].ToString());
                    }


                    if (dt.Rows[i]["MarketName"] != DBNull.Value)
                    {
                        aInfo.MarketName = dt.Rows[i]["MarketName"].ToString();
                    }




                    if (dt.Rows[i]["FromEmpId"] != DBNull.Value)
                    {
                        aInfo.FromEmpId = Convert.ToInt32(dt.Rows[i]["FromEmpId"].ToString());
                    }



                    if (dt.Rows[i]["ToEmpId"] != DBNull.Value)
                    {
                        aInfo.ToEmpId = Convert.ToInt32(dt.Rows[i]["ToEmpId"].ToString());
                    }
                    if (dt.Rows[i]["TableId"] != DBNull.Value)
                    {
                        aInfo.TableId = Convert.ToInt32(dt.Rows[i]["TableId"].ToString());
                    }
                    if (dt.Rows[i]["Status"] != DBNull.Value)
                    {
                        aInfo.Status = dt.Rows[i]["Status"].ToString();
                    }
                    if (dt.Rows[i]["Comments"] != DBNull.Value)
                    {
                        aInfo.Comments = dt.Rows[i]["Comments"].ToString();
                    }

                    if (dt.Rows[i]["Type"] != DBNull.Value)
                    {
                        aInfo.Type = (dt.Rows[i]["Type"].ToString());
                    }


                    if (dt.Rows[i]["Step"] != DBNull.Value)
                    {
                        aInfo.Step = Convert.ToInt32(dt.Rows[i]["Step"].ToString());
                    }





                    if (dt.Rows[i]["FromEmpId"] != DBNull.Value)
                    {
                        aInfo.FromEmpId = Convert.ToInt32(dt.Rows[i]["FromEmpId"].ToString());
                    }
                    if (dt.Rows[i]["ToEmpId"] != DBNull.Value)
                    {
                        aInfo.ToEmpId = Convert.ToInt32(dt.Rows[i]["ToEmpId"].ToString());
                    }


                    if (dt.Rows[i]["TableId"] != DBNull.Value)
                    {
                        aInfo.TableId = Convert.ToInt32(dt.Rows[i]["TableId"].ToString());
                    }

                    if (dt.Rows[i]["Comments"] != DBNull.Value)
                    {
                        aInfo.Comments = dt.Rows[i]["Comments"].ToString();
                    }

                    if (dt.Rows[i]["Type"] != DBNull.Value)
                    {
                        aInfo.Type = dt.Rows[i]["Type"].ToString();
                    }





                    if (dt.Rows[i]["GroupId"] != DBNull.Value)
                    {
                        aInfo.GroupId = Convert.ToInt32(dt.Rows[i]["GroupId"].ToString());
                    }

                    if (dt.Rows[i]["RegionId"] != DBNull.Value)
                    {
                        aInfo.RegionId = Convert.ToInt32(dt.Rows[i]["RegionId"].ToString());
                    }


                    if (dt.Rows[i]["AreaId"] != DBNull.Value)
                    {
                        aInfo.AreaId = Convert.ToInt32(dt.Rows[i]["AreaId"].ToString());
                    }


                    if (dt.Rows[i]["TerritoryId"] != DBNull.Value)
                    {
                        aInfo.TerritoryId = Convert.ToInt32(dt.Rows[i]["TerritoryId"].ToString());
                    }


                    if (dt.Rows[i]["RoleTypeId"] != DBNull.Value)
                    {
                        aInfo.RoleTypeId = Convert.ToInt32(dt.Rows[i]["RoleTypeId"].ToString());
                    }


                    if (dt.Rows[i]["EmpMasterCode"] != DBNull.Value)
                    {
                        aInfo.EmpMasterCode = dt.Rows[i]["EmpMasterCode"].ToString();
                    }


                    if (dt.Rows[i]["EmpName"] != DBNull.Value)
                    {
                        aInfo.EmpName = dt.Rows[i]["EmpName"].ToString();
                    }


                    if (dt.Rows[i]["TerritoryName"] != DBNull.Value)
                    {
                        aInfo.TerritoryName = dt.Rows[i]["TerritoryName"].ToString();
                    }

                    if (dt.Rows[i]["TerritoryCode"] != DBNull.Value)
                    {
                        aInfo.TerritoryCode = dt.Rows[i]["TerritoryCode"].ToString();
                    }

                    if (dt.Rows[i]["AreaCode"] != DBNull.Value)
                    {
                        aInfo.AreaCode = dt.Rows[i]["AreaCode"].ToString();
                    }


                    if (dt.Rows[i]["ToRoleTypeId"] != DBNull.Value)
                    {
                        aInfo.ToRoleTypeId = Convert.ToInt32(dt.Rows[i]["ToRoleTypeId"].ToString());
                    }

                    if (dt.Rows[i]["MIOEmpId"] != DBNull.Value)
                    {
                        aInfo.MIOEmpId = Convert.ToInt32(dt.Rows[i]["MIOEmpId"].ToString());
                    }

                    if (dt.Rows[i]["ASMEMPId"] != DBNull.Value)
                    {
                        aInfo.ASMEMPId = Convert.ToInt32(dt.Rows[i]["ASMEMPId"].ToString());
                    }

                    if (dt.Rows[i]["RSMEMPId"] != DBNull.Value)
                    {
                        aInfo.RSMEMPId = Convert.ToInt32(dt.Rows[i]["RSMEMPId"].ToString());
                    }
                    if (dt.Rows[i]["NSMEMPId"] != DBNull.Value)
                    {
                        aInfo.NSMEMPId = Convert.ToInt32(dt.Rows[i]["NSMEMPId"].ToString());
                    }

             

                    List<SqlParameter> aSqlParameterListDetals = new List<SqlParameter>();

                    aSqlParameterListDetals.Add(new SqlParameter("@id", aInfo.TableId));
                    DataTable dtDoctor = accessManager.GetDataTable("sp_webapi_GetOrderMasterById", aSqlParameterListDetals);


                    OrderMasterDAO aDetails;


                    aDetails = new OrderMasterDAO();

                    if (dtDoctor.Rows[0]["OrderId"] != DBNull.Value)
                    {
                        aDetails.OrderId = Convert.ToInt32(dtDoctor.Rows[0]["OrderId"].ToString());
                    }
                    

                    if (dtDoctor.Rows[0]["OrderCode"] != DBNull.Value)
                    {
                        aDetails.OrderCode = (dtDoctor.Rows[0]["OrderCode"].ToString());
                    }

                    

                    if (dtDoctor.Rows[0]["TotalAmount"] != DBNull.Value)
                    {
                        aDetails.TotalAmount = Convert.ToDecimal(dtDoctor.Rows[0]["TotalAmount"].ToString());
                    }


                    if (dtDoctor.Rows[0]["TotalTP"] != DBNull.Value)
                    {
                        aDetails.TotalTP = Convert.ToDecimal(dtDoctor.Rows[0]["TotalTP"].ToString());
                    }
                    if (dtDoctor.Rows[0]["TotalVAT"] != DBNull.Value)
                    {
                        aDetails.TotalVAT = Convert.ToDecimal(dtDoctor.Rows[0]["TotalVAT"].ToString());
                    }



                    List<SqlParameter> aSqlCust = new List<SqlParameter>();

                    aSqlCust.Add(new SqlParameter("@id", dtDoctor.Rows[0]["CustomerMasterId"]));
                    DataTable dtCust = accessManager.GetDataTable("sp_webapi_GetOrderCustMasterById", aSqlCust);


                    mCustMaster aCustDetails;


                    aCustDetails = new mCustMaster();
                    if (dtCust.Rows[0]["CustomerMasterId"] != DBNull.Value)
                    {
                        aCustDetails.CustomerMasterId = Convert.ToInt32(dtCust.Rows[0]["CustomerMasterId"]);
                    }
                    if (dtCust.Rows[0]["CustomerName"] != DBNull.Value)
                    {
                        aCustDetails.CustomerName = dtCust.Rows[0]["CustomerName"].ToString();
                    }


                    if (dtCust.Rows[0]["CustomerCode"] != DBNull.Value)
                    {
                        aCustDetails.CustomerCode = dtCust.Rows[0]["CustomerCode"].ToString();

                    }


                    if (dtCust.Rows[0]["CategoryId"] != DBNull.Value)
                    {
                        aCustDetails.CategoryId = Convert.ToInt32(dtCust.Rows[0]["CategoryId"].ToString());

                    }
                    if (dtCust.Rows[0]["MarketId"] != DBNull.Value)
                    {
                        aCustDetails.MarketId = Convert.ToInt32(dtCust.Rows[0]["MarketId"].ToString());

                    }
                    if (dtCust.Rows[0]["CategoryId"] != DBNull.Value)
                    {
                        aCustDetails.CategoryId = Convert.ToInt32(dtCust.Rows[0]["CategoryId"].ToString());

                    }
                    if (dtCust.Rows[0]["Address"] != DBNull.Value)
                    {
                        aCustDetails.Address = dtCust.Rows[0]["Address"].ToString();
                    }


                    aCustDetails.MarketName = dtCust.Rows[0]["MarketName"] != DBNull.Value ? dtCust.Rows[0]["MarketName"].ToString() : "";


                    aCustDetails.MarketCode = dtCust.Rows[0]["MarketCode"] != DBNull.Value ? dtCust.Rows[0]["MarketCode"].ToString() : "";

                    aCustDetails.CellNo = dtCust.Rows[0]["CellNo"] != DBNull.Value ? dtCust.Rows[0]["CellNo"].ToString() : "";

                    aCustDetails.Addrees2 = dtCust.Rows[0]["StreetAddress"] != DBNull.Value ? dtCust.Rows[0]["StreetAddress"].ToString() : "";
                    aCustDetails.City = "";

                    aCustDetails.ConPerson = dtCust.Rows[0]["OwnerName"] != DBNull.Value ? dtCust.Rows[0]["OwnerName"].ToString() : "";
                    aCustDetails.ShippingCond = "";


                    List<SqlParameter> aSqlOrderDetals = new List<SqlParameter>();

                    aSqlOrderDetals.Add(new SqlParameter("@OrderId", aDetails.OrderId));
                    DataTable dtDtls = accessManager.GetDataTable("sp_Webapi_Get_OrderDetailsById", aSqlOrderDetals);

                    List<OrderDtls> aDetailsList = new List<OrderDtls>();
                    OrderDtls aOrdDetails;
                    for (var kk = 0; kk < dtDtls.Rows.Count; kk++)

                    {

                        aOrdDetails = new OrderDtls();
                        if (dtDtls.Rows[kk]["ProductId"] != DBNull.Value)
                        {
                            aOrdDetails.ProductId = Convert.ToInt32(dtDtls.Rows[kk]["ProductId"].ToString());
                        }
                        if (dtDtls.Rows[kk]["ProductCode"] != DBNull.Value)
                        {
                            aOrdDetails.ProductCode = dtDtls.Rows[kk]["ProductCode"].ToString();
                        }

                        if (dtDtls.Rows[kk]["ProductName"] != DBNull.Value)
                        {
                            aOrdDetails.ProductName = dtDtls.Rows[kk]["ProductName"].ToString();
                        }


                        if (dtDtls.Rows[kk]["Quantity"] != DBNull.Value)
                        {
                            aOrdDetails.Quantity = Convert.ToInt32(dtDtls.Rows[kk]["Quantity"].ToString());
                        }

                        if (dtDtls.Rows[kk]["UnitPrice"] != DBNull.Value)
                        {
                            aOrdDetails.UnitPrice = Convert.ToDecimal(dtDtls.Rows[kk]["UnitPrice"].ToString());
                        }

                        if (dtDtls.Rows[kk]["TotalTradePrice"] != DBNull.Value)
                        {
                            aOrdDetails.TotalTradePrice = Convert.ToDecimal(dtDtls.Rows[kk]["TotalTradePrice"].ToString());
                        }
                        if (dtDtls.Rows[kk]["TotalVatAmount"] != DBNull.Value)
                        {
                            aOrdDetails.TotalVatAmount = Convert.ToDecimal(dtDtls.Rows[kk]["TotalVatAmount"].ToString());
                        }


                        aDetailsList.Add(aOrdDetails);
                    }
                    aDetails.aOrderDtls = aDetailsList;
                    aInfo.aCustMasterDAO = aCustDetails;
                    aInfo.aOrderMasterDAO = aDetails;
                  






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



        public ResultInfo SaveOrder_ApplogDAL(OrderSaveApprovalLogDAO atten)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@OrderApprovalId", atten.OrderApprovalId ?? (object)DBNull.Value ?? (object)DBNull.Value));
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

                aInformation.isSuccess = accessManager.SaveData("sp_webapi_SaveOrderAppLog", gSqlParameterList);

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