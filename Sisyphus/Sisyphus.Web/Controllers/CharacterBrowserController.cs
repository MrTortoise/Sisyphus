namespace Sisyphus.Web.Controllers
{
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
            var viewModel = new CharacterBrowserIndexViewModel { Characters = charcaters };
            return this.View(viewModel);
        }

        [Authorize(Roles = "Writer")]
        public ActionResult Edit(string name)
        {
            var service = new CharacterService();
            var userName = ContextWrapper.Instance.UserName;
            var c = service.GetCharacter(name, userName);
            
            var sexService = new SexService();
            var sexes = sexService.GetSexes(userName);

            var raceService = new RaceService();
            var races = raceService.GetRaces(userName);

            var viewModel = new CharacterEditViewModel { Character = c, Sexes = sexes, Races = races };
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Writer")]
        public ActionResult Edit(Character character)
        {
            var service = new CharacterService();
            service.Update(character);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Writer")]
        public ActionResult Create(Character character)
        {
            var service = new CharacterService();

            string userName = ContextWrapper.Instance.UserName;
            service.CreateChraracter(
                character.Name,
                character.BackStory,
                character.RaceId,
                character.SexId,
                userName);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Writer")]
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

        [Authorize(Roles = "Writer")]
        public ActionResult Delete(string name)
        {
            var service = new CharacterService();
            var userName = ContextWrapper.Instance.UserName;

            var character = service.GetCharacter(name, userName);
            return this.View(character);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Writer")]
        public ActionResult Delete(int id)
        {
            var service = new CharacterService();

            service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}