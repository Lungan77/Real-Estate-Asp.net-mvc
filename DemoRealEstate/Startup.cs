using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoRealEstate.Startup))]
namespace DemoRealEstate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
