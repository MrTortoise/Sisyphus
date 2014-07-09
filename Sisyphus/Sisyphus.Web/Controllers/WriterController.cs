using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sisyphus.Web.Controllers
{
    using System.Web.UI;

    using Microsoft.AspNet.Identity;

    using Sisyphus.Core.Services;
    using Sisyphus.Web.Models;

    [RequireHttps]
    [AllowAnonymous]
    public class WriterController : Controller
    {
        // GET: Writer
        public ActionResult Index()
        {
            var controller = new StoriesService();
            var stories = controller.GetStories();
            var sessionService = new SessionService();
            var session = sessionService.GetSessionForUser(ContextWrapper.Instance.UserName);
            var model = new WriterIndexViewModel() { Stories = stories, SelectedStory = session.Story };

            return View(model);
        }

         [Authorize(Roles = "Writer")]
        public ActionResult PlacesEditor()
        {
            return RedirectToAction("Index", "PlacesEditor");
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
        public ActionResult SelectStory(string storyName)
        {
            var userName = ContextWrapper.Instance.UserName;
            var sessionService = new SessionService();

            sessionService.CreateSession(userName, storyName);
            return RedirectToAction("Index");
        }
    }
}