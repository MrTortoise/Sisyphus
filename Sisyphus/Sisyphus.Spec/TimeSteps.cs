using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.Collections.Generic;
    using System.Web.WebPages;

    using Sisyphus.Core.Model;
    using Sisyphus.Web.Controllers;

    [Binding]
    public class TimeSteps
    {
        [Given(@"I create a time system with the following members")]
        public void GivenICreateATimeSystemWithTheFollowingMembers(Table table)
        {
            var timeController = new TimeController();
            foreach (var row in table.Rows)
            {
                int bit = row[0].AsInt();
                int value = row[1].AsInt();
                string text = row[2];
                var timeUnit = new TimeUnit(bit, value, text);
                timeController.CreateTimeUnit(timeUnit);
            }
        }

        [When(@"I set the time to")]
        [Given(@"I set the time to")]
        public void GivenISetTheTimeTo(Table table)
        {
            var timeController = new TimeController();
            var timeUnits = new Dictionary<int, int>();
            foreach (var row in table.Rows)
            {
                var bit = row[0].AsInt();
                var value = row[1].AsInt();
                timeUnits.Add(bit, value);
            }

            
        }
        
        [When(@"I wait for a time period")]
        public void WhenIWaitForATimePeriod(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I expect the current time value to be")]
        public void ThenIExpectTheCurrentTimeValueToBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The current time should be ""(.*)""")]
        public void ThenTheCurrentTimeShouldBe(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
