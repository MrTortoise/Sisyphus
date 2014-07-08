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

        [Given(@"I have created the stories")]
        public void GivenIHaveCreatedTheStories(Table table)
        {
            var controller = new WriterController();
            foreach (var row in table.Rows)
            {
                var name = row[0];
                var backstory = row[1];
                controller.CreateStory(name, backstory);
            }
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

        [When(@"I select the story ""(.*)""")]
        public void WhenISelectTheStory(string name)
        {
            var controller = (WriterController)ScenarioContext.Current[WriterControllerName];
            controller.SelectStory(name);
        }

        [Then(@"I expect the active story to be ""(.*)""")]
        public void ThenIExpectTheActiveStoryToBe(string p0)
        {
            ScenarioContext.Current.Pending();
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
    }
}
