namespace Sisyphus.Web
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Sisyphus.Core;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Config.Source = new AppConfigSource();
            ContextWrapper.Instance = new ContextWrapper();
            SisyphusDateTime.DateTimeAdapter = new DateTimeAdapter();
            MigrationConfig.ConfigureMigration();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}