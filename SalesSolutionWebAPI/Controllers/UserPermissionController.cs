using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SalesSolutionWebAPI.Controllers
{
    public class UserPermissionController : ApiController
    {


        private readonly iUserPermission _aRepo = new UserPermissionDAL();
        UserPermissionDAL aDal = new UserPermissionDAL();

      
        public IHttpActionResult GetMenuPermissionRolewise(string MenuId, string MenuName, string RoleTypeId)
        {
            return Json(_aRepo.GetMenuPermissionRolewiseDAL(MenuId, MenuName,RoleTypeId));
        }

    }
}
