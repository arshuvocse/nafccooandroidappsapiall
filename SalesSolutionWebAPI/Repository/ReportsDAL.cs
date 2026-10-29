using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace SalesSolutionWebAPI.Repository
{
    public class ReportsDAL
    {
        private DataAccessManager accessManager = new DataAccessManager();

        public DataTable GetStockReport(int empId, string type)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                DataTable dt = new DataTable();
                if (type== "Main")
                {
                    dt = accessManager.GetDataTable("sp_webapi_Get_StockReport", aSqlParameterlist);
                }
                if (type == "Sample")
                {
                    dt = accessManager.GetDataTable("sp_webapi_Get_SampleStockReport_new", aSqlParameterlist);
                }

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


        public DataTable GetSampleStockReport(int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                DataTable dt = accessManager.GetDataTable("sp_webapi_Get_SampleStockReport", aSqlParameterlist);
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


        public DataTable GetPrescriptionReport_Two(string EmpId, string frmDate, string toDate, string ProductId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@EmpId", EmpId));
                aSqlParameterlist.Add(new SqlParameter("@ProductId", ProductId));

                aSqlParameterlist.Add(new SqlParameter("@frmDate", frmDate));
                aSqlParameterlist.Add(new SqlParameter("@toDate", toDate));
                DataTable dt = accessManager.GetDataTable("sp_webapi_rpt_PrescriptionReport_Two", aSqlParameterlist);
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


        public DataTable GetPrescriptionReport_Three(string EmpId, string frmDate, string toDate )
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@EmpId", EmpId));
          

                aSqlParameterlist.Add(new SqlParameter("@frmDate", frmDate));
                aSqlParameterlist.Add(new SqlParameter("@toDate", toDate));

                DataTable dt = accessManager.GetDataTable("sp_webapi_rpt_PrescriptionReport_Three", aSqlParameterlist);
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

        public DataTable GetPrescriptionReport_One(string EmpId, string frmDate, string toDate)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@EmpId", EmpId));


                aSqlParameterlist.Add(new SqlParameter("@frmDate", frmDate));
                aSqlParameterlist.Add(new SqlParameter("@toDate", toDate));

                DataTable dt = accessManager.GetDataTable("sp_webapi_rpt_PrescriptionReport_One", aSqlParameterlist);
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



        public IList<CustomerPenDao> GetCustomerPendingRejectList(int empId, string ApprovalStatus)
        {



            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                aSqlParameterlist.Add(new SqlParameter("@ApprovalStatus", ApprovalStatus));

                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_CustomerPendingReject", aSqlParameterlist);
                List<CustomerPenDao> aList = new List<CustomerPenDao>();
                for (var i = 0; i < dt.Rows.Count; i++)

                {
                    CustomerPenDao aInfo = new CustomerPenDao();


                    if (dt.Rows[i]["CustomerMasterId"] != DBNull.Value)
                    {
                        aInfo.CustomerMasterId = Convert.ToInt32(dt.Rows[i]["CustomerMasterId"].ToString());
                    }


                    if (dt.Rows[i]["CustomerName"] != DBNull.Value)
                    {
                        aInfo.CustomerName = (dt.Rows[i]["CustomerName"].ToString());
                    }
 
                    if (dt.Rows[i]["Address"] != DBNull.Value)
                    {
                        aInfo.Address = (dt.Rows[i]["Address"].ToString());
                    }
                    if (dt.Rows[i]["ActionStatus"] != DBNull.Value)
                    {
                        aInfo.ActionStatus = (dt.Rows[i]["ActionStatus"].ToString());
                    }
                    if (dt.Rows[i]["MarketName"] != DBNull.Value)
                    {
                        aInfo.MarketName = (dt.Rows[i]["MarketName"].ToString());
                    }

                    if (dt.Rows[i]["ProgramTypeName"] != DBNull.Value)
                    {
                        aInfo.ProgramTypeName = (dt.Rows[i]["ProgramTypeName"].ToString());
                    }




                    if (dt.Rows[i]["CellNo"] != DBNull.Value)
                    {
                        aInfo.CellNo = (dt.Rows[i]["CellNo"].ToString());
                    }

 




 

                    if (dt.Rows[i]["ProgramTypeName"] != DBNull.Value)
                    {
                        aInfo.ProgramTypeName = (dt.Rows[i]["ProgramTypeName"].ToString());
                    }

                   


                    if (dt.Rows[i]["OwnerName"] != DBNull.Value)
                    {
                        aInfo.OwnerName = (dt.Rows[i]["OwnerName"].ToString());
                    }
                    if (dt.Rows[i]["WaitingRole"] != DBNull.Value)
                    {
                        aInfo.WaitingRole = (dt.Rows[i]["WaitingRole"].ToString());
                    }


                    if (dt.Rows[i]["WatingEmployee"] != DBNull.Value)
                    {
                        aInfo.WatingEmployee = (dt.Rows[i]["WatingEmployee"].ToString());
                    }

                    string imagefullpath = (dt.Rows[i]["CustomerImagePreName"].ToString() + ((int)dt.Rows[i]["CustomerMasterId"]).ToString() + ".jpg");


                    try
                    {
                        byte[] imageArray = System.IO.File.ReadAllBytes(@imagefullpath);
                        aInfo.ImageBase64String = Convert.ToBase64String(imageArray);
                        aInfo.CustomerImagePreName = imagefullpath;

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
                throw;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
            
        }

       

        public IList<CustomerPenDao> GetCustomerPendingRejectLists(int empId)
        {



            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId)); 

                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_CustomerAll", aSqlParameterlist);
                List<CustomerPenDao> aList = new List<CustomerPenDao>();
                for (var i = 0; i < dt.Rows.Count; i++)

                {
                    CustomerPenDao aInfo = new CustomerPenDao();


                    if (dt.Rows[i]["CustomerMasterId"] != DBNull.Value)
                    {
                        aInfo.CustomerMasterId = Convert.ToInt32(dt.Rows[i]["CustomerMasterId"].ToString());
                    }


                    if (dt.Rows[i]["CustomerName"] != DBNull.Value)
                    {
                        aInfo.CustomerName = (dt.Rows[i]["CustomerName"].ToString());
                    }

                    if (dt.Rows[i]["Address"] != DBNull.Value)
                    {
                        aInfo.Address = (dt.Rows[i]["Address"].ToString());
                    }
                    if (dt.Rows[i]["ActionStatus"] != DBNull.Value)
                    {
                        aInfo.ActionStatus = (dt.Rows[i]["ActionStatus"].ToString());
                    }
                    if (dt.Rows[i]["MarketName"] != DBNull.Value)
                    {
                        aInfo.MarketName = (dt.Rows[i]["MarketName"].ToString());
                    }

                    if (dt.Rows[i]["ProgramTypeName"] != DBNull.Value)
                    {
                        aInfo.ProgramTypeName = (dt.Rows[i]["ProgramTypeName"].ToString());
                    }




                    if (dt.Rows[i]["CellNo"] != DBNull.Value)
                    {
                        aInfo.CellNo = (dt.Rows[i]["CellNo"].ToString());
                    }








                    if (dt.Rows[i]["ProgramTypeName"] != DBNull.Value)
                    {
                        aInfo.ProgramTypeName = (dt.Rows[i]["ProgramTypeName"].ToString());
                    }




                    if (dt.Rows[i]["OwnerName"] != DBNull.Value)
                    {
                        aInfo.OwnerName = (dt.Rows[i]["OwnerName"].ToString());
                    }
                    if (dt.Rows[i]["WaitingRole"] != DBNull.Value)
                    {
                        aInfo.WaitingRole = (dt.Rows[i]["WaitingRole"].ToString());
                    }


                    if (dt.Rows[i]["WatingEmployee"] != DBNull.Value)
                    {
                        aInfo.WatingEmployee = (dt.Rows[i]["WatingEmployee"].ToString());
                    }
                    if (dt.Rows[i]["CustomerStatus"] != DBNull.Value)
                    {
                        aInfo.CustomerStatus = (dt.Rows[i]["CustomerStatus"].ToString());
                    }



                    aInfo.GroupId = dt.Rows[i]["GroupId"] != DBNull.Value ? dt.Rows[i]["GroupId"].ToString() : "";
                    aInfo.RegionId = dt.Rows[i]["RegionId"] != DBNull.Value ? dt.Rows[i]["RegionId"].ToString() : "";
                    aInfo.AreaId = dt.Rows[i]["AreaId"] != DBNull.Value ? dt.Rows[i]["AreaId"].ToString() : "";
                    aInfo.TerritoryId = dt.Rows[i]["TerritoryId"] != DBNull.Value ? dt.Rows[i]["TerritoryId"].ToString() : "";
                    aInfo.SubTerritoryId = dt.Rows[i]["SubTerritoryId"] != DBNull.Value ? dt.Rows[i]["SubTerritoryId"].ToString() : "";
                    aInfo.MarketId = dt.Rows[i]["MarketId"] != DBNull.Value ? dt.Rows[i]["MarketId"].ToString() : "";

                    //if (dt.Rows[i]["BtnupdateInfo"] != DBNull.Value)
                    //{
                    //    aInfo.BtnupdateInfo = Convert.ToInt32(dt.Rows[i]["BtnupdateInfo"].ToString());
                    //}

                


                    if (dt.Rows[i]["ImageString"] != DBNull.Value)
                    {
                        aInfo.ImageBase64String = dt.Rows[i]["ImageString"].ToString();
                    }


                    //aInfo.GroupName = dt.Rows[i]["GroupName"] != DBNull.Value ? dt.Rows[i]["GroupName"].ToString() : "";
                    //aInfo.RegionName = dt.Rows[i]["RegionName"] != DBNull.Value ? dt.Rows[i]["RegionName"].ToString() : "";
                    //aInfo.AreaName = dt.Rows[i]["AreaName"] != DBNull.Value ? dt.Rows[i]["AreaName"].ToString() : "";
                    //aInfo.TerritoryName = dt.Rows[i]["TerritoryName"] != DBNull.Value ? dt.Rows[i]["TerritoryName"].ToString() : "";
                    //aInfo.SubTerritoryId = dt.Rows[i]["SubTerritoryId"] != DBNull.Value ? dt.Rows[i]["SubTerritoryId"].ToString() : "";
                    //aInfo.SubTerritoryName = dt.Rows[i]["SubTerritoryName"] != DBNull.Value ? dt.Rows[i]["SubTerritoryName"].ToString() : "";

                    aList.Add(aInfo);
                }
                return aList;

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


        public IList<CustomerPenDao> GetCustomerUpdateInfoDAL(int empId,  string GroupId, string ZoneId, string AreaId, string TerritoryId, string SubTerritoryId, string MarketId)
        {



            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                aSqlParameterlist.Add(new SqlParameter("@GroupId_", GroupId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@ZoneId_", ZoneId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@AreaId_", AreaId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@TerritoryId", TerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@SubTerritoryId", SubTerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@MarketId", MarketId ?? (object)DBNull.Value ?? (object)DBNull.Value));


                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_CustomerAllIsMarketUpdate2022", aSqlParameterlist);
                List<CustomerPenDao> aList = new List<CustomerPenDao>();
                for (var i = 0; i < dt.Rows.Count; i++)

                {
                    CustomerPenDao aInfo = new CustomerPenDao();


                    if (dt.Rows[i]["CustomerMasterId"] != DBNull.Value)
                    {
                        aInfo.CustomerMasterId = Convert.ToInt32(dt.Rows[i]["CustomerMasterId"].ToString());
                    }


                    if (dt.Rows[i]["CustomerName"] != DBNull.Value)
                    {
                        aInfo.CustomerName = (dt.Rows[i]["CustomerName"].ToString());
                    }

                    if (dt.Rows[i]["Address"] != DBNull.Value)
                    {
                        aInfo.Address = (dt.Rows[i]["Address"].ToString());
                    }
                    if (dt.Rows[i]["ActionStatus"] != DBNull.Value)
                    {
                        aInfo.ActionStatus = (dt.Rows[i]["ActionStatus"].ToString());
                    }
                    if (dt.Rows[i]["MarketName"] != DBNull.Value)
                    {
                        aInfo.MarketName = (dt.Rows[i]["MarketName"].ToString());
                    }

                    if (dt.Rows[i]["ProgramTypeName"] != DBNull.Value)
                    {
                        aInfo.ProgramTypeName = (dt.Rows[i]["ProgramTypeName"].ToString());
                    }




                    if (dt.Rows[i]["CellNo"] != DBNull.Value)
                    {
                        aInfo.CellNo = (dt.Rows[i]["CellNo"].ToString());
                    }








                    if (dt.Rows[i]["ProgramTypeName"] != DBNull.Value)
                    {
                        aInfo.ProgramTypeName = (dt.Rows[i]["ProgramTypeName"].ToString());
                    }




                    if (dt.Rows[i]["OwnerName"] != DBNull.Value)
                    {
                        aInfo.OwnerName = (dt.Rows[i]["OwnerName"].ToString());
                    }
                    if (dt.Rows[i]["WaitingRole"] != DBNull.Value)
                    {
                        aInfo.WaitingRole = (dt.Rows[i]["WaitingRole"].ToString());
                    }


                    if (dt.Rows[i]["WatingEmployee"] != DBNull.Value)
                    {
                        aInfo.WatingEmployee = (dt.Rows[i]["WatingEmployee"].ToString());
                    }
                    if (dt.Rows[i]["CustomerStatus"] != DBNull.Value)
                    {
                        aInfo.CustomerStatus = (dt.Rows[i]["CustomerStatus"].ToString());
                    }



                    aInfo.GroupId = dt.Rows[i]["GroupId"] != DBNull.Value ? dt.Rows[i]["GroupId"].ToString() : "";
                    aInfo.RegionId = dt.Rows[i]["RegionId"] != DBNull.Value ? dt.Rows[i]["RegionId"].ToString() : "";
                    aInfo.AreaId = dt.Rows[i]["AreaId"] != DBNull.Value ? dt.Rows[i]["AreaId"].ToString() : "";
                    aInfo.TerritoryId = dt.Rows[i]["TerritoryId"] != DBNull.Value ? dt.Rows[i]["TerritoryId"].ToString() : "";
                    aInfo.SubTerritoryId = dt.Rows[i]["SubTerritoryId"] != DBNull.Value ? dt.Rows[i]["SubTerritoryId"].ToString() : "";
                    aInfo.MarketId = dt.Rows[i]["MarketId"] != DBNull.Value ? dt.Rows[i]["MarketId"].ToString() : "";

                    if (dt.Rows[i]["BtnupdateInfo"] != DBNull.Value)
                    {
                        aInfo.BtnupdateInfo = Convert.ToInt32(dt.Rows[i]["BtnupdateInfo"].ToString());
                    }




                    if (dt.Rows[i]["ImageString"] != DBNull.Value)
                    {
                        aInfo.ImageString = dt.Rows[i]["ImageString"].ToString();
                    }


                    aInfo.GroupName = dt.Rows[i]["GroupName"] != DBNull.Value ? dt.Rows[i]["GroupName"].ToString() : "";
                    aInfo.RegionName = dt.Rows[i]["RegionName"] != DBNull.Value ? dt.Rows[i]["RegionName"].ToString() : "";
                    aInfo.AreaName = dt.Rows[i]["AreaName"] != DBNull.Value ? dt.Rows[i]["AreaName"].ToString() : "";
                    aInfo.TerritoryName = dt.Rows[i]["TerritoryName"] != DBNull.Value ? dt.Rows[i]["TerritoryName"].ToString() : "";
                    aInfo.SubTerritoryId = dt.Rows[i]["SubTerritoryId"] != DBNull.Value ? dt.Rows[i]["SubTerritoryId"].ToString() : "";
                    aInfo.SubTerritoryName = dt.Rows[i]["SubTerritoryName"] != DBNull.Value ? dt.Rows[i]["SubTerritoryName"].ToString() : "";

                    aList.Add(aInfo);
                }
                return aList;

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


        public string Query(string empId, string Role, string Month, string Year)
        {
            string parm = "";
            if (Role == "MBE")
            {
                parm = parm + " AND SLS.MBEId ='"+ empId + "'";
            }

          

            if (Role == "MIO")
            {
                parm = parm + " AND SLS.MIOId ='" + empId + "'";
            }

            if (Role == "AM")
            {
                parm = parm + " AND SLS.ASMId ='" + empId + "'";
            }

            if (Role == "DZSM")
            {
                parm = parm + " AND SLS.RSMId ='" + empId + "'";
            }

            if (Role == "NSM")
            {
                parm = parm + " AND SLS.NSMId ='" + empId + "'";
            }

            if (Month != "")
            {
                parm = parm + " AND MONTH(CONVERT(DATE, SLS.InvoiceDate)) ='" + Month + "'";
            }

            if (Year != "")
            {
                parm = parm + " AND YEAR(CONVERT(DATE, SLS.InvoiceDate)) ='" + Year + "'";
            }

            string para = @"SELECT ROW_NUMBER() Over (ORDER BY SLS.CustomerCode) AS [SN], InvoiceDate, MBEId, MIOId, ASMId, RSMId, ISNULL(COUNT(SLS.CustomerCode), 0) ordered_qty, SLS.CustomerCode + ' : ' + SLS.CustomerName customer_name, sum(OrderValue) ordered_value, sum(InvoiceValue) InvoiceValue from (SELECT  InvoiceDate, MBEId, MIOId, ASMId, RSMId, CustomerCode, CustomerName, ClusterCode,RegionCode,AreaCode,CLSH.TerritoryCode AS FieldName,MBECode,CLSH.MBE AS FieldForceName,SUM(CLSH.OrderValue) AS OrderValue,SUM(ProformaValue) AS ProformaValue,SUM(InvoiceValue) InvoiceValue,
SUM(ReturnValue) ReturnValue,CASE WHEN SUM(ReturnValue) > 0 THEN (CAST(((SUM(ReturnValue) * 100)/(SUM(InvoiceValue) + ISNULL(SUM(ReturnValue),0))) as decimal(16,2))) 
ELSE CAST(0 as decimal(16,2)) END AS ReturnPercentage,SUM(OnDelivery) OnDelivery,SUM(CreditAmount) CreditAmount,SUM(CollectionAmount) CollectionAmount,SUM(ISNULL(TargetValue,0)) TargetValue,
CASE WHEN SUM(ISNULL(TargetValue,0)) > 0 THEN CAST(((SUM(CollectionAmount) *100)/SUM(ISNULL(TargetValue,0))) as decimal(16,2))  ELSE CAST(0 as decimal(16,2)) END AS Achivement FROM (SELECT   InvoiceDate, MBEId, MIOId, ASMId, RSMId, CustomerCode, CustomerName,EmpMasterCode,ClusterCode,ClusterHead,RegionCode,RSM,AreaCode,ASM,SLS.TerritoryCode,MBECode,MBE,SUM(OrderValue) AS OrderValue,SUM(ProformaValue) AS ProformaValue,SUM(InvoiceValue) InvoiceValue,
SUM(ReturnValue) ReturnValue, CASE WHEN SUM(ReturnValue) > 0 THEN (CAST(((SUM(ReturnValue) * 100)/(SUM(InvoiceValue) + ISNULL(SUM(ReturnValue),0))) as decimal(16,2))) 
ELSE CAST(0 as decimal(16,2)) END AS ReturnPercentage,SUM(OnDelivery) OnDelivery,SUM(DueAmount) CreditAmount,SUM(PaymentAmount) CollectionAmount,ISNULL(TGT.TotalTargetByTpVat,0) TargetValue,
CASE WHEN ISNULL(TGT.TotalTargetByTpVat,0) > 0 THEN CAST(((SUM(PaymentAmount) *100)/TGT.TotalTargetByTpVat) as decimal(16,2))  ELSE CAST(0 as decimal(16,2)) END AS Achivement
FROM (SELECT C.CustomerCode, C.CustomerName,  MBE.EmpMasterCode, ODR.SubmissionDate,I.InvoiceDate,ODR.GroupId,CLS.RegionId,CLS.RegionCode AS ClusterCode,RGN.AreaId,RGN.AreaCode AS RegionCode,ARA.TerritoryId,ARA.TerritoryCode AS AreaCode,
TTR.SubTerritoryId,TTR.SubTerritoryCode AS TerritoryCode,RSM.EmpInfoId AS RSMId,RSM.EmpMasterCode +' : '+  RSM.EmpName AS ClusterHead,ASM.EmpInfoId AS ASMId,
ASM.EmpMasterCode +' : '+  ASM.EmpName AS RSM,MIO.EmpInfoId AS MIOId,MIO.EmpMasterCode +' : '+  MIO.EmpName AS ASM,
MBE.EmpInfoId AS MBEId,MBE.EmpMasterCode AS MBECode,MBE.EmpName AS MBE,ISNULL(OV.OrderValue,0) AS OrderValue,ISNULL(PV.ProformaValue,0) AS ProformaValue,
ISNULL(IV.InvoiceValue,0) AS InvoiceValue,ISNULL(ODV.OnDelivery,0) AS OnDelivery, ISNULL(RV.ReturnValue,0) ReturnValue,(ISNULL(PT.PaymentAmount,0) - CASE WHEN  ISNULL(PT.PaymentAmount,0) > 0 THEN InvoiceVat ELSE 0 END) PaymentAmount,
(ISNULL(IV.InvoiceValue,0) - (ISNULL(PT.PaymentAmount,0) - CASE WHEN  ISNULL(PT.PaymentAmount,0) > 0 THEN InvoiceVat ELSE 0 END)) AS DueAmount FROM tblInvoice AS I with (nolock)
LEFT JOIN tblOrder AS ODR with (nolock) ON I.OrderId = ODR.OrderId
 LEFT JOIN tblCustMaster C WITH (NOLOCK) ON C.CustomerMasterId = ODR.CustomerMasterId 
LEFT JOIN tblRegion AS CLS with (nolock) ON ODR.RegionCode_Ord = CLS.RegionCode
LEFT JOIN tblArea AS RGN with (nolock) ON ODR.AreaCode_Ord = RGN.AreaCode 
LEFT JOIN tblTerritory AS ARA with (nolock) ON ODR.TerritoryCode_Ord  = ARA.TerritoryCode
LEFT JOIN tblSubTerritory AS TTR with (nolock) ON ODR.SubTerritoryCode_Ord = TTR.SubTerritoryCode 
LEFT JOIN tblEmpGeneralInfo AS MBE with (nolock) ON ODR.MBEEmpInfoId = MBE.EmpInfoId
LEFT JOIN tblEmpGeneralInfo AS MIO with (nolock) ON ODR.MIOId = MIO.EmpInfoId 
LEFT JOIN tblEmpGeneralInfo AS ASM with (nolock) ON ODR.ASMId = ASM.EmpInfoId
LEFT JOIN tblEmpGeneralInfo AS RSM with (nolock) ON ODR.RSMId = RSM.EmpInfoId 
LEFT JOIN (SELECT T.InvoiceId,SUM(ODRD.TotalTradePrice) OrderValue FROM tblInvoice AS T
LEFT JOIN tblInvoiceDetail AS TID ON T.InvoiceId = TID.InvoiceId 
LEFT JOIN tblOrderDetail AS ODRD ON TID.OrderDetailsId = ODRD.OrderDetailId GROUP BY T.InvoiceId) AS OV ON I.InvoiceId = OV.InvoiceId
LEFT JOIN (SELECT T.InvoiceId,SUM(TID.TotalPrice) AS ProformaValue FROM tblInvoice AS T
LEFT JOIN tblInvoiceDetail AS TID ON T.InvoiceId = TID.InvoiceId
LEFT JOIN tblOrder AS TODR ON T.OrderId = TODR.OrderId GROUP BY T.InvoiceId) AS PV ON I.InvoiceId = PV.InvoiceId
LEFT JOIN (SELECT T.InvoiceId,SUM(TID.DeliveryTotalPrice) InvoiceValue,SUM(TID.DeliveryTotalPriceVatAmount) InvoiceVat FROM tblInvoice AS T
LEFT JOIN tblInvoiceDetail AS TID ON T.InvoiceId = TID.InvoiceId
LEFT JOIN tblOrder AS TODR ON T.OrderId = TODR.OrderId WHERE DeliveryInvoiceStatus IN ('Full','Partial') GROUP BY T.InvoiceId) AS IV ON I.InvoiceId = IV.InvoiceId
LEFT JOIN (SELECT T.InvoiceId,SUM(TID.TotalPrice) OnDelivery FROM tblInvoice AS T
LEFT JOIN tblInvoiceDetail AS TID ON T.InvoiceId = TID.InvoiceId
LEFT JOIN tblOrder AS TODR ON T.OrderId = TODR.OrderId WHERE DeliveryInvoiceStatus IS NULL GROUP BY T.InvoiceId) AS ODV ON I.InvoiceId = ODV.InvoiceId
LEFT JOIN (SELECT T.InvoiceId,SUM(TID.TotalPrice-ISNULL(TID.DeliveryTotalPrice,0)) ReturnValue FROM tblInvoice AS T
LEFT JOIN tblInvoiceDetail AS TID ON T.InvoiceId = TID.InvoiceId
LEFT JOIN tblOrder AS TODR ON T.OrderId = TODR.OrderId WHERE DeliveryInvoiceStatus IN ('Reject','Partial') GROUP BY T.InvoiceId) AS RV ON I.InvoiceId = RV.InvoiceId
LEFT JOIN (SELECT CP.InvoiceId,SUM(CP.PaymentAmount) AS PaymentAmount FROM tblCustPayDetail AS CP GROUP BY CP.InvoiceId) AS PT ON I.InvoiceId = PT.InvoiceId) AS SLS 
LEFT JOIN (SELECT DISTINCT TerritoryCode,TC.TotalTargetByTp TotalTargetByTpVat,TG.Year,TG.Month FROM tbl_Target_MIOWiseTargetSetup AS TGD
LEFT JOIN tbl_Target_MIOTargetSetupMaster AS TG ON TGD.MioTargetMasterId = TG.MioTargetMasterId
LEFT JOIN tbl_Target_CategoryMaster AS TC ON TGD.TargetCategoryId = TC.TargetId  WHERE TerritoryCode IS NOT NULL  ) AS TGT ON SLS.TerritoryCode = TGT.TerritoryCode WHERE  ClusterCode IS NOT NULL     GROUP BY  InvoiceDate,   MBEId, MIOId, ASMId, RSMId, CustomerCode, CustomerName, EmpMasterCode,ClusterCode,ClusterHead,RegionCode,RSM,AreaCode,ASM,SLS.TerritoryCode,MBECode,MBE,TGT.TotalTargetByTpVat ) AS CLSH WHERE CLSH.TerritoryCode IS NOT NULL  GROUP BY InvoiceDate,  MBEId, MIOId, ASMId, RSMId, CustomerCode, CustomerName,  ClusterCode,RegionCode,AreaCode,CLSH.TerritoryCode,MBECode,CLSH.MBE)SLS where SLS.InvoiceDate is not null    " + parm + @"
GROUP BY InvoiceDate, MBEId, MIOId, ASMId, RSMId, SLS.CustomerCode, SLS.CustomerName";
            //and tblCutting.CuttingQty>0 
            return para;

        }



        public string QueryProduct(string empId, string Role, string Month, string Year)
        {
            string parm = "";
            if (Role == "MBE")
            {
                parm = parm + " AND SLS.MBEId ='" + empId + "'";
            }



            if (Role == "MIO")
            {
                parm = parm + " AND SLS.MIOId ='" + empId + "'";
            }

            if (Role == "AM")
            {
                parm = parm + " AND SLS.ASMId ='" + empId + "'";
            }

            if (Role == "DZSM")
            {
                parm = parm + " AND SLS.RSMId ='" + empId + "'";
            }

            if (Role == "NSM")
            {
                parm = parm + " AND SLS.NSMId ='" + empId + "'";
            }

            if (Month != "")
            {
                parm = parm + " AND MONTH(CONVERT(DATE, SLS.InvoiceDate)) ='" + Month + "'";
            }

            if (Year != "")
            {
                parm = parm + " AND YEAR(CONVERT(DATE, SLS.InvoiceDate)) ='" + Year + "'";
            }

            string para = @"SELECT ROW_NUMBER() Over (ORDER BY SLS.CustomerCode) AS [SN], InvoiceDate, MBEId, MIOId, ASMId, RSMId, ISNULL(COUNT(SLS.CustomerCode), 0) ordered_qty, SLS.CustomerCode + ' : ' + SLS.CustomerName customer_name, sum(OrderValue) ordered_value, sum(InvoiceValue) InvoiceValue from (SELECT  InvoiceDate, MBEId, MIOId, ASMId, RSMId, CustomerCode, CustomerName, ClusterCode,RegionCode,AreaCode,CLSH.TerritoryCode AS FieldName,MBECode,CLSH.MBE AS FieldForceName,SUM(CLSH.OrderValue) AS OrderValue,SUM(ProformaValue) AS ProformaValue,SUM(InvoiceValue) InvoiceValue,
SUM(ReturnValue) ReturnValue,CASE WHEN SUM(ReturnValue) > 0 THEN (CAST(((SUM(ReturnValue) * 100)/(SUM(InvoiceValue) + ISNULL(SUM(ReturnValue),0))) as decimal(16,2))) 
ELSE CAST(0 as decimal(16,2)) END AS ReturnPercentage,SUM(OnDelivery) OnDelivery,SUM(CreditAmount) CreditAmount,SUM(CollectionAmount) CollectionAmount,SUM(ISNULL(TargetValue,0)) TargetValue,
CASE WHEN SUM(ISNULL(TargetValue,0)) > 0 THEN CAST(((SUM(CollectionAmount) *100)/SUM(ISNULL(TargetValue,0))) as decimal(16,2))  ELSE CAST(0 as decimal(16,2)) END AS Achivement FROM (SELECT   InvoiceDate, MBEId, MIOId, ASMId, RSMId, CustomerCode, CustomerName,EmpMasterCode,ClusterCode,ClusterHead,RegionCode,RSM,AreaCode,ASM,SLS.TerritoryCode,MBECode,MBE,SUM(OrderValue) AS OrderValue,SUM(ProformaValue) AS ProformaValue,SUM(InvoiceValue) InvoiceValue,
SUM(ReturnValue) ReturnValue, CASE WHEN SUM(ReturnValue) > 0 THEN (CAST(((SUM(ReturnValue) * 100)/(SUM(InvoiceValue) + ISNULL(SUM(ReturnValue),0))) as decimal(16,2))) 
ELSE CAST(0 as decimal(16,2)) END AS ReturnPercentage,SUM(OnDelivery) OnDelivery,SUM(DueAmount) CreditAmount,SUM(PaymentAmount) CollectionAmount,ISNULL(TGT.TotalTargetByTpVat,0) TargetValue,
CASE WHEN ISNULL(TGT.TotalTargetByTpVat,0) > 0 THEN CAST(((SUM(PaymentAmount) *100)/TGT.TotalTargetByTpVat) as decimal(16,2))  ELSE CAST(0 as decimal(16,2)) END AS Achivement
FROM (SELECT C.CustomerCode, C.CustomerName,  MBE.EmpMasterCode, ODR.SubmissionDate,I.InvoiceDate,ODR.GroupId,CLS.RegionId,CLS.RegionCode AS ClusterCode,RGN.AreaId,RGN.AreaCode AS RegionCode,ARA.TerritoryId,ARA.TerritoryCode AS AreaCode,
TTR.SubTerritoryId,TTR.SubTerritoryCode AS TerritoryCode,RSM.EmpInfoId AS RSMId,RSM.EmpMasterCode +' : '+  RSM.EmpName AS ClusterHead,ASM.EmpInfoId AS ASMId,
ASM.EmpMasterCode +' : '+  ASM.EmpName AS RSM,MIO.EmpInfoId AS MIOId,MIO.EmpMasterCode +' : '+  MIO.EmpName AS ASM,
MBE.EmpInfoId AS MBEId,MBE.EmpMasterCode AS MBECode,MBE.EmpName AS MBE,ISNULL(OV.OrderValue,0) AS OrderValue,ISNULL(PV.ProformaValue,0) AS ProformaValue,
ISNULL(IV.InvoiceValue,0) AS InvoiceValue,ISNULL(ODV.OnDelivery,0) AS OnDelivery, ISNULL(RV.ReturnValue,0) ReturnValue,(ISNULL(PT.PaymentAmount,0) - CASE WHEN  ISNULL(PT.PaymentAmount,0) > 0 THEN InvoiceVat ELSE 0 END) PaymentAmount,
(ISNULL(IV.InvoiceValue,0) - (ISNULL(PT.PaymentAmount,0) - CASE WHEN  ISNULL(PT.PaymentAmount,0) > 0 THEN InvoiceVat ELSE 0 END)) AS DueAmount FROM tblInvoice AS I with (nolock)
LEFT JOIN tblOrder AS ODR with (nolock) ON I.OrderId = ODR.OrderId
 LEFT JOIN tblCustMaster C WITH (NOLOCK) ON C.CustomerMasterId = ODR.CustomerMasterId 
LEFT JOIN tblRegion AS CLS with (nolock) ON ODR.RegionCode_Ord = CLS.RegionCode
LEFT JOIN tblArea AS RGN with (nolock) ON ODR.AreaCode_Ord = RGN.AreaCode 
LEFT JOIN tblTerritory AS ARA with (nolock) ON ODR.TerritoryCode_Ord  = ARA.TerritoryCode
LEFT JOIN tblSubTerritory AS TTR with (nolock) ON ODR.SubTerritoryCode_Ord = TTR.SubTerritoryCode 
LEFT JOIN tblEmpGeneralInfo AS MBE with (nolock) ON ODR.MBEEmpInfoId = MBE.EmpInfoId
LEFT JOIN tblEmpGeneralInfo AS MIO with (nolock) ON ODR.MIOId = MIO.EmpInfoId 
LEFT JOIN tblEmpGeneralInfo AS ASM with (nolock) ON ODR.ASMId = ASM.EmpInfoId
LEFT JOIN tblEmpGeneralInfo AS RSM with (nolock) ON ODR.RSMId = RSM.EmpInfoId 
LEFT JOIN (SELECT T.InvoiceId,SUM(ODRD.TotalTradePrice) OrderValue FROM tblInvoice AS T
LEFT JOIN tblInvoiceDetail AS TID ON T.InvoiceId = TID.InvoiceId 
LEFT JOIN tblOrderDetail AS ODRD ON TID.OrderDetailsId = ODRD.OrderDetailId GROUP BY T.InvoiceId) AS OV ON I.InvoiceId = OV.InvoiceId
LEFT JOIN (SELECT T.InvoiceId,SUM(TID.TotalPrice) AS ProformaValue FROM tblInvoice AS T
LEFT JOIN tblInvoiceDetail AS TID ON T.InvoiceId = TID.InvoiceId
LEFT JOIN tblOrder AS TODR ON T.OrderId = TODR.OrderId GROUP BY T.InvoiceId) AS PV ON I.InvoiceId = PV.InvoiceId
LEFT JOIN (SELECT T.InvoiceId,SUM(TID.DeliveryTotalPrice) InvoiceValue,SUM(TID.DeliveryTotalPriceVatAmount) InvoiceVat FROM tblInvoice AS T
LEFT JOIN tblInvoiceDetail AS TID ON T.InvoiceId = TID.InvoiceId
LEFT JOIN tblOrder AS TODR ON T.OrderId = TODR.OrderId WHERE DeliveryInvoiceStatus IN ('Full','Partial') GROUP BY T.InvoiceId) AS IV ON I.InvoiceId = IV.InvoiceId
LEFT JOIN (SELECT T.InvoiceId,SUM(TID.TotalPrice) OnDelivery FROM tblInvoice AS T
LEFT JOIN tblInvoiceDetail AS TID ON T.InvoiceId = TID.InvoiceId
LEFT JOIN tblOrder AS TODR ON T.OrderId = TODR.OrderId WHERE DeliveryInvoiceStatus IS NULL GROUP BY T.InvoiceId) AS ODV ON I.InvoiceId = ODV.InvoiceId
LEFT JOIN (SELECT T.InvoiceId,SUM(TID.TotalPrice-ISNULL(TID.DeliveryTotalPrice,0)) ReturnValue FROM tblInvoice AS T
LEFT JOIN tblInvoiceDetail AS TID ON T.InvoiceId = TID.InvoiceId
LEFT JOIN tblOrder AS TODR ON T.OrderId = TODR.OrderId WHERE DeliveryInvoiceStatus IN ('Reject','Partial') GROUP BY T.InvoiceId) AS RV ON I.InvoiceId = RV.InvoiceId
LEFT JOIN (SELECT CP.InvoiceId,SUM(CP.PaymentAmount) AS PaymentAmount FROM tblCustPayDetail AS CP GROUP BY CP.InvoiceId) AS PT ON I.InvoiceId = PT.InvoiceId) AS SLS 
LEFT JOIN (SELECT DISTINCT TerritoryCode,TC.TotalTargetByTp TotalTargetByTpVat,TG.Year,TG.Month FROM tbl_Target_MIOWiseTargetSetup AS TGD
LEFT JOIN tbl_Target_MIOTargetSetupMaster AS TG ON TGD.MioTargetMasterId = TG.MioTargetMasterId
LEFT JOIN tbl_Target_CategoryMaster AS TC ON TGD.TargetCategoryId = TC.TargetId  WHERE TerritoryCode IS NOT NULL  ) AS TGT ON SLS.TerritoryCode = TGT.TerritoryCode WHERE  ClusterCode IS NOT NULL     GROUP BY  InvoiceDate,   MBEId, MIOId, ASMId, RSMId, CustomerCode, CustomerName, EmpMasterCode,ClusterCode,ClusterHead,RegionCode,RSM,AreaCode,ASM,SLS.TerritoryCode,MBECode,MBE,TGT.TotalTargetByTpVat ) AS CLSH WHERE CLSH.TerritoryCode IS NOT NULL  GROUP BY InvoiceDate,  MBEId, MIOId, ASMId, RSMId, CustomerCode, CustomerName,  ClusterCode,RegionCode,AreaCode,CLSH.TerritoryCode,MBECode,CLSH.MBE)SLS where SLS.InvoiceDate is not null    " + parm + @"
GROUP BY InvoiceDate, MBEId, MIOId, ASMId, RSMId, SLS.CustomerCode, SLS.CustomerName";
            //and tblCutting.CuttingQty>0 
            return para;

        }


        public CWSRDAO  GetCustWiseOrderReportDAL(string Role, string empId, string Month, string Year, string type)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                aSqlParameterlist.Add(new SqlParameter("@Role", Role ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@Month", Month ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@Year", Year ?? (object)DBNull.Value ?? (object)DBNull.Value));

                DataTable dtDoctor = new DataTable();
                DataTable dt = new DataTable();
                if (type == "Order")
                {

                    List<SqlParameter> aSqlParameterlist2 = new List<SqlParameter>();
                    aSqlParameterlist2.Add(new SqlParameter("@Parameter", Query(empId, Role, Month, Year)));
                    dt = accessManager.GetDataTable("sp_GET_SummaryReportCustomerWise", aSqlParameterlist2);

                    //dtDoctor = accessManager.GetDataTable("sp_Webapi_GetCustWiseOrderReportSum", aSqlParameterlist);

                    //dt = accessManager.GetDataTable("sp_Webapi_GetCustWiseOrderReport", aSqlParameterlist);
                }
                if (type == "Sales")
                {

                    //List<SqlParameter> aSqlParameterlist2 = new List<SqlParameter>();
                    //aSqlParameterlist2.Add(new SqlParameter("@Parameter", Query(empId, Role, Month, Year)));
                    dt = accessManager.GetDataTable("sp_Webapi_GetCustomerWiseSalesReport", aSqlParameterlist);
                }


                    CWSRDAO aDetails = new CWSRDAO();

                if (dt.Rows.Count > 0)
                {
                    aDetails = new CWSRDAO();
                    int ordered_qty = dt.AsEnumerable().Sum(row => row.Field<int>("ordered_qty"));
                   
                    decimal ordered_value = 0;

                    if (type == "Order")
                    {
                        ordered_value = dt.AsEnumerable().Sum(row => row.Field<decimal>("ordered_value"));

                    }

                    if (type == "Sales")
                    {
                        ordered_value = dt.AsEnumerable().Sum(row => row.Field<decimal>("InvoiceValue"));

                    }


                    aDetails.total_qty = (ordered_qty.ToString());
                    aDetails.total_amount = (ordered_value.ToString());



                    List<CWSData> aDetailsListDD = new List<CWSData>();
                    CWSData aChemberDetails;
                    for (var ch = 0; ch < dt.Rows.Count; ch++)

                    {

                        aChemberDetails = new CWSData();
                         
                            aChemberDetails.SN = (dt.Rows[ch]["SN"].ToString());
                            aChemberDetails.customer_name = (dt.Rows[ch]["customer_name"].ToString());
                        aChemberDetails.ordered_qty = (dt.Rows[ch]["ordered_qty"].ToString());

                        if (type == "Order")
                        {
                            aChemberDetails.ordered_value = (dt.Rows[ch]["ordered_value"].ToString());

                        }

                        if (type == "Sales")
                        {
                            aChemberDetails.ordered_value = (dt.Rows[ch]["InvoiceValue"].ToString());

                        }
                     
                     

                        aDetailsListDD.Add(aChemberDetails);
                    }
                    aDetails.cwsDataList = aDetailsListDD;




                }






                return aDetails;

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

        public EmployeeWiseTotalDAO GetEmployeeWiseTotalCountDAL( string empId, string Date)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();

                aSqlParameterlist.Add(new SqlParameter("@EmpId", empId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                aSqlParameterlist.Add(new SqlParameter("@currentDate", Date ?? (object)DBNull.Value ?? (object)DBNull.Value));

                DataTable dtDoctor = new DataTable();
                dtDoctor = accessManager.GetDataTable("sp_Get_TotalCountForEmployee", aSqlParameterlist);
                EmployeeWiseTotalDAO aDetails = new EmployeeWiseTotalDAO();

                aDetails.TotalOrder = (dtDoctor.Rows[0]["TotalOrder"].ToString());
                aDetails.totalDcr = (dtDoctor.Rows[0]["totalDcr"].ToString());
                aDetails.TotalRX = (dtDoctor.Rows[0]["TotalRX"].ToString());

             

                return aDetails;

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

            public  PWSRDAO GetProductWiseOrderReportDAL(string Role, string empId, string Month, string Year, string type)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                aSqlParameterlist.Add(new SqlParameter("@Role", Role ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@Month", Month ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@Year", Year ?? (object)DBNull.Value ?? (object)DBNull.Value));
                DataTable dtDoctor = new DataTable();
                DataTable dt = new DataTable();
                if(type=="Order")
                { 
              //  dtDoctor = accessManager.GetDataTable("sp_Webapi_GetProductWiseOrderReportSum", aSqlParameterlist);

                  dt = accessManager.GetDataTable("sp_Webapi_GetProductWiseOrderReport", aSqlParameterlist);
                }
                if (type == "Sales")
                {
                  //  dtDoctor = accessManager.GetDataTable("sp_Webapi_GetProductWiseSalesReportSum", aSqlParameterlist);

                    dt = accessManager.GetDataTable("sp_Webapi_GetProductWiseSalesReport", aSqlParameterlist);
                }
                    PWSRDAO aDetails= new PWSRDAO();

                if (dt.Rows.Count>0)
                {
                    aDetails = new PWSRDAO();



                    int? order_times = dt.AsEnumerable().Sum(row => row.Field<int?>("order_times"));
                    int? ordered_qty = dt.AsEnumerable().Sum(row => row.Field<int?>("ordered_qty"));

                    decimal? ordered_value = dt.AsEnumerable().Sum(row => row.Field<decimal?>("ordered_value"));
                    aDetails.total_ot = order_times.ToString();
                    aDetails.total_qty = (ordered_qty.ToString());
                    aDetails.total_amount = (ordered_value.ToString());




                    List<pwsDataLists> aDetailsListDD = new List<pwsDataLists>();
                    pwsDataLists aChemberDetails;
                    for (var ch = 0; ch < dt.Rows.Count; ch++)

                    {

                        aChemberDetails = new pwsDataLists();
                        aChemberDetails.SN = (dt.Rows[ch]["SN"].ToString());
                        aChemberDetails.product_name = (dt.Rows[ch]["product_name"].ToString());
                        aChemberDetails.ordered_qty = (dt.Rows[ch]["ordered_qty"].ToString());
                        aChemberDetails.order_times = (dt.Rows[ch]["order_times"].ToString());
                        aChemberDetails.ordered_value = (dt.Rows[ch]["ordered_value"].ToString());

                        aDetailsListDD.Add(aChemberDetails);
                    }
                    aDetails.pwsDataList = aDetailsListDD;

                  
                    aDetails.pwsDataList = aDetailsListDD;


                }






                return aDetails;

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




        public DataTable GetDoctorPendingReject(int empId, string   ApprovalStatus)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                aSqlParameterlist.Add(new SqlParameter("@ApprovalStatus", ApprovalStatus));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorPendingReject", aSqlParameterlist);
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

        public DataTable GetDoctorPendingRejects(int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId)); 
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorAll", aSqlParameterlist);
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

        public DataTable GetDWSPReport_Emp(string MonthValue, string Year, string Role, string EmpId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB); 
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@MonthValue", MonthValue));
                gSqlParameterList.Add(new SqlParameter("@Year", Year));
                gSqlParameterList.Add(new SqlParameter("@Role", Role));
               
                List<SqlParameter> gSqlEmp = new List<SqlParameter>();
                gSqlEmp.Add(new SqlParameter("@EmployeeId", (EmpId)));
                gSqlEmp.Add(new SqlParameter("@Role", Role));
                DataTable dt = new DataTable();
                DataTable dtEmp = accessManager.GetDataTable("sp_Webapi_Get_RSM_DZSMByRole", gSqlEmp);

                if (dtEmp.Rows.Count > 0)
                {
                   

                  

                    if (Role == "AM") {
                        EmpId = dtEmp.Rows[0]["EmpAreaId"].ToString();
                        gSqlParameterList.Add(new SqlParameter("@EmpId", EmpId));
                        dt = accessManager.GetDataTable("sp_WEBAPI_Process_DWSPReportAM", gSqlParameterList); }

                    if (Role == "DZSM") {
                        EmpId = dtEmp.Rows[0]["EmpRegionId"].ToString();
                        gSqlParameterList.Add(new SqlParameter("@EmpId", EmpId));
                        dt = accessManager.GetDataTable("sp_WEBAPI_Process_DWSPReportDZSM", gSqlParameterList); }
                }

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
        public DataTable GetDoctorUpdateInfoDAL(int empId, string GroupId, string ZoneId, string AreaId, string TerritoryId, string SubTerritoryId, string MarketId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@empId", empId));
                gSqlParameterList.Add(new SqlParameter("@GroupId_", GroupId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ZoneId_", ZoneId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@AreaId_", AreaId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@TerritoryId", TerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@SubTerritoryId", SubTerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@MarketId", MarketId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorAllIsMarketUpdate2022", gSqlParameterList);
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

        public DataTable GetCampaingDaa(int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_CampaingData", aSqlParameterlist);
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


        public IList<CampaingDAO> GetCampaingDaaNewDAL(int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@empId", empId));
                 

                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_CampaingData", gSqlParameterList);
                //SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_Get_DoctorClaimApp", gSqlParameterList);
                List<CampaingDAO> aList = new List<CampaingDAO>();
                for (var i = 0; i < dt.Rows.Count; i++)

                {
                    CampaingDAO aInfo = new CampaingDAO();


                    if (dt.Rows[i]["CampgainMasterId"] != DBNull.Value)
                    {
                        aInfo.CampgainMasterId = Convert.ToInt32(dt.Rows[i]["CampgainMasterId"].ToString());
                    }

                 
                    if (dt.Rows[i]["CampaignCode"] != DBNull.Value)
                    {
                        aInfo.CampaignCode = (dt.Rows[i]["CampaignCode"].ToString());
                    }


                    if (dt.Rows[i]["CampaignDesc"] != DBNull.Value)
                    {
                        aInfo.CampaignDesc = (dt.Rows[i]["CampaignDesc"].ToString());
                    }
                    if (dt.Rows[i]["CampaignName"] != DBNull.Value)
                    {
                        aInfo.CampaignName = (dt.Rows[i]["CampaignName"].ToString());
                    }
                    if (dt.Rows[i]["FromDate"] != DBNull.Value)
                    {
                        aInfo.FromDate = (dt.Rows[i]["FromDate"].ToString());
                    }

                    if (dt.Rows[i]["Todate"] != DBNull.Value)
                    {
                        aInfo.Todate = (dt.Rows[i]["Todate"].ToString());
                    }
                    if (dt.Rows[i]["Todate"] != DBNull.Value)
                    {
                        aInfo.Todate = (dt.Rows[i]["Todate"].ToString());
                    }


                    List<SqlParameter> aSqlParameterListDetals = new List<SqlParameter>();

                    aSqlParameterListDetals.Add(new SqlParameter("@id", aInfo.CampgainMasterId));
                    DataTable dtDoctor = accessManager.GetDataTable("sp_Webapi_GET_CampaignDetail_ById", aSqlParameterListDetals);

                    List<CampaingDtls> aDetailsList = new List<CampaingDtls>();
                    CampaingDtls aDetails;


                    aDetails = new CampaingDtls();

                    for (var ch = 0; ch < dtDoctor.Rows.Count; ch++)

                    {

                        if (dtDoctor.Rows[ch]["OfferTypeName"] != DBNull.Value)
                    {
                        aDetails.OfferTypeName = (dtDoctor.Rows[ch]["OfferTypeName"].ToString());
                    }

                    if (dtDoctor.Rows[ch]["ProductName"] != DBNull.Value)
                    {
                        aDetails.ProductName = (dtDoctor.Rows[ch]["ProductName"].ToString());
                    }
                    if (dtDoctor.Rows[ch]["Qty"] != DBNull.Value)
                    {
                        aDetails.Qty = (dtDoctor.Rows[ch]["Qty"].ToString());
                    }

                        aDetailsList.Add(aDetails);

                    }
                    aInfo.CampaingDetails = aDetailsList;

                   




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

        public DataTable GetTargetvsAcchivementData(int empId,int month,int year)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                aSqlParameterlist.Add(new SqlParameter("@month", month));
                aSqlParameterlist.Add(new SqlParameter("@year", year));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_TargetVsAcchivementData", aSqlParameterlist);
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
        public DataTable GetMonthlyTarvsAchiv(string empId, string month, string year, string Type)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                aSqlParameterlist.Add(new SqlParameter("@month", month));
                aSqlParameterlist.Add(new SqlParameter("@year", year));
                aSqlParameterlist.Add(new SqlParameter("@Type", Type));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_MonthlyTargetVsAcchivementData", aSqlParameterlist);
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
        public DataTable GetTadaList(int userId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@userId", userId));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_TADAClist", aSqlParameterlist);
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






        public   Grand_Total  GetExpenseSummeryDAL(string Role, string empId, string Month,   string year)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                List<SqlParameter> aSqlAll = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                
                aSqlParameterlist.Add(new SqlParameter("@Role", Role ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@Month", Month ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@Year", year ?? (object)DBNull.Value ?? (object)DBNull.Value));

                aSqlAll.Add(new SqlParameter("@empId", empId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                DataTable dtDoctor = accessManager.GetDataTable("sp_Webapi_Get_EmployyeMonthlyExpenseSum", aSqlParameterlist);
                DataTable dtAllowences = accessManager.GetDataTable("sp_Webapi_Get_EmpAllawance_Monthly", aSqlAll);

                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_EmployyeMonthlyExpense", aSqlParameterlist);


              
                Grand_Total aDetails= new Grand_Total();

                if (dtDoctor.Rows[0]["GrandTotal"] != DBNull.Value)
                {
                    aDetails = new Grand_Total();
                    aDetails.GrandTotal = (dtDoctor.Rows[0]["GrandTotal"].ToString());
                    aDetails.Allowences = (dtAllowences.Rows[0]["Allowences"].ToString());




                    List<Expense_List> aDetailsListDD = new List<Expense_List>();
                    Expense_List aChemberDetails;
                    for (var ch = 0; ch < dt.Rows.Count; ch++)

                    {

                        aChemberDetails = new Expense_List();
                        if (dt.Rows[ch]["daAmount"] != DBNull.Value)
                        {
                            aChemberDetails.daAmount = (dt.Rows[ch]["daAmount"].ToString());
                        }
                         if (dt.Rows[ch]["MarketTourType"] != DBNull.Value)
                        {
                            aChemberDetails.MarketTourType = (dt.Rows[ch]["MarketTourType"].ToString());
                        }

                        if (dt.Rows[ch]["date"] != DBNull.Value)
                        {
                            aChemberDetails.date = (dt.Rows[ch]["date"].ToString());
                        }


                        if (dt.Rows[ch]["mileageAmount"] != DBNull.Value)
                        {
                            aChemberDetails.mileageAmount = (dt.Rows[ch]["mileageAmount"].ToString());
                        }


                        if (dt.Rows[ch]["expenseAmount"] != DBNull.Value)
                        {
                            aChemberDetails.expenseAmount = (dt.Rows[ch]["expenseAmount"].ToString());
                        }


                        if (dt.Rows[ch]["totalAmount"] != DBNull.Value)
                        {
                            aChemberDetails.totalAmount = (dt.Rows[ch]["totalAmount"].ToString());
                        }
 
                        aDetailsListDD.Add(aChemberDetails);
                    }
                    aDetails.Expense_Lists = aDetailsListDD;

                    

                }






                return aDetails;

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

        public ResultInfo ChangePasswordDAL(string empId, string OldPass, String NewPass)
        {

            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@empId", empId));
                gSqlParameterList.Add(new SqlParameter("@OldPass", OldPass));
                gSqlParameterList.Add(new SqlParameter("@NewPass", NewPass));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_CheckOld_Password", gSqlParameterList);

                if (dt.Rows.Count == 1)
                {
                    aInformation.isSuccess = accessManager.UpdateData("sp_Webapi_Update_Password", gSqlParameterList);

                }
                else
                {
                    aInformation.Msd = "Old Password is not correct!";
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

        public OnOffButtonForCustomerDAO GetOnOffButtonForCustomerChangeDAL()
        {
            OnOffButtonForCustomerDAO aInformation = new OnOffButtonForCustomerDAO();
            try
            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);



                 

               

                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_OnOffButtonForCustomerChange");
                DataTable dtMS = accessManager.GetDataTable("sp_Webapi_Get_OnOffButtonForCustomerChange_MS");

                if (dt.Rows.Count > 0)
                {
                    aInformation.btnCustProvider = Convert.ToInt32(dt.Rows[0]["btnCustProvider"].ToString());
                    
                }
                else
                {
                    aInformation.btnCustProvider =0;
                    
                }

                if (dtMS.Rows.Count > 0)
                {
                     aInformation.btnCustMS = Convert.ToInt32(dtMS.Rows[0]["btnCustMS"].ToString());

                }
                else
                {
                    
                    aInformation.btnCustMS = 0;
                }




                DataTable dtDoc = accessManager.GetDataTable("sp_Webapi_Get_OnOffButtonForDocChange");
                DataTable dtDocMS = accessManager.GetDataTable("sp_Webapi_Get_OnOffButtonForDocChange_MS");
                if (dtDoc.Rows.Count > 0)
                {
                    aInformation.btnDocProvider = Convert.ToInt32(dtDoc.Rows[0]["btnDocProvider"].ToString());

                }
                else
                {
                    aInformation.btnDocProvider = 0;

                }

                if (dtDocMS.Rows.Count > 0)
                {
                    aInformation.btnDocMS = Convert.ToInt32(dtDocMS.Rows[0]["btnDocMS"].ToString());

                }
                else
                {

                    aInformation.btnDocMS = 0;
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

    }
}