using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sisyphus.Web.Startup))]
namespace Sisyphus.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
