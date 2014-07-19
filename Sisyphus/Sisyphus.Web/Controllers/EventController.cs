namespace Sisyphus.Web.Controllers
{
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Web.Mvc;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;
    using Sisyphus.Web.Models;

    public class EventController : Controller
    {
        public ActionResult Create()
        {
            var userName = ContextWrapper.Instance.UserName;
            var placesService = new PlaceService();
            var places = placesService.GetPlaces(userName);

            var characterService = new CharacterService();
            var characters = characterService.GetCharacters(userName);

            var createEventViewModel = new CreateEventViewModel() { Places = places, Characters = characters };

            return this.View(createEventViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name, string description, List<string> outcomes, List<string> places, int duration, List<string> characters, EventType eventType)
        {
            var eventService = new EventService();
            var userName = ContextWrapper.Instance.UserName;
            var gameEvent = eventService.CreateEvent(
                name,
                description,
                outcomes,
                places,
                duration,
                characters,
                eventType,
                userName);

            return RedirectToAction("Edit", gameEvent);

        }

        public ActionResult Edit(string name)
        {
            var placeService = new PlaceService();
            string userName = ContextWrapper.Instance.UserName;
            var places = placeService.GetPlaces(userName);

            var characterService = new CharacterService();
            var characters = characterService.GetCharacters(userName);

            var eventService = new EventService();
            var gameEvent = eventService.GetEvent(name, userName);

            var viewModel = new GameEventEditViewModel()
                            {
                                Places = places,
                                Characters = characters,
                                GameEvent = gameEvent
                            };

            return this.View(viewModel);
        }

        public ActionResult AddCharacterToEvent(string characterName, GameEvent gameEvent)
        {
            var eventService = new EventService();
            var returnedEvent = eventService.AddCharacterToEvent(characterName, gameEvent);

            return RedirectToAction("Edit", returnedEvent);
        }

        public ActionResult Index()
        {
            var service = new EventService();
            var userName = ContextWrapper.Instance.UserName;
            var events = service.GetEvents(userName);
            var eventIndexViewModel = new EventIndexViewModel() { Events = events };
            return this.View(eventIndexViewModel);
        }

        public ActionResult Details(string name)
        {
            var service = new EventService();
            var userName = ContextWrapper.Instance.UserName;
            var gameEvent = service.GetEvent(name, userName);
            return this.View(gameEvent);
        }

        public ActionResult Delete(string name)
        {
            var service = new EventService();
            var userName = ContextWrapper.Instance.UserName;
            var gameEvent = service.GetEvent(name, userName);
            return this.View(gameEvent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(GameEvent model)
        {
            var service = new EventService();
            service.Delete(model);
            return RedirectToAction("Index");
        }
    }
}