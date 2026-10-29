using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace SalesSolutionWebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            //container.RegisterType<iProduct, ProductDAL>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}