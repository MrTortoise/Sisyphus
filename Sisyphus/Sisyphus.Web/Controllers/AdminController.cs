using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sisyphus.Web.Controllers
{
    using Sisyphus.Core.Services;
    using Sisyphus.Web.Models;

    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return List(0, 10);
        }

        public ActionResult List(int skip, int pageSize)
        {
            var service = new IdentityService();
            var userRoles = service.GetUserRoles(skip, pageSize);
            var vm = new AdminViewModel(skip, pageSize, userRoles);
            return this.View(vm);
        }

        public ActionResult RemoveRoleFromUser(UserModel model)
        {
            return this.Index();
        }

        public ActionResult AssignRoleToUser(string userId, string role)
        {
            var service = new IdentityService();
            service.AddUserToRole(userId, role);
            return this.List(0, 10);
        }
    }
}