using SalesSolutionWebAPI.Models;
using System.Collections.Generic;
namespace SalesSolutionWebAPI.Interface
{
    public interface iProduct
    {
        void AddProduct(mProduct aProduct);
        IList<mProduct> GetAllProducts(int empId);
        IList<mProduct> GetSampleProduct(int empId);
    }
}
