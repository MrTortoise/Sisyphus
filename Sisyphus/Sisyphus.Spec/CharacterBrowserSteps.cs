using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.CodeDom;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.UI;

    using NUnit.Framework;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;
    using Sisyphus.Web.Controllers;
    using Sisyphus.Web.Models;

    [Binding]
    public class CharacterBrowserSteps
    {
        private const string EditViewModel = "editViewModel";

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

        [Given(@"I open the character editor with ""(.*)"" selected")]
        public void GivenIOpenTheCharacterEditorWithSelected(string name)
        {
            var controller = new CharacterBrowserController();
            var result = (ViewResult)controller.Edit(name);
            var model = (CharacterEditViewModel)result.Model;
            ScenarioContext.Current.Add(EditViewModel, model);
        }

        [Then(@"I expect the following character to be int he editor")]
        public void ThenIExpectTheFollowingCharacterToBeIntHeEditor(Table table)
        {
            var model = (CharacterEditViewModel)ScenarioContext.Current[EditViewModel];
            var name = table.Rows[0][0];
            var backstory = table.Rows[0][1];
            var race = table.Rows[0][2];
            var sex = table.Rows[0][3];

            var character = model.Character;
            Assert.AreEqual(name,character.Name);
            Assert.AreEqual(backstory, character.BackStory);
            Assert.AreEqual(race,character.Race.Name);
            Assert.AreEqual(sex, character.Sex.Name);
        }

        [Then(@"I expect the races to be the following")]
        public void ThenIExpectTheRacesToBeTheFollowing(Table table)
        {
            var model = (CharacterEditViewModel)ScenarioContext.Current[EditViewModel];
            var races = model.Races;

            foreach (var row in table.Rows)
            {
                var race = races.Single(r => r.Name == row[0]);
                Assert.AreEqual(row[1], race.BackStory);
            }
        }

        [Then(@"I expect the sexes to the be the following")]
        public void ThenIExpectTheSexesToTheBeTheFollowing(Table table)
        {
            var model = (CharacterEditViewModel)ScenarioContext.Current[EditViewModel];
            var sexes = model.Sexes;

            foreach (var row in table.Rows)
            {
                var sex = sexes.Single(r => r.Name == row[0]);
                Assert.AreEqual(row[1], sex.Description);
            }
        }

        [When(@"I save that character with info name ""(.*)"" backstory ""(.*)"" raceid ""(.*)"" and sexid ""(.*)""")]
        public void WhenISaveThatCharacterWithInfoNameBackstoryRaceidAndSexid(string name, string backStory, int raceId, int sexId)
        {
            var model = (CharacterEditViewModel)ScenarioContext.Current[EditViewModel];
            model.Character.Name = name;
            model.Character.BackStory = backStory;
            model.Character.RaceId = raceId;
            model.Character.SexId = sexId;

            var controller = new CharacterBrowserController();
            controller.Edit(model.Character);
        }

        [Then(@"I expect the following characters to exist")]
        public void ThenIExpectTheFollowingCharactersToExist(Table table)
        {
            var controller = new CharacterBrowserController();
            var result = (ViewResult)controller.Index();
            var model = (CharacterBrowserIndexViewModel)result.Model;
            foreach (var row in table.Rows)
            {
                var name = row[0];
                var backstory = row[1];
                var race = row[2];
                var sex = row[3];

                var character = model.Characters.Single(c => c.Name == name);
                Assert.AreEqual(backstory,character.BackStory);
                Assert.AreEqual(race,character.Race.Name);
                Assert.AreEqual(sex, character.Sex.Name);
            }

        }


    }
}
