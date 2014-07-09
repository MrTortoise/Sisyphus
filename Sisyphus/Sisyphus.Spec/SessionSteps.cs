using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using NUnit.Framework;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;
    using Sisyphus.Web;

    [Binding]
    public class SessionSteps
    {
        [When(@"I create a session for user ""(.*)"" on story ""(.*)""")]
        [Given(@"I create a session for user ""(.*)"" on story ""(.*)""")]
        public void GivenICreateASessionForUserOnStory(string userName, string storyName)
        {
            var cont = new SessionService();
            var session = cont.CreateSession(userName, storyName);
            ScenarioContext.Current.Add("createdSession", session);
        }

        [When(@"I get the current session for user ""(.*)""")]
        public void WhenIGetTheCurrentSessionForUser(string userName)
        {
            var cont = new SessionService();
            var session = cont.GetSessionForUser(userName);
            ScenarioContext.Current.Add("currentSession", session);
        }

        [Then(@"I expect the current session for user ""(.*)"" to be for story ""(.*)""")]
        public void ThenIExpectTheCurrentSessionForUserToBeForStory(string userName, string storyName)
        {
            var cont = new SessionService();
            var session = cont.GetSessionForUser(userName);
            Assert.AreEqual(storyName, session.Story.Name);
        }

        [Then(@"i expect the second session to be diferent from the first.")]
        public void ThenIExpectTheSecondSessionToBeDiferentFromTheFirst()
        {
            var first = (Session)ScenarioContext.Current["createdSession"];
            var second = (Session)ScenarioContext.Current["currentSession"];
            Assert.AreNotEqual(first.Id, second.Id);
        }
    }
}
