namespace Sisyphus.Web.Controllers
{
    using System.Web.Mvc;

    public class CharacterBrowserController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}