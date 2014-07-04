namespace Sisyphus.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Sisyphus.Core.Services;
    using Sisyphus.Web.Models;

    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return this.View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult List(int skip, int pageSize)
        {
            var service = new IdentityService();
            Dictionary<string, List<string>> userRoles = service.GetUserRoles(skip, pageSize);
            Dictionary<string,string> allRoles = service.GetAllRoles();
            var vm = new AdminViewModel(skip, pageSize, userRoles, allRoles);
            return this.View(vm);
        }

        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RemoveRoleFromUser(string role, string user)
        {
            var service = new IdentityService();
            service.RemoveRoleFromUser(role, user);
            return RedirectToAction("List", new { skip = 0, pageSize = 10 });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AssignRoleToUser(string userId, string role)
        {
            var service = new IdentityService();
            service.AddUserToRole(userId, role);
            return this.List(0, 10);
        }
    
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        //ublic ActionResult AddRoleToUser([Bind(Include = "UserName,AllRoles,Roles")]UserRoleViewModel roleViewModel)
        public ActionResult AddRoleToUser(string username, string roleDropDown)
        {
            var service = new IdentityService();
            //service.AddUserNameToRole(roleViewModel.UserName, roleViewModel.AllRoles.Single(r => r.Selected).Text);
            service.AddUserNameToRole(username, roleDropDown);
            return RedirectToAction("List", new { skip = 0, pageSize = 10 });
        }
    }
}