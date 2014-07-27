using System;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Routing;

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

            var createEventViewModel = new CreateEventViewModel()
            {
                Places = places,
                Characters = characters,
                Event = new GameEvent()
            };

            return this.View(createEventViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name, string description, int duration, EventType eventType, string outcomes)
        {
            var eventService = new EventService();

            var outcomeList = outcomes.Split(',').ToList();

            var userName = ContextWrapper.Instance.UserName;
            var ge = eventService.CreateEvent(name, description, duration, eventType, outcomeList, userName);

            return RedirectToAction("Edit", "Event", new {name = ge.Name});
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

            if (gameEvent == null)
            {
                return this.HttpNotFound();
            }

            var outcomeString = gameEvent.ConstructOutcomeString();

            var viewModel = new GameEventEditViewModel()
            {
                Places = places,
                Characters = characters,
                GameEvent = gameEvent,
                OutComes = outcomeString
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int gameEventId, string name, string description,int duration, EventType eventType, string outcomes)
        {
            var eventservice = new EventService();
            var ge = eventservice.UpdateEvent(gameEventId, name, description, duration, eventType, outcomes);
            return RedirectToAction("Details", "Event", new {name = ge.Name});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCharacterToEvent(int characterId, int eventId)
        {
            var eventService = new EventService();
            var returnedEvent = eventService.AddCharacterToEvent(characterId, eventId);

            return RedirectToAction("Edit", "Event",new {name = returnedEvent.Name});
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveCharacterFromEvent(int eventId, int characterId)
        {
            var eventService = new EventService();
            var gameEvent = eventService.RemoveCharacterFromEvent(eventId, characterId);
            return RedirectToAction("Edit", "Event",new {name = gameEvent.Name});

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPlaceToEvent(int eventId, int placeId)
        {
            var eventService = new EventService();
            var gameEvent = eventService.AddPlaceToEvent(eventId, placeId);
            return RedirectToAction("Edit", "Event", new { name = gameEvent.Name });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemovePlaceFromEvent(int eventId, int placeId)
        {
            var eventService = new EventService();
            var gameEvent = eventService.RemovePlaceFromEvent(eventId, placeId);
            return RedirectToAction("Edit", "Event", new { name = gameEvent.Name });
        }
    }
}