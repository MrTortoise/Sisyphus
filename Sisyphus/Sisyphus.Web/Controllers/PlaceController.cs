namespace Sisyphus.Web.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Mvc;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;

    [RequireHttps]
    public class PlaceController : Controller
    {
        // GET: Place
        /// <summary>
        ///     Returns the index view for places
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var service = new PlaceService();
            List<Place> items = service.Places(0, 20,ContextWrapper.Instance.UserName);
            return this.View(items);
        }

        [Authorize(Roles = "Writer")]
        public ActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        ///     Returns the Create view for places
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Writer")]
        public ActionResult Create([Bind(Include = "Name,History")] Place placeModel)
        {
            if (this.ModelState.IsValid)
            {
                var service = new PlaceService();
                string userName = ContextWrapper.Instance.UserName;
                service.CreatePlace(placeModel, userName);
                return this.RedirectToAction("Index");
            }
            return this.View(placeModel);
        }

        /// <summary>
        ///     Returns the list view for places
        /// </summary>
        /// <returns></returns>
        public ActionResult List(int skip, int pageSize)
        {
            var service = new PlaceService();
            List<Place> places = service.Places(skip, pageSize, ContextWrapper.Instance.UserName);
            return this.View(places);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var service = new PlaceService();
            Place item = service.GetPlace(id.Value);

            if (item == null)
            {
                return this.HttpNotFound();
            }

            return this.View(item);
        }

        [Authorize(Roles = "Writer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var service = new PlaceService();
            Place item = service.GetPlace(id.Value);

            if (item == null)
            {
                return this.HttpNotFound();
            }

            return this.View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Writer")]
        public ActionResult Edit([Bind(Include = "Id,Name,History")] Place place)
        {
            if (this.ModelState.IsValid)
            {
                var service = new PlaceService();
                service.EditPlace(place);
                return this.RedirectToAction("Index");
            }
            return this.View(place);
        }

        [Authorize(Roles = "Writer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var service = new PlaceService();
            Place place = service.GetPlace(id.Value);
            if (place == null)
            {
                return this.HttpNotFound();
            }

            return this.View(place);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Writer")]
        public ActionResult DeleteConfirmed(int id)
        {
            var service = new PlaceService();
            Place place = service.GetPlace(id);
            service.Delete(place);
            return this.RedirectToAction("Index");
        }
    }
}