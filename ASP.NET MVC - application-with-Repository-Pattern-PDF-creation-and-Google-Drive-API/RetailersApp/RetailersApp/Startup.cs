using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RetailersApp.Startup))]
namespace RetailersApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
