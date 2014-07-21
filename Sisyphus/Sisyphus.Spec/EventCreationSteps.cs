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
    using Sisyphus.Web;
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
            ScenarioContext.Current.Add(CreateEventView, result);
        }


        //[Given(@"I add the following characters to the event ""(.*)""")]
        //public void GivenIAddTheFollowingCharactersToTheEvent(string eventName, Table table)
        //{
        //    var eventservice = new EventService();
        //    var gameEvent = eventservice.GetEvent(eventName);
        //    var cont = new EventController();
        //    foreach (var tableRow in table.Rows)
        //    {
        //        cont.AddCharacterToEvent(tableRow[0], gameEvent);
        //    }
        //}

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

        [Then(@"I expec the eventIndexViewModel to contain the following events")]
        [Then(@"I expect the following events to exist")]
        public void ThenIExpectTheFollowingEventsToExist(Table table)
        {
            var controller = new EventController();
            var result = (ViewResult)controller.Index();
            var model = (EventIndexViewModel)result.Model;

            foreach (var tableRow in table.Rows)
            {
                var name = tableRow[0];
                var description = tableRow[1];
                var outcomes = tableRow[2].Split(',').ToList();
                var places = tableRow[3].Split(',').ToList();
                var duration = tableRow[4].AsInt();
                var characters = tableRow[5].Split(',').ToList();
                var eventTypeString = tableRow[6];
                var eventType = Enum.Parse(typeof(EventType), eventTypeString);

                Assert.Contains(name, model.Events.Select(e => e.Name).ToList());
                var gameEvent = model.Events.Single(e => e.Name == name);

                Assert.IsNotNull(gameEvent);
                Assert.AreEqual(description, gameEvent.Description);
                Assert.AreEqual(duration, gameEvent.Duration);
                Assert.AreEqual(eventType, gameEvent.EventType);

                foreach (var outcome in outcomes.Where(s=>!string.IsNullOrWhiteSpace(s)))
                {
                    Assert.IsTrue(gameEvent.Outcomes.Any(o => o.Name == outcome));
                }
                foreach (var place in places.Where(s => !string.IsNullOrWhiteSpace(s)))
                {
                    Assert.IsTrue(gameEvent.Places.Any(p => p.Name == place));
                }
                foreach (var character in characters.Where(s => !string.IsNullOrWhiteSpace(s)))
                {
                    Assert.IsTrue(gameEvent.Characters.Any(c => c.Name == character));
                }

                if (tableRow.ContainsKey("Story"))
                {
                    var story = tableRow[7];
                    Assert.AreEqual(story, gameEvent.Story.Name);
                }
            }
        }

        [When(@"I edit the Event ""(.*)""")]
        public void WhenIEditTheEvent(string eventName)
        {
            var eventController = new EventController();
            var result = eventController.Edit(eventName);
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

        [When(@"I open the event controller")]
        public void WhenIOpenTheEventController()
        {
            var controller = new EventController();
            var result = (ViewResult)controller.Index();
            ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        }

        [When(@"I click view event details for event ""(.*)""")]
        public void WhenIClickViewEventDetailsForEvent(string eventName)
        {
            var controller = new EventController();
            var result = controller.Details(eventName);
            ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        }

        [Then(@"I expect to see the following event in Event Details")]
        [Then(@"I expect the delete event view to have the following event selected")]
        public void ThenIExpectToSeeTheFollowingEventInEventDetails(Table table)
        {
            var result = (ViewResult)ScenarioContext.Current[ActionStepsHelpers.ReturnedResult];
            var model = (GameEvent)result.Model;

            var name = table.Rows[0][0];
            var description = table.Rows[0][1];
            var outcomesString = table.Rows[0][2];
            var outcomes = outcomesString.Split(',');
            var placesString = table.Rows[0][3];
            var places = placesString.Split(',');
            var duration = int.Parse(table.Rows[0][4]);
            var charactersString = table.Rows[0][5];
            var characterNames = charactersString.Split(',');
            var eventType = Enum.Parse(typeof(EventType), table.Rows[0][6]);


            Assert.AreEqual(name, model.Name);
            Assert.AreEqual(description, model.Description);
            foreach (var outcome in outcomes)
            {
                Assert.IsTrue(model.Outcomes.Select(o => o.Name).Contains(outcome));
            }
            foreach (var place in places)
            {
                Assert.IsTrue(model.Places.Select(p => p.Name).Contains(place));
            }
            Assert.AreEqual(duration, model.Duration);
            foreach (var characterName in characterNames)
            {
                Assert.IsTrue(model.Characters.Select(c => c.Name).Contains(characterName));
            }
            Assert.AreEqual(eventType, model.EventType);

        }

        [When(@"I delete event ""(.*)""")]
        public void WhenIDeleteEvent(string eventName)
        {
            var controller = new EventController();
            var result = (ViewResult)controller.Delete(eventName);
            var model = (GameEvent)result.Model;
            controller.Delete(model);
        }

        [Then(@"I expect the event editor to have the following Event selected")]
        public void ThenIExpectTheEventEditorToHaveTheFollowingEventSelected(Table table)
        {
            var result = (ViewResult)ScenarioContext.Current[ActionStepsHelpers.ReturnedResult];
            var vm = (GameEventEditViewModel)result.Model;
            var model = vm.GameEvent;

            var name = table.Rows[0][0];
            var description = table.Rows[0][1];
            var outcomesString = table.Rows[0][2];
            var outcomes = outcomesString.Split(',');
            var placesString = table.Rows[0][3];
            var places = placesString.Split(',');
            var duration = int.Parse(table.Rows[0][4]);
            var charactersString = table.Rows[0][5];
            var characterNames = charactersString.Split(',');
            var eventType = Enum.Parse(typeof(EventType), table.Rows[0][6]);


            Assert.AreEqual(name, model.Name);
            Assert.AreEqual(description, model.Description);
            foreach (var outcome in outcomes)
            {
                Assert.IsTrue(model.Outcomes.Select(o => o.Name).Contains(outcome));
            }
            foreach (var place in places)
            {
                Assert.IsTrue(model.Places.Select(p => p.Name).Contains(place));
            }
            Assert.AreEqual(duration, model.Duration);
            foreach (var characterName in characterNames)
            {
                Assert.IsTrue(model.Characters.Select(c => c.Name).Contains(characterName));
            }
            Assert.AreEqual(eventType, model.EventType);
        }

        [When(@"I click delete event ""(.*)"" in Index")]
        public void WhenIClickDeleteEventInIndex(string eventName)
        {
            var controller = new EventController();
            var result = controller.Delete(eventName);
            ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        }

        [Then(@"I expect the event called ""(.*)"" to not exist")]
        public void ThenIExpectTheEventCalledToNotExist(string name)
        {
            var userName = ContextWrapper.Instance.UserName;
            var service = new EventService();
            var gameEvent = service.GetEvent(name, userName);
            Assert.IsNull(gameEvent);
        }

    }
}
