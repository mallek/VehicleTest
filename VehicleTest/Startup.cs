using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehicleTest.Startup))]
namespace VehicleTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
