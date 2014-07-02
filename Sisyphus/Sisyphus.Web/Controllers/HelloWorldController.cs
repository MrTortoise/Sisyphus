namespace Sisyphus.Web.Controllers
{
    using System.Web.Mvc;

    [RequireHttps]
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            this.ViewBag.Message = "Hello " + name;
            this.ViewBag.NumTimes = numTimes;

            return this.View();
        }
    }
}