using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.Web.Mvc;

    using Sisyphus.Web.Controllers;

    [Binding]
    public class CharacterBrowserSteps
    {
        [Given(@"I create the following characters")]
        public void GivenICreateTheFollowingCharacters(Table table)
        {
            var controller = new CharacterBrowserController();
            foreach (TableRow tableRow in table.Rows)
            {
                var name = tableRow[0];
                var backStory = tableRow[1];
                var race = tableRow[2];
                var sex = tableRow[3];
                throw new NotImplementedException();
             //   controller.Create(name, backStory, race, sex);
            }
        }

        [Given(@"I open the view Character Browser")]
        public void GivenIOpenTheView(string p0)
        {
            var controller = new CharacterBrowserController();
            var result = controller.Index();
            ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        }


        [Given(@"I select the character ""(.*)"" in the character browser")]
        public void GivenISelectTheCharacterInTheCharacterBrowser(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select the character ""(.*)"" in the character browser")]
        public void WhenISelectTheCharacterInTheCharacterBrowser(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select view events in the character browser")]
        public void WhenISelectViewEventsInTheCharacterBrowser()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select the following characters to be followed")]
        public void WhenISelectTheFollowingCharactersToBeFollowed(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I expect the character browser to contain the following characters")]
        public void ThenIExpectTheCharacterBrowserToContainTheFollowingCharacters(Table table)
        {
            var view = (ViewResult)ScenarioContext.Current[ActionStepsHelpers.ReturnedResult];
            var model = view.Model;
        }

        [Then(@"I expect to get the ""(.*)"" view")]
        public void ThenIExpectToGetTheView(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I expect the chatacter ""(.*)"" to be the CharacterInformation views subject")]
        public void ThenIExpectTheChatacterToBeTheCharacterInformationViewsSubject(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I expect the events in the events browser to be")]
        public void ThenIExpectTheEventsInTheEventsBrowserToBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I expect the following characters to be followed")]
        public void ThenIExpectTheFollowingCharactersToBeFollowed(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
