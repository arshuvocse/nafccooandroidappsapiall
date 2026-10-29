using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Repository;
using System.Web.Http;

namespace SalesSolutionWebAPI.Controllers
{
    public class TrainingController : ApiController
    {
        private readonly iTraining _aRepo = new TrainingDAL();
        TrainingDAL aDal = new TrainingDAL();

        // GET: api/Notice
        public IHttpActionResult GetTrainingList(int empId)
        {
            return Json(_aRepo.GetTraining(empId));
        }



        [HttpGet]
        [Route("api/Training/UpdateTrainingReadByEmpId")]

        public IHttpActionResult UpdateTrainingReadByEmpId(int id, int EmpId)
        {
            return Json(aDal.UpdateTrainingReadByEmpIdDAL(id, EmpId));
        }
       
    }
}
