namespace Sisyphus.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Sisyphus.Core.Services;
    using Sisyphus.Web.Models;

    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return this.List(0, 10);
        }

        [HttpGet]
        public ActionResult List(int skip, int pageSize)
        {
            var service = new IdentityService();
            Dictionary<string, List<string>> userRoles = service.GetUserRoles(skip, pageSize);
            Dictionary<string,string> allRoles = service.GetAllRoles();
            var vm = new AdminViewModel(skip, pageSize, userRoles, allRoles);
            return this.View(vm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RemoveRoleFromUser(string role, string user)
        {
            return RedirectToAction("Index");
        }

        public ActionResult AssignRoleToUser(string userId, string role)
        {
            var service = new IdentityService();
            service.AddUserToRole(userId, role);
            return this.List(0, 10);
        }
    
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddRoleToUser([Bind(Include = "UserName,AllRoles,Roles")]UserRoleViewModel roleViewModel)
        {
            var service = new IdentityService();
            service.AddUserNameToRole(roleViewModel.UserName, roleViewModel.AllRoles.Single(r => r.Selected).Text);
            return this.List(0, 10);
        }
    }
}