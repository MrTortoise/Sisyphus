namespace Sisyphus.Spec
{
    using TechTalk.SpecFlow;

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