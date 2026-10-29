using SalesSolutionWebAPI.Models;
using SalesSolutionWebAPI.Repository;
using System.Web.Http;

namespace SalesSolutionWebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        CustomerDAL _aRepo = new CustomerDAL();

        [HttpGet]
        public IHttpActionResult GetCustomerByUSerId(int empId)
        {
            return Json(_aRepo.GetCustomerByUser(empId));

        }

        [HttpPost]
        [Route("api/Customer/SaveChemistCall")]
        public IHttpActionResult SavechemistCall(ChemistCallMaster aInfo)
        {
            return Json(_aRepo.SavechemistCall(aInfo));
        }

        [HttpGet]
        [Route("api/Customer/GetCustomerList")]
        public IHttpActionResult GetCustomerList()
        {

            return Json(_aRepo.GetCustomerListDAL());
        }


        [HttpGet]
        [Route("api/Customer/GetCustomerType")]
        public IHttpActionResult GetCustomerType()
        {

            return Json(_aRepo.GetCustomerType());
        }


        [HttpGet]
        [Route("api/Customer/GetChemistCall")]
        public IHttpActionResult GetChemistCall(string empId, string frmDate, string toDate)
        {

            return Json(_aRepo.GetChemistCall(empId, frmDate ,toDate));
        }


        [HttpPost]
        [Route("api/Customer/SaveCustomer")]

        public IHttpActionResult SaveCustomer(CustomerSM aInfo)
        {
            return Json(_aRepo.SaveCustomer(aInfo));
        }


        [HttpGet]
        [Route("api/Customer/GetCustomer_Applog")]

        public IHttpActionResult GetCustomer_Applog(string pram, string Role, string AppStatus, string FromDt, string ToDt, string EmpId, string TerritoryId)
        {
            return Json(_aRepo.GetCustomer_ApplogDAL(pram, Role, AppStatus, FromDt, ToDt, EmpId, TerritoryId));
        }

        [HttpPost]
        [Route("api/Customer/SaveCustomer_Applog")]
        public IHttpActionResult SaveCustomer_Applog(CustomerSaveAppLog_DAO attendance)
        {
            return Json(_aRepo.SaveCustomer_ApplogDAL(attendance));
        }



        [HttpPost]
        [Route("api/Customer/UpdateCustomerProvider")]

        public IHttpActionResult UpdateCustomerProvider(string empId, string CustomerId, string ProviderTypeId)
        {
            return Json(_aRepo.UpdateCustomerProviderDAL(empId, CustomerId, ProviderTypeId));
        }

        [HttpPost]
        [Route("api/Customer/UpdateCustomerMarket")]

        public IHttpActionResult UpdateCustomerMarket(CustomerMArket_DAO _DAO)
        {
            return Json(_aRepo.UpdateCustomerMarketDAL(_DAO));
        }

        [HttpGet]
        [Route("api/Customer/GetCustomerDueList")]
        public IHttpActionResult GetCustomerDueList(int empId, int Month, int Year)
        {
            return Json(_aRepo.GetCustomerDueListDAL(empId, Month, Year));
        }
    }
}
