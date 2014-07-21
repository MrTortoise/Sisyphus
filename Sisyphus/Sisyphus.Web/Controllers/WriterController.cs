using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sisyphus.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.UI;

    using Glimpse.Core.Extensions;

    using Microsoft.AspNet.Identity;

    using Sisyphus.Core.Services;
    using Sisyphus.Web.Models;

    [RequireHttps]
    public class WriterController : Controller
    {
        // GET: Writer
        public ActionResult Index()
        {
            var controller = new StoriesService();
            var stories = controller.GetStories();
            var sessionService = new SessionService();
            var session = sessionService.GetSessionForUser(ContextWrapper.Instance.UserName);
            var model = new WriterIndexViewModel()
                        {
                            Stories = stories,
                            SelectedStoryName = session.Story == null ? null : session.Story.Name,
                            BackStory = session.Story == null ? null : session.Story.BackStory
                        };

            return View(model);
        }

         [Authorize(Roles = "Writer")]
        public ActionResult PlacesEditor()
        {
            return RedirectToAction("Index", "Place");
        }

        [Authorize(Roles = "Writer")]
        public ActionResult CharacterBrowser()
        {
            return RedirectToAction("Index", "CharacterBrowser");
        }

        [Authorize(Roles = "Writer")]
        public ActionResult EventSequencer()
        {
            return RedirectToAction("Index", "EventSequencer");
        }

        public ActionResult TimeEditor()
        {
            return RedirectToAction("Index", "Time");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateStory(string name, string backstory)
        {
            var service = new StoriesService();
            service.CreateStory(name, backstory);
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SelectStory(string selectedStoryName)
        {
            var userName = ContextWrapper.Instance.UserName;
            var sessionService = new SessionService();
            sessionService.SelectStoryForSession(userName, selectedStoryName);
            return RedirectToAction("Index");
        }

        public ActionResult RaceEditor()
        {
            return RedirectToAction("Index", "Race");
        }

        public ActionResult SexEditor()
        {
            return RedirectToAction("Index", "Sex");
        }

        public ActionResult StoryEditor()
        {
            return RedirectToAction("Index", "Story");
        }
    }
}