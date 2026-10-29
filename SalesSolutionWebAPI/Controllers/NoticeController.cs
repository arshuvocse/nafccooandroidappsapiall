using SalesSolutionWebAPI.Interface;
using SalesSolutionWebAPI.Repository;
using System.Web.Http;

namespace SalesSolutionWebAPI.Controllers
{
    public class NoticeController : ApiController
    {
        private readonly iNotice _aRepo = new NoticeDAL();
        NoticeDAL aDal = new NoticeDAL();

        // GET: api/Notice
        public IHttpActionResult Get(int empId)
        {
            return Json(_aRepo.GetNotices(empId));
        }



        [HttpGet]
        [Route("api/Notice/UpdateNoticeBoardReadByEmpId")]

        public IHttpActionResult UpdateNoticeBoardReadByEmpId(int id, int EmpId, string AppSeenDate)
        {
            return Json(aDal.UpdateNoticeBoardReadByEmpIdDAL(id, EmpId, AppSeenDate));
        }
        // POST: api/Notice
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Notice/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Notice/5
        public void Delete(int id)
        {
        }
    }
}
