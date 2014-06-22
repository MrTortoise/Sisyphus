using System.Data.Entity;

using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using NUnit.Framework;

    using Sisyphus.Core;
    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;
    using Sisyphus.Web.Controllers;

    [Binding]
    public class PlacesSteps
    {
        private const string PlacesKey = "places";

        [When(@"I create a place called ""(.*)"" with history ""(.*)""")]
        public void WhenICreateAPlaceCalledWithHistory(string name, string history)
        {
            var place = new Place(name, history);
            var placeController = new PlaceController();
            placeController.Create(place);
        }

        [Then(@"I expect places to contain")]
        public void ThenIExpectPlacesToContain(Table table)
        {
            var placeService = new PlaceService();
            foreach (var row in table.Rows)
            {
                var place = new Place(row[0], row[1]);
                var item = placeService.GetPlace(place.Name);

                Assert.IsNotNull(item);
                Assert.AreEqual(place.Name,item.Name);
                Assert.AreEqual(place.History, item.History);
            }
        }

        [Given(@"I create the following places")]
        [When(@"I create the following places")]
        public void WhenICreateTheFollowingPlaces(Table table)
        {
            var cont = new PlaceController();
            foreach (var row in table.Rows)
            {
                var place = new Place(row[0], row[1]);
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
            foreach (var row in table.Rows)
            {
                var place = new Place(row[0], row[1]);
                Assert.IsTrue(places.Any(p => place.Name == p.Name && place.History == p.History));
            }
        }

    }
}


