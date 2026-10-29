using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SalesSolutionWebAPI.Startup))]

namespace SalesSolutionWebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
