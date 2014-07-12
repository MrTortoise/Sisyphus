namespace Sisyphus.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;
    using Sisyphus.Web.Models;

    public class RaceController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRace(string name, string backStory)
        {
            var userName = ContextWrapper.Instance.UserName;
            var service = new RaceService();
            service.CreateRace(name, backStory, userName);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var userName = ContextWrapper.Instance.UserName;
            var service = new RaceService();
            var races = service.GetRaces(userName);
            return this.View(races);
        }

        public ActionResult EditRace(string name)
        {
            var userName = ContextWrapper.Instance.UserName;
            var service = new RaceService();
            var race = service.GetRace(userName);
            return this.View(race);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Race race)
        {
            var userName = ContextWrapper.Instance.UserName;
            var service = new RaceService();
            service.EditRace(race, userName);
            return RedirectToAction("Index");
        }
    }
}