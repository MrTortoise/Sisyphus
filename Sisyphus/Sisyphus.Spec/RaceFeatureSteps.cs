using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using NUnit.Framework;

    using Sisyphus.Core.Model;
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
                controller.CreateRace(row[0],row[1]);
            }
        }

        [Then(@"I expect the following races to exist")]
        public void ThenIExpectTheFollowingRacesToExist(Table table)
        {
            var controller = new RaceController();
            var races = (ViewResult)controller.Index();
            var stories= (List<Race>)races.Model;

            foreach (var row in table.Rows)
            {
                var race = stories.Single(r => r.Name == row[0]);
                Assert.AreEqual(row[1], race.BackStory);
            }
        }
    }
}
