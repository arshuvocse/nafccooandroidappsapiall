using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Repository
{
    public class DoctorDAL
    {
        private TourPlanDAL aTourPlanDAL = new TourPlanDAL();

        private DataAccessManager accessManager = new DataAccessManager();

        public DataTable GetDoctorDegree()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorDegree");
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

        public DataTable GetDoctorSpecialDayDAL()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorSpecialDay");
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

        public DataTable GetDoctorSpeciality()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorSpeciality");
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

        public DataTable GetDoctorType()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorType");
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


        public DataTable GetProgramType()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorProgramType");
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

        public DataTable GetProviderType()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_ProviderType");
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


        public DataTable GetSMCType()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_SMCType");
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
        public DataTable GetNonEffectiveReason()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_NonEffectiveReason");
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

        public DataTable GetDoctorCategory()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorCategory");
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


        //public IList<DoctorProductBrandMasterDAO> GetDoctorBrand()
        //{
        //    try
        //    {
        //        accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
        //        List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
        //        DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorBrand");
        //        List<DoctorProductBrandMasterDAO> aList = new List<DoctorProductBrandMasterDAO>();
        //        DoctorProductBrandMasterDAO aInfo = new DoctorProductBrandMasterDAO();
        //        if (dt.Rows[0]["MaxValue"] != DBNull.Value)
        //        {
        //            aInfo.MaxValue = Convert.ToInt32(dt.Rows[0]["MaxValue"].ToString());
        //        }

        //        List<DoctorProductBrandDao> aDetailsList = new List<DoctorProductBrandDao>();
        //        DoctorProductBrandDao aDetails;
        //        for (var kk = 0; kk < dt.Rows.Count; kk++)

        //        {

        //            aDetails = new DoctorProductBrandDao();
        //            if (dt.Rows[kk]["ProductBrandId"] != DBNull.Value)
        //            {
        //                aDetails.ProductBrandId = Convert.ToInt32(dt.Rows[kk]["ProductBrandId"].ToString());
        //            }
        //            if (dt.Rows[kk]["ProductSQName"] != DBNull.Value)
        //            {
        //                aDetails.ProductSQName = dt.Rows[kk]["ProductSQName"].ToString();
        //            }
        //            aDetailsList.Add(aDetails);
        //        }
        //        aInfo.aBrandListDAO = aDetailsList;
        //        aList.Add(aInfo);

        //        return aList;
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

        public DataTable GetDoctorBrand()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorBrand");

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
        public DataTable GetDoctorInstitution()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorInstitute");
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
        public DataTable GetDoctorChemberType()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorChamber");
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

        public DataTable GetDoctorChemberName(int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empid", empId));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_ChamberName", aSqlParameterlist);
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
        public DataTable GetDoctorContactType()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();

                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorContactType");
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



        public ResultInfo SaveDoctor(DoctorSM aDoctor)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime? entryDtae = DateTime.Now;
                gSqlParameterList.Add(new SqlParameter("@MasterId", aDoctor.DoctorId));
                gSqlParameterList.Add(new SqlParameter("@doctorName", aDoctor.DoctorName ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@remarks", aDoctor.Remarks ?? (object)DBNull.Value ?? (object)DBNull.Value));


                gSqlParameterList.Add(new SqlParameter("@entryBy", aDoctor.SessionUser));
                gSqlParameterList.Add(new SqlParameter("@EntryDate", entryDtae ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@designaionId", aDoctor.DesignationId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@DoctorTypeId", aDoctor.DoctorTypeId ?? (object)DBNull.Value ?? (object)DBNull.Value));

            
                gSqlParameterList.Add(new SqlParameter("@marketId", aDoctor.MarketId ?? (object)DBNull.Value ?? (object)DBNull.Value));


                gSqlParameterList.Add(new SqlParameter("@DoctorCategoryId", aDoctor.DoctorCategoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));


                gSqlParameterList.Add(new SqlParameter("@ProgramTypeId", aDoctor.ProgramTypeId ?? (object)DBNull.Value ?? (object)DBNull.Value));



                gSqlParameterList.Add(new SqlParameter("@UnionName", aDoctor.UnionName ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@StationTypeId", aDoctor.StationTypeId ?? (object)DBNull.Value ?? (object)DBNull.Value));


                gSqlParameterList.Add(new SqlParameter("@SMCTypeId", aDoctor.SMCTypeId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@thanaId", aDoctor.ThanaId ?? (object)DBNull.Value ?? (object)DBNull.Value));
               
             

            

          


 

                gSqlParameterList.Add(new SqlParameter("@BMDCRegistration", aDoctor.BMDCRegistration ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@NoofRx", aDoctor.NoofRx ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@Gender", aDoctor.Gender ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@DegreeType", aDoctor.DegreeType ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@DoctorAddress", aDoctor.DoctorAddress ?? (object)DBNull.Value ?? (object)DBNull.Value)); 


              

                gSqlParameterList.Add(new SqlParameter("@NoofPatient", aDoctor.NoofPatient ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@DoctorPatientStatus", aDoctor.DoctorPatientStatus ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@NoofCallPerMonth", aDoctor.NoofCallPerMonth ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@Location", aDoctor.Location ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@TourTypeId", aDoctor.TourTypeId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                int pk = 0;

                if (aDoctor.DoctorId > 0)
                {
                    aInformation.isSuccess = accessManager.UpdateData("sp_Webapi_Save_DoctorUpdate", gSqlParameterList);
                    if (aInformation.isSuccess)
                    {
                        pk = aDoctor.DoctorId;
                    }
                }
                else
                {
                    pk = accessManager.SaveDataReturnPrimaryKey("sp_Webapi_Save_DoctorEntry", gSqlParameterList);




                }
                if (pk > 0)
                {
                    aInformation.isSuccess = true;

                    try
                    {
                        if (!string.IsNullOrEmpty(aDoctor.VisitingCardImg))
                        {
                            AppPrimaryDAL app = new AppPrimaryDAL();
                            ImagePath _path = new ImagePath();
                            string type = "DoctorVisitingCard";
                            _path = app.GetImagePath(type);
                            string targetPath = @"" + _path.ImagePathValue + "";
                            if (!Directory.Exists(targetPath))
                            {
                                Directory.CreateDirectory(targetPath);
                            }

                            string filePath = targetPath + "/" + _path.ImagePreName + pk + "." + "jpg";
                            File.WriteAllBytes(filePath, Convert.FromBase64String(aDoctor.VisitingCardImg));
                        }
                    }
                    catch
                    {

                    }

                }
                if (aInformation.isSuccess)
                {
                    string[] degreeList = null;
                    string[] BrandList = null;
                    string[] spList = null;
                    string[] docTypeList = null;
                    string[] instituteList = null;
                    string[] weeklyvisitdayList = null;
                    try
                    {
                        degreeList = aDoctor.DegreeStr.Split(',');

                    }
                    catch
                    {

                    }
                    try
                    {
                          BrandList = aDoctor.BrandStr.Split(',');
                    }
                    catch
                    {

                    }
                    try
                    {
                        spList = aDoctor.SpecialityStr.Split(',');
                    }
                    catch
                    {

                    }
                    try
                    {
                        docTypeList = aDoctor.DoctorTypeStr.Split(',');
                    }
                    catch { }

                    try
                    {
                        instituteList = aDoctor.InstitutionSTr.Split(',');
                    }
                    catch { }

                    try
                    {
                        weeklyvisitdayList = aDoctor.Weeklyvisitday.Split(',');
                    }
                    catch { }


                    try
                    {
                        if (degreeList.Length > 0)
                    {
                        foreach (String item in degreeList)
                        {
                            if (item != "")
                            {
                                List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                                aSqlParameterList.Add(new SqlParameter("@masterId", pk));
                                aSqlParameterList.Add(new SqlParameter("@itemName", item));
                                aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_DoctorDegreeDetail", aSqlParameterList);
                            }

                        }

                    }
                    }
                    catch { }
                    try
                    {
                        if (spList.Length > 0)
                    {
                        foreach (String item in spList)
                            if (item != "")
                            {
                                {
                                    List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                                    aSqlParameterList.Add(new SqlParameter("@masterId", pk));
                                    aSqlParameterList.Add(new SqlParameter("@itemName", item));
                                    aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_DoctorSpecialityDetail", aSqlParameterList);
                                }
                            }

                    }
                    }
                    catch { }
                    try
                    {
                        if (docTypeList.Length > 0)
                    {
                        foreach (String item in docTypeList)
                        {
                            if (item != "")
                            {
                                List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                                aSqlParameterList.Add(new SqlParameter("@masterId", pk));
                                aSqlParameterList.Add(new SqlParameter("@itemName", item));
                                aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_DoctorTypeDetail", aSqlParameterList);
                            }
                        }

                    }
                    }
                    catch { }
                    try
                    {
                        if (instituteList.Length > 0)
                        {
                            foreach (String item in instituteList)
                            {
                                if (item != "")
                                {
                                    List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                                    aSqlParameterList.Add(new SqlParameter("@masterId", pk));
                                    aSqlParameterList.Add(new SqlParameter("@itemName", item));
                                    aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_DoctorInstitutionDetail", aSqlParameterList);
                                }
                            }

                        }
                    }
                    catch { }

                    
                    try
                    {
                        if (weeklyvisitdayList.Length > 0)
                        {
                            foreach (String item in weeklyvisitdayList)
                            {
                                if (item != "")
                                {
                                    List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                                    aSqlParameterList.Add(new SqlParameter("@masterId", pk));
                                    aSqlParameterList.Add(new SqlParameter("@itemName", item));
                                    aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_DoctorweeklyvisitdayDetail", aSqlParameterList);
                                }
                            }

                        }
                    }
                    catch { }



                    try
                    {
                        if (BrandList.Length > 0)
                        {
                            foreach (String item in BrandList)
                            {
                                if (item != "")
                                {
                                    List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                                    aSqlParameterList.Add(new SqlParameter("@masterId", pk));
                                    aSqlParameterList.Add(new SqlParameter("@itemName", item));
                                    aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_DoctorBrandDetail", aSqlParameterList);
                                }
                            }

                        }
                    }
                    catch { }
                    try
                    {
                        if (aDoctor.aChemberListDAO != null)
                    {
                        foreach (DoctorChemberDetailDAO item in aDoctor.aChemberListDAO)
                        {
                            List<SqlParameter> aSqlParameterList = new List<SqlParameter>();

                            aSqlParameterList.Add(new SqlParameter("@pk", pk));
                            aSqlParameterList.Add(new SqlParameter("@ChamberTypeId", item.ChamberTypeId));
                            aSqlParameterList.Add(new SqlParameter("@Name", item.Name));
                            aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_DoctorChemberDetail", aSqlParameterList);

                        }
                    }
                     
                }
                 catch
                 {
 
                  }


            try
                    {
                        if (aDoctor.PracticeList != null)
                    {
                        foreach (PracticeListDAO item in aDoctor.PracticeList)
                        {
                            List<SqlParameter> aSqlParameterList = new List<SqlParameter>();

                            aSqlParameterList.Add(new SqlParameter("@pk", pk));
                            aSqlParameterList.Add(new SqlParameter("@PracticeShiftId", item.PracticeShiftId));
                            aSqlParameterList.Add(new SqlParameter("@Time", item.Time));
                            aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_DoctorPracticeShiftDetail", aSqlParameterList);

                        }
                    }
                    }
                    catch
                    {

                    }


            try
                    {
                        if (aDoctor.CustomerList != null)
                    {
                        foreach (CustomerViewModel item in aDoctor.CustomerList)
                        {
                            List<SqlParameter> aSqlParameterList = new List<SqlParameter>();

                            aSqlParameterList.Add(new SqlParameter("@pk", pk));
                            aSqlParameterList.Add(new SqlParameter("@CustomerMasterId", item.CustomerMasterId));
                            aSqlParameterList.Add(new SqlParameter("@CustomerName", item.CustomerName));
                            aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_CustomerInDoctorDetail", aSqlParameterList);

                        }
                    }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (aDoctor.aDoctorContactDAO != null)
                    {
                        foreach (DoctorContactDAO item in aDoctor.aDoctorContactDAO)
                        {
                            List<SqlParameter> aSqlParameterList = new List<SqlParameter>();

                            aSqlParameterList.Add(new SqlParameter("@pk", pk));
                            aSqlParameterList.Add(new SqlParameter("@Contact", item.Contact ?? (object)DBNull.Value ?? (object)DBNull.Value));
                            aSqlParameterList.Add(new SqlParameter("@ContactTypeId", item.ContactTypeId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                            aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_DoctorContactDetail", aSqlParameterList);

                        }
                    }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (aDoctor.aDoctorSpecialDAO != null)
                    {
                        foreach (DoctorSpecialDAO item in aDoctor.aDoctorSpecialDAO)
                        {
                            List<SqlParameter> aSqlParameterList = new List<SqlParameter>();

                            aSqlParameterList.Add(new SqlParameter("@pk", pk));
                            aSqlParameterList.Add(new SqlParameter("@SpeciaDateStr", item.SpeciaDateStr ?? (object)DBNull.Value ?? (object)DBNull.Value));
                            aSqlParameterList.Add(new SqlParameter("@SpecialDayId", item.SpecialDayId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                            aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_DoctorSpecialDayDetail", aSqlParameterList);

                        }
                    }
                    }
                    catch
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


        public ResultInfo UpdateDoctorProviderDAL(string empId, string DoctorId, String ProviderTypeId)
        {

            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@empId", empId));
                gSqlParameterList.Add(new SqlParameter("@DoctorId", DoctorId));
                gSqlParameterList.Add(new SqlParameter("@ProgramTypeId", ProviderTypeId));

                aInformation.isSuccess = accessManager.UpdateData("sp_Webapi_UpdateDoctorProvider", gSqlParameterList);



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


        public ResultInfo UpdateDoctorMarketDAL(DoctorMArket_DAO _DAO)
        {

            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                List<SqlParameter> sqlCheck = new List<SqlParameter>();


                gSqlParameterList.Add(new SqlParameter("@empId", _DAO.empId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@DoctorId", _DAO.DoctorId ?? (object)DBNull.Value ?? (object)DBNull.Value));
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

                    aInformation.isSuccess = accessManager.UpdateData("sp_Webapi_UpdateDoctorMarket", gSqlParameterList);
                }
                else
                {
                    aInformation.Msd = "This Market is not valid. Please select another market.";

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


        public IList<DoctorList_DAO> GetDoctorList(int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@empid", empId));

                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorList", gSqlParameterList);
                List<DoctorList_DAO> aList = new List<DoctorList_DAO>();
                for (var i = 0; i < dt.Rows.Count; i++)

                {
                    DoctorList_DAO aInfo = new DoctorList_DAO();

                    if (dt.Rows[i]["DoctorId"] != DBNull.Value)
                    {
                        aInfo.DoctorId = Convert.ToInt32(dt.Rows[i]["DoctorId"].ToString());
                    }
                    if (dt.Rows[i]["DoctorName"] != DBNull.Value)
                    {
                        aInfo.DoctorName = (dt.Rows[i]["DoctorName"].ToString());
                    }

                    if (dt.Rows[i]["DoctorCode"] != DBNull.Value)
                    {
                        aInfo.DoctorCode = (dt.Rows[i]["DoctorCode"].ToString());
                    }


                    if (dt.Rows[i]["DocContact"] != DBNull.Value)
                    {
                        aInfo.DocContact = (dt.Rows[i]["DocContact"].ToString());
                    }



                    if (dt.Rows[i]["Gender"] != DBNull.Value)
                    {
                        aInfo.Gender = dt.Rows[i]["Gender"].ToString();
                    }
                    if (dt.Rows[i]["DoctorAddress"] != DBNull.Value)
                    {
                        aInfo.DoctorAddress = dt.Rows[i]["DoctorAddress"].ToString();
                    }

                    if (dt.Rows[i]["DoctorPatientStatus"] != DBNull.Value)
                    {
                        aInfo.DoctorPatientStatus = dt.Rows[i]["DoctorPatientStatus"].ToString();
                    }

                    //if (dt.Rows[i]["ProgramTypeName"] != DBNull.Value)
                    //{
                    //    aInfo.ProgramTypeName = dt.Rows[i]["ProgramTypeName"].ToString();
                    //}

                    //if (dt.Rows[i]["ChemberName"] != DBNull.Value)
                    //{
                    //    aInfo.ChemberName = dt.Rows[i]["ChemberName"].ToString();
                    //}


                    aInfo.GroupId = dt.Rows[i]["GroupId"] != DBNull.Value ? dt.Rows[i]["GroupId"].ToString() : "";
                    aInfo.RegionId = dt.Rows[i]["RegionId"] != DBNull.Value ? dt.Rows[i]["RegionId"].ToString() : "";
                    aInfo.AreaId = dt.Rows[i]["AreaId"] != DBNull.Value ? dt.Rows[i]["AreaId"].ToString() : "";
                    aInfo.TerritoryId = dt.Rows[i]["TerritoryId"] != DBNull.Value ? dt.Rows[i]["TerritoryId"].ToString() : "";
                    aInfo.SubTerritoryId = dt.Rows[i]["SubTerritoryId"] != DBNull.Value ? dt.Rows[i]["SubTerritoryId"].ToString() : "";
                    aInfo.MarketId = dt.Rows[i]["MarketId"] != DBNull.Value ? dt.Rows[i]["MarketId"].ToString() : "";
                    aInfo.MarketName = dt.Rows[i]["MarketName"] != DBNull.Value ? dt.Rows[i]["MarketName"].ToString() : "";
           


                    List<SqlParameter> aSqlParameterListDetals = new List<SqlParameter>();

                    aSqlParameterListDetals.Add(new SqlParameter("@DoctorId", dt.Rows[i]["DoctorId"]));
                    DataTable dtDoctorChem = accessManager.GetDataTable("sp_Webapi_Get_DoctorBrandByDoctorId", aSqlParameterListDetals);



                     
                    List<doctorBrandDAO> aDetailsList = new List<doctorBrandDAO>();
                    doctorBrandDAO aChemberDetails;
                    for (var ch = 0; ch < dtDoctorChem.Rows.Count; ch++)

                    {

                        aChemberDetails = new doctorBrandDAO();
                        if (dtDoctorChem.Rows[ch]["DoctorId"] != DBNull.Value)
                        {
                            aChemberDetails.DoctorId = Convert.ToInt32(dtDoctorChem.Rows[ch]["DoctorId"].ToString());
                        }

                        if (dtDoctorChem.Rows[ch]["BrandId"] != DBNull.Value)
                        {
                            aChemberDetails.BrandId = Convert.ToInt32(dtDoctorChem.Rows[ch]["BrandId"].ToString());
                        }


                        if (dtDoctorChem.Rows[ch]["BrandName"] != DBNull.Value)
                        {
                            aChemberDetails.BrandName = dtDoctorChem.Rows[ch]["BrandName"].ToString();
                        }

                        aDetailsList.Add(aChemberDetails);
                    }
                    
               
                    
                    
                    aInfo.doctorBrand = aDetailsList;

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




        public IList<DoctorList_DAO> GetPlannedDoctorList(int empId, string date)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@empid", empId));
                gSqlParameterList.Add(new SqlParameter("@date", date));

                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_PlannedDoctorList", gSqlParameterList);
                List<DoctorList_DAO> aList = new List<DoctorList_DAO>();
                for (var i = 0; i < dt.Rows.Count; i++)

                {
                    DoctorList_DAO aInfo = new DoctorList_DAO();

                    if (dt.Rows[i]["DoctorId"] != DBNull.Value)
                    {
                        aInfo.DoctorId = Convert.ToInt32(dt.Rows[i]["DoctorId"].ToString());
                    }
                    if (dt.Rows[i]["DoctorName"] != DBNull.Value)
                    {
                        aInfo.DoctorName = (dt.Rows[i]["DoctorName"].ToString());
                    }

                    if (dt.Rows[i]["DoctorCode"] != DBNull.Value)
                    {
                        aInfo.DoctorCode = (dt.Rows[i]["DoctorCode"].ToString());
                    }


                    if (dt.Rows[i]["DocContact"] != DBNull.Value)
                    {
                        aInfo.DocContact = (dt.Rows[i]["DocContact"].ToString());
                    }



                    if (dt.Rows[i]["Gender"] != DBNull.Value)
                    {
                        aInfo.Gender = dt.Rows[i]["Gender"].ToString();
                    }
                    if (dt.Rows[i]["DoctorAddress"] != DBNull.Value)
                    {
                        aInfo.DoctorAddress = dt.Rows[i]["DoctorAddress"].ToString();
                    }

                    if (dt.Rows[i]["DoctorPatientStatus"] != DBNull.Value)
                    {
                        aInfo.DoctorPatientStatus = dt.Rows[i]["DoctorPatientStatus"].ToString();
                    }

                    //if (dt.Rows[i]["ProgramTypeName"] != DBNull.Value)
                    //{
                    //    aInfo.ProgramTypeName = dt.Rows[i]["ProgramTypeName"].ToString();
                    //}

                    //if (dt.Rows[i]["ChemberName"] != DBNull.Value)
                    //{
                    //    aInfo.ChemberName = dt.Rows[i]["ChemberName"].ToString();
                    //}


                    aInfo.GroupId = dt.Rows[i]["GroupId"] != DBNull.Value ? dt.Rows[i]["GroupId"].ToString() : "";
                    aInfo.RegionId = dt.Rows[i]["RegionId"] != DBNull.Value ? dt.Rows[i]["RegionId"].ToString() : "";
                    aInfo.AreaId = dt.Rows[i]["AreaId"] != DBNull.Value ? dt.Rows[i]["AreaId"].ToString() : "";
                    aInfo.TerritoryId = dt.Rows[i]["TerritoryId"] != DBNull.Value ? dt.Rows[i]["TerritoryId"].ToString() : "";
                    aInfo.SubTerritoryId = dt.Rows[i]["SubTerritoryId"] != DBNull.Value ? dt.Rows[i]["SubTerritoryId"].ToString() : "";
                    aInfo.MarketId = dt.Rows[i]["MarketId"] != DBNull.Value ? dt.Rows[i]["MarketId"].ToString() : "";
                    aInfo.MarketName = dt.Rows[i]["MarketName"] != DBNull.Value ? dt.Rows[i]["MarketName"].ToString() : "";



                    List<SqlParameter> aSqlParameterListDetals = new List<SqlParameter>();

                    aSqlParameterListDetals.Add(new SqlParameter("@DoctorId", dt.Rows[i]["DoctorId"]));
                    DataTable dtDoctorChem = accessManager.GetDataTable("sp_Webapi_Get_DoctorBrandByDoctorId", aSqlParameterListDetals);




                    List<doctorBrandDAO> aDetailsList = new List<doctorBrandDAO>();
                    doctorBrandDAO aChemberDetails;
                    for (var ch = 0; ch < dtDoctorChem.Rows.Count; ch++)

                    {

                        aChemberDetails = new doctorBrandDAO();
                        if (dtDoctorChem.Rows[ch]["DoctorId"] != DBNull.Value)
                        {
                            aChemberDetails.DoctorId = Convert.ToInt32(dtDoctorChem.Rows[ch]["DoctorId"].ToString());
                        }

                        if (dtDoctorChem.Rows[ch]["BrandId"] != DBNull.Value)
                        {
                            aChemberDetails.BrandId = Convert.ToInt32(dtDoctorChem.Rows[ch]["BrandId"].ToString());
                        }


                        if (dtDoctorChem.Rows[ch]["BrandName"] != DBNull.Value)
                        {
                            aChemberDetails.BrandName = dtDoctorChem.Rows[ch]["BrandName"].ToString();
                        }

                        aDetailsList.Add(aChemberDetails);
                    }




                    aInfo.doctorBrand = aDetailsList;

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

        //public DataTable GetDoctorList(int empId)
        //{
        //    try
        //    {
        //        accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
        //        List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
        //        aSqlParameterlist.Add(new SqlParameter("@empid", empId));

        //        DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorList", aSqlParameterlist);
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


        public DoctorSM GetDoctorEdtMode(int doctorId)
        {
            if (doctorId <= 0) return null;

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                var prms = new List<SqlParameter>
        {
            new SqlParameter("@DoctorID", SqlDbType.Int) { Value = doctorId }
        };

                // ✅ Execute as stored procedure
                DataSet ds = accessManager.GetDataSet(
                    "sp_Webapi_Get_DoctorEdtMode",
                    prms 
                );

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    return null;

                // ---------------- 1) Master ----------------
                DataRow mRow = ds.Tables[0].Rows[0];
                var m = new DoctorSM
                {
                    DoctorId = ToInt(mRow, "DoctorId"),
                    DoctorName = ToStr(mRow, "DoctorName"),
                     DegreeType = ToStr(mRow, "DegreeType"),
                    Remarks = ToStr(mRow, "Remarks"),
                    DivisionId = ToInt(mRow, "DivisionId"),
                    DistrictId = ToInt(mRow, "DistrictId"),
                    ThanaId = ToInt(mRow, "ThanaId"),
                    DegreeStr = ToStr(mRow, "DegreeStr"),
                    BrandStr = ToStr(mRow, "BrandStr"),
                    SpecialityStr = ToStr(mRow, "SpecialityStr"),
                    DoctorTypeStr = ToStr(mRow, "DoctorTypeStr"),
                    InstitutionSTr = ToStr(mRow, "InstitutionSTr"),
                    DoctorTypeId = ToInt(mRow, "DoctorTypeId"),
                    SessionUser = ToInt(mRow, "SessionUser"),
                    SubMarketId = ToInt(mRow, "SubMarketId"),
                    MarketId = ToInt(mRow, "MarketId"),
                    TerritoryId = ToInt(mRow, "TerritoryId"),
                    SubTerritoryId = ToInt(mRow, "SubTerritoryId"),
                    UnionName = ToStr(mRow, "UnionName"),
                    BMDCRegistration = ToStr(mRow, "BMDCRegistration"),
                    Gender = ToStr(mRow, "Gender"),
                    Weeklyvisitday = ToStr(mRow, "WeeklyVisitDay"), // <-- keep consistent naming
                    Location = ToStr(mRow, "Location"),
                    DoctorAddress = ToStr(mRow, "DoctorAddress"),
                    NoofPatient = ToStr(mRow, "NoOfPatient"),
                    NoofRx = ToStr(mRow, "NoOfRx"),
                    DoctorPatientStatus = ToStr(mRow, "DoctorPatientStatus"),
                    NoofCallPerMonth = ToStr(mRow, "NoOfCallPerMonth"),
                    VisitingCardImg = ToStr(mRow, "VisitingCardImg"),
                    DoctorCategoryId = ToInt(mRow, "DoctorCategoryId"),
                    StationTypeId = ToInt(mRow, "StationTypeId"),
                    DesignationId = ToInt(mRow, "DesignationId"),
                    // If SP returns INT, convert in SP to NVARCHAR; otherwise ToStr still works
                    TourTypeId = ToStr(mRow, "TourTypeId")
                };

                // ---------------- 2) Contacts ----------------
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    var contacts = new List<DoctorContactDAO>();
                    foreach (DataRow r in ds.Tables[1].Rows)
                    {
                        contacts.Add(new DoctorContactDAO
                        {
                            ContactTypeId = ToInt(r, "ContactTypeId"),
                            ContactType = ToStr(r, "ContactType"),
                            Contact = ToStr(r, "Contact")
                        });
                    }
                    m.aDoctorContactDAO = contacts; // property set (C# way)
                }

                // ---------------- 3) Practice Shifts ----------------
                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    var shifts = new List<PracticeListDAO>();
                    foreach (DataRow r in ds.Tables[2].Rows)
                    {
                        shifts.Add(new PracticeListDAO
                        {

                            PracticeShift = ToStr(r, "LocationName"),
                            Time = ToStr(r, "LocationName"),
                            PracticeShiftId = ToInt(r, "PracticeShiftId")
                        });
                    }
                    m.PracticeList = shifts;
                }

                // ---------------- 4) Specials ----------------
                if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                {
                    var specs = new List<DoctorSpecialDAO>();
                    foreach (DataRow r in ds.Tables[3].Rows)
                    {
                        specs.Add(new DoctorSpecialDAO
                        {
                           
                            SpecialDay = ToStr(r, "SpecialDay")
                        });
                    }
                    m.aDoctorSpecialDAO = specs;
                }

                // ---------------- 4) Specials ----------------
                if (ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
                {
                    var specs = new List<CustomerViewModel>();
                    foreach (DataRow r in ds.Tables[4].Rows)
                    {
                        specs.Add(new CustomerViewModel
                        {
                           
                            CustomerMasterId = ToInt(r, "CustomerMasterId"),
                            CustomerName = ToStr(r, "CustomerName")
                        });
                    }
                    m.CustomerList = specs;
                }

                return m;
            }
            catch
            {
                // Optional: log
                throw; // rethrow so caller can handle
            }
            finally
            {
                accessManager.SqlConnectionClose(); // close once
            }
        }

        // ---------- Null-safe helpers ----------
        private static string ToStr(DataRow row, string col)
        {
            return row.Table.Columns.Contains(col) && row[col] != DBNull.Value ? Convert.ToString(row[col]) : string.Empty;
        }
        private static int ToInt(DataRow row, string col)
        {
            if (!row.Table.Columns.Contains(col) || row[col] == DBNull.Value) return 0;
            int v; return int.TryParse(row[col].ToString(), out v) ? v : 0;
        }




        public IList<DoctorAppLog_DAO> GetDoctor_ApplogDAL(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, string ProgramTypeId, string DoctorTypeId)
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

                //gSqlParameterList.Add(new SqlParameter("@StationTypeId", StationTypeId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ProgramTypeId", ProgramTypeId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@DoctorTypeId", DoctorTypeId ?? (object)DBNull.Value ?? (object)DBNull.Value));



                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorClaimApp", gSqlParameterList);
                //SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_Get_DoctorClaimApp", gSqlParameterList);
                List<DoctorAppLog_DAO> aList = new List<DoctorAppLog_DAO>();
                for (var i = 0; i < dt.Rows.Count; i++)

                           {
                    DoctorAppLog_DAO aInfo = new DoctorAppLog_DAO();


                    if (dt.Rows[i]["DoctorApprovalId"] != DBNull.Value)
                    {
                        aInfo.DoctorApprovalId = Convert.ToInt32(dt.Rows[i]["DoctorApprovalId"].ToString());
                    }

                    if (dt.Rows[i]["DoctorId"] != DBNull.Value)
                    {
                        aInfo.DoctorId = Convert.ToInt32(dt.Rows[i]["DoctorId"]);
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


                    if (dt.Rows[i]["WaitingRole"] != DBNull.Value)
                    {
                        aInfo.WaitingRole = dt.Rows[i]["WaitingRole"].ToString();
                    }


                    if (dt.Rows[i]["WatingEmployee"] != DBNull.Value)
                    {
                        aInfo.WatingEmployee = dt.Rows[i]["WatingEmployee"].ToString();
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


                    List<SqlParameter> aSqlParameterListDetals = new List<SqlParameter>();

                    aSqlParameterListDetals.Add(new SqlParameter("@DoctorId", aInfo.TableId));
                    DataTable dtDoctor = accessManager.GetDataTable("sp_Webapi_Get_DoctorMaster_AppLog", aSqlParameterListDetals);

                   
                    DoctorSMDao aDetails;
                  

                        aDetails = new DoctorSMDao();
                        if (dtDoctor.Rows[0]["DoctorId"] != DBNull.Value)
                        {
                            aDetails.DoctorId = Convert.ToInt32(dtDoctor.Rows[0]["DoctorId"].ToString());
                        }
                        if (dtDoctor.Rows[0]["DoctorName"] != DBNull.Value)
                        {
                            aDetails.DoctorName = dtDoctor.Rows[0]["DoctorName"].ToString();
                        }

                        if (dtDoctor.Rows[0]["DoctorCode"] != DBNull.Value)
                        {
                            aDetails.DoctorCode = dtDoctor.Rows[0]["DoctorCode"].ToString();
                        }

                        if (dtDoctor.Rows[0]["ContactTypeId"] != DBNull.Value)
                        {
                            aDetails.ContactTypeId = Convert.ToInt32(dtDoctor.Rows[0]["ContactTypeId"].ToString());
                        }

                    if (dtDoctor.Rows[0]["ContactType"] != DBNull.Value)
                    {
                        aDetails.ContactType = dtDoctor.Rows[0]["ContactType"].ToString();
                    }

                    if (dtDoctor.Rows[0]["Contact"] != DBNull.Value)
                    {
                        aDetails.Contact = dtDoctor.Rows[0]["Contact"].ToString();
                    }

                    if (dtDoctor.Rows[0]["DesignationName"] != DBNull.Value)
                        {
                            aDetails.DesignationName = dtDoctor.Rows[0]["DesignationName"].ToString();
                        }


                        if (dtDoctor.Rows[0]["DoctorTypeId"] != DBNull.Value)
                        {
                            aDetails.DoctorTypeId = Convert.ToInt32(dtDoctor.Rows[0]["DoctorTypeId"].ToString());
                        }

                  

                    if (dtDoctor.Rows[0]["DoctorTypeName"] != DBNull.Value)
                        {
                            aDetails.DoctorTypeStr = dtDoctor.Rows[0]["DoctorTypeName"].ToString();
                        }


                        if (dtDoctor.Rows[0]["DegreeName"] != DBNull.Value)
                        {
                            aDetails.DegreeStr = dtDoctor.Rows[0]["DegreeName"].ToString();
                        }

                        if (dtDoctor.Rows[0]["DoctorSpeciality"] != DBNull.Value)
                        {
                            aDetails.SpecialityStr = dtDoctor.Rows[0]["DoctorSpeciality"].ToString();
                        }

                        if (dtDoctor.Rows[0]["DoctorInstitution"] != DBNull.Value)
                        {
                            aDetails.InstitutionSTr = dtDoctor.Rows[0]["DoctorInstitution"].ToString();
                        }
                        if (dtDoctor.Rows[0]["DoctorBrand"] != DBNull.Value)
                        {
                            aDetails.BrandStr = dtDoctor.Rows[0]["DoctorBrand"].ToString();
                        }

                        if (dtDoctor.Rows[0]["DoctorCategoryId"] != DBNull.Value)
                        {
                            aDetails.DoctorCategoryId = Convert.ToInt32(dtDoctor.Rows[0]["DoctorCategoryId"].ToString());
                        }

                        if (dtDoctor.Rows[0]["CategoryName"] != DBNull.Value)
                        {
                            aDetails.CategoryName = dtDoctor.Rows[0]["CategoryName"].ToString();
                        }

                        if (dtDoctor.Rows[0]["ProgramTypeId"] != DBNull.Value)
                        {
                            aDetails.ProgramTypeId = Convert.ToInt32(dtDoctor.Rows[0]["ProgramTypeId"].ToString());
                        }


                    if (dtDoctor.Rows[0]["DesignationId"] != DBNull.Value)
                    {
                        aDetails.DesignationId = Convert.ToInt32(dtDoctor.Rows[0]["DesignationId"].ToString());
                    }

                    if (dtDoctor.Rows[0]["ProgramTypeName"] != DBNull.Value)
                        {
                            aDetails.ProgramTypeName = dtDoctor.Rows[0]["ProgramTypeName"].ToString();
                        }

                    if (dtDoctor.Rows[0]["StationTypeId"] != DBNull.Value)
                    {
                        aDetails.StationTypeId = Convert.ToInt32(dtDoctor.Rows[0]["StationTypeId"].ToString());
                    }

                    if (dtDoctor.Rows[0]["SpecialDayId"] != DBNull.Value)
                        {
                            aDetails.SpecialDayId = Convert.ToInt32(dtDoctor.Rows[0]["SpecialDayId"].ToString());
                        }

                        if (dtDoctor.Rows[0]["SpecialDay"] != DBNull.Value)
                        {
                            aDetails.SpecialDay = dtDoctor.Rows[0]["SpecialDay"].ToString();
                        }

                        if (dtDoctor.Rows[0]["AreaName"] != DBNull.Value)
                        {
                            aDetails.AreaName = dtDoctor.Rows[0]["AreaName"].ToString();
                        }

                        if (dtDoctor.Rows[0]["TerritoryName"] != DBNull.Value)
                        {
                            aDetails.TerritoryName = dtDoctor.Rows[0]["TerritoryName"].ToString();
                        }

                        if (dtDoctor.Rows[0]["SubTerritoryName"] != DBNull.Value)
                        {
                            aDetails.SubTerritoryName = dtDoctor.Rows[0]["SubTerritoryName"].ToString();
                        }


                        if (dtDoctor.Rows[0]["MarketName"] != DBNull.Value)
                        {
                            aDetails.MarketName = dtDoctor.Rows[0]["MarketName"].ToString();
                        }

                    if (dtDoctor.Rows[0]["RegionName"] != DBNull.Value)
                    {
                        aDetails.RegionName = dtDoctor.Rows[0]["RegionName"].ToString();
                    }


                    if (dtDoctor.Rows[0]["TerritoryId"] != DBNull.Value)
                    {
                        aDetails.TerritoryId = Convert.ToInt32(dtDoctor.Rows[0]["TerritoryId"].ToString());
                    }

                    if (dtDoctor.Rows[0]["SubTerritoryId"] != DBNull.Value)
                    {
                        aDetails.SubTerritoryId = Convert.ToInt32(dtDoctor.Rows[0]["SubTerritoryId"].ToString());
                    }
                    if (dtDoctor.Rows[0]["MarketId"] != DBNull.Value)
                        {
                            aDetails.MarketId = Convert.ToInt32(dtDoctor.Rows[0]["MarketId"].ToString());
                        }


                        if (dtDoctor.Rows[0]["SpeciaDateStr"] != DBNull.Value)
                        {
                            aDetails.SpeciaDateStr = dtDoctor.Rows[0]["SpeciaDateStr"].ToString();
                        }

                        if (dtDoctor.Rows[0]["Reamrks"] != DBNull.Value)
                        {
                            aDetails.Remarks = dtDoctor.Rows[0]["Reamrks"].ToString();
                        }


                    if (dtDoctor.Rows[0]["SMCType"] != DBNull.Value)
                    {
                        aDetails.SMCTypeName = (dtDoctor.Rows[0]["SMCType"].ToString());
                    }


                    if (dtDoctor.Rows[0]["SMCTypeId"] != DBNull.Value)
                    {
                        aDetails.SMCTypeId = Convert.ToInt32(dtDoctor.Rows[0]["SMCTypeId"].ToString());
                    }
                    if (dtDoctor.Rows[0]["DoctorAddress"] != DBNull.Value)
                    {
                        aDetails.DoctorAddress = (dtDoctor.Rows[0]["DoctorAddress"].ToString());
                    }
                    //aDoctorMasterList.Add(aDetails);
                    List<SqlParameter> asqChem = new List<SqlParameter>();

                        asqChem.Add(new SqlParameter("@DoctorId", aInfo.TableId));
                        DataTable dtDoctorChem = accessManager.GetDataTable("sp_Webapi_Get_DoctorChember_AppLog", asqChem);
                        List<DoctorChemberDetailDAOApp> aDetailsList = new List<DoctorChemberDetailDAOApp>();
                        DoctorChemberDetailDAOApp aChemberDetails;
                        for (var ch = 0; ch < dtDoctorChem.Rows.Count; ch++)

                        {

                            aChemberDetails = new DoctorChemberDetailDAOApp();
                            if (dtDoctorChem.Rows[ch]["ChamberTypeId"] != DBNull.Value)
                            {
                                aChemberDetails.ChamberTypeId = Convert.ToInt32(dtDoctorChem.Rows[ch]["ChamberTypeId"].ToString());
                            }

                            if (dtDoctorChem.Rows[ch]["ChamberTypeName"] != DBNull.Value)
                            {
                                aChemberDetails.ChamberTypeName = dtDoctorChem.Rows[ch]["ChamberTypeName"].ToString();
                            }
                            if (dtDoctorChem.Rows[ch]["ChamberName"] != DBNull.Value)
                            {
                                aChemberDetails.ChamberName = dtDoctorChem.Rows[ch]["ChamberName"].ToString();
                            }
                            aDetailsList.Add(aChemberDetails);
                        }
                        aDetails.aChemberListDAO = aDetailsList;




                    List<SqlParameter> asqCon = new List<SqlParameter>();

                    asqCon.Add(new SqlParameter("@DoctorId", aInfo.TableId));
                    DataTable dtCon = accessManager.GetDataTable("sp_Webapi_Get_DoctorContact_AppLog", asqCon);
                    List<DoctorContactDAONew> aConList = new List<DoctorContactDAONew>();
                    DoctorContactDAONew aConDetails;
                    for (var ch = 0; ch < dtCon.Rows.Count; ch++)

                    {

                        aConDetails = new DoctorContactDAONew();
                        if (dtCon.Rows[ch]["ContactTypeId"] != DBNull.Value)
                        {
                            aConDetails.ContactTypeId = Convert.ToInt32(dtCon.Rows[ch]["ContactTypeId"].ToString());
                        }

                        if (dtCon.Rows[ch]["Contact"] != DBNull.Value)
                        {
                            aConDetails.Contact = dtCon.Rows[ch]["Contact"].ToString();
                        }

                        if (dtCon.Rows[ch]["ContactType"] != DBNull.Value)
                        {
                            aConDetails.ContactType = dtCon.Rows[ch]["ContactType"].ToString();
                        }

                        aConList.Add(aConDetails);
                    }
                    aDetails.aDoctorContactDAO = aConList;


                    List<SqlParameter> asqday = new List<SqlParameter>();

                    asqday.Add(new SqlParameter("@DoctorId", aInfo.TableId));
                    DataTable dtday = accessManager.GetDataTable("sp_Webapi_Get_DoctorSpecialDay_AppLog", asqday);
                    List<DoctorSpecialDAONew> aDayList = new List<DoctorSpecialDAONew>();
                    DoctorSpecialDAONew aDayDetails;
                    for (var ch = 0; ch < dtday.Rows.Count; ch++)

                    {

                        aDayDetails = new DoctorSpecialDAONew();
                        if (dtday.Rows[ch]["SpecialDayId"] != DBNull.Value)
                        {
                            aDayDetails.SpecialDayId = Convert.ToInt32(dtday.Rows[ch]["SpecialDayId"].ToString());
                        }

                        if (dtday.Rows[ch]["SpecialDate"] != DBNull.Value)
                        {
                            aDayDetails.SpeciaDateStr = dtday.Rows[ch]["SpecialDate"].ToString();
                        }

                        if (dtday.Rows[ch]["SpecialDay"] != DBNull.Value)
                        {
                            aDayDetails.SpecialDay = dtday.Rows[ch]["SpecialDay"].ToString();
                        }

                        aDayList.Add(aDayDetails);
                    }
                    aDetails.aDoctorSpecialDAO = aDayList;




                    aInfo.DoctorMasterDao = aDetails;




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


        public ResultInfo SaveDoctor_ApplogDAL(SaveDoctorAppLog_DAO atten)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@DoctorApprovalId", atten.DoctorApprovalId ?? (object)DBNull.Value ?? (object)DBNull.Value));
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

                aInformation.isSuccess = accessManager.SaveData("sp_webapi_SaveDoctorAppLog", gSqlParameterList);

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



        public ResultInfo SaveDCR_ApplogDAL(SaveDCRAppLog_DAO atten)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@DCRApprovalId", atten.DCRApprovalId ?? (object)DBNull.Value ?? (object)DBNull.Value));
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

                aInformation.isSuccess = accessManager.SaveData("sp_webapi_SaveDCRAppLog", gSqlParameterList);

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


    

        public DataTable GetPrescriptionTYpe(int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empid", empId));

                DataTable dt = accessManager.GetDataTable("sp_WebAPi_Get_PrescriptionType", aSqlParameterlist);
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


        public ResultInfo SavePrescritpion(PrescriptionSM aInfo)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@doctorId", aInfo.rxDoctor ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@rxOtherDoctor", aInfo.rxOtherDoctor ?? (object)DBNull.Value ?? (object)DBNull.Value));
       
               
                gSqlParameterList.Add(new SqlParameter("@rxDate", aInfo.rxDate ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@submitDate", aInfo.submitDate ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@sessionUser", aInfo.submitby ?? (object)DBNull.Value ?? (object)DBNull.Value));


                int pk = 0;
                pk = accessManager.SaveDataReturnPrimaryKey("sp_Webapi_Save_Prescription", gSqlParameterList);
                if (pk > 0)
                {
                    aInformation.isSuccess = true;
                    foreach (daorxBrand item in aInfo.rxBrand)
                    {
                        List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                        aSqlParameterList.Add(new SqlParameter("@productId", item.ProductId));
                        aSqlParameterList.Add(new SqlParameter("@pk", pk));
                        aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_PrescriptionDetail", aSqlParameterList);

                    }


                }

                if (aInformation.isSuccess)
                {

                    if (aInfo.rxImg != "")
                    {
                        AppPrimaryDAL app = new AppPrimaryDAL();
                        ImagePath _path = new ImagePath();
                        string type = "Prescription";
                        _path = app.GetImagePath(type);



                        string targetPath = @"" + _path.ImagePathValue + "";


                        if (!System.IO.Directory.Exists(targetPath))
                        {
                            System.IO.Directory.CreateDirectory(targetPath);
                        }

                        string filePath = targetPath + "/" + _path.ImagePreName + pk + "." + "jpg";
                        File.WriteAllBytes(filePath, Convert.FromBase64String(aInfo.rxImg));
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

        public DataTable GetPrescriptionList(int empId, string FromDt, string ToDt)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empid", empId));
                aSqlParameterlist.Add(new SqlParameter("@FromDt", FromDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@ToDt", ToDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_PrescriptionList", aSqlParameterlist);
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

        public ResultInfo SavePrescription_ApplogDAL(SavePrescription_Applog_DAO atten)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@PrescriptionApprovalId", atten.PrescriptionApprovalId ?? (object)DBNull.Value ?? (object)DBNull.Value));
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

                aInformation.isSuccess = accessManager.SaveData("sp_webapi_SavePrescriptionAppLog", gSqlParameterList);

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
        public IList<Prescription_Applog_DAO> GetPrescription_ApplogDAL(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, string GroupId, string ZoneId, string AreaId, string TerritoryId)
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
                gSqlParameterList.Add(new SqlParameter("@GroupId", GroupId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@ZoneId", ZoneId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@AreaId", AreaId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@TerritoryId", TerritoryId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_PrescriptionApp", gSqlParameterList);
                //SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_Get_DoctorClaimApp", gSqlParameterList);
                List<Prescription_Applog_DAO> aList = new List<Prescription_Applog_DAO>();
                for (var i = 0; i < dt.Rows.Count; i++)

                {
                    Prescription_Applog_DAO aInfo = new Prescription_Applog_DAO();


                    if (dt.Rows[i]["PrescriptionApprovalId"] != DBNull.Value)
                    {
                        aInfo.PrescriptionApprovalId = Convert.ToInt32(dt.Rows[i]["PrescriptionApprovalId"].ToString());
                    }

                    if (dt.Rows[i]["PrescriptionId"] != DBNull.Value)
                    {
                        aInfo.PrescriptionId = Convert.ToInt32(dt.Rows[i]["PrescriptionId"]);
                    }

                    if (dt.Rows[i]["EmpInfoId"] != DBNull.Value)
                    {
                        aInfo.EmpInfoId = Convert.ToInt32(dt.Rows[i]["EmpInfoId"].ToString());

                    }

                    if (dt.Rows[i]["EntryDate"] != DBNull.Value)
                    {
                        aInfo.Date = (dt.Rows[i]["EntryDate"].ToString());
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


                    List<SqlParameter> aSqlParameterListDetals = new List<SqlParameter>();

                    aSqlParameterListDetals.Add(new SqlParameter("@id", aInfo.TableId));
                    DataTable dtDoctor = accessManager.GetDataTable("sp_Webapi_Get_PrescriptionByPrescriptionIdId", aSqlParameterListDetals);


                    PrescriptionRMasterDAO aDetails;


                    aDetails = new PrescriptionRMasterDAO();

                    if (dtDoctor.Rows[0]["PrescriptionId"] != DBNull.Value)
                    {
                        aDetails.PrescriptionId = Convert.ToInt32(dtDoctor.Rows[0]["PrescriptionId"].ToString());
                    }

                    if (dtDoctor.Rows[0]["DoctorId"] != DBNull.Value)
                    {
                        aDetails.DoctorId = Convert.ToInt32(dtDoctor.Rows[0]["DoctorId"].ToString());
                    }

                    if (dtDoctor.Rows[0]["PrescriptionDate"] != DBNull.Value)
                    {
                        aDetails.PrescriptionDate = dtDoctor.Rows[0]["PrescriptionDate"].ToString();
                    }


                    if (dtDoctor.Rows[0]["PrescriptionType"] != DBNull.Value)
                    {
                        aDetails.PrescriptionType = dtDoctor.Rows[0]["PrescriptionType"].ToString();
                    }


                    if (dtDoctor.Rows[0]["DoctorName"] != DBNull.Value)
                    {
                        aDetails.DoctorName = dtDoctor.Rows[0]["DoctorName"].ToString();
                    }


                    if (dtDoctor.Rows[0]["ChemberName"] != DBNull.Value)
                    {
                        aDetails.ChemberName = dtDoctor.Rows[0]["ChemberName"].ToString();
                    }



                    if (dtDoctor.Rows[0]["GroupName"] != DBNull.Value)
                    {
                        aDetails.GroupName = dtDoctor.Rows[0]["GroupName"].ToString();
                    }


                    if (dtDoctor.Rows[0]["AreaName"] != DBNull.Value)
                    {
                        aDetails.AreaName = dtDoctor.Rows[0]["AreaName"].ToString();
                    }

                    if (dtDoctor.Rows[0]["TerritoryName"] != DBNull.Value)
                    {
                        aDetails.TerritoryName = dtDoctor.Rows[0]["TerritoryName"].ToString();
                    }


                    if (dtDoctor.Rows[0]["SubTerritoryName"] != DBNull.Value)
                    {
                        aDetails.SubTerritoryName = dtDoctor.Rows[0]["SubTerritoryName"].ToString();
                    }

                    if (dtDoctor.Rows[0]["MarketName"] != DBNull.Value)
                    {
                        aDetails.MarketName = dtDoctor.Rows[0]["MarketName"].ToString();
                    }


                    if (dtDoctor.Rows[0]["ImageString"] != DBNull.Value)
                    {
                        aDetails.ImageString = dtDoctor.Rows[0]["ImageString"].ToString();
                    }

                    List<SqlParameter> asqChem = new List<SqlParameter>();

                    asqChem.Add(new SqlParameter("@id", aInfo.TableId));
                    DataTable dtDoctorChem = accessManager.GetDataTable("sp_Webapi_Get_PresCripProductbyId", asqChem);
                    List<PrescriptionDtlsDAO> aDetailsList = new List<PrescriptionDtlsDAO>();
                    PrescriptionDtlsDAO aChemberDetails;
                    for (var ch = 0; ch < dtDoctorChem.Rows.Count; ch++)

                    {

                        aChemberDetails = new PrescriptionDtlsDAO();


                        if (dtDoctorChem.Rows[ch]["ProductId"] != DBNull.Value)
                        {
                            aChemberDetails.ProductId = Convert.ToInt32(dtDoctorChem.Rows[ch]["ProductId"].ToString());
                        }


                        if (dtDoctorChem.Rows[ch]["ProductName"] != DBNull.Value)
                        {
                            aChemberDetails.ProductName = dtDoctorChem.Rows[ch]["ProductName"].ToString();
                        }

                        aDetailsList.Add(aChemberDetails);
                    }
                    aDetails.aPrescriptionDtlsDAO = aDetailsList;



                    aInfo.aPrescriptionRMasterDAO = aDetails;




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
         

        public IList<DCRMaster_App> GetDCR_ApplogDAL(string pram, string Role, string AppStatus, string Month, string Year, string EmpId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>(); 
                gSqlParameterList.Add(new SqlParameter("@Role", Role ?? (object)DBNull.Value ?? (object)DBNull.Value));
                pram = NewMethod(pram, Role, gSqlParameterList);

                gSqlParameterList.Add(new SqlParameter("@AppStatus", AppStatus ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@Month", Month ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Year", Year ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EmpId", EmpId ?? (object)DBNull.Value ?? (object)DBNull.Value));

              


                DataTable dtDoctor = accessManager.GetDataTable("sp_Webapi_Get_DCRApp", gSqlParameterList);
                //SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_Get_DoctorClaimApp", gSqlParameterList);
                List<DCRMaster_App> aList = new List<DCRMaster_App>();
                for (var i = 0; i < dtDoctor.Rows.Count; i++)

                {
                    DCRMaster_App aDetails = new DCRMaster_App();

                     

                  


                   

                   
  
                        aDetails.dcrId = dtDoctor.Rows[i]["dcrId"].ToString();
                        aDetails.dcrDate = dtDoctor.Rows[i]["dcrDate"].ToString();

                    aDetails.planned = dtDoctor.Rows[i]["planned"].ToString();
                    

                    
                        aDetails.doctorName = dtDoctor.Rows[i]["doctorName"].ToString();
                   


                     
                        

                    
                        aDetails.callTime = dtDoctor.Rows[i]["callTime"].ToString();
                    


                   
                        aDetails.callType = dtDoctor.Rows[i]["callType"].ToString();
                    

                    
                        aDetails.doctorType = dtDoctor.Rows[i]["doctorType"].ToString();
                    
                        aDetails.productPriority = dtDoctor.Rows[i]["productPriority"].ToString();
                    

                     
                        aDetails.callWith = dtDoctor.Rows[i]["callWith"].ToString();
                        aDetails.entryBy = dtDoctor.Rows[i]["entryBy"].ToString();
                        aDetails.approvalStatus = dtDoctor.Rows[i]["approvalStatus"].ToString();




                    aList.Add(aDetails);

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

        public DataTable GetVisitTYpe()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctoreVisitTypeForDcr");
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

        public DataTable GetBrandWisePromo()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_BrandWisePromo");
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

        public DataTable GetDoctorChamberForDcr(int doctorId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>
                {
                    new SqlParameter("@doctorId",doctorId)
                };
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorChamberByDocId", aSqlParameterlist);
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

        public DataTable GetProductForDcrByType(int empId, string type)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>
                {
                    new SqlParameter("@empId",empId),
                    new SqlParameter("@type",type)
                };
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DcrProductByType", aSqlParameterlist);
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



        public ResultInfo SaveDcr(DcrMaster aInfo)
        {
            ResultInfo aInformation = new ResultInfo();


            DateTime dtSuppliedDate = DateTime.Parse(aInfo.date);

            if (dtSuppliedDate.Subtract(DateTime.Today).Days == 0 || dtSuppliedDate.Subtract(DateTime.Today).Days == -1)
            {
                try
                {




                    accessManager.SqlConnectionOpen(DataBase.SalesDisDB);


                    DataTable dtProduct = new DataTable();
                    bool insuf = false;

                    string msg = "";
                    if (aInfo.callpriorityProducts != null)
                    {
                        foreach (ModelCallPriorityProduct item in aInfo.callpriorityProducts)
                        {

                            foreach (BrandWisePromo Promoitem in item.BrandWisePromoList)
                            {
                                List<SqlParameter> gList = new List<SqlParameter>();
                                gList.Add(new SqlParameter("@BrandId", item.BrandId));
                              
                                gList.Add(new SqlParameter("@promoId", Promoitem.promoId));
                                gList.Add(new SqlParameter("@EmpInfoId", aInfo.empId));
                                dtProduct = accessManager.GetDataTable("sp_Webapi_CHK_PROMOProductQty", gList);
                                if (dtProduct.Rows.Count == 0)
                                {
                                
                                    insuf = true;

                                    try
                                    {
                                        DataTable dtProductCHK = accessManager.GetDataTable("sp_Webapi_CHK_PROMOProductQty_kk", gList);

                                        msg = dtProductCHK.Rows[0]["MessageBox"].ToString();
                                    }
                                    catch { }
                                }
                            }
                        }
                    }


                    int pk = 0;

                    if (insuf == false)
                    {
                        List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                    DateTime entryDtae = DateTime.Now;

                    gSqlParameterList.Add(new SqlParameter("@empId", aInfo.empId));
                    gSqlParameterList.Add(new SqlParameter("@dcrDate", aInfo.date));
                    gSqlParameterList.Add(new SqlParameter("@drId", aInfo.drId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                    gSqlParameterList.Add(new SqlParameter("@callStatus", null ?? (object)DBNull.Value ?? (object)DBNull.Value));
                    gSqlParameterList.Add(new SqlParameter("@callTime", aInfo.callTime ?? (object)DBNull.Value ?? (object)DBNull.Value));

                    gSqlParameterList.Add(new SqlParameter("@callType", aInfo.callType ?? (object)DBNull.Value ?? (object)DBNull.Value));
                    gSqlParameterList.Add(new SqlParameter("@drcallType", aInfo.drcallType ?? (object)DBNull.Value ?? (object)DBNull.Value));

                    gSqlParameterList.Add(new SqlParameter("@planned", aInfo.planned ?? (object)DBNull.Value ?? (object)DBNull.Value));

                    gSqlParameterList.Add(new SqlParameter("@DCPDetailId", aInfo.DCPDetailId ?? (object)DBNull.Value ?? (object)DBNull.Value));

                    pk = accessManager.SaveDataReturnPrimaryKey("sp_Webapi_Save_DcrInfo", gSqlParameterList);
                    if (pk > 0)
                    {
                        aInformation.isSuccess = true;


                        string[] CallWithList = null;

                        try
                        {
                            CallWithList = aInfo.callWith.Split(',');

                        }
                        catch
                        {

                        }


                        try
                        {
                            if (CallWithList.Length > 0)
                            {
                                foreach (String item in CallWithList)
                                {
                                    if (item != "")
                                    {
                                        List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                                        aSqlParameterList.Add(new SqlParameter("@pk", pk));
                                        aSqlParameterList.Add(new SqlParameter("@RoleType", item));
                                        aSqlParameterList.Add(new SqlParameter("@empId", aInfo.empId));
                                        aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_DcrVisitedWith", aSqlParameterList);
                                    }

                                }

                            }
                        }
                        catch { }

                        if (aInfo.callpriorityProducts != null)
                        {
                            foreach (ModelCallPriorityProduct item in aInfo.callpriorityProducts)
                            {

                                foreach (BrandWisePromo Promoitem in item.BrandWisePromoList)
                                {
                                    List<SqlParameter> agf = new List<SqlParameter>();
                                    agf.Add(new SqlParameter("@BrandId", item.BrandId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                 
                                    agf.Add(new SqlParameter("@priority", item.priority ?? (object)DBNull.Value ?? (object)DBNull.Value));

                                    agf.Add(new SqlParameter("@BrandWisePromoId", Promoitem.promoId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                                    agf.Add(new SqlParameter("@EmpInfoId", aInfo.empId));
                                    agf.Add(new SqlParameter("@pk", pk));

                                    aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_DcrProduct", agf);
                                }
                            }

                            }
                        
                        aInformation.Msd = "DCR Saved!";
                    }


                    else
                    {
                        aInformation.Msd = "Doctor Already Added!";

                    }
                    }
                    else
                    {
                        aInformation.isValiCheck = true;
                        //if (dtDoctorChem.Rows[0]["Qty"] != DBNull.Value)
                        //{
                        aInformation.Msd = msg;
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
            }

            else
            {
                aInformation.isSuccess = false;

                aInformation.Msd = "Can not Make call  for this day!";
            }
            return aInformation;



        }


        public DataTable GetDcrList(string empId, string FromDt, string ToDt)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empid", empId));
                aSqlParameterlist.Add(new SqlParameter("@FromDt", FromDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@ToDt", ToDt ?? (object)DBNull.Value ?? (object)DBNull.Value));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DcrListById", aSqlParameterlist);
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




        public ResultInfo DeleteDCP(string DCPDetailId )
        {


            ResultInfo aInformation = new ResultInfo();
            try

            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@DCPDetailId", DCPDetailId));
          
                aInformation.isSuccess = accessManager.DeleteData("sp_Webapi_Delete_DCP", gSqlParameterList);

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


        public ResultInfo SaveDCP_Applog(DCPMaster_App aInfo)
        {


            ResultInfo aInformation = new ResultInfo();
            try

            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();

                gSqlParameterList.Add(new SqlParameter("@empId", aInfo.empId));
 
               
                gSqlParameterList.Add(new SqlParameter("@DCPMasterId", aInfo.DCPMasterId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@approvalStatus", aInfo.approvalStatus ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@Remarks", aInfo.Remarks ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@RoleType", aInfo.RoleType ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aInformation.isSuccess = accessManager.DeleteData("sp_Webapi_Save_DCP_AppLog", gSqlParameterList);

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


        public ResultInfo SaveDCR_Applog(DCRMaster_App_New aInfo)
        {


            ResultInfo aInformation = new ResultInfo();
            try

            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();

                gSqlParameterList.Add(new SqlParameter("@empId", aInfo.empId));


                gSqlParameterList.Add(new SqlParameter("@dcrId", aInfo.dcrId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@approvalStatus", aInfo.approvalStatus ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@Remarks", aInfo.Remarks ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@RoleType", aInfo.RoleType ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aInformation.isSuccess = accessManager.DeleteData("sp_Webapi_Save_DCR_AppLog", gSqlParameterList);

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
        public ResultInfo DeleteDCR(int id)
        {


            ResultInfo aInformation = new ResultInfo();
            try

            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@id", id));
                aInformation.isSuccess = accessManager.DeleteData("sp_Webapi_Delete_Dcr", gSqlParameterList);

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


        public DataTable GetDoctorDesignation()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorDesignation");
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

        public DataTable GetDWSPTotalsDAL(int month, int year, int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@month", month));
                gSqlParameterList.Add(new SqlParameter("@year", year));
                gSqlParameterList.Add(new SqlParameter("@empId", empId));
                DataTable dt = accessManager.GetDataTable("sp_Get_GetDWSPTotalsByEmpId", gSqlParameterList);
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


        public ResultInfo SaveDocTourPlan(List<DocTourPlanMaster> aInfo)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                DateTime entryDtae = DateTime.Now;
                if (aInfo != null)
                {
                    foreach (DocTourPlanMaster item in aInfo)
                    {
                        List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                        gSqlParameterList.Add(new SqlParameter("@TourDate", item.TourPlanDate));
                        gSqlParameterList.Add(new SqlParameter("@doctorId", item.DoctorId));
                        gSqlParameterList.Add(new SqlParameter("@empId", item.EmpInfoId));
                        aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_TourPlanInfo_Doctor", gSqlParameterList);

                    }


                }
                else
                {
                    aInformation.isSuccess = false;
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


        public ResultInfo SaveDCPInfo(DCPMaster aInfo)
        {
            ResultInfo aInformation = new ResultInfo();

            string todaydate = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime dtSuppliedDate = DateTime.Parse(aInfo.DCPDate);

            if (dtSuppliedDate.Subtract(DateTime.Today).Days >=0)
            {
             
                try
            {




                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);


                int pk = 0;
















                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@doctorId", aInfo.DoctorId));
                gSqlParameterList.Add(new SqlParameter("@TourTypeId", "0" ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@WorkSession", aInfo.WorkSession ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@empId", aInfo.empId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@DCPDate", aInfo.DCPDate ?? (object)DBNull.Value ?? (object)DBNull.Value));

             
                    pk = accessManager.SaveDataReturnPrimaryKey("sp_Webapi_Save_DCPDetail", gSqlParameterList);


                    if (pk > 0)
                    {
                        aInformation.isSuccess = true;

                        aInformation.Msd = "Saved Successfully!";

                    }
                    else
                    {
                        aInformation.isSuccess = false;

                        aInformation.Msd = "Already Call Plan for this Doctor!";
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
            }

            else
            {
                aInformation.isSuccess = false;

                aInformation.Msd = "Can not Call Plan  for previous day!";
            }
            return aInformation;



        } 



        public ResultInfo SaveDWSPDAL(DWSPMasterDAO item)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                DateTime entryDtae = DateTime.Now;
                 
                     
                        List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                        gSqlParameterList.Add(new SqlParameter("@DWSPDate", item.DWSPDate ?? (object)DBNull.Value ?? (object)DBNull.Value));
                        gSqlParameterList.Add(new SqlParameter("@empId", item.EmpInfoId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                        gSqlParameterList.Add(new SqlParameter("@FCBAmount", item.FCBAmount ?? (object)DBNull.Value ?? (object)DBNull.Value));
                        gSqlParameterList.Add(new SqlParameter("@CampaignAmount", item.CampaignAmount ?? (object)DBNull.Value ?? (object)DBNull.Value));
                        gSqlParameterList.Add(new SqlParameter("@GeneralAmount", item.GeneralAmount ?? (object)DBNull.Value ?? (object)DBNull.Value));

                        aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_DWSPMaster", gSqlParameterList);

                  
                if (aInformation.isSuccess == false)
                {
                    aInformation.Msd = "Already Submitted!";
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

        public DataTable Get_DoctorTourPLanDetails(int month, int year, int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@month", month));
                aSqlParameterlist.Add(new SqlParameter("@year", year));
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_TourTourPlanDetails", aSqlParameterlist);
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





        public IList<DCPList> GetDCPList(int month, int year, int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@month", month));
                aSqlParameterlist.Add(new SqlParameter("@year", year));
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                //DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DCPList", aSqlParameterlist);
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DCPMaster", aSqlParameterlist);
                 
                List<DCPList> aList = new List<DCPList>();
                for (var i = 0; i < dt.Rows.Count; i++)

                {
                    DCPList aInfo = new DCPList();




                    if (dt.Rows[i]["DayNameStr"] != DBNull.Value)
                    {
                        aInfo.DayNameStr = (dt.Rows[i]["DayNameStr"].ToString());
                    }


                    if (dt.Rows[i]["DCPMasterId"] != DBNull.Value)
                    {
                        aInfo.DCPMasterId = (dt.Rows[i]["DCPMasterId"].ToString());
                    }


                    if (dt.Rows[i]["MonthValue"] != DBNull.Value)
                    {
                        aInfo.MonthValue = (dt.Rows[i]["MonthValue"].ToString());
                    }

                    if (dt.Rows[i]["YearValue"] != DBNull.Value)
                    {
                        aInfo.YearValue = (dt.Rows[i]["YearValue"].ToString());
                    }

                    if (dt.Rows[i]["DayValue"] != DBNull.Value)
                    {
                        aInfo.DayValue = (dt.Rows[i]["DayValue"].ToString());
                    }



                    if (dt.Rows[i]["DCPDate"] != DBNull.Value)
                    {
                        aInfo.DCPDate = (dt.Rows[i]["DCPDate"].ToString());
                    }

                    if (dt.Rows[i]["IsFinalSubmit"] != DBNull.Value)
                    {
                        aInfo.IsFinalSubmit = (dt.Rows[i]["IsFinalSubmit"].ToString());
                    }


                    if (dt.Rows[i]["CoutPlan"] != DBNull.Value)
                    {
                        aInfo.CoutPlan = (dt.Rows[i]["CoutPlan"].ToString());
                    }

                    if (dt.Rows[i]["FinalSubmitRemarks"] != DBNull.Value)
                    {
                        aInfo.FinalSubmitRemarks = (dt.Rows[i]["FinalSubmitRemarks"].ToString());
                    }

                    List<SqlParameter> aSqlParameterListDetals = new List<SqlParameter>();

                    aSqlParameterListDetals.Add(new SqlParameter("@DCPDate", aInfo.DCPDate));
                    aSqlParameterListDetals.Add(new SqlParameter("@month", month));
                    aSqlParameterListDetals.Add(new SqlParameter("@year", year));
                    aSqlParameterListDetals.Add(new SqlParameter("@empId", empId));

                    DataTable dtVW = accessManager.GetDataTable("sp_Webapi_Get_DCPList", aSqlParameterListDetals);


                    List<DCPListDao> aVWList = new List<DCPListDao>();
                    DCPListDao aVWDetails;
                    for (var ch = 0; ch < dtVW.Rows.Count; ch++)

                    {

                        aVWDetails = new DCPListDao();

                        if (dtVW.Rows[ch]["RowNum"] != DBNull.Value)
                        {
                            aVWDetails.SL = (dtVW.Rows[ch]["RowNum"].ToString());
                        }
                        if (dtVW.Rows[ch]["worksession"] != DBNull.Value)
                        {
                            aVWDetails.worksession = (dtVW.Rows[ch]["worksession"].ToString());
                        }

                        if (dtVW.Rows[ch]["tourType"] != DBNull.Value)
                        {
                            aVWDetails.tourType = dtVW.Rows[ch]["tourType"].ToString();
                        }


                        if (dtVW.Rows[ch]["DCPDetailId"] != DBNull.Value)
                        {
                            aVWDetails.DCPDetailId = dtVW.Rows[ch]["DCPDetailId"].ToString();
                        }



                        if (dtVW.Rows[ch]["DoctorName"] != DBNull.Value)
                        {
                            aVWDetails.DoctorName = dtVW.Rows[ch]["DoctorName"].ToString();
                        }


                        if (dtVW.Rows[ch]["DoctorId"] != DBNull.Value)
                        {
                            aVWDetails.DoctorId = dtVW.Rows[ch]["DoctorId"].ToString();
                        }
                        if (dtVW.Rows[ch]["isCalled"] != DBNull.Value)
                        {
                            aVWDetails.isCalled = Convert.ToBoolean(dtVW.Rows[ch]["isCalled"]);
                            
                        }







                        aVWList.Add(aVWDetails);
                    }
                    aInfo.DCPListDtl = aVWList;




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

        public DataTable GetDWSPDetailDAL(int month, int year, int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@month", month));
                aSqlParameterlist.Add(new SqlParameter("@year", year));
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DWSPDetails", aSqlParameterlist);
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
        public ResultInfo DeleteDoctorTourPlan(int id)
        {


            ResultInfo aInformation = new ResultInfo();
            try

            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@id", id));
                aInformation.isSuccess = accessManager.DeleteData("sp_Webapi_Delete_DoctorTourPlan", gSqlParameterList);

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


        public ResultInfo FinalSubmitDoctorTour(int empId, int month, int year, String remarks)
        {

            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@empId", empId));
                gSqlParameterList.Add(new SqlParameter("@month", month));
                gSqlParameterList.Add(new SqlParameter("@year", year));
                gSqlParameterList.Add(new SqlParameter("@remarks", remarks));
                aInformation.isSuccess = accessManager.UpdateData("sp_Webapi_Update_DoctorFinalSubmit", gSqlParameterList);
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


        public ResultInfo DCPFinalSubmit(int empId, int month, int year, String remarks)
        {

            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@empId", empId));
                gSqlParameterList.Add(new SqlParameter("@month", month));
                gSqlParameterList.Add(new SqlParameter("@year", year));
                gSqlParameterList.Add(new SqlParameter("@remarks", remarks));
                aInformation.isSuccess = accessManager.UpdateData("sp_Webapi_Update_DCPFinalSubmit", gSqlParameterList);
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


        public DataTable Get_TourPlanMasterData(int month, int year, int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                aSqlParameterlist.Add(new SqlParameter("@month", month));
                aSqlParameterlist.Add(new SqlParameter("@year", year));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorVisitPlanMasterData", aSqlParameterlist);
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
        public DCPMasterDataDao GetDCPMaster(int month, int year, int empId)
        {

            DCPMasterDataDao aInformation = new DCPMasterDataDao();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                aSqlParameterlist.Add(new SqlParameter("@month", month));
                aSqlParameterlist.Add(new SqlParameter("@year", year));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DCPMasterData", aSqlParameterlist);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["DCPMasterId"] != DBNull.Value)
                    {
                        aInformation.DCPMasterId = Convert.ToInt32(dt.Rows[0]["DCPMasterId"].ToString());
                    }


                    if (dt.Rows[0]["MonthValue"] != DBNull.Value)
                    {
                        aInformation.MonthValue = Convert.ToInt32(dt.Rows[0]["MonthValue"].ToString());
                    }


                    if (dt.Rows[0]["YearValue"] != DBNull.Value)
                    {
                        aInformation.YearValue = Convert.ToInt32(dt.Rows[0]["YearValue"].ToString());
                    }

                    if (dt.Rows[0]["EmpInfoId"] != DBNull.Value)
                    {
                        aInformation.EmpInfoId = Convert.ToInt32(dt.Rows[0]["EmpInfoId"].ToString());
                    }

                    if (dt.Rows[0]["IsFinalSubmit"] != DBNull.Value)
                    {
                        aInformation.IsFinalSubmit = Convert.ToBoolean(dt.Rows[0]["IsFinalSubmit"].ToString());
                    }

                    if (dt.Rows[0]["ApprovalStatus"] != DBNull.Value)
                    {
                        aInformation.ApprovalStatus = (dt.Rows[0]["ApprovalStatus"].ToString());
                    }


                  
                        aInformation.FinalSubmitRemarks = (dt.Rows[0]["FinalSubmitRemarks"].ToString());
                 

                   
                        aInformation.CoutPlan = (dt.Rows[0]["CoutPlan"].ToString());
                  

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


        public DataTable GetTodaysDoctorPlan(DateTime cDate, int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@cDate", cDate));
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
           
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DoctorPlanByDate", aSqlParameterlist);
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
        public DataTable GetDWSPByDateDAL(DateTime cDate, int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@cDate", cDate));
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));

                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DWSPByDate", aSqlParameterlist);
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
        public DataTable GetTodaysTask( int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
            
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));

                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_TodaysTask", aSqlParameterlist);
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
        public DataTable GetUserRole()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_Userrole");
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


        public DataTable GetEmpInfoRoleID(int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();

                aSqlParameterlist.Add(new SqlParameter("@empId", empId));

                DataTable dt = accessManager.GetDataTable("sp_Webapi_GetEmpInfoRoleID", aSqlParameterlist);
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

        public DataTable GetUserByRoleId(int id,int empId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@id", id));
                aSqlParameterlist.Add(new SqlParameter("@empId", empId));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_UserByRoleId", aSqlParameterlist);
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


        public DataTable GetDoctorVisitTYpe()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_VisitTypeForDcr");
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


        public ResultInfo SaveDoctorVisitPlan_ApplogDAL(SaveDoctorVisit_Applog_DAO atten)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                DateTime entryDtae = DateTime.Now;

                gSqlParameterList.Add(new SqlParameter("@VisitPlanApprovalId", atten.VisitPlanApprovalId ?? (object)DBNull.Value ?? (object)DBNull.Value));
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

                aInformation.isSuccess = accessManager.SaveData("sp_webapi_SaveVisitPlanAppLog", gSqlParameterList);

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

        public IList<DoctorVisitPlan_Applog_DAO> GetDoctorVisit_ApplogDAL(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, int? MonthValue, int? YearValue)
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
                gSqlParameterList.Add(new SqlParameter("@MonthValue", MonthValue ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@YearValue", YearValue ?? (object)DBNull.Value ?? (object)DBNull.Value));


                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_VisitPlanApp", gSqlParameterList);
                //SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_Get_DoctorClaimApp", gSqlParameterList);
                List<DoctorVisitPlan_Applog_DAO> aList = new List<DoctorVisitPlan_Applog_DAO>();
                for (var i = 0; i < dt.Rows.Count; i++)

                {
                    DoctorVisitPlan_Applog_DAO aInfo = new DoctorVisitPlan_Applog_DAO();


                    if (dt.Rows[i]["DocTPMaster"] != DBNull.Value)
                    {
                        aInfo.DocTPMaster = Convert.ToInt32(dt.Rows[i]["DocTPMaster"].ToString());
                    }

                    if (dt.Rows[i]["MonthValue"] != DBNull.Value)
                    {
                        aInfo.MonthValue = Convert.ToInt32(dt.Rows[i]["MonthValue"]);
                    }

                    if (dt.Rows[i]["YearValue"] != DBNull.Value)
                    {
                        aInfo.YearValue = Convert.ToInt32(dt.Rows[i]["YearValue"]);
                    }

                    if (dt.Rows[i]["VisitPlanApprovalId"] != DBNull.Value)
                    {
                        aInfo.VisitPlanApprovalId = Convert.ToInt32(dt.Rows[i]["VisitPlanApprovalId"]);
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


                    List<SqlParameter> aSqlParameterListDetals = new List<SqlParameter>();

                    aSqlParameterListDetals.Add(new SqlParameter("@id", aInfo.TableId));
                    DataTable dtDoctor = accessManager.GetDataTable("sp_webapi_GetDoctorVisitPlanMasterById", aSqlParameterListDetals);


                    DoctorVisitPlanMasterDAO aDetails;


                    aDetails = new DoctorVisitPlanMasterDAO();

                    if (dtDoctor.Rows[0]["DocTPMaster"] != DBNull.Value)
                    {
                        aDetails.DocTPMaster = Convert.ToInt32(dtDoctor.Rows[0]["DocTPMaster"].ToString());
                    }
                    if (dtDoctor.Rows[0]["EmpInfoId"] != DBNull.Value)
                    {
                        aDetails.EmpInfoId = Convert.ToInt32(dtDoctor.Rows[0]["EmpInfoId"].ToString());
                    }

                    if (dtDoctor.Rows[0]["MonthValue"] != DBNull.Value)
                    {
                        aDetails.MonthValue = (dtDoctor.Rows[0]["MonthValue"].ToString());
                    }

                    if (dtDoctor.Rows[0]["YearValue"] != DBNull.Value)
                    {
                        aDetails.YearValue = dtDoctor.Rows[0]["YearValue"].ToString();
                    }

                    

                    if (dtDoctor.Rows[0]["MonthName"] != DBNull.Value)
                    {
                        aDetails.MonthName = dtDoctor.Rows[0]["MonthName"].ToString();
                    }


                    if (dtDoctor.Rows[0]["IsFinalSubmit"] != DBNull.Value)
                    {
                        aDetails.IsFinalSubmit = Convert.ToBoolean(dtDoctor.Rows[0]["IsFinalSubmit"].ToString());
                    }
                    if (dtDoctor.Rows[0]["ApprovalStatus"] != DBNull.Value)
                    {
                        aDetails.ApprovalStatus = dtDoctor.Rows[0]["ApprovalStatus"].ToString();
                    }


                    List<SqlParameter> asqChem = new List<SqlParameter>();

                    asqChem.Add(new SqlParameter("@id", aInfo.TableId));
                    DataTable dtDoctorChem = accessManager.GetDataTable("sp_webapi_GetDoctorVisitDateById", asqChem);
                    List<dcvisDtlsDAODate> aDetailsList = new List<dcvisDtlsDAODate>();
                    dcvisDtlsDAODate aChemberDetails;
                    for (var ch = 0; ch < dtDoctorChem.Rows.Count; ch++)

                    {



                        aChemberDetails = new dcvisDtlsDAODate();



                        if (dtDoctorChem.Rows[ch]["TourPlanDate"] != DBNull.Value)
                        {
                            aChemberDetails.VisitPlanDate = dtDoctorChem.Rows[ch]["TourPlanDate"].ToString();

                         
                        string TourPlanDate = dtDoctorChem.Rows[ch]["TourPlanDate"].ToString();


                            if (dtDoctorChem.Rows[ch]["DayValue"] != DBNull.Value)
                            {
                                aChemberDetails.DayValue = dtDoctorChem.Rows[ch]["DayValue"].ToString();

                            }
                            if (dtDoctorChem.Rows[ch]["DayName"] != DBNull.Value)
                            {
                                aChemberDetails.DayName = dtDoctorChem.Rows[ch]["DayName"].ToString();

                            }


                            List<SqlParameter> asqDetls = new List<SqlParameter>();

                            asqDetls.Add(new SqlParameter("@id", aInfo.TableId));
                            asqDetls.Add(new SqlParameter("@TourPlanDate", TourPlanDate));
                            DataTable dtDtl = accessManager.GetDataTable("sp_webapi_GetvisitPlanDetailById_new", asqDetls);
                            List<VisitPlanDtlsDAO> amarketList = new List<VisitPlanDtlsDAO>();
                            VisitPlanDtlsDAO aMrkDtls;
                            for (var chmr = 0; chmr < dtDtl.Rows.Count; chmr++)

                            {

                                aMrkDtls = new VisitPlanDtlsDAO();


                                
                                if (dtDtl.Rows[chmr]["DoctorName"] != DBNull.Value)
                                {
                                    aMrkDtls.DoctorName = dtDtl.Rows[chmr]["DoctorName"].ToString();

                                }

                                amarketList.Add(aMrkDtls);
                            }



                            aChemberDetails.aVisitDtlsDAO = amarketList;


                        }




                        aDetailsList.Add(aChemberDetails);
                    }

                    aDetails.aDoctorVisitPlanDetail = aDetailsList;


                    aInfo.aDoctorVisitPlanMaster = aDetails;



                    //if (dtDoctor.Rows[0]["DoctorName"] != DBNull.Value)
                    //{
                    //    aDetails.DoctorName = dtDoctor.Rows[0]["DoctorName"].ToString();
                    //}

                  





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

        public IList<DCPListAPP> GetDCP_Applog(string pram, string Role, string AppStatus, string Month, string Year, string EmpId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                gSqlParameterList.Add(new SqlParameter("@param", pram ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Role", Role ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@AppStatus", AppStatus ?? (object)DBNull.Value ?? (object)DBNull.Value));

                gSqlParameterList.Add(new SqlParameter("@Month", Month ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@Year", Year ?? (object)DBNull.Value ?? (object)DBNull.Value));
                gSqlParameterList.Add(new SqlParameter("@EmpId", EmpId ?? (object)DBNull.Value ?? (object)DBNull.Value));
           
                
                    DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DCPApp", gSqlParameterList);

                    List<DCPListAPP> aList = new List<DCPListAPP>();
                    for (var i = 0; i < dt.Rows.Count; i++)

                    {
                    DCPListAPP aInfo = new DCPListAPP();




                        


                        if (dt.Rows[i]["DCPMasterId"] != DBNull.Value)
                        {
                            aInfo.DCPMasterId = (dt.Rows[i]["DCPMasterId"].ToString());
                        }

 

                        


                        if (dt.Rows[i]["DCPDate"] != DBNull.Value)
                        {
                            aInfo.DCPDate = (dt.Rows[i]["DCPDate"].ToString());
                        }

                        if (dt.Rows[i]["IsFinalSubmit"] != DBNull.Value)
                        {
                            aInfo.IsFinalSubmit = (dt.Rows[i]["IsFinalSubmit"].ToString());
                        }


                        if (dt.Rows[i]["CoutPlan"] != DBNull.Value)
                        {
                            aInfo.ApprovalStatus = (dt.Rows[i]["CoutPlan"].ToString());
                        }

                        if (dt.Rows[i]["FinalSubmitRemarks"] != DBNull.Value)
                        {
                            aInfo.FinalSubmitRemarks = (dt.Rows[i]["FinalSubmitRemarks"].ToString());
                        }


                    if (dt.Rows[i]["EntryBy"] != DBNull.Value)
                    {
                        aInfo.EntryBy = (dt.Rows[i]["EntryBy"].ToString());
                    }

                    string EmpInfoId = "";
                    if (dt.Rows[i]["EmpInfoId"] != DBNull.Value)
                    {
                        EmpInfoId = (dt.Rows[i]["EmpInfoId"].ToString());
                    }
                    List<SqlParameter> aSqlParameterListDetals = new List<SqlParameter>();

                        aSqlParameterListDetals.Add(new SqlParameter("@empId", EmpInfoId ));
                        aSqlParameterListDetals.Add(new SqlParameter("@DCPDate", aInfo.DCPDate));


                    DataTable dtVW = accessManager.GetDataTable("sp_Webapi_Get_DCPListAPP", aSqlParameterListDetals);


                        List<DCPListDao> aVWList = new List<DCPListDao>();
                        DCPListDao aVWDetails;
                        for (var ch = 0; ch < dtVW.Rows.Count; ch++)

                        {

                            aVWDetails = new DCPListDao();

                            if (dtVW.Rows[ch]["RowNum"] != DBNull.Value)
                            {
                                aVWDetails.SL = (dtVW.Rows[ch]["RowNum"].ToString());
                            }
                            if (dtVW.Rows[ch]["worksession"] != DBNull.Value)
                            {
                                aVWDetails.worksession = (dtVW.Rows[ch]["worksession"].ToString());
                            }

                            if (dtVW.Rows[ch]["tourType"] != DBNull.Value)
                            {
                                aVWDetails.tourType = dtVW.Rows[ch]["tourType"].ToString();
                            }


                            if (dtVW.Rows[ch]["DCPDetailId"] != DBNull.Value)
                            {
                                aVWDetails.DCPDetailId = dtVW.Rows[ch]["DCPDetailId"].ToString();
                            }



                            if (dtVW.Rows[ch]["DoctorName"] != DBNull.Value)
                            {
                                aVWDetails.DoctorName = dtVW.Rows[ch]["DoctorName"].ToString();
                            }


                            if (dtVW.Rows[ch]["DoctorId"] != DBNull.Value)
                            {
                                aVWDetails.DoctorId = dtVW.Rows[ch]["DoctorId"].ToString();
                            }




                            aVWList.Add(aVWDetails);
                        }
                        aInfo.DCPListDtl = aVWList;




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

        public DataTable GetDarDAL(string empid, string teri_id, string date)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empid", empid));
                aSqlParameterlist.Add(new SqlParameter("@teri_id", teri_id ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@date", date ?? (object)DBNull.Value ?? (object)DBNull.Value));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_Get_DARListById", aSqlParameterlist);
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

        public DataTable GetDailySalesReportDAL(string empid, string teri_id, string date)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterlist = new List<SqlParameter>();
                aSqlParameterlist.Add(new SqlParameter("@empid", empid));
                aSqlParameterlist.Add(new SqlParameter("@teri_id", teri_id ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterlist.Add(new SqlParameter("@date", date ?? (object)DBNull.Value ?? (object)DBNull.Value));
                DataTable dt = accessManager.GetDataTable("sp_Webapi_GetDailySalesReport", aSqlParameterlist);
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



        public ResultInfo SaveDailySalesReportDAL(List<DSRDAO> aInfo)
        {
            ResultInfo aInformation = new ResultInfo();
            try
            {

                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);

                DateTime entryDtae = DateTime.Now;
                if (aInfo != null)
                {
                    foreach (DSRDAO item in aInfo)
                    {
                        List<SqlParameter> gSqlParameterList = new List<SqlParameter>();
                        gSqlParameterList.Add(new SqlParameter("@empid", item.empid));
                        gSqlParameterList.Add(new SqlParameter("@teri_id", item.teri_id));
                        gSqlParameterList.Add(new SqlParameter("@date", item.date));
                        gSqlParameterList.Add(new SqlParameter("@Reason", item.Reason));
                        aInformation.isSuccess = accessManager.SaveData("sp_Webapi_Save_DailySalesReport", gSqlParameterList);

                    }


                }
                else
                {
                    aInformation.isSuccess = false;
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

    }
}