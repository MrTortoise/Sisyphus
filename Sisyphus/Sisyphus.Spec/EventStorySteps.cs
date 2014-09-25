using System;
using Sisyphus.Core.Model;
using Sisyphus.Web.Controllers;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    [Binding]
    public class EventStorySteps
    {
        [When(@"I add to the event ""(.*)"" from perspective of ""(.*)"" the following lines of dialogue")]
        public void WhenIAddToTheEventFromPerspectiveOfTheFollowingLinesOfDialogue(string eventName, string characterName, Table table)
        {
            var controller = new EventStoryController();
            int storyItemIndex = int.Parse(table.Rows[0][0]);
            var dialogue = table.Rows[0][1];

            controller.CreateStoryItem(eventName, characterName, storyItemIndex, dialogue, StoryItemType.Dialogue);
        }

        [When(@"I add to the event ""(.*)"" from perspective of ""(.*)"" the following Narrative")]
        public void WhenIAddToTheEventFromPerspectiveOfTheFollowingNarrative(string eventName, string characterName, Table table)
        {
            var controller = new EventStoryController();
            int storyItemIndex = int.Parse(table.Rows[0][0]);
            var dialogue = table.Rows[0][1];

            controller.CreateStoryItem(eventName, characterName, storyItemIndex, dialogue, StoryItemType.Narrative);
        }

        [Then(@"I expect ""(.*)"" to have the following story for the event ""(.*)""")]
        public void ThenIExpectToHaveTheFollowingStoryForTheEvent(string characterName, string eventName, Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I expect ""(.*)"" to have the following story for event ""(.*)""")]
        public void ThenIExpectToHaveTheFollowingStoryForEvent(string characterName, string eventName, Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
