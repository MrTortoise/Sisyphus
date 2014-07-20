using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.UI;

    using NUnit.Framework;

    using Sisyphus.Web.Controllers;
    using Sisyphus.Web.Models;

    [Binding]
    public class WriterIndexSteps
    {
        private const string WriterControllerName = "writerController";

        [Given(@"I use the controller WriterHome")]
        public void GivenIUseTheControllerWriterHome()
        {
            var controller = new WriterController();
            ScenarioContext.Current.Add(WriterControllerName, controller);
        }



        [Then(@"I expect the WriterHome controller to have the following stories available")]
        public void ThenIExpectTheWriterHomeControllerToHaveTheFollowingStoriesAvailable(Table table)
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var view = (ViewResult)controller.Index();
            var model = (WriterIndexViewModel)view.Model;

            foreach (var row in table.Rows)
            {
                Assert.IsTrue(model.Stories.Any(s => s.Name == row[0]));
                var story = model.Stories.Single(s => s.Name == row[0]);
                Assert.AreEqual(story.BackStory, row[1]);
            }
        }

        [Given(@"I select the story ""(.*)""")]
        [When(@"I select the story ""(.*)""")]
        public void WhenISelectTheStory(string name)
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            controller.SelectStory(name);
        }

        [Then(@"I expect the active story to be ""(.*)""")]
        public void ThenIExpectTheActiveStoryToBe(string storyName)
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var result = (ViewResult)controller.Index();
            var model = (WriterIndexViewModel)result.Model;
            Assert.AreEqual(storyName, model.SelectedStoryName);
        }



        [When(@"I click open PlacesEditor on the writer index")]
        public void WhenIClickOpenPlacesEditor()
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var result = controller.PlacesEditor();
            ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        }



        [When(@"I click open Character browser on the writer index")]
        public void WhenIClickOpenCharacterBrowserOnThePlacesEditor()
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var result = controller.CharacterBrowser();
            ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        }

        [When(@"I click open Time editor on the writer index")]
        public void WhenIClickOpenTimeEditorOnThePlacesEditor()
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var result = controller.TimeEditor();
            ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        }

        [When(@"I click open event sequencer on the writer index")]
        public void WhenIClickOpenEventSequencerOnThePlacesController()
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var result = controller.EventSequencer();
            ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        }

        [When(@"I click open race editor on the writer index")]
        public void WhenIClickOpenRaceEditorOnTheWriterIndex()
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var result = controller.RaceEditor();
            ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        }

        [When(@"I click open sex editor on the writer index")]
        public void WhenIClickOpenSexEditorOnTheWriterIndex()
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            var result = controller.SexEditor();
            ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        }


    }
}
