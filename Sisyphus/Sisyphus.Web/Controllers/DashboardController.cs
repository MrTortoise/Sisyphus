namespace Sisyphus.Web.Controllers
{
    using System.Web.Mvc;

    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return this.View();
        }
    }
}