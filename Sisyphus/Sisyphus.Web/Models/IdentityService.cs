namespace Sisyphus.Web.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Sisyphus.Core;
    using Sisyphus.Core.Repository;

    public class IdentityService
    {
        public bool RoleExists(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext(Config.GetConnectionString())));
            return rm.RoleExists(name);
        }

        public bool CreateRole(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext(Config.GetConnectionString())));
            var idResult =  rm.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }


        public bool CreateUser(ApplicationUser user, string password)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext(Config.GetConnectionString())));
            var idResult = um.Create(user, password);
            return idResult.Succeeded;
        }


        public bool AddUserToRole(string userId, string roleName)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext(Config.GetConnectionString())));
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }


        public void ClearUserRoles(string userId)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext(Config.GetConnectionString())));

            var role = um.GetRolesAsync(userId);
            Task.WaitAll(role);

            var roles = role.Result;

            foreach (var r in roles)
            {
                um.RemoveFromRole(userId, r);
            }
        }
    }
}