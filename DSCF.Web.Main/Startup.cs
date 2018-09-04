using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DSCF.Web.Main.Startup))]
namespace DSCF.Web.Main
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
