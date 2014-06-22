using System.Data.Entity;

using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.Data.Entity;

    using NUnit.Framework;

    using Sisyphus.Core;
    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;

    [Binding]
    public class PlacesSteps
    {
        [When(@"I create a place called ""(.*)"" with history ""(.*)""")]
        public void WhenICreateAPlaceCalledWithHistory(string name, string history)
        {
            var place = new Place(name, history);
            var placeService = new PlaceService();
            placeService.CreatePlace(place);

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
    }
}


