using SalesSolutionWebAPI.Models;
using System.Collections.Generic;

namespace SalesSolutionWebAPI.Interface
{
    public interface iNotice
    {
        IList<Notice> GetNotices(int empId);

    }
}
