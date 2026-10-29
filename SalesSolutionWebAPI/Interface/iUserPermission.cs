using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSolutionWebAPI.Interface
{
    interface iUserPermission
    {
        IList<MenuPermissionRolewiseDAO> GetMenuPermissionRolewiseDAL(string MenuId, string MenuName, string RoleTypeId);
    }
}
