using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.Web.Mvc;

    using NUnit.Framework;

    using Sisyphus.Web.Controllers;

    [Binding]
    public class WriterIndexSteps
    {
        private const string WriterControllerName = "writerController";

        private const string ReturnedResult = "returned";

        [Given(@"I use the controller WriterHome")]
        public void GivenIUseTheControllerWriterHome()
        {
            var controller = new WriterController();
            ScenarioContext.Current.Add(WriterControllerName, controller);
        }


        [When(@"I click open PlacesEditor on the writer index")]
        public void WhenIClickOpenPlacesEditor()
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var result = controller.PlacesEditor();
            ScenarioContext.Current.Add(ReturnedResult, result);
        }



        [When(@"I click open Character browser on the writer index")]
        public void WhenIClickOpenCharacterBrowserOnThePlacesEditor()
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var result = controller.CharacterBrowser();
            ScenarioContext.Current.Add(ReturnedResult, result);
        }

        [When(@"I click open Time editor on the writer index")]
        public void WhenIClickOpenTimeEditorOnThePlacesEditor()
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var result = controller.TimeEditor();
            ScenarioContext.Current.Add(ReturnedResult, result);
        }

        [When(@"I click open event sequencer on the writer index")]
        public void WhenIClickOpenEventSequencerOnThePlacesController()
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var result = controller.EventSequencer();
            ScenarioContext.Current.Add(ReturnedResult, result);
        }

        [Then(@"The resulting RedirectToRouteResult should be to controller ""(.*)"" action ""(.*)""")]
        public void ThenTheResultingRedirectToRouteResultShouldBeToControllerAction(string controller, string action)
        {
            var result = ScenarioContext.Current[ReturnedResult] as RedirectToRouteResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(controller, result.RouteValues["controller"]);
            Assert.AreEqual(action, result.RouteValues["action"]);
        }

    }
}
