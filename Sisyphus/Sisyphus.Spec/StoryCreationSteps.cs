using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Web.Mvc;

    using NUnit.Framework;
    using NUnit.Framework.Constraints;

    using Sisyphus.Core.Model;
    using Sisyphus.Web.Controllers;

    [Binding]
    public class StoryCreationSteps 
    {
        [When(@"I have created the stories")]
        [Given(@"I have created the stories")]
        public void GivenIHaveCreatedTheStories(Table table)
        {
            var controller = new StoryController();
            foreach (var row in table.Rows)
            {
                var name = row[0];
                var backstory = row[1];
                controller.Create(name, backstory);
            }
        }

        [When(@"I open the story controller index")]
        public void WhenIOpenTheStoryControllerIndex()
        {
            var controller = new StoryController();
            var result = (ViewResult)controller.Index();
            if (ScenarioContext.Current.ContainsKey(ActionStepsHelpers.ReturnedResult))
            {
                ScenarioContext.Current[ActionStepsHelpers.ReturnedResult] = result;
            }
            else
            {
                ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);    
            }
        }

        [Then(@"I expect the following stories to exist")]
        public void ThenIExpectTheFollowingStoriesToExist(Table table)
        {
            var result = (ViewResult)ScenarioContext.Current[ActionStepsHelpers.ReturnedResult];
            var model = ((IEnumerable<Story>)result.Model).ToList();
            Assert.IsNotNull(model);
            foreach (var row in table.Rows)
            {
                var name = row[0];
                var backStory= row[1];
                Assert.IsTrue(model.Any(m => m.Name == name));
                var story = model.Single(m => m.Name == name);
                Assert.AreEqual(backStory, story.BackStory);
            }
        }

        [When(@"I view details of the story ""(.*)""")]
        public void WhenIViewDetailsOfTheStory(string name)
        {
            var controller = new StoryController();
            var result = (ViewResult)controller.Details(name);
            ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        }

        [Then(@"I expect the story in details to be called ""(.*)"" and its backstory to be ""(.*)""")]
        public void ThenIExpectTheStoryInDetailsToBeCalledAndItsBackstoryToBe(string name, string backstory)
        {
            var result = (ViewResult)ScenarioContext.Current[ActionStepsHelpers.ReturnedResult];
            var model = (Story)result.Model;

            Assert.AreEqual(name, model.Name);
            Assert.AreEqual(backstory, model.BackStory);
        }

         [Given(@"I click edit story ""(.*)""")]
        [When(@"I click edit story ""(.*)""")]
        public void WhenIClickEditStory(string name)
        {
            var controller = new StoryController();
            var result = (ViewResult)controller.Edit(name);
            ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        }

        [Then(@"I expect the story editor to have story ""(.*)"" with backstory ""(.*)"" to be selected")]
        public void ThenIExpectTheStoryEditorToHaveStoryWithBackstoryToBeSelected(string name, string backstory)
        {
            var result = (ViewResult)ScenarioContext.Current[ActionStepsHelpers.ReturnedResult];
            var model = (Story)result.Model;

            Assert.AreEqual(name, model.Name);
            Assert.AreEqual(backstory, model.BackStory);
        }

        [When(@"I set the story name to ""(.*)"" and the backstory to ""(.*)"" and save the edit")]
        public void WhenISetTheStoryNameToAndTheBackstoryToAndSaveTheEdit(string name, string backstory)
        {
            var result = (ViewResult)ScenarioContext.Current[ActionStepsHelpers.ReturnedResult];
            var model = (Story)result.Model;

            model.Name = name;
            model.BackStory = backstory;

            var controller = new StoryController();
            controller.Edit(model);
        }

        //[When(@"I click delete story ""(.*)""")]
        //[Given(@"I click delete story ""(.*)""")]
        //public void WhenIClickDeleteStory(string name)
        //{
        //    var controller = new StoryController();
        //    var result = (ViewResult)controller.Delete(name);
        //    ScenarioContext.Current.Add(ActionStepsHelpers.ReturnedResult, result);
        //}

        [Then(@"I expect the story deleter to have story ""(.*)"" with backstory ""(.*)"" to be selected")]
        public void ThenIExpectTheStoryDeleterToHaveStoryWithBackstoryToBeSelected(string name, string backstory)
        {
            var result = (ViewResult)ScenarioContext.Current[ActionStepsHelpers.ReturnedResult];
            var model = (Story)result.Model;

            Assert.AreEqual(name, model.Name);
            Assert.AreEqual(backstory, model.BackStory);
        }

        //[When(@"I delete the selected story")]
        //public void WhenIDeleteTheSelectedStory()
        //{
        //    var result = (ViewResult)ScenarioContext.Current[ActionStepsHelpers.ReturnedResult];
        //    var model = (Story)result.Model;

        //    var controller = new StoryController();
        //    controller.Delete(model);
        //}

        [Then(@"I expect the followign stories to not exist")]
        public void ThenIExpectTheFollowignStoriesToNotExist(Table table)
        {
            var controller = new StoryController();
            var result = (ViewResult)controller.Index();
            var model = ((IEnumerable<Story>)result.Model).ToList();

            foreach (var row in table.Rows)
            {
                var name = row[0];
                Assert.IsFalse(model.Any(m => m.Name == name));
            }
        }


    }
}
