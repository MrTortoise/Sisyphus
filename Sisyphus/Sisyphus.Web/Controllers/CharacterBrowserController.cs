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
            var viewModel = new CharacterEditViewModel() { Character = c };
            return this.View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCharacter(string name, string backStory, string race, string sex)
        {
            var service = new CharacterService();

            string userName = ContextWrapper.Instance.UserName;
            service.CreateChraracter(name, backStory, race, sex, userName);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            var viewModel = new CharacterCreateViewModel();
            viewModel.Character = new Character();
            return this.View(viewModel);
        }
    }
}