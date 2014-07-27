using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sisyphus.Web.Controllers
{
    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;

    public class SexController : Controller
    {
        // GET: Sex
        public ActionResult Index()
        {
            var userName = ContextWrapper.Instance.UserName;
            var service = new SexService();
            var sexes = service.GetSexes(userName);
            return View(sexes);
        }

        // GET: Sex/Details/5
        public ActionResult Details(string name)
        {
            var userName = ContextWrapper.Instance.UserName;
            var service = new SexService();
            var sex = service.GetSex(name, userName);
            return View(sex);
        }

        [Authorize(Roles = "Writer")]
        // GET: Sex/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sex/Create
        [Authorize(Roles = "Writer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name, string description)
        {
            try
            {
                var userName = ContextWrapper.Instance.UserName;
                var service = new SexService();
                service.Create(name, description, userName);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sex/Edit/5
        [Authorize(Roles = "Writer")]
        public ActionResult Edit(string name)
        {
            var userName = ContextWrapper.Instance.UserName;
            var service = new SexService();
            var sex = service.GetSex(name, userName);
            return View(sex);
        }

        // POST: Sex/Edit/5
        [HttpPost]
        [Authorize(Roles = "Writer")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sex sex)
        {
            var service = new SexService();
            service.Update(sex);

            return RedirectToAction("Index");
        }

        // GET: Sex/Delete/5
        [Authorize(Roles = "Writer")]
        public ActionResult Delete(string name)
        {
            return View();
        }

        // POST: Sex/Delete/5
        [HttpPost]
        [Authorize(Roles = "Writer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSex(string name)
        {
            try
            {
                var userName = ContextWrapper.Instance.UserName;
                var service = new SexService();
                service.Delete(name, userName);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(name);
            }
        }
    }
}
