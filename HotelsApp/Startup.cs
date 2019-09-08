using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelsApp.Startup))]
namespace HotelsApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
