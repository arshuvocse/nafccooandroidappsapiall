using SalesSolutionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SalesSolutionWebAPI.Controllers
{
    public class TestController : ApiController
    {
        private const string V = "E:/ZasImage/ExpenseClaim";

        [HttpPost]
        public IHttpActionResult UplaodImage(Prescription pres)
        {
            try
            {
                //string folder = System.Web.HttpContext.Current.Server.MapPath("../../img");
                //if (!Directory.Exists(folder))
                //{
                //    Directory.CreateDirectory(folder);
                //}

                string targetPath = @"E:\imgsr";
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                string filePath = targetPath + "/" + "sdd" + "." + "jpg";
                File.WriteAllBytes(filePath, Convert.FromBase64String(pres.PresImage));
              
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok();

        }


        [HttpGet]
        public IHttpActionResult GetImage()
        {
            string fPath = "E:/ZasImage/ExpenseClaim/" + "Exp-" + 5+".jpg";
            byte[] imageArray = System.IO.File.ReadAllBytes(@fPath);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            return null;
        }
    }
}
