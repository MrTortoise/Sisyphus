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

        public ActionResult Edit(GameEvent gameEvent)
        {
            var placeService = new PlaceService();
            string userName = ContextWrapper.Instance.UserName;
            var places = placeService.GetPlaces(userName);

            var characterService = new CharacterService();
            var characters = characterService.GetCharacters(userName);

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
    }
}