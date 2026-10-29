using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace SalesSolutionWebAPI.Repository
{
    public class CustomerDAL 
    {
        private DataAccessManager accessManager = new DataAccessManager();

        public void AddCustomer(mCustomer aCustomer)
        {
            throw new NotImplementedException();
        }

        public IList<mCustomer> GetALLCustomer()
        {
            throw new NotImplementedException();
        }

        public IList<mCustomer> GetCustomerByUser(int empId)
        {




            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                aSqlParameterList.Add(new SqlParameter("@empId", empId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_webapi_GetCustomerbyUser", aSqlParameterList);
                List<mCustomer> aList = new List<mCustomer>();

                while (dr.Read())
                {
                    mCustomer aInfo = new mCustomer();

                    if (dr["CustomerMasterId"] != DBNull.Value)
                    {
                        aInfo.CustomerMasterId = Convert.ToInt32(dr["CustomerMasterId"]);
                    }
                    if (dr["CustomerName"] != DBNull.Value)
                    {
                        aInfo.CustomerName = dr["CustomerName"].ToString();
                    }


                    if (dr["CustomerCode"] != DBNull.Value)
                    {
                        aInfo.CustomerCode = dr["CustomerCode"].ToString();

                    }


                    if (dr["Address"] != DBNull.Value)
                    {
                        aInfo.Address = dr["Address"].ToString();
                    }

                    aInfo.Balance = dr["Balance"] != DBNull.Value ? dr["Balance"].ToString() : "";
                    aInfo.MarketName = dr["MarketName"] != DBNull.Value ? dr["MarketName"].ToString() : "";
                    aInfo.CellNo = dr["CellNo"] != DBNull.Value ? dr["CellNo"].ToString() : "";
                    aInfo.CreditLimit = dr["CreditLimit"] != DBNull.Value ? dr["CreditLimit"].ToString() : "";

                    aInfo.CustomerType = dr["CustomerType"] != DBNull.Value ? dr["CustomerType"].ToString() : "";
                    aInfo.CustomerStation = dr["CustomerStation"] != DBNull.Value ? dr["CustomerStation"].ToString() : "";
                    aInfo.Route = dr["Route"] != DBNull.Value ? dr["Route"].ToString() : "";


                    aInfo.GroupId = dr["GroupId"] != DBNull.Value ? dr["GroupId"].ToString() : "";
                    aInfo.RegionId = dr["RegionId"] != DBNull.Value ? dr["RegionId"].ToString() : "";
                    aInfo.AreaId = dr["AreaId"] != DBNull.Value ? dr["AreaId"].ToString() : "";
                    aInfo.TerritoryId = dr["TerritoryId"] != DBNull.Value ? dr["TerritoryId"].ToString() : "";
                    aInfo.SubTerritoryId = dr["SubTerritoryId"] != DBNull.Value ? dr["SubTerritoryId"].ToString() : "";
                    aInfo.MarketId = dr["MarketId"] != DBNull.Value ? dr["MarketId"].ToString() : "";

                    aInfo.Note = dr["Note"] != DBNull.Value ? dr["Note"].ToString() : "";

                    if (dr["CustomerCheck"] != DBNull.Value)
                    {
                        aInfo.CustomerCheck = Convert.ToInt32(dr["CustomerCheck"]);
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

        public void RemoveCustomer(int customerID)
        {
            throw new NotImplementedException();
        }


        public DataTable GetCustomerType()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_CustomerType");
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


        public DataTable GetChemistCall(string empId, string frmDate, string toDate)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                aSqlParameterList.Add(new SqlParameter("@empId", empId));
                aSqlParameterList.Add(new SqlParameter("@frmDate", frmDate));
                aSqlParameterList.Add(new SqlParameter("@toDate", toDate));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_GetChemistCall", aSqlParameterList);
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


        public ResultInfo SavechemistCall(ChemistCallMaster aInfo)
        {
            ResultInfo aInformation = new ResultInfo();


            
                try
                {




                    accessManager.SqlConnectionOpen(DataBase.SalesDisDB);


                    

                    int pk = 0;

                     
                        List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                        DateTime entryDtae = DateTime.Now;

                        gSqlParameterList.Add(new SqlParameter("@EmployeeId", aInfo.empId));
                        gSqlParameterList.Add(new SqlParameter("@ChemistCallDate", aInfo.ChemistCallDate ?? (object)DBNull.Value ?? (object)DBNull.Value));
            
                        
                        gSqlParameterList.Add(new SqlParameter("@IsGivenOrder", aInfo.IsGivenOrder ?? (object)DBNull.Value ?? (object)DBNull.Value));

                        gSqlParameterList.Add(new SqlParameter("@LatVal", aInfo.LatVal ?? (object)DBNull.Value ?? (object)DBNull.Value));
                        gSqlParameterList.Add(new SqlParameter("@LongVal", aInfo.LongVal ?? (object)DBNull.Value ?? (object)DBNull.Value));
                        gSqlParameterList.Add(new SqlParameter("@Address", aInfo.Address ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@CustomerMasterId", aInfo.CustomerMasterId ?? (object)DBNull.Value ?? (object)DBNull.Value));


                gSqlParameterList.Add(new SqlParameter("@ReasonId", aInfo.ReasonId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@Comments", aInfo.Comments ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@CallTime", aInfo.CallTime ?? (object)DBNull.Value ?? (object)DBNull.Value));



                pk = accessManager.SaveDataReturnPrimaryKey("sp_Webapi_Save_ChemistCallMaster", gSqlParameterList);
                        if (pk > 0)
                        {
                            aInformation.isSuccess = true;


                            


                          

                         

                            aInformation.Msd = "Chemist Call Saved!";
                        


                        
                    }
                    else
                    {
                        aInformation.isValiCheck = true;
                        //if (dtDoctorChem.Rows[0]["Qty"] != DBNull.Value)
                        //{
                        aInformation.Msd = "Some thing went wrong!";
                        //}
                        //aInformation.Msd = "";
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



        public IList<CustomerSMListDao> GetCustomerListDAL()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_webapi_GetCustomerList");
                List<CustomerSMListDao> aList = new List<CustomerSMListDao>();
                for (var i = 0; i < dt.Rows.Count; i++)

                {
                    CustomerSMListDao aInfo = new CustomerSMListDao();


                    if (dt.Rows[i]["CustomerMasterId"] != DBNull.Value)
                    {
                        aInfo.CustomerMasterId = Convert.ToInt32(dt.Rows[i]["CustomerMasterId"].ToString());
                    }


                    if (dt.Rows[i]["CustomerName"] != DBNull.Value)
                    {
                        aInfo.CustomerName =  (dt.Rows[i]["CustomerName"].ToString());
                    }

                    if (dt.Rows[i]["CustomerCode"] != DBNull.Value)
                    {
                        aInfo.CustomerCode = (dt.Rows[i]["CustomerCode"].ToString());
                    }
                    if (dt.Rows[i]["Address"] != DBNull.Value)
                    {
                        aInfo.Address =  (dt.Rows[i]["Address"].ToString());
                    }

                    if (dt.Rows[i]["MarketName"] != DBNull.Value)
                    {
                        aInfo.MarketName = (dt.Rows[i]["MarketName"].ToString());
                    }


                    if (dt.Rows[i]["MarketId"] != DBNull.Value)
                    {
                        aInfo.MarketId = Convert.ToInt32(dt.Rows[i]["MarketId"].ToString());
                    }


                    if (dt.Rows[i]["AreaName"] != DBNull.Value)
                    {
                        aInfo.AreaName = (dt.Rows[i]["AreaName"].ToString());
                    }

                    if (dt.Rows[i]["CellNo"] != DBNull.Value)
                    {
                        aInfo.CellNo = (dt.Rows[i]["CellNo"].ToString());
                    }


                    if (dt.Rows[i]["CustomerTypeId"] != DBNull.Value)
                    {
                        aInfo.CustomerTypeId =Convert.ToInt32 (dt.Rows[i]["CustomerTypeId"].ToString());
                    }



                   


                    //if (dt.Rows[i]["EmpId"] != DBNull.Value)
                    //{
                    //    aInfo.EmpId = Convert.ToInt32(dt.Rows[i]["EmpId"].ToString());
                    //}
                    if (dt.Rows[i]["VoterID"] != DBNull.Value)
                    {
                        aInfo.VoterID =  (dt.Rows[i]["VoterID"].ToString());
                    }
                    if (dt.Rows[i]["CustomerType"] != DBNull.Value)
                    {
                        aInfo.CustomerType = (dt.Rows[i]["CustomerType"].ToString());
                    }


                    if (dt.Rows[i]["Reamrks"] != DBNull.Value)
                    {
                        aInfo.Reamrks = (dt.Rows[i]["Reamrks"].ToString());
                    }

                    if (dt.Rows[i]["Latitude"] != DBNull.Value)
                    {
                        aInfo.Latitude = (dt.Rows[i]["Latitude"].ToString());
                    }



                    if (dt.Rows[i]["Longitude"] != DBNull.Value)
                    {
                        aInfo.Longitude = (dt.Rows[i]["Longitude"].ToString());
                    }


                    if (dt.Rows[i]["StreetAddress"] != DBNull.Value)
                    {
                        aInfo.StreetAddress = (dt.Rows[i]["StreetAddress"].ToString());
                    }


                    if (dt.Rows[i]["ProgramTypeId"] != DBNull.Value)
                    {
                        aInfo.ProgramTypeId =Convert.ToInt32 (dt.Rows[i]["ProgramTypeId"].ToString());
                    }

                    if (dt.Rows[i]["ProgramTypeName"] != DBNull.Value)
                    {
                        aInfo.ProgramTypeName = (dt.Rows[i]["ProgramTypeName"].ToString());
                    }

                    if (dt.Rows[i]["TermOfPayment"] != DBNull.Value)
                    {
                        aInfo.TermOfPayment = (dt.Rows[i]["TermOfPayment"].ToString());
                    }


                    if (dt.Rows[i]["OwnerName"] != DBNull.Value)
                    {
                        aInfo.ConPerson = (dt.Rows[i]["OwnerName"].ToString());
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

                    string imagefullpathLi = (dt.Rows[i]["TradeLicenseImagePreName"].ToString() + ((int)dt.Rows[i]["CustomerMasterId"]).ToString() + ".jpg");


                    try
                    {
                        byte[] imageArray = System.IO.File.ReadAllBytes(@imagefullpathLi);
                        aInfo.TradeLicenseImg = Convert.ToBase64String(imageArray);
                        aInfo.TradeLicenseImagePreName = imagefullpath;

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



        public ResultInfo SaveCustomer(CustomerSM aInfo)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@name", aInfo.CustomerName));
                gSqlParameterList.Add(new SqlParameter("@address", aInfo.Address));
                gSqlParameterList.Add(new SqlParameter("@phone", aInfo.CellNo));
                gSqlParameterList.Add(new SqlParameter("@conPerson", aInfo.ConPerson));
                gSqlParameterList.Add(new SqlParameter("@termOfPayment", aInfo.TermOfPayment));
                gSqlParameterList.Add(new SqlParameter("@isFromApp", aInfo.IsFromApp));
                gSqlParameterList.Add(new SqlParameter("@marketId", aInfo.MarketId));
                //gSqlParameterList.Add(new SqlParameter("@thana", aInfo.ThanaId));
                //gSqlParameterList.Add(new SqlParameter("@districtId", aInfo.DistrictId));
                //gSqlParameterList.Add(new SqlParameter("@divisionId", aInfo.DivisionId));
               // gSqlParameterList.Add(new SqlParameter("@typeId", aInfo.CustomerTypeId));
                gSqlParameterList.Add(new SqlParameter("@ProgramTypeId", aInfo.ProgramTypeId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@SMCTypeId", aInfo.SMCTypeId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@empId", aInfo.EmpId));


                gSqlParameterList.Add(new SqlParameter("@VoterID", aInfo.VoterID));
                gSqlParameterList.Add(new SqlParameter("@TradeLicense", aInfo.TradeLicense));
                gSqlParameterList.Add(new SqlParameter("@Reamrks", aInfo.Reamrks));

                gSqlParameterList.Add(new SqlParameter("@Latitude", aInfo.Latitude));
                gSqlParameterList.Add(new SqlParameter("@Longitude", aInfo.Longitude));
                gSqlParameterList.Add(new SqlParameter("@StreetAddress", aInfo.StreetAddress));

       


                int pk = 0;

                if (aInfo.CustomerMasterId > 0)
                {

                  
                    List<SqlParameter> aSqlParameterList = new List<SqlParameter>();

                    aSqlParameterList.Add(new SqlParameter("@id", aInfo.CustomerMasterId));
                    aSqlParameterList.Add(new SqlParameter("@MarketId", aInfo.MarketId));

                    aSqlParameterList.Add(new SqlParameter("@CellNo", aInfo.CellNo));
                    DataTable dt = accessManager.GetDataTable("sp_Webapi_check_Customer", aSqlParameterList);
                    if (dt.Rows.Count == 0)
                    {
                        gSqlParameterList.Add(new SqlParameter("@id", aInfo.CustomerMasterId));

                        aInformation.isSuccess = accessManager.UpdateData("sp_Webapi_Update_Customer", gSqlParameterList);
                        if (aInformation.isSuccess)
                        {
                            pk = aInfo.CustomerMasterId;
                        }
                    }
                    else
                    {
                        pk = 0;
                    }
                }
                else
                {
                    pk = accessManager.SaveDataReturnPrimaryKey("sp_Webapi_Save_Customer", gSqlParameterList);


                    if(aInfo.EmpId>0)
                    {



                        CustomerAppLog_DAO aInfoApp = new CustomerAppLog_DAO();
                      
                        List<SqlParameter> gSqlEmp = new List<SqlParameter>();

                        gSqlEmp.Add(new SqlParameter("@EmployeeId", (aInfo.EmpId )));
                        DataTable dtEmp = accessManager.GetDataTable("sp_Webapi_Get_RSM_DZSMcheck", gSqlEmp);




                        if (dtEmp.Rows.Count > 0)
                        {
                            string NewEmpId = dtEmp.Rows[0]["ASMEMPId"].ToString();
                            if (NewEmpId != "nai")
                            {

                                List<SqlParameter> gSqlNewEmp = new List<SqlParameter>();
                                gSqlEmp.Add(new SqlParameter("@EmployeeId", aInfo.EmpId));
                                DataTable dtNewEmp = accessManager.GetDataTable("sp_Webapi_Get_DICcheck", gSqlNewEmp);

                                if (dtNewEmp.Rows[0]["UserType"].ToString() != "DZSM")
                                {
                                     
                                

                                List<SqlParameter> gSqlGet = new List<SqlParameter>();
                                gSqlGet.Add(new SqlParameter("@CustomerMasterId", (pk)));
                                DataTable dt = accessManager.GetDataTable("sp_Get_CustomerAppDataForDuplicate", gSqlGet);
                                List<SqlParameter> gSql = new List<SqlParameter>();

                                if (dt.Rows[0]["CustomerApprovalId"] != DBNull.Value)
                                {
                                    aInfoApp.CustomerApprovalId = Convert.ToInt32(dt.Rows[0]["CustomerApprovalId"].ToString());
                                }

                                if (dt.Rows[0]["CustomerMasterId"] != DBNull.Value)
                                {
                                    aInfoApp.CustomerMasterId = Convert.ToInt32(dt.Rows[0]["CustomerMasterId"]);
                                }

                                if (dt.Rows[0]["EmpInfoId"] != DBNull.Value)
                                {
                                    aInfoApp.EmpInfoId = Convert.ToInt32(NewEmpId);

                                }

                                if (dt.Rows[0]["Date"] != DBNull.Value)
                                {
                                    aInfoApp.Date = (dt.Rows[0]["Date"].ToString());
                                }


                                if (dt.Rows[0]["FromEmpId"] != DBNull.Value)
                                {
                                    aInfoApp.FromEmpId = Convert.ToInt32(NewEmpId);
                                }



                                if (dt.Rows[0]["ToEmpId"] != DBNull.Value)
                                {
                                    aInfoApp.ToEmpId = Convert.ToInt32(dt.Rows[0]["ToEmpId"].ToString());
                                }
                                if (dt.Rows[0]["TableId"] != DBNull.Value)
                                {
                                    aInfoApp.TableId = Convert.ToInt32(dt.Rows[0]["TableId"].ToString());
                                }
                                if (dt.Rows[0]["Status"] != DBNull.Value)
                                {
                                    aInfoApp.Status = dt.Rows[0]["Status"].ToString();
                                }
                                if (dt.Rows[0]["Comments"] != DBNull.Value)
                                {
                                    aInfoApp.Comments = dt.Rows[0]["Comments"].ToString();
                                }

                                if (dt.Rows[0]["Type"] != DBNull.Value)
                                {
                                    aInfoApp.Type = (dt.Rows[0]["Type"].ToString());
                                }


                                if (dt.Rows[0]["Step"] != DBNull.Value)
                                {
                                    aInfoApp.Step = Convert.ToInt32(dt.Rows[0]["Step"].ToString());
                                }



                                if (dt.Rows[0]["ApprovalStatus"] != DBNull.Value)
                                {
                                    aInfoApp.ApprovalStatus = dt.Rows[0]["ApprovalStatus"].ToString();
                                }

                                 

                                if (dt.Rows[0]["GroupId"] != DBNull.Value)
                                {
                                    aInfoApp.GroupId = Convert.ToInt32(dt.Rows[0]["GroupId"].ToString());
                                }

                                if (dt.Rows[0]["RegionId"] != DBNull.Value)
                                {
                                    aInfoApp.RegionId = Convert.ToInt32(dt.Rows[0]["RegionId"].ToString());
                                }


                                if (dt.Rows[0]["AreaId"] != DBNull.Value)
                                {
                                    aInfoApp.AreaId = Convert.ToInt32(dt.Rows[0]["AreaId"].ToString());
                                }


                                if (dt.Rows[0]["TerritoryId"] != DBNull.Value)
                                {
                                    aInfoApp.TerritoryId = Convert.ToInt32(dt.Rows[0]["TerritoryId"].ToString());
                                }


                                if (dt.Rows[0]["RoleTypeId"] != DBNull.Value)
                                {
                                    aInfoApp.RoleTypeId = Convert.ToInt32(dt.Rows[0]["RoleTypeId"].ToString());
                                }




                                gSql.Add(new SqlParameter("@CustomerApprovalId", aInfoApp.CustomerApprovalId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@Date",DateTime.Now ));
                                gSql.Add(new SqlParameter("@FromEmpId", aInfoApp.FromEmpId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@ToEmpId", aInfoApp.ToEmpId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@TableId", aInfoApp.TableId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@Status", "Verified" ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@Comments", "ABC" ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@Type", aInfoApp.Type ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@Step", aInfoApp.Step+1 ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@GroupId", aInfoApp.GroupId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@RegionId", aInfoApp.RegionId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@AreaId", aInfoApp.AreaId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@TerritoryId", aInfoApp.TerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                                gSql.Add(new SqlParameter("@ToGroupId", null ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@ToRegionId", null ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@ToAreaId", null ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@ToTerritoryId", null ?? (object)DBNull.Value ?? (object)DBNull.Value));

                                gSql.Add(new SqlParameter("@EntryByS", aInfoApp.EmpInfoId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@EntryDateS", entryDtae ));
                                gSql.Add(new SqlParameter("@EntryTimeS", null ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@ApproveByS", aInfoApp.EmpInfoId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@ApproveDateS", entryDtae ));
                                gSql.Add(new SqlParameter("@ApproveTimeS", null ?? (object)DBNull.Value ?? (object)DBNull.Value));

                                gSql.Add(new SqlParameter("@EntryByApp", aInfoApp.EmpInfoId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@EntryDateApp", entryDtae ));
                                gSql.Add(new SqlParameter("@EntryTimeApp", null?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@ApproveByApp", aInfoApp.EmpInfoId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@ApproveDateApp", entryDtae));
                                gSql.Add(new SqlParameter("@ApproveTimeApp", null ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                gSql.Add(new SqlParameter("@MenuId", 302 ));

                                aInformation.isSuccess = accessManager.SaveData("sp_webapi_SaveCustomerAppLog", gSql);
                            }
                            }


                        }


                    }

                }
               
                if (pk > 0)
                {
                    aInformation.isSuccess = true;

                }
                else
                {
                    aInformation.isValiCheck = true;

                }

                if (aInformation.isSuccess)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(aInfo.ImageBase64String))
                        {
                            AppPrimaryDAL app = new AppPrimaryDAL();
                            ImagePath _path = new ImagePath();
                            string type = "Customer";
                            _path = app.GetImagePath(type);
                            string targetPath = @"" + _path.ImagePathValue + "";
                            if (!Directory.Exists(targetPath))
                            {
                                Directory.CreateDirectory(targetPath);
                            }

                            string filePath = targetPath + "/" + _path.ImagePreName + pk + "." + "jpg";
                            File.WriteAllBytes(filePath, Convert.FromBase64String(aInfo.ImageBase64String));
                        }


                        if (!string.IsNullOrEmpty(aInfo.TradeLicenseImg))
                        {
                            AppPrimaryDAL app = new AppPrimaryDAL();
                            ImagePath _path = new ImagePath();
                            string type = "TradeLicense";
                            _path = app.GetImagePath(type);
                            string targetPath = @"" + _path.ImagePathValue + "";
                            if (!Directory.Exists(targetPath))
                            {
                                Directory.CreateDirectory(targetPath);
                            }

                            string filePath = targetPath + "/" + _path.ImagePreName + pk + "." + "jpg";
                            File.WriteAllBytes(filePath, Convert.FromBase64String(aInfo.TradeLicenseImg));
                        }
                    }
                    catch(Exception ex)
                    {

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

        public IList<CustomerAppLog_DAO> GetCustomer_ApplogDAL(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, string TerritoryId)
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
                gSqlParameterList.Add(new SqlParameter("@TerritoryId", TerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));


                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_CustomerApp", gSqlParameterList);
                //SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_Get_DoctorClaimApp", gSqlParameterList);
                List<CustomerAppLog_DAO> aList = new List<CustomerAppLog_DAO>();
                for (var i = 0; i < dt.Rows.Count; i++)

                {
                    CustomerAppLog_DAO aInfo = new CustomerAppLog_DAO();


                    if (dt.Rows[i]["CustomerApprovalId"] != DBNull.Value)
                    {
                        aInfo.CustomerApprovalId = Convert.ToInt32(dt.Rows[i]["CustomerApprovalId"].ToString());
                    }

                    if (dt.Rows[i]["CustomerMasterId"] != DBNull.Value)
                    {
                        aInfo.CustomerMasterId = Convert.ToInt32(dt.Rows[i]["CustomerMasterId"]);
                    }

                    if (dt.Rows[i]["EmpInfoId"] != DBNull.Value)
                    {
                        aInfo.EmpInfoId = Convert.ToInt32(dt.Rows[i]["EmpInfoId"].ToString());

                    }

                    if (dt.Rows[i]["Date"] != DBNull.Value)
                    {
                        aInfo.Date = (dt.Rows[i]["Date"].ToString());
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



                    if (dt.Rows[i]["ApprovalStatus"] != DBNull.Value)
                    {
                        aInfo.ApprovalStatus = dt.Rows[i]["ApprovalStatus"].ToString();
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

                    if (dt.Rows[i]["WaitingRole"] != DBNull.Value)
                    {
                        aInfo.WaitingRole = dt.Rows[i]["WaitingRole"].ToString();
                    }


                    if (dt.Rows[i]["WatingEmployee"] != DBNull.Value)
                    {
                        aInfo.WatingEmployee = dt.Rows[i]["WatingEmployee"].ToString();
                    }

                    List<SqlParameter> aSqlParameterListDetals = new List<SqlParameter>();

                    aSqlParameterListDetals.Add(new SqlParameter("@CustomerMasterId", aInfo.TableId));
                    DataTable dtDoctor = accessManager.GetDataTable("sp_webapi_GetCustomerListByCusId", aSqlParameterListDetals);


                    CustomerSMListDao aDetails;


                    aDetails = new CustomerSMListDao();
                    if (dtDoctor.Rows[0]["CustomerMasterId"] != DBNull.Value)
                    {
                        aDetails.CustomerMasterId = Convert.ToInt32(dtDoctor.Rows[0]["CustomerMasterId"].ToString());
                    }


                    if (dtDoctor.Rows[0]["CustomerName"] != DBNull.Value)
                    {
                        aDetails.CustomerName = (dtDoctor.Rows[0]["CustomerName"].ToString());
                    }

                    if (dtDoctor.Rows[0]["CustomerCode"] != DBNull.Value)
                    {
                        aDetails.CustomerCode = (dtDoctor.Rows[0]["CustomerCode"].ToString());
                    }
                    if (dtDoctor.Rows[0]["Address"] != DBNull.Value)
                    {
                        aDetails.Address = (dtDoctor.Rows[0]["Address"].ToString());
                    }

                    if (dtDoctor.Rows[0]["MarketName"] != DBNull.Value)
                    {
                        aDetails.MarketName = (dtDoctor.Rows[0]["MarketName"].ToString());
                    }


                    if (dtDoctor.Rows[0]["MarketId"] != DBNull.Value)
                    {
                        aDetails.MarketId = Convert.ToInt32(dtDoctor.Rows[0]["MarketId"].ToString());
                    }

                    if (dtDoctor.Rows[0]["SubTerritoryId"] != DBNull.Value)
                    {
                        aDetails.SubTerritoryId = Convert.ToInt32(dtDoctor.Rows[0]["SubTerritoryId"].ToString());
                    }

                    if (dtDoctor.Rows[0]["TerritoryId"] != DBNull.Value)
                    {
                        aDetails.TerritoryId = Convert.ToInt32(dtDoctor.Rows[0]["TerritoryId"].ToString());
                    }

                    if (dtDoctor.Rows[0]["AreaId"] != DBNull.Value)
                    {
                        aDetails.AreaId = Convert.ToInt32(dtDoctor.Rows[0]["AreaId"].ToString());
                    }


                    if (dtDoctor.Rows[0]["RegionId"] != DBNull.Value)
                    {
                        aDetails.RegionId = Convert.ToInt32(dtDoctor.Rows[0]["RegionId"].ToString());
                    }

                    if (dtDoctor.Rows[0]["GroupId"] != DBNull.Value)
                    {
                        aDetails.GroupId = Convert.ToInt32(dtDoctor.Rows[0]["GroupId"].ToString());
                    }


                    if (dtDoctor.Rows[0]["AreaName"] != DBNull.Value)
                    {
                        aDetails.AreaName = (dtDoctor.Rows[0]["AreaName"].ToString());
                    }

                    if (dtDoctor.Rows[0]["CellNo"] != DBNull.Value)
                    {
                        aDetails.CellNo = (dtDoctor.Rows[0]["CellNo"].ToString());
                    }
                    if (dtDoctor.Rows[0]["TradeLicense"] != DBNull.Value)
                    {
                        aDetails.TradeLicense = (dtDoctor.Rows[0]["TradeLicense"].ToString());
                    }

                    if (dtDoctor.Rows[0]["CustomerTypeId"] != DBNull.Value)
                    {
                        aDetails.CustomerTypeId = Convert.ToInt32(dtDoctor.Rows[0]["CustomerTypeId"].ToString());
                    }



                   


                    //if (dtDoctor.Rows[0]["EmpId"] != DBNull.Value)
                    //{
                    //    aDetails.EmpId = Convert.ToInt32(dtDoctor.Rows[0]["EmpId"].ToString());
                    //}
                    if (dtDoctor.Rows[0]["VoterID"] != DBNull.Value)
                    {
                        aDetails.VoterID = (dtDoctor.Rows[0]["VoterID"].ToString());
                    }
                    if (dtDoctor.Rows[0]["CustomerType"] != DBNull.Value)
                    {
                        aDetails.CustomerType = (dtDoctor.Rows[0]["CustomerType"].ToString());
                    }


                    if (dtDoctor.Rows[0]["Reamrks"] != DBNull.Value)
                    {
                        aDetails.Reamrks = (dtDoctor.Rows[0]["Reamrks"].ToString());
                    }

                    if (dtDoctor.Rows[0]["Latitude"] != DBNull.Value)
                    {
                        aDetails.Latitude = (dtDoctor.Rows[0]["Latitude"].ToString());
                    }



                    if (dtDoctor.Rows[0]["Longitude"] != DBNull.Value)
                    {
                        aDetails.Longitude = (dtDoctor.Rows[0]["Longitude"].ToString());
                    }


                    if (dtDoctor.Rows[0]["StreetAddress"] != DBNull.Value)
                    {
                        aDetails.StreetAddress = (dtDoctor.Rows[0]["StreetAddress"].ToString());
                    }


                    if (dtDoctor.Rows[0]["ProgramTypeId"] != DBNull.Value)
                    {
                        aDetails.ProgramTypeId = Convert.ToInt32(dtDoctor.Rows[0]["ProgramTypeId"].ToString());
                    }

                    if (dtDoctor.Rows[0]["ProgramTypeName"] != DBNull.Value)
                    {
                        aDetails.ProgramTypeName = (dtDoctor.Rows[0]["ProgramTypeName"].ToString());
                    }

                    if (dtDoctor.Rows[0]["TermOfPayment"] != DBNull.Value)
                    {
                        aDetails.TermOfPayment = (dtDoctor.Rows[0]["TermOfPayment"].ToString());
                    }


                    if (dtDoctor.Rows[0]["OwnerName"] != DBNull.Value)
                    {
                        aDetails.ConPerson = (dtDoctor.Rows[0]["OwnerName"].ToString());
                    }


                    if (dtDoctor.Rows[0]["ImageBase64String"] != DBNull.Value)
                    {
                        aDetails.ImageBase64String = dtDoctor.Rows[0]["ImageBase64String"].ToString();
                    }

                    if (dtDoctor.Rows[0]["TradeLicenseImg"] != DBNull.Value)
                    {
                        aDetails.TradeLicenseImg = dtDoctor.Rows[0]["TradeLicenseImg"].ToString();
                    }


                    if (dtDoctor.Rows[0]["SMCType"] != DBNull.Value)
                    {
                        aDetails.SMCTypeName = (dtDoctor.Rows[0]["SMCType"].ToString());
                    }


                    if (dtDoctor.Rows[0]["SMCTypeId"] != DBNull.Value)
                    {
                        aDetails.SMCTypeId = Convert.ToInt32(dtDoctor.Rows[0]["SMCTypeId"].ToString());
                    }

                    aInfo.CustomerSMListDao = aDetails;




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
        public ResultInfo SaveCustomer_ApplogDAL(CustomerSaveAppLog_DAO atten)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@CustomerApprovalId", atten.CustomerApprovalId ?? (object)DBNull.Value ?? (object)DBNull.Value));
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

                aInformation.isSuccess = accessManager.SaveData("sp_webapi_SaveCustomerAppLog", gSqlParameterList);

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


        public ResultInfo UpdateCustomerProviderDAL(string empId, string CustomerId, string ProviderTypeId)
        {

            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@empId", empId));
                gSqlParameterList.Add(new SqlParameter("@CustomerMasterId", CustomerId));
                gSqlParameterList.Add(new SqlParameter("@ProgramTypeId", ProviderTypeId));
                
                    aInformation.isSuccess = accessManager.UpdateData("sp_Webapi_UpdateCustomerProvider", gSqlParameterList);

                

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


        public ResultInfo UpdateCustomerMarketDAL(CustomerMArket_DAO _DAO)
        {

            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> sqlCheck = new List<SqlParameter>();

                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@empId", _DAO.empId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@CustomerMasterId", _DAO.CustomerId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@TGroupId", _DAO.GroupId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@TZoneId", _DAO.ZoneId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@TAreaId", _DAO.AreaId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@TTeritoryId", _DAO.TerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@TSTeritoryId", _DAO.STeritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@TMarketId", _DAO.MarketId ?? (object)DBNull.Value ?? (object)DBNull.Value));



                sqlCheck.Add(new SqlParameter("@Marketd", _DAO.MarketId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                DataTable dtMS = accessManager.GetDataTable("sp_Webapi_CheckFakeMarket", sqlCheck);

                if (dtMS.Rows.Count == 0)
                {
                    aInformation.isSuccess = accessManager.UpdateData("sp_Webapi_UpdateCustomerMarket", gSqlParameterList);
                }
                else
                {
                    aInformation.isValiCheck = true;
                    aInformation.Msd = "This Market is not valid. Please select another market.";

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

        public IList<ModelCustomerDue> GetCustomerDueListDAL(int empId, int Month, int Year)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                aSqlParameterList.Add(new SqlParameter("@empId", empId));
                aSqlParameterList.Add(new SqlParameter("@Month", Month));
                aSqlParameterList.Add(new SqlParameter("@Year", Year));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_GetCustomerDueList", aSqlParameterList);
                List<ModelCustomerDue> aList = new List<ModelCustomerDue>();

                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    ModelCustomerDue aInfo = new ModelCustomerDue();
                    aInfo.CustomerCode = dt.Rows[i]["CustomerCode"] != DBNull.Value ? dt.Rows[i]["CustomerCode"].ToString() : "";
                    aInfo.CustomerName = dt.Rows[i]["CustomerName"] != DBNull.Value ? dt.Rows[i]["CustomerName"].ToString() : "";
                    aInfo.DueAmount = dt.Rows[i]["DueAmount"] != DBNull.Value ? dt.Rows[i]["DueAmount"].ToString() : "";
                    aInfo.MarketName = dt.Rows[i]["MarketName"] != DBNull.Value ? dt.Rows[i]["MarketName"].ToString() : "";
                    aInfo.CellNo = dt.Rows[i]["CellNo"] != DBNull.Value ? dt.Rows[i]["CellNo"].ToString() : "";
                    aInfo.Address = dt.Rows[i]["Address"] != DBNull.Value ? dt.Rows[i]["Address"].ToString() : "";
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

    }
}
