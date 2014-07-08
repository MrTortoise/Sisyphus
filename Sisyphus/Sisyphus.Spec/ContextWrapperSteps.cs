using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.Security.Cryptography.X509Certificates;

    using NUnit.Framework;

    using Sisyphus.Web;

    [Binding]
    public class ContextWrapperSteps
    {
        [Given(@"I set ContextWrapper To use TestContextWrapper")]
        public void GivenISetContextWrapperToUseTestContextWrapper()
        {
            ContextWrapper.Instance = new TestContextWrapper();
        }

        [When(@"I set the user Identity to ""(.*)""")]
        public void WhenISetTheUserIdentityTo(string userName)
        {
            var wrapper = (TestContextWrapper)ContextWrapper.Instance;
            wrapper.UserName = userName;
        }

        [Then(@"I expect the logged in user to be ""(.*)""")]
        public void ThenIExpectTheLoggedInUserToBe(string userName)
        {
            Assert.AreEqual(userName, ContextWrapper.Instance.UserName);
        }
    }
}
