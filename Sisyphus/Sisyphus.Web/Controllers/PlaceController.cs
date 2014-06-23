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

        public ActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// Returns the Create view for places
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,History")]Place placeModel)
        {
            if (ModelState.IsValid)
            {
                var service = new PlaceService();
                service.CreatePlace(placeModel);
                return RedirectToAction("Index");
            }
            return this.View(placeModel);
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

        public ActionResult Edit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,History")] Place place)
        {
            if (ModelState.IsValid)
            {
                var service = new PlaceService();
                service.EditPlace(place);
                return RedirectToAction("Index");
            }
            return this.View(place);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var service = new PlaceService();
            var place = service.GetPlace(id.Value);
            if (place == null)
            {
                return HttpNotFound();
            }

            return this.View(place);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var service = new PlaceService();
            Place place = service.GetPlace(id);
            service.Delete(place);
            return RedirectToAction("Index");
        }
    }
}