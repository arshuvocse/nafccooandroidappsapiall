using SalesSolutionWebAPI.Models;
using System.Collections.Generic;

namespace SalesSolutionWebAPI.Interface
{
    interface iOrderManagement
    {
        ResultInfo MakeOrder(OrderMaster aOrder);
        IList<OrderMaster> GetOrderList(string userid);
        void DeleteOrder(int orderId);

        IList<CompanyUnit> GetCompanyUnitListByEmpId(int empId);
    }
}
