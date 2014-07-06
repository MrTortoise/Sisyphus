using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sisyphus.Web.Controllers
{
    using Sisyphus.Core.Services;

    public class CharacterEditorController : Controller
    {
        // GET: Character
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCharacter(string name, string backStory, string race, string sex, string place)
        {
            var service = new CharacterService();
            service.CreateChraracter(name, backStory, race, sex, place);

            return RedirectToAction("Index");
        }
    }
}