using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CargoWebApp.Startup))]
namespace CargoWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
