using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using Sisyphus.Web.Controllers;

    [Binding]
    public class RaceFeatureSteps
    {
        [When(@"I create the following races")]
        public void WhenICreateTheFollowingRaces(Table table)
        {
            var controller = new RaceController();
            foreach (var row in table.Rows)
            {
                var race = new Race { Name = row[0], BackStory = row[1] };
                controller.CreateRace(race);
            }
        }

        [Then(@"I expect the following races to exist")]
        public void ThenIExpectTheFollowingRacesToExist(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
