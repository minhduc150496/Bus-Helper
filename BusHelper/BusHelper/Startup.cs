using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusHelper.Startup))]
namespace BusHelper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
