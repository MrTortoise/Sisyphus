using Microsoft.Owin;

using Sisyphus.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace Sisyphus.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}