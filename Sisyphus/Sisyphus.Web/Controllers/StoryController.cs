namespace Sisyphus.Web.Controllers
{
    using System.Web.Mvc;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;

    public class StoryController : Controller
    {
        [Authorize(Roles = "Writer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name, string backstory)
        {
            var userName = ContextWrapper.Instance.UserName;
            var service = new StoryService();
            service.CreateStory(name, backstory, userName);

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var userName = ContextWrapper.Instance.UserName;
            var service = new StoryService();

            var stories = service.GetStories(userName);
            return this.View(stories);
        }

        [Authorize(Roles = "Writer")]
        public ActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = "Writer")]
        public ActionResult Edit(string name)
        {
            var userName = ContextWrapper.Instance.UserName;
            var service = new StoryService();
            var story = service.GetStory(name, userName);
            return this.View(story);
        }

        [Authorize(Roles = "Writer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Story story)
        {
            var service = new StoryService();
            service.UpdateStory(story);
            return RedirectToAction("Index");
        }

        public ActionResult Details(string name)
        {
            var userName = ContextWrapper.Instance.UserName;
            var service = new StoryService();
            var story = service.GetStory(name, userName);
            return this.View(story);
        }

        //public ActionResult Delete(string name)
        //{
        //    var userName = ContextWrapper.Instance.UserName;
        //    var service = new StoryService();
        //    var story = service.GetStory(name, userName);
        //    return this.View(story);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(Story story)
        //{
        //    var service = new StoryService();
        //    service.Delete(story);
        //    return RedirectToAction("Index");
        //}
    }
}