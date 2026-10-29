using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Repository;
using System.Web.Http;

namespace SalesSolutionWebAPI.Controllers
{
    public class ProductController : ApiController
    {
        private readonly iProduct aProDAL = new ProductDAL();



        [HttpGet]
        public IHttpActionResult GetAllProdutcs(int empId)
        {
            return Json(aProDAL.GetAllProducts(empId));
        }


        [HttpGet]
        [Route("api/Product/GetSampleProducts")]
        public IHttpActionResult GetSamplePro(int empId)
        {
            return Json(aProDAL.GetSampleProduct(empId));
        }
    }
}
