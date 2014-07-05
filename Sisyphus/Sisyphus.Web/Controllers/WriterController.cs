using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sisyphus.Web.Controllers
{
    [RequireHttps]
    [AllowAnonymous]
    public class WriterController : Controller
    {
        // GET: Writer
        public ActionResult Index()
        {
            return View();
        }

         [Authorize(Roles = "Writer")]
        public ActionResult PlacesEditor()
        {
            return RedirectToAction("Index", "PlacesEditor");
        }

        [Authorize(Roles = "Writer")]
        public ActionResult CharacterBrowser()
        {
            return RedirectToAction("Index", "CharacterEditor");
        }

        [Authorize(Roles = "Writer")]
        public ActionResult EventSequencer()
        {
            return RedirectToAction("Index", "EventSequencer");
        }
    }
}