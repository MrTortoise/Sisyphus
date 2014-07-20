using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
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
                controller.CreateStory(name, backstory);
            }
        }
    }
}
