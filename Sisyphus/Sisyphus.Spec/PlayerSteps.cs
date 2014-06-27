using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    [Binding]
    public class PlayerSteps
    {
        [Given(@"I have created player instance")]
        public void GivenIHaveCreatedPlayerInstance()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
