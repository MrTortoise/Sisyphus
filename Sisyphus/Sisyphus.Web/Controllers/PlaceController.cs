using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sisyphus.Web.Controllers
{
    public class PlaceController : Controller
    {
        // GET: Place
        public ActionResult Index()
        {
            return this.View();
        }

        public string Welcome(string name, int id = 1)
        {
            return HttpUtility.HtmlEncode("Hi " + name + ":" + id);
        }
    }
}