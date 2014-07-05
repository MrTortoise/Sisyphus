using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
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


        [When(@"I click open PlacesEditor")]
        public void WhenIClickOpenPlacesEditor()
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var result = controller.PlacesEditor();
            ScenarioContext.Current.Add(ReturnedResult, result);
        }



        [When(@"I click open Character browser on the Places Editor")]
        public void WhenIClickOpenCharacterBrowserOnThePlacesEditor()
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var result = controller.CharacterBrowser();
            ScenarioContext.Current.Add(ReturnedResult, result);
        }

        [When(@"I click open Time editor on the places editor")]
        public void WhenIClickOpenTimeEditorOnThePlacesEditor()
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var result = controller.PlacesEditor();
            ScenarioContext.Current.Add(ReturnedResult, result);
        }

        [When(@"I click open event sequencer on the places controller")]
        public void WhenIClickOpenEventSequencerOnThePlacesController()
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var result = controller.EventSequencer();
            ScenarioContext.Current.Add(ReturnedResult, result);
        }

        [Then(@"The resulting Action result should be PlacesEditorIndex")]
        public void ThenTheResultingActionResultShouldBePlacesIndex()
        {
            var result = ScenarioContext.Current[ReturnedResult];
        }

        [Then(@"The resulting Action result should be CharacterBrowserIndex")]
        public void ThenTheResultingActionResultShouldBeCharacterBrowserIndex()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The resulting Action result should be TimeEditor")]
        public void ThenTheResultingActionResultShouldBeTimeEditor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The resulting Action result shuold be TimeEditor")]
        public void ThenTheResultingActionResultShuoldBeTimeEditor()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
