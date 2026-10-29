using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Repository
{
    public class AppPrimaryDAL
    {  private DataAccessManager accessManager = new DataAccessManager();


        public AppInfo GetActiveVersion()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterList = new List<SqlParameter>();

                SqlDataReader dr = accessManager.GetSqlDataReader("sp_WebApi_GetVersion");
                AppInfo aInfo = new AppInfo();

                while (dr.Read())
                {

                    aInfo.Version = Convert.ToInt32(dr["Version"]);
                    aInfo.VersionName = dr["VersionName"].ToString();

                    // DownloadUrl / IsForceUpdate are read defensively (HasColumn check) so this
                    // keeps working even before sp_WebApi_GetVersion is migrated to return them.
                    if (HasColumn(dr, "DownloadUrl") && dr["DownloadUrl"] != DBNull.Value)
                    {
                        aInfo.DownloadUrl = dr["DownloadUrl"].ToString();
                    }
                    if (HasColumn(dr, "IsForceUpdate") && dr["IsForceUpdate"] != DBNull.Value)
                    {
                        aInfo.IsForceUpdate = Convert.ToBoolean(dr["IsForceUpdate"]);
                    }

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

        private static bool HasColumn(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (string.Equals(reader.GetName(i), columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }


        public ImagePath GetImagePath(string type)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterList = new List<SqlParameter> { 
                    new SqlParameter("@type",type)
                };

                SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_Get_ImagePath", aSqlParameterList);
                ImagePath aInfo = new ImagePath();

                while (dr.Read())
                {

                    aInfo.ImagePreName = dr["ImagePreName"].ToString();
                    aInfo.ImagePathValue = dr["ImagePath"].ToString();


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

    }
}