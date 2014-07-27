using Sisyphus.Web;

namespace Sisyphus.Spec
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using NUnit.Framework;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;
    using Sisyphus.Web.Controllers;

    using TechTalk.SpecFlow;

    [Binding]
    public class PlacesSteps
    {
        private const string PlacesKey = "places";

        [When(@"I create a place called ""(.*)"" with history ""(.*)""")]
        public void WhenICreateAPlaceCalledWithHistory(string name, string history)
        {
            var place = new Place() { Name = name, History = history };
            var placeController = new PlaceController();
            placeController.Create(place);
        }

        [Then(@"I expect places to contain")]
        public void ThenIExpectPlacesToContain(Table table)
        {
            var placeService = new PlaceService();
            foreach (TableRow row in table.Rows)
            {
                var place = new Place(){Name = row[0],History = row[1]};
                string userName = ContextWrapper.Instance.UserName;
                Place item = placeService.GetPlace(place.Name, userName);

                Assert.IsNotNull(item);
                Assert.AreEqual(place.Name, item.Name);
                Assert.AreEqual(place.History, item.History);
            }
        }

        [Given(@"I create the following places")]
        [When(@"I create the following places")]
        public void WhenICreateTheFollowingPlaces(Table table)
        {
            var cont = new PlaceController();
            foreach (TableRow row in table.Rows)
            {
                var place = new Place() { Name = row[0], History = row[1] };
                cont.Create(place);
                Assert.IsTrue(place.Id != 0);
            }
        }

        [When(@"I get (.*) places skipping (.*) and store them")]
        public void WhenIGetPlacesSkippingAndStoreThem(int skip, int take)
        {
            var cont = new PlaceController();
            var result = cont.List(skip, take) as ViewResult;
            var items = (List<Place>)result.Model;
            ScenarioContext.Current.Add(PlacesKey, items);
        }

        [Then(@"I expect the stored places to contain the following")]
        public void ThenIExpectTheStoredPlacesToContainTheFollowing(Table table)
        {
            var places = (List<Place>)ScenarioContext.Current[PlacesKey];
            foreach (TableRow row in table.Rows)
            {
                var place = new Place() { Name = row[0], History = row[1] };
                Assert.IsTrue(places.Any(p => place.Name == p.Name && place.History == p.History));
            }
        }
    }
}