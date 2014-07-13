namespace Sisyphus.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;
    using Sisyphus.Web.Models;

    public class CharacterBrowserController : Controller
    {
        public ActionResult Index()
        {
            var userName = ContextWrapper.Instance.UserName;
            var service = new CharacterService();
            var charcaters = service.GetCharacters(userName);
            var viewModel = new CharacterBrowserIndexViewModel() { Characters = charcaters };
            return this.View(viewModel);
        }

        public ActionResult Edit(string character)
        {
            var service = new CharacterService();
            var userName = ContextWrapper.Instance.UserName;
            var c = service.GetCharacter(character, userName);
            
            var sexService = new SexService();
            var sexes = sexService.GetSexes(userName);

            var raceService = new RaceService();
            var races = raceService.GetRaces(userName);

            var viewModel = new CharacterEditViewModel() { Character = c, Sexes = sexes, Races = races };
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Character character)
        {
            var service = new CharacterService();
            service.Update(character);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name, string backStory, string race, string sex)
        {
            var service = new CharacterService();

            string userName = ContextWrapper.Instance.UserName;
            service.CreateChraracter(name, backStory, race, sex, userName);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            var username = ContextWrapper.Instance.UserName;
            var sexService = new SexService();
            var sexes = sexService.GetSexes(username);

            var raceService = new RaceService();
            var races = raceService.GetRaces(username);

            var viewModel = new CharacterCreateViewModel { Character = new Character(), Races = races, Sexes = sexes };
            return this.View(viewModel);
        }

        public ActionResult Details(string name)
        {
            var service = new CharacterService();
            var userName = ContextWrapper.Instance.UserName;

            var character = service.GetCharacter(name, userName);
            return this.View(character);
        }

        public ActionResult Delete(string name)
        {
            var service = new CharacterService();
            var userName = ContextWrapper.Instance.UserName;

            var character = service.GetCharacter(name, userName);
            return this.View(character);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = new CharacterService();

            service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}