using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Web.WebPages;

    using NUnit.Framework;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;
    using Sisyphus.Web.Controllers;

    [Binding]
    public class EventCreationSteps
    {
        [Given(@"I create the following event")]
        [When(@"I create the following event")]
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
            ScenarioContext.Current.Add("CreateEventView",result);
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
            var controller = new EventSequencerController();
            var result = controller.CreateEvent();


        }

        [Then(@"I expect event creation to have the following characters available")]
        public void ThenIExpectEventCreationToAhveTheFollowingCharactersAvailable(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I expect the following events to exist")]
        public void ThenIExpectTheFollowingEventsToExist(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I edit the Event ""(.*)""")]
        public void WhenIEditTheEvent(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I expect event event editor to have the followibng places")]
        public void ThenIExpectEventEventEditorToHaveTheFollowibngPlaces(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I expect the event editor to have the following characters")]
        public void ThenIExpectTheEventEditorToHaveTheFollowingCharacters(Table table)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
