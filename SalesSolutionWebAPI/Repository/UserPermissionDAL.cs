using SalesSolutionWebAPI.DataManager;
using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Repository
{
    public class UserPermissionDAL : iUserPermission
    {


        private DataAccessManager accessManager = new DataAccessManager();

        public IList<MenuPermissionRolewiseDAO> GetMenuPermissionRolewiseDAL(string MenuId, string MenuName, string RoleTypeId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SalesDisDB);
                List<SqlParameter> aSqlParameterList = new List<SqlParameter>();
                aSqlParameterList.Add(new SqlParameter("@MenuId", MenuId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterList.Add(new SqlParameter("@MenuName", MenuName ?? (object)DBNull.Value ?? (object)DBNull.Value));
                aSqlParameterList.Add(new SqlParameter("@RoleTypeId", RoleTypeId ?? (object)DBNull.Value ?? (object)DBNull.Value));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_Webapi_Get_MenuPermissionRolewise", aSqlParameterList);
                List<MenuPermissionRolewiseDAO> aList = new List<MenuPermissionRolewiseDAO>();

                while (dr.Read())
                {
                    MenuPermissionRolewiseDAO aInfo = new MenuPermissionRolewiseDAO();

                    if (dr["RolePermissionId"] != DBNull.Value)
                    {
                        aInfo.RolePermissionId =  (dr["RolePermissionId"].ToString());
                    }
                    if (dr["MenuId"] != DBNull.Value)
                    {
                        aInfo.MenuId = dr["MenuId"].ToString();
                    }
                    if (dr["MenuName"] != DBNull.Value)
                    {
                        aInfo.MenuName = dr["MenuName"].ToString();

                    }
                    if (dr["RoleTypeId"] != DBNull.Value)
                    {
                        aInfo.RoleTypeId = dr["RoleTypeId"].ToString();
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

         
    }
}