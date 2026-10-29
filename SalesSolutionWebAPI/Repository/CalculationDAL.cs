using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Repository
{
    public class CalculationDAL
    {
        private DataAccessManager accessManager = new DataAccessManager();


        public DataTable Get_TourPlanForTadaClaim(int empId,DateTime tourDate)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                aSqlParameterlist.Add(new SqlParameter("@tourDate", tourDate));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_TourPlanDataForTadaClaim", aSqlParameterlist);
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


        public ResultInfo SaveTadaClaim(TadaClaim aInfo)
        {


            ResultInfo aInformation = new ResultInfo();
            try

            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@tadaDate", aInfo.TadaDate));
                gSqlParameterList.Add(new SqlParameter("@empId", aInfo.EmpInfoId));
                gSqlParameterList.Add(new SqlParameter("@remarks", aInfo.Remarks));
                gSqlParameterList.Add(new SqlParameter("@type", aInfo.TourType));
                gSqlParameterList.Add(new SqlParameter("@HotelName", aInfo.HotelName));
                gSqlParameterList.Add(new SqlParameter("@HotelPhone", aInfo.HotelPhone));
                gSqlParameterList.Add(new SqlParameter("@id", aInfo.id));
                gSqlParameterList.Add(new SqlParameter("@NewTourTypeId", aInfo.NewTourTypeId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                 
                int pk = 0;
                pk = accessManager.SaveDataReturnPrimaryKey("sp_Webapi_Save_TadaClaim", gSqlParameterList);

                if (pk>0)
                {
                    aInformation.isSuccess = true;
                }
                if (aInformation.isSuccess)
                {
                    if (aInfo.ImageString != null)
                    {
                        if (aInfo.ImageString != "")
                        {
                            AppPrimaryDAL app = new AppPrimaryDAL();
                            ImagePath _path = new ImagePath();
                            string type = "DAClaim";
                            _path = app.GetImagePath(type);



                            string targetPath = @"" + _path.ImagePathValue + "";


                            if (!System.IO.Directory.Exists(targetPath))
                            {
                                System.IO.Directory.CreateDirectory(targetPath);
                            }

                            string filePath = targetPath + "/" + _path.ImagePreName + pk + "." + "jpg";
                            File.WriteAllBytes(filePath, Convert.FromBase64String(aInfo.ImageString));
                        }

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


        #region ExpenseCLaim
        public DataTable Get_ExpenseType()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_ExpenseType");
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
        public DataTable Get_ExpenseTypeDetails(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter> { 
                new SqlParameter("@id",id)
                };
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_ExpenseTypeDetails", aSqlParameterlist);
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
        public ResultInfo SaveExpenseClaim(ExpenseClaimMaster aInfo)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@typeid", aInfo.ExpenseTypeId));
                gSqlParameterList.Add(new SqlParameter("@expDate", aInfo.ExpenseDate));
                gSqlParameterList.Add(new SqlParameter("@empId", aInfo.EmpInfoId));
                gSqlParameterList.Add(new SqlParameter("@amount", aInfo.Amount));
                gSqlParameterList.Add(new SqlParameter("@remarks", aInfo.Remarks));
                gSqlParameterList.Add(new SqlParameter("@isFromApp", aInfo.IsFromApp));
                int pk = 0;

                if (aInfo.ExpenseClaimID > 0)
                {

                     gSqlParameterList.Add(new SqlParameter("@id", aInfo.ExpenseClaimID));
                    //List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                    //aSqlParameterList.Add(new SqlParameter("@ExpenseDate", aInfo.ExpenseDate));

                    //aSqlParameterList.Add(new SqlParameter("@id", aInfo.ExpenseClaimID)); 
                    //aSqlParameterList.Add(new SqlParameter("@EmpInfoId", aInfo.EmpInfoId));
                   

                    //aSqlParameterList.Add(new SqlParameter("@typeid", aInfo.ExpenseTypeId));
                    //DataTable dt = accessManager.GetDataTable("sp_Webapi_check_ExpenseClaim", aSqlParameterList);
                    //if (dt.Rows.Count == 0)
                    {

                        aInformation.isSuccess = accessManager.UpdateData("sp_Webapi_Update_ExpenseClaim", gSqlParameterList);

                        pk = aInfo.ExpenseClaimID;
                    }
                    //else
                    //{
                    //    pk = 0;
                    //}

                }
                else
                {
                    pk = accessManager.SaveDataReturnPrimaryKey("sp_Webapi_Save_ExpenseClaimMaster", gSqlParameterList);
                  
                }
 
            

            
             
                if (pk > 0)
                {
                    aInformation.isSuccess = true;
                    if (aInfo.aDetailList != null)
                    {
                        foreach (ExpenseClaimDetails item in aInfo.aDetailList)
                        {
                            List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                  
                            aSqlParameterList.Add(new SqlParameter("@pk", pk));
                            aSqlParameterList.Add(new SqlParameter("@typeDetailsId", item.ExpenseTypDetailsId));
                            aSqlParameterList.Add(new SqlParameter("@vStr", item.ValueText));
                            aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_ExpenseClaimDetails", aSqlParameterList);

                        }
                    }

                    if (!string.IsNullOrEmpty(aInfo.ImageBase64String))
                    {
                        AppPrimaryDAL app = new AppPrimaryDAL();
                        ImagePath _path = new ImagePath();
                        string type = "Expense";
                        _path = app.GetImagePath(type);




                        //string targetPath = @"E:\ZasImage";
                        string targetPath = @"" + _path.ImagePathValue + "";
                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }

                        string filePath = targetPath + "/" + _path.ImagePreName + pk + "." + "jpg";
                        File.WriteAllBytes(filePath, Convert.FromBase64String(aInfo.ImageBase64String));
                    }



                }
                else
                {
                    aInformation.isSuccess = false;
                    aInformation.isValiCheck = true;
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




        public IList<ExpenseClaimMasterDAO> GetExpenseList(string monthValue, string yearValue, string statusTxt, string empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter> {
                new SqlParameter("@monthValue",monthValue ?? (object)DBNull.Value ?? (object)DBNull.Value),
                new SqlParameter("@yearValue",yearValue ?? (object)DBNull.Value ?? (object)DBNull.Value),
                new SqlParameter("@statusTxt",statusTxt?? (object)DBNull.Value ?? (object)DBNull.Value),
                new SqlParameter("@empId",empId?? (object)DBNull.Value ?? (object)DBNull.Value)
                };
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_ExpenseClaimList", aSqlParameterlist);
                //SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_Get_ExpenseClaimList", aSqlParameterlist);
                List<ExpenseClaimMasterDAO> aList = new List<ExpenseClaimMasterDAO>();


                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    ExpenseClaimMasterDAO aInfo = new ExpenseClaimMasterDAO();

                    if (dt.Rows[i]["ExpenseClaimID"] != DBNull.Value)
                    {
                        aInfo.ExpenseClaimID = (dt.Rows[i]["ExpenseClaimID"].ToString());
                    }

                    if (dt.Rows[i]["ExpenseTypeId"] != DBNull.Value)
                    {
                        aInfo.ExpenseTypeId = (dt.Rows[i]["ExpenseTypeId"].ToString());
                    }
                    if (dt.Rows[i]["ExpDate"] != DBNull.Value)
                    {
                        aInfo.ExpDate = dt.Rows[i]["ExpDate"].ToString();
                    }
                    if (dt.Rows[i]["EmpName"] != DBNull.Value)
                    {
                        aInfo.EmpName = dt.Rows[i]["EmpName"].ToString();
                    }
                    if (dt.Rows[i]["ExpenseTypeName"] != DBNull.Value)
                    {
                        aInfo.ExpenseTypeName = dt.Rows[i]["ExpenseTypeName"].ToString();
                    }
                    if (dt.Rows[i]["ApprovalStatus"] != DBNull.Value)
                    {
                        aInfo.ApprovalStatus = dt.Rows[i]["ApprovalStatus"].ToString();
                    }
                    if (dt.Rows[i]["Amount"] != DBNull.Value)
                    {
                        aInfo.Amount = dt.Rows[i]["Amount"].ToString();
                    }
                    if (dt.Rows[i]["Remarks"] != DBNull.Value)
                    {
                        aInfo.Remarks = dt.Rows[i]["Remarks"].ToString();
                    }

                    if (dt.Rows[0]["ImageString"] != DBNull.Value)
                    {
                        aInfo.ImageString = dt.Rows[0]["ImageString"].ToString();
                    }
                    if (dt.Rows[i]["ImageString"] != DBNull.Value)
                    {
                        aInfo.ImageString = dt.Rows[i]["ImageString"].ToString();
                    }

                    List<SqlParameter> aSqlParameterListDetals = new List<SqlParameter>();

                            aSqlParameterListDetals.Add(new SqlParameter("@ExpenseClaimID", aInfo.ExpenseClaimID));
                            DataTable dtDtls = accessManager.GetDataTable("sp_Webapi_Get_ExpenseClaimListDetaisl", aSqlParameterListDetals);

                    List<ExpenseClaimDetailsDAO> aDetailsList = new List<ExpenseClaimDetailsDAO>();
                    ExpenseClaimDetailsDAO aDetails;
                    for (var kk = 0; kk < dtDtls.Rows.Count; kk++)
                    
                        {

                        aDetails = new ExpenseClaimDetailsDAO();
                        if (dtDtls.Rows[kk]["ValueText"] != DBNull.Value)
                        {
                            aDetails.ValueText = dtDtls.Rows[kk]["ValueText"].ToString();
                        }
                        if (dtDtls.Rows[kk]["FieldName"] != DBNull.Value)
                        {
                            aDetails.FieldName = dtDtls.Rows[kk]["FieldName"].ToString();
                        }

                        if (dtDtls.Rows[kk]["ExpenseTypDetailsId"] != DBNull.Value)
                        {
                            aDetails.ExpenseTypDetailsId = Convert.ToInt32(dtDtls.Rows[kk]["ExpenseTypDetailsId"].ToString());
                        }
                        aDetailsList.Add(aDetails);
                    }
                    aInfo.aDetailListDAO = aDetailsList;


                    //if (dr["Announcement"] != DBNull.Value)
                    //{
                    //    aInfo.Announcement = dr["Announcement"].ToString();

                    //}
                    //if (dr["FromDate"] != DBNull.Value)
                    //{
                    //    aInfo.FromDate = dr["FromDate"].ToString();
                    //}
                    //if (dr["ToDate"] != DBNull.Value)
                    //{
                    //    aInfo.ToDate = dr["ToDate"].ToString();
                    //}

                    //if (dr["IsAppCheck"] != DBNull.Value)
                    //{
                    //    aInfo.IsAppCheck = Convert.ToBoolean(dr["IsAppCheck"].ToString());
                    //}
                    //string imagefullpath = (dr["ImagePreName"].ToString() + ((int)dr["NoticeId"]).ToString() + ".jpg");


                    //try
                    //{
                    //    byte[] imageArray = System.IO.File.ReadAllBytes(@imagefullpath);
                    //    aInfo.ImageString = Convert.ToBase64String(imageArray);
                    //    aInfo.ImagePreName = imagefullpath;

                    //}
                    //catch (Exception ex)
                    //{

                    //}
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

        public DataTable Get_ExpenseCLaimList(int monthValue,int yearValue,string statusTxt,int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter> {
                new SqlParameter("@monthValue",monthValue),
                new SqlParameter("@yearValue",yearValue),
                new SqlParameter("@statusTxt",statusTxt),
                new SqlParameter("@empId",empId)
                };
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_ExpenseClaimList", aSqlParameterlist);
                DataTable dtDtls = new DataTable();
                int masId = 0;
                for(var i = 0; i < dt.Rows.Count; i++)
                {


                    masId = Convert.ToInt32(dt.Rows[i]["ExpenseClaimID"].ToString());

                    List<SqlParameter> aSqlParameterListDetals = new List<SqlParameter>();

                    aSqlParameterListDetals.Add(new SqlParameter("@ExpenseClaimID", masId));
                      dtDtls = accessManager.GetDataTable("sp_Webapi_Get_ExpenseClaimListDetaisl", aSqlParameterListDetals);

                 }

                // AppPrimaryDAL app = new AppPrimaryDAL();
                // ImagePath _path = new ImagePath();
                // string type = "Expense";
                // _path = app.GetImagePath(type);

                //int pk =0;


                // try
                // {
                //     pk = Convert.ToInt32(dt.Rows[0]["ExpenseClaimID"].ToString());
                // }
                // catch(Exception ex)
                // {

                // }


                // string targetPath = @"" + _path.ImagePathValue + "";


                // if (!System.IO.Directory.Exists(targetPath))
                // {
                //     System.IO.Directory.CreateDirectory(targetPath);
                // }
                // string ImgSring = "";
                // string filePath = targetPath + "/" + _path.ImagePreName + pk + "." + "jpg";
                // File.WriteAllBytes(filePath, Convert.FromBase64String(ImgSring));

              

                return dtDtls;
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

        public DataTable Get_ExpenseClaimMasterData(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter> {
                new SqlParameter("@id",id)
                };
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_ExpenseClaimMasterDataById", aSqlParameterlist);
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


        public ResultInfo DeleteExpeseClaim(int id)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@id", id));
                aInformation.isSuccess = accessManager.UpdateData("sp_Webapi_Delete_ExpenseClaim", gSqlParameterList);

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


        public IList<TADA_ApplogDAO> GetTADA_Applog_DAL(string pram, string Role, string AppStatus,  string FromDt, string ToDt, string EmpId, string Month, string Year)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@Role", Role ?? (object)DBNull.Value ?? (object)DBNull.Value));
                pram = NewMethod(pram, Role, gSqlParameterList);
                gSqlParameterList.Add(new SqlParameter("@AppStatus", AppStatus ?? (object)DBNull.Value ?? (object)DBNull.Value));
             
                gSqlParameterList.Add(new SqlParameter("@FromDt", FromDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ToDt", ToDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EmpId", EmpId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@Month", Month ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Year", Year ?? (object)DBNull.Value ?? (object)DBNull.Value));



                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_TADAAppData", gSqlParameterList);

              
                List<TADA_ApplogDAO> aList = new List<TADA_ApplogDAO>();

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    TADA_ApplogDAO aInfo = new TADA_ApplogDAO();

                    if (dt.Rows[i]["ApprovalId"] != DBNull.Value)
                    {
                        aInfo.ApprovalId = Convert.ToInt32(dt.Rows[i]["ApprovalId"]);
                    }

                    if (dt.Rows[i]["EmpInfoId"] != DBNull.Value)
                    {
                        aInfo.EmpInfoId = Convert.ToInt32(dt.Rows[i]["EmpInfoId"].ToString());

                    }


                    if (dt.Rows[i]["TadaDate"] != DBNull.Value)
                    {
                        aInfo.TadaDate = (dt.Rows[i]["TadaDate"].ToString());
                    }


                    if (dt.Rows[i]["ApprovalStatus"] != DBNull.Value)
                    {
                        aInfo.ApprovalStatus = dt.Rows[i]["ApprovalStatus"].ToString();
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
                    DataTable dtDoctor = accessManager.GetDataTable("sp_webapi_GetTADAAppDataById", aSqlParameterListDetals);


                    DAMasterDAO aDetails;


                    aDetails = new DAMasterDAO();

                    if (dtDoctor.Rows[0]["TadaID"] != DBNull.Value)
                    {
                        aDetails.TadaID = Convert.ToInt32(dtDoctor.Rows[0]["TadaID"].ToString());
                    }
                    if (dtDoctor.Rows[0]["EmpInfoId"] != DBNull.Value)
                    {
                        aDetails.EmpInfoId = Convert.ToInt32(dtDoctor.Rows[0]["EmpInfoId"].ToString());
                    }

                    if (dtDoctor.Rows[0]["TadaDate"] != DBNull.Value)
                    {
                        aDetails.TadaDate = (dtDoctor.Rows[0]["TadaDate"].ToString());
                    }

                    if (dtDoctor.Rows[0]["EmpName"] != DBNull.Value)
                    {
                        aDetails.EmpName = dtDoctor.Rows[0]["EmpName"].ToString();
                    }


                    if (dtDoctor.Rows[0]["EmpName"] != DBNull.Value)
                    {
                        aDetails.EmpName = dtDoctor.Rows[0]["EmpName"].ToString();
                    }


                    if (dtDoctor.Rows[0]["DaAmt"] != DBNull.Value)
                    {
                        aDetails.DaAmt = Convert.ToDecimal(dtDoctor.Rows[0]["DaAmt"].ToString());
                    }


                    if (dtDoctor.Rows[0]["Remarks"] != DBNull.Value)
                    {
                        aDetails.Remarks = dtDoctor.Rows[0]["Remarks"].ToString();
                    }

                    if (dtDoctor.Rows[0]["MarketName"] != DBNull.Value)
                    {
                        aDetails.MarketName = dtDoctor.Rows[0]["MarketName"].ToString();
                    }

                    if (dtDoctor.Rows[0]["ApprovalStatus"] != DBNull.Value)
                    {
                        aDetails.ApprovalStatus = dtDoctor.Rows[0]["ApprovalStatus"].ToString();
                    }

                    if (dtDoctor.Rows[0]["ImageString"] != DBNull.Value)
                    {
                        aDetails.ImageString = dtDoctor.Rows[0]["ImageString"].ToString();
                    }

                    aInfo.aTADAMasterDAO = aDetails;






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


        public IList<ExpanseApprovalLogDAO> GetExpenseClaim_Applog_DAL(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>(); 
                gSqlParameterList.Add(new SqlParameter("@Role", Role ?? (object)DBNull.Value ?? (object)DBNull.Value));
                pram = NewMethod(pram, Role, gSqlParameterList);

                gSqlParameterList.Add(new SqlParameter("@AppStatus", AppStatus ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@FromDt", FromDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ToDt", ToDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EmpId", EmpId ?? (object)DBNull.Value ?? (object)DBNull.Value));


                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_ExpanseClaimApp", gSqlParameterList);


                List<ExpanseApprovalLogDAO> aList = new List<ExpanseApprovalLogDAO>();

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    ExpanseApprovalLogDAO aInfo = new ExpanseApprovalLogDAO();

                    if (dt.Rows[i]["ExpenseClaimID"] != DBNull.Value)
                    {
                        aInfo.ExpenseClaimID = Convert.ToInt32(dt.Rows[i]["ExpenseClaimID"]);
                    }

                    if (dt.Rows[i]["EmpInfoId"] != DBNull.Value)
                    {
                        aInfo.EmpInfoId = Convert.ToInt32(dt.Rows[i]["EmpInfoId"].ToString());

                    }

                    if (dt.Rows[i]["ExpenseTypeId"] != DBNull.Value)
                    {
                        aInfo.ExpenseTypeId = Convert.ToInt32(dt.Rows[i]["ExpenseTypeId"].ToString());
                    }
                    if (dt.Rows[i]["Amount"] != DBNull.Value)
                    {
                        aInfo.Amount = Convert.ToDecimal(dt.Rows[i]["Amount"]);
                    }
                    if (dt.Rows[i]["Remarks"] != DBNull.Value)
                    {
                        aInfo.Remarks = dt.Rows[i]["Remarks"].ToString();
                    }

                    if (dt.Rows[i]["ExpenseDate"] != DBNull.Value)
                    {
                        aInfo.ExpenseDate = (dt.Rows[i]["ExpenseDate"].ToString());
                    }


                    if (dt.Rows[i]["ApprovalStatus"] != DBNull.Value)
                    {
                        aInfo.ApprovalStatus = dt.Rows[i]["ApprovalStatus"].ToString();
                    }
                    if (dt.Rows[i]["ExpenseTypeName"] != DBNull.Value)
                    {
                        aInfo.ExpenseTypeName = dt.Rows[i]["ExpenseTypeName"].ToString();
                    }



                    if (dt.Rows[i]["ExpanseApprovalId"] != DBNull.Value)
                    {
                        aInfo.ExpanseApprovalId = Convert.ToInt32(dt.Rows[i]["ExpanseApprovalId"].ToString());
                    }


                    if (dt.Rows[i]["Date"] != DBNull.Value)
                    {
                        aInfo.Date = Convert.ToDateTime(dt.Rows[i]["Date"].ToString());
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

                    if (dt.Rows[i]["ImageString"] != DBNull.Value)
                    {
                        aInfo.ImageString = dt.Rows[i]["ImageString"].ToString();
                    }

                    List<SqlParameter> aSqlParameterListDetals = new List<SqlParameter>();

                    aSqlParameterListDetals.Add(new SqlParameter("@ExpenseClaimID", aInfo.ExpenseClaimID));
                    DataTable dtDtls = accessManager.GetDataTable("sp_Webapi_Get_ExpenseClaimListDetaisl", aSqlParameterListDetals);

                    List<ExpenseClaimDetailsDAO> aDetailsList = new List<ExpenseClaimDetailsDAO>();
                    ExpenseClaimDetailsDAO aDetails;
                    for (var kk = 0; kk < dtDtls.Rows.Count; kk++)

                    {

                        aDetails = new ExpenseClaimDetailsDAO();
                        if (dtDtls.Rows[kk]["ValueText"] != DBNull.Value)
                        {
                            aDetails.ValueText = dtDtls.Rows[kk]["ValueText"].ToString();
                        }
                        if (dtDtls.Rows[kk]["FieldName"] != DBNull.Value)
                        {
                            aDetails.FieldName = dtDtls.Rows[kk]["FieldName"].ToString();
                        }
                        aDetailsList.Add(aDetails);
                    }
                    aInfo.aDetailListDAO = aDetailsList;



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



        public IList<MileageClaimAppLog_DAO> GetMileageClaim_Applog_DAL(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, string Month, string Year)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@param", pram ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Role", Role ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@AppStatus", AppStatus ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@FromDt", FromDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ToDt", ToDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EmpId", EmpId ?? (object)DBNull.Value ?? (object)DBNull.Value));


                gSqlParameterList.Add(new SqlParameter("@Month", Month ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Year", Year ?? (object)DBNull.Value ?? (object)DBNull.Value));

                SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_Get_MileageAppData", gSqlParameterList);
                List<MileageClaimAppLog_DAO> aList = new List<MileageClaimAppLog_DAO>();

                while (dr.Read())
                {
                    MileageClaimAppLog_DAO aInfo = new MileageClaimAppLog_DAO();

                    if (dr["MileageClaimId"] != DBNull.Value)
                    {
                        aInfo.MileageClaimId = Convert.ToInt32(dr["MileageClaimId"]);
                    }

                    if (dr["EmpInfoId"] != DBNull.Value)
                    {
                        aInfo.EmpInfoId = Convert.ToInt32(dr["EmpInfoId"].ToString());

                    }
                    
                    if (dr["MileageDate"] != DBNull.Value)
                    {
                        aInfo.MileageDate =  (dr["MileageDate"].ToString());
                    }

                    if (dr["TransportName"] != DBNull.Value)
                    {
                        aInfo.TransportName = (dr["TransportName"].ToString());
                    }

                    if (dr["MarketName"] != DBNull.Value)
                    {
                        aInfo.MarketName = (dr["MarketName"].ToString());
                    }



                    if (dr["AllowedMilagePerKM"] != DBNull.Value)
                    {
                        aInfo.AllowedMilagePerKM = Convert.ToDecimal(dr["AllowedMilagePerKM"].ToString());
                    }
                    if (dr["MeterReading"] != DBNull.Value)
                    {
                        aInfo.MeterReading = Convert.ToDecimal(dr["MeterReading"].ToString());
                    }
                    if (dr["MileageInKM"] != DBNull.Value)
                    {
                        aInfo.MileageInKM = Convert.ToDecimal(dr["MileageInKM"].ToString());
                    }

                    if (dr["MileageAmount"] != DBNull.Value)
                    {
                        aInfo.MileageAmount = Convert.ToDecimal(dr["MileageAmount"].ToString());
                    }

                    if (dr["Remarks"] != DBNull.Value)
                    {
                        aInfo.Remarks = dr["Remarks"].ToString();
                    }


                    if (dr["ApprovalStatus"] != DBNull.Value)
                    {
                        aInfo.ApprovalStatus = dr["ApprovalStatus"].ToString();
                    }




                    if (dr["ApprovalId"] != DBNull.Value)
                    {
                        aInfo.ApprovalId = Convert.ToInt32(dr["ApprovalId"].ToString());
                    }


                    if (dr["Date"] != DBNull.Value)
                    {
                        aInfo.Date = Convert.ToDateTime(dr["Date"].ToString());
                    }

                    if (dr["FromEmpId"] != DBNull.Value)
                    {
                        aInfo.FromEmpId = Convert.ToInt32(dr["FromEmpId"].ToString());
                    }



                    if (dr["ToEmpId"] != DBNull.Value)
                    {
                        aInfo.ToEmpId = Convert.ToInt32(dr["ToEmpId"].ToString());
                    }
                    if (dr["TableId"] != DBNull.Value)
                    {
                        aInfo.TableId = Convert.ToInt32(dr["TableId"].ToString());
                    }
                    if (dr["Status"] != DBNull.Value)
                    {
                        aInfo.Status = dr["Status"].ToString();
                    }
                    if (dr["Comments"] != DBNull.Value)
                    {
                        aInfo.Comments = dr["Comments"].ToString();
                    }

                    if (dr["Type"] != DBNull.Value)
                    {
                        aInfo.Type = (dr["Type"].ToString());
                    }


                    if (dr["Step"] != DBNull.Value)
                    {
                        aInfo.Step = Convert.ToInt32(dr["Step"].ToString());
                    }





                    if (dr["FromEmpId"] != DBNull.Value)
                    {
                        aInfo.FromEmpId = Convert.ToInt32(dr["FromEmpId"].ToString());
                    }
                    if (dr["ToEmpId"] != DBNull.Value)
                    {
                        aInfo.ToEmpId = Convert.ToInt32(dr["ToEmpId"].ToString());
                    }


                    if (dr["TableId"] != DBNull.Value)
                    {
                        aInfo.TableId = Convert.ToInt32(dr["TableId"].ToString());
                    }

                    if (dr["Comments"] != DBNull.Value)
                    {
                        aInfo.Comments = dr["Comments"].ToString();
                    }

                    if (dr["Type"] != DBNull.Value)
                    {
                        aInfo.Type = dr["Type"].ToString();
                    }





                    if (dr["GroupId"] != DBNull.Value)
                    {
                        aInfo.GroupId = Convert.ToInt32(dr["GroupId"].ToString());
                    }

                    if (dr["RegionId"] != DBNull.Value)
                    {
                        aInfo.RegionId = Convert.ToInt32(dr["RegionId"].ToString());
                    }


                    if (dr["AreaId"] != DBNull.Value)
                    {
                        aInfo.AreaId = Convert.ToInt32(dr["AreaId"].ToString());
                    }


                    if (dr["TerritoryId"] != DBNull.Value)
                    {
                        aInfo.TerritoryId = Convert.ToInt32(dr["TerritoryId"].ToString());
                    }


                    if (dr["RoleTypeId"] != DBNull.Value)
                    {
                        aInfo.RoleTypeId = Convert.ToInt32(dr["RoleTypeId"].ToString());
                    }


                    if (dr["EmpMasterCode"] != DBNull.Value)
                    {
                        aInfo.EmpMasterCode = dr["EmpMasterCode"].ToString();
                    }


                    if (dr["EmpName"] != DBNull.Value)
                    {
                        aInfo.EmpName = dr["EmpName"].ToString();
                    }


                    if (dr["TerritoryName"] != DBNull.Value)
                    {
                        aInfo.TerritoryName = dr["TerritoryName"].ToString();
                    }

                    if (dr["TerritoryCode"] != DBNull.Value)
                    {
                        aInfo.TerritoryCode = dr["TerritoryCode"].ToString();
                    }

                    if (dr["AreaCode"] != DBNull.Value)
                    {
                        aInfo.AreaCode = dr["AreaCode"].ToString();
                    }


                    if (dr["ToRoleTypeId"] != DBNull.Value)
                    {
                        aInfo.ToRoleTypeId = Convert.ToInt32(dr["ToRoleTypeId"].ToString());
                    }

                    if (dr["MIOEmpId"] != DBNull.Value)
                    {
                        aInfo.MIOEmpId = Convert.ToInt32(dr["MIOEmpId"].ToString());
                    }

                    if (dr["ASMEMPId"] != DBNull.Value)
                    {
                        aInfo.ASMEMPId = Convert.ToInt32(dr["ASMEMPId"].ToString());
                    }

                    if (dr["RSMEMPId"] != DBNull.Value)
                    {
                        aInfo.RSMEMPId = Convert.ToInt32(dr["RSMEMPId"].ToString());
                    }
                    if (dr["NSMEMPId"] != DBNull.Value)
                    {
                        aInfo.NSMEMPId = Convert.ToInt32(dr["NSMEMPId"].ToString());
                    }


                    if (dr["ImageString"] != DBNull.Value)
                    {
                        aInfo.ImageString = dr["ImageString"].ToString();
                    }
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

        public ResultInfo SaveExpenseClaim_ApplogDAL(ExpanseSaveApprovalLogDAO atten)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@ExpanseApprovalId", atten.ExpanseApprovalId ?? (object)DBNull.Value ?? (object)DBNull.Value));
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

                
                int pk = 0;

                pk = accessManager.SaveDataReturnPrimaryKey("sp_webapi_SaveExpanseAppLog", gSqlParameterList);

                if (pk > 0)
                {
                    aInformation.isSuccess = true;
                }
                else
                {
                    aInformation.isValiCheck = true;
                    aInformation.Msd = "Approved date already expired.";

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


        public ResultInfo SaveTADAClaim_ApplogDAL(TADASaveApprovalLogDAO atten)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@TADAApprovalId", atten.TADAApprovalId ?? (object)DBNull.Value ?? (object)DBNull.Value));
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
 

                int pk = 0;

                pk = accessManager.SaveDataReturnPrimaryKey("sp_webapi_SaveTADAAppLog", gSqlParameterList);

                if (pk > 0)
                {
                    aInformation.isSuccess = true;
                }
                else
                {
                    aInformation.isValiCheck = true;
                    aInformation.Msd = "Approved date already expired.";

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


        public ResultInfo SaveMileageClaim_Applog_DAL(SaveMileageClaimAppLog_DAO atten)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@MileageApprovalId", atten.MileageApprovalId ?? (object)DBNull.Value ?? (object)DBNull.Value));
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
                int pk = 0;

                pk = accessManager.SaveDataReturnPrimaryKey("sp_webapi_SaveMileageAppLog", gSqlParameterList);

                if (pk > 0)
                {
                    aInformation.isSuccess = true;
                }
                else
                {
                    aInformation.isValiCheck = true;
                    aInformation.Msd = "Approved date already expired.";

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

        #endregion


        #region Mileage Claim
        public DataTable Get_TransportList()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_TransportList");
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
        public ResultInfo SaveMileageClaim(MileageClaim aInfo)
        {

            ResultInfo aInformation = new ResultInfo();
            try
            {
                int pk = 0;

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;
                gSqlParameterList.Add(new SqlParameter("@MileageClaimId", aInfo.MileageClaimId ));
                gSqlParameterList.Add(new SqlParameter("@mileagDate", aInfo.MileageDate ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@transportId", aInfo.TransportId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@mileageInKM", aInfo.MileageInKM ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@meterReading", aInfo.MeterReading ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@MarketId", aInfo.MarketId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                
                gSqlParameterList.Add(new SqlParameter("@remakrs", aInfo.Remarks));
                gSqlParameterList.Add(new SqlParameter("@empId", aInfo.EmpInfoId));

                if (aInfo.MileageClaimId > 0)
                {
                    aInformation.isSuccess = accessManager.UpdateData("sp_Webapi_Update_MileageClaim", gSqlParameterList);

                    pk = aInfo.MileageClaimId;
                    
                }
                else
                {
                    pk = accessManager.SaveDataReturnPrimaryKey("sp_Webapi_Save_MileageClaim", gSqlParameterList);
                    if (pk > 0)
                    {
                        aInformation.isSuccess = true;
                        

                    }
                    else
                    {
                        aInformation.isSuccess = false;
                        aInformation.isValiCheck = true;
                    }
                }

                if (pk > 0)
                {
                    if (aInformation.isSuccess)
                    {
                        if (!string.IsNullOrEmpty(aInfo.ImageBase64String))
                        {
                            AppPrimaryDAL app = new AppPrimaryDAL();
                            ImagePath _path = new ImagePath();
                            string type = "Mileage";
                            _path = app.GetImagePath(type);




                            //string targetPath = @"E:\ZasImage";
                            string targetPath = @"" + _path.ImagePathValue + "";
                            if (!Directory.Exists(targetPath))
                            {
                                Directory.CreateDirectory(targetPath);
                            }

                            string filePath = targetPath + "/" + _path.ImagePreName + pk + "." + "jpg";
                            File.WriteAllBytes(filePath, Convert.FromBase64String(aInfo.ImageBase64String));
                        }


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
        public IList<GetExpanseDAO> Get_MileageCLaimList(string monthValue, string yearValue, string statusTxt, string empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter> {
                new SqlParameter("@monthValue",monthValue),
                new SqlParameter("@yearValue",yearValue),
                new SqlParameter("@statusTxt",statusTxt ?? (object)DBNull.Value ?? (object)DBNull.Value),
                new SqlParameter("@empId",empId)
                };
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_MileageClaimList", aSqlParameterlist);
                List<GetExpanseDAO> aList = new List<GetExpanseDAO>();

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    GetExpanseDAO aInfo = new GetExpanseDAO();

                    if (dt.Rows[i]["MileageClaimId"] != DBNull.Value)
                    {
                        aInfo.MileageClaimId = Convert.ToInt32(dt.Rows[i]["MileageClaimId"]);
                    }

                    

                    if (dt.Rows[i]["TransportName"] != DBNull.Value)
                    {
                        aInfo.TransportName = (dt.Rows[i]["TransportName"].ToString());
                    }


                    if (dt.Rows[i]["EmpName"] != DBNull.Value)
                    {
                        aInfo.EmpName = (dt.Rows[i]["EmpName"].ToString());
                    }
                    if (dt.Rows[i]["Remarks"] != DBNull.Value)
                    {
                        aInfo.Remarks = (dt.Rows[i]["Remarks"].ToString());
                    }

                    if (dt.Rows[i]["MileageDate"] != DBNull.Value)
                    {
                        aInfo.MileageDate = (dt.Rows[i]["MileageDate"].ToString());
                    }

                    if (dt.Rows[i]["MileageInKM"] != DBNull.Value)
                    {
                        aInfo.MileageInKM =Convert.ToDecimal (dt.Rows[i]["MileageInKM"].ToString());
                    }

                    if (dt.Rows[i]["MeterReading"] != DBNull.Value)
                    {
                        aInfo.MeterReading = Convert.ToDecimal(dt.Rows[i]["MeterReading"].ToString());
                    }

                    if (dt.Rows[i]["MarketName"] != DBNull.Value)
                    {
                        aInfo.MarketName = (dt.Rows[i]["MarketName"].ToString());
                    }

                    if (dt.Rows[i]["MarketName"] != DBNull.Value)
                    {
                        aInfo.MarketName = (dt.Rows[i]["MarketName"].ToString());
                    }

                    if (dt.Rows[i]["ApprovalStatus"] != DBNull.Value)
                    {
                        aInfo.ApprovalStatus = (dt.Rows[i]["ApprovalStatus"].ToString());
                    }


                    if (dt.Rows[i]["ImageString"] != DBNull.Value)
                    {
                        aInfo.ImageString = dt.Rows[i]["ImageString"].ToString();
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




            public MileageClaimViewModel GetMileageCLaimDetailsById(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterList = new List<SqlParameter> {
                    new SqlParameter("@id",id)
                };

                SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_Get_MileageDetailsByID", aSqlParameterList);
                MileageClaimViewModel aInfo = new MileageClaimViewModel();

                while (dr.Read())
                {
                    if (dr["MileageDate"] != DBNull.Value) aInfo.MileageDate = dr["MileageDate"].ToString();
                    if (dr["TransportName"] != DBNull.Value) aInfo.TransportName = dr["TransportName"].ToString();
                    if (dr["MileageInKM"] != DBNull.Value) aInfo.MileageInKM = dr["MileageInKM"].ToString();
                    if (dr["MeterReading"] != DBNull.Value) aInfo.MeterReading = dr["MeterReading"].ToString();
                    if (dr["SMName"] != DBNull.Value) aInfo.SMName = dr["SMName"].ToString();
                    if (dr["MarketName"] != DBNull.Value) aInfo.MarketName = dr["MarketName"].ToString();
                    if (dr["TerritoryName"] != DBNull.Value) aInfo.TerritoryName = dr["TerritoryName"].ToString();
                    if (dr["AreaName"] != DBNull.Value) aInfo.AreaName = dr["AreaName"].ToString();
                    if (dr["Remarks"] != DBNull.Value) aInfo.Remarks = dr["Remarks"].ToString();
                    if (dr["ApprovalStatus"] != DBNull.Value) aInfo.ApprovalStatus = dr["ApprovalStatus"].ToString();



                }

                return aInfo;

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


        #endregion


        public DataTable GetBonusCampaign(int customerId,int empId,double totalAmt,string productCodeMultiple)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter> {
                new SqlParameter("@customerId",customerId),
                new SqlParameter("@empId",empId),
                new SqlParameter("@totalAmt",totalAmt),
                new SqlParameter("@productCodeMultiple",productCodeMultiple)
                };
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_BonusCampaingData", aSqlParameterlist);
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

        public TADAAmountViewModel GetTadaAmount(int userId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterList = new List<SqlParameter> {
                    new SqlParameter("@userId",userId)
                };

                SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_GET_TADAAmountByUser", aSqlParameterList);
                TADAAmountViewModel aInfo = new TADAAmountViewModel();

                while (dr.Read())
                {

                    aInfo.TaAmount = dr["TAAmount"].ToString();
                    aInfo.DaAmount = dr["DAAmount"].ToString();


                }

                return aInfo;

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


        public DataTable GetTadaList(string monthValue, string yearValue, string statusTxt, string userId, string FromDt, string ToDt)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter> {
                new SqlParameter("@monthValue",monthValue),
                new SqlParameter("@yearValue",yearValue),
                new SqlParameter("@statusTxt",statusTxt  ?? (object)DBNull.Value ?? (object)DBNull.Value),
                new SqlParameter("@userId",userId  ?? (object)DBNull.Value ?? (object)DBNull.Value),
                new SqlParameter("@FromDt",FromDt ?? (object)DBNull.Value ?? (object)DBNull.Value),
                new SqlParameter("@ToDt",ToDt ?? (object)DBNull.Value ?? (object)DBNull.Value)

            };
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

    }
}