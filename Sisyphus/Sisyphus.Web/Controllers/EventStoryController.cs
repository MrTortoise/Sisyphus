using System.Web.Mvc;
using System.Web.Routing;
using Sisyphus.Core.Model;
using Sisyphus.Core.Services;

namespace Sisyphus.Web.Controllers
{
    public class EventStoryController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStoryItem(string eventName, string characterName, int storyItemIndex, string dialogue, StoryItemType storyItemType)
        {
            var userName = ContextWrapper.Instance.UserName;
            var service = new StoryItemService();
            var storyItem= service.CreateStoryItem(eventName, characterName, storyItemIndex, dialogue, storyItemType, userName);
            return RedirectToAction("Details", "EventStory", new RouteValueDictionary {{"storyItem", storyItem}});

        }
    }
}