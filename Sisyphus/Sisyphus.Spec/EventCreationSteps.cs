using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Web.Mvc;
    using System.Web.WebPages;

    using NUnit.Framework;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;
    using Sisyphus.Web.Controllers;
    using Sisyphus.Web.Models;

    [Binding]
    public class EventCreationSteps
    {
        private const string CreateEventView = "CreateEventView";

        [Given(@"I create the following events")]
        [When(@"I create the following events")]
        public void WhenICreateTheFollowingEvent(Table table)
        {
            var controller = new EventController();
            foreach (var tableRow in table.Rows)
            {
                var name = tableRow[0];
                var description = tableRow[1];
                var outcomes = tableRow[2].Split(',').ToList();
                var places = tableRow[3].Split(',').ToList();
                var duration = tableRow[4].AsInt();
                var characters = tableRow[5].Split(',').ToList();
                var eventTypeInt = tableRow[6].AsInt();
                var eventType = (EventType)eventTypeInt;

                controller.Create(name, description, outcomes, places, duration, characters, eventType);
            }
        }

        [When(@"I click create event in the event sequencer")]
        public void WhenIClickCreateEventInTheEventSequencer()
        {
            var cont = new EventSequencerController();
            var result = cont.CreateEvent();
            ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        }

        [When(@"I call create on Event controller")]
        public void WhenICallCreateOnEventController()
        {
            var cont = new EventController();
            var result = cont.Create();
            ScenarioContext.Current.Add(CreateEventView,result);
        }


        [Given(@"I add the following characters to the event ""(.*)""")]
        public void GivenIAddTheFollowingCharactersToTheEvent(string eventName, Table table)
        {
            var eventservice = new EventService();
            var gameEvent = eventservice.GetEvent(eventName);
            var cont = new EventController();
            foreach (var tableRow in table.Rows)
            {
                cont.AddCharacterToEvent(tableRow[0], gameEvent);
            }
        }

        [Then(@"I expect event creation to have the following places")]
        public void ThenIExpectEventCreationToHaveTheFollowingPlaces(Table table)
        {
            var view = ScenarioContext.Current[CreateEventView] as ViewResult;
            Assert.IsNotNull(view);
            var viewModel = view.Model as CreateEventViewModel;
            Assert.IsNotNull(viewModel);

            foreach (var row in table.Rows)
            {
                Assert.IsTrue(viewModel.Places.Any(p => p.Name == row[0]));
            }
        }

        [Then(@"I expect event creation to have the following characters available")]
        public void ThenIExpectEventCreationToAhveTheFollowingCharactersAvailable(Table table)
        {
            var view = ScenarioContext.Current[CreateEventView] as ViewResult;
            Assert.IsNotNull(view);
            var viewModel = view.Model as CreateEventViewModel;
            Assert.IsNotNull(viewModel);

            foreach (var row in table.Rows)
            {
                Assert.IsTrue(viewModel.Characters.Any(p => p.Name == row[0]));
            }
        }

        [Then(@"I expect the following events to exist")]
        public void ThenIExpectTheFollowingEventsToExist(Table table)
        {
            var eventService = new EventService();
            foreach (var tableRow in table.Rows)
            {
                var name = tableRow[0];
                var description = tableRow[1];
                var outcomes = tableRow[2].Split(',').ToList();
                var places = tableRow[3].Split(',').ToList();
                var duration = tableRow[4].AsInt();
                var characters = tableRow[5].Split(',').ToList();
                var eventTypeInt = tableRow[6].AsInt();
                var eventType = (EventType)eventTypeInt;

                var gameEvent = eventService.GetEvent(name);

                Assert.IsNotNull(gameEvent);
                Assert.AreEqual(description, gameEvent.Description);
                Assert.AreEqual(duration, gameEvent.Duration);
                Assert.AreEqual(eventType, gameEvent.EventType);

                foreach (var outcome in outcomes)
                {
                    Assert.IsTrue(gameEvent.OutcomeEntities.Any(o => o.Name == outcome));
                }
                foreach (var place in places)
                {
                    Assert.IsTrue(gameEvent.PlaceEntities.Any(p => p.Name == place));
                }
                foreach (var character in characters)
                {
                    Assert.IsTrue(gameEvent.CharacterEntities.Any(c => c.Name == character));
                }
            }
        }

        [When(@"I edit the Event ""(.*)""")]
        public void WhenIEditTheEvent(string eventName)
        {
            var eventService = new EventService();
            var gameEvent = eventService.GetEvent(eventName);
            var eventController = new EventController();
            var result = eventController.Edit(gameEvent);
            ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        }

        [Then(@"I expect event event editor to have the following places")]
        public void ThenIExpectEventEventEditorToHaveTheFollowibngPlaces(Table table)
        {
            var view = ScenarioContext.Current[ActionStepsHelpers.ReturnedResult] as ViewResult;
            Assert.IsNotNull(view);
            var viewmodel = view.Model as GameEventEditViewModel;
            Assert.IsNotNull(viewmodel);

            foreach (var row in table.Rows)
            {
                Assert.IsTrue(viewmodel.Places.Any(p => p.Name == row[0]));
            }
        }

        [Then(@"I expect the event editor to have the following characters")]
        public void ThenIExpectTheEventEditorToHaveTheFollowingCharacters(Table table)
        {
            var view = ScenarioContext.Current[ActionStepsHelpers.ReturnedResult] as ViewResult;
            Assert.IsNotNull(view);
            var viewmodel = view.Model as GameEventEditViewModel;
            Assert.IsNotNull(viewmodel);

            foreach (var row in table.Rows)
            {
                Assert.IsTrue(viewmodel.Characters.Any(p => p.Name == row[0]));
            }
        }

    }
}
