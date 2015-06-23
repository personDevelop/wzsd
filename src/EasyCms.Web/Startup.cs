using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyCms.Web.Startup))]
namespace EasyCms.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
