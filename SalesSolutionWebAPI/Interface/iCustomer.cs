using SalesSolutionWebAPI.Models;
using System.Collections.Generic;

namespace SalesSolutionWebAPI.Interface
{
    interface iCustomer
    {
        void AddCustomer(mCustomer aCustomer);
        IList<mCustomer> GetALLCustomer();
        IList<mCustomer> GetCustomerByUser(int userID);
        void RemoveCustomer(int customerID);
    }
}
