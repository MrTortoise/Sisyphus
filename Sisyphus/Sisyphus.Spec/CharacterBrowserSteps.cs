using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.Linq;
    using System.Web.Mvc;

    using NUnit.Framework;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;
    using Sisyphus.Web.Controllers;
    using Sisyphus.Web.Models;

    [Binding]
    public class CharacterBrowserSteps
    {
        [When(@"I create the following characters")]
        [Given(@"I create the following characters")]
        public void GivenICreateTheFollowingCharacters(Table table)
        {
            var userName = (string)ScenarioContext.Current[AdminSteps.LoggedInUser];
            var controller = new CharacterBrowserController();
            var raceService = new RaceService();
            var races = raceService.GetRaces(userName);

            var sexService = new SexService();
            var sexes = sexService.GetSexes(userName);

            var sessionService = new SessionService();
            var session = sessionService.GetSessionForUser(userName);

            Assert.IsNotNull(session.StoryId);

            foreach (TableRow tableRow in table.Rows)
            {
                var name = tableRow[0];
                var backStory = tableRow[1];
                var race = tableRow[2];
                var sex = tableRow[3];

                var raceId = races.Single(r => r.Name == race).Id;
                var sexId = sexes.Single(s => s.Name == sex).Id;

                var character = new Character()
                                {
                                    Name = name,
                                    BackStory = backStory,
                                    RaceId = raceId,
                                    SexId = sexId,
                                    StoryId = session.StoryId.Value
                                };

                controller.Create(character);
            }
        }

        [Given(@"I open the view Character Browser")]
        [When(@"I open the view Character Browser")]
        public void GivenIOpenTheView()
        {
            var controller = new CharacterBrowserController();
            var result = controller.Index();
            ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        }

        [When(@"I select the character ""(.*)"" in the character browser")]
        [Given(@"I select the character ""(.*)"" in the character browser")]
        public void GivenISelectTheCharacterInTheCharacterBrowser(string name)
        {
            var controller = new CharacterBrowserController();
            var result = (ViewResult)controller.Details(name);
            ScenarioContext.Current.Add("Details", result);
        }

        [Then(@"I expect the chatacter ""(.*)"" to be the Character Details views subject")]
        public void ThenIExpectTheChatacterToBeTheCharacterDetailsViewsSubject(string name)
        {
            var result = (ViewResult)ScenarioContext.Current["Details"];
            var character = (Character)result.Model;
            Assert.AreEqual(name, character.Name);
        }

        [Then(@"I expect the character browser to contain the following characters")]
        public void ThenIExpectTheCharacterBrowserToContainTheFollowingCharacters(Table table)
        {
            var view = (ViewResult)ScenarioContext.Current[ActionStepsHelpers.ReturnedResult];
            var model = (CharacterBrowserIndexViewModel)view.Model;
            var characters = model.Characters;
            foreach (var row in table.Rows)
            {
                var name = row[0];
                var backStory = row[1];
                var race = row[2];
                var sex = row[3];

                var c = characters.Single(i => i.Name == name);
                Assert.AreEqual(backStory,c.BackStory);
                Assert.AreEqual(race,c.Race.Name);
                Assert.AreEqual(sex, c.Sex.Name);
            }
        }
    }
}
