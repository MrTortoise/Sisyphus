namespace Sisyphus.Core.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Sisyphus.Core;
    using Sisyphus.Core.Repository;
    using Sisyphus.Web.Models;

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


        public IdentityResult CreateUser(ApplicationUser user, string password)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext(Config.GetConnectionString())));
            var idResult = um.Create(user, password);
            return idResult;
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

        public Dictionary<string, List<string>> GetUserRoles(int skip, int pageSize)
        {
            var context = new ApplicationDbContext(Config.GetConnectionString());
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var allRoles = rm.Roles.ToList();
            rm.Dispose();
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            
            var retval = new Dictionary<string, List<string>>();
            var users = um.Users.Include("Roles").OrderBy(u => u.UserName).Skip(skip).Take(pageSize).ToList();
            foreach (var user in users)
            {
                var roles = allRoles.Where(r => user.Roles.Any(i => i.RoleId == r.Id)).Select(j => j.Name).ToList();
                retval.Add(user.UserName, roles);
            }

            return retval;
        }

        public List<ApplicationUser> GetUsers()
        {
            var um = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext(Config.GetConnectionString())));

            var users = um.Users;
            return users.ToList();
        }

        public ApplicationUser GetUser(string userName)
        {
            var um = new UserManager<ApplicationUser>(
                 new UserStore<ApplicationUser>(new ApplicationDbContext(Config.GetConnectionString())));

            var user = um.Users.SingleOrDefault(i => i.UserName == userName);
            return user;
        }

        public bool IsUserInRole(string userName, string role)
        {
            var rm =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new ApplicationDbContext(Config.GetConnectionString())));

            var roleId = rm.Roles.Single(r => r.Name == role).Id;

            var um =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext(Config.GetConnectionString())));

            var retVal = um.Users.Single(u => u.UserName == userName).Roles.Any(r => r.RoleId == roleId);
            return retVal;
        }
    }
}