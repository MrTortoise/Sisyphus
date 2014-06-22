using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sisyphus.Web.Controllers
{
    using System.Net;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;

    [RequireHttps]
    public class PlaceController : Controller
    {
        // GET: Place
        /// <summary>
        /// Returns the index view for places
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var service = new PlaceService();
            var items = service.Places(0, 20);
            return this.View(items);
        }

        /// <summary>
        /// Returns the Create view for places
        /// </summary>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, History")]Place place)
        {
            if (ModelState.IsValid)
            {
                var service = new PlaceService();
                service.CreatePlace(place);
                return RedirectToAction("Index");
            }
            return this.View(place);
        }

         /// <summary>
         /// Returns the list view for places
         /// </summary>
         /// <returns></returns>
         public ActionResult List(int skip, int pageSize)
         {
             var service = new PlaceService();
             var places = service.Places(skip, pageSize);
             return this.View(places);
         }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var service = new PlaceService();
            var item = service.GetPlace(id.Value);

            if (item == null)
            {
                return HttpNotFound();
            }

            return this.View(item);
        }
    }
}