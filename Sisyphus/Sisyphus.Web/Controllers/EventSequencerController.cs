namespace Sisyphus.Web.Controllers
{
    using System.Web.Mvc;

    using Sisyphus.Core.Services;
    using Sisyphus.Web.Models;

    public class EventSequencerController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult CreateEvent()
        {
            return RedirectToAction("Create", "Event");
        }
    }
}