namespace Sisyphus.Core.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Sisyphus.Core.Repository;
    using Sisyphus.Web.Models;

    public class IdentityService
    {
        #region Public Methods and Operators

        public bool AddUserToRole(string userId, string roleName)
        {
            var um =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext(Config.GetConnectionString())));
            IdentityResult idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }

        public void ClearUserRoles(string userId)
        {
            var um =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext(Config.GetConnectionString())));

            Task<IList<string>> role = um.GetRolesAsync(userId);
            Task.WaitAll(role);

            IList<string> roles = role.Result;

            foreach (string r in roles)
            {
                um.RemoveFromRole(userId, r);
            }
        }

        public bool CreateRole(string name)
        {
            var rm =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new ApplicationDbContext(Config.GetConnectionString())));
            IdentityResult idResult = rm.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }

        public IdentityResult CreateUser(ApplicationUser user, string password)
        {
            var um =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext(Config.GetConnectionString())));
            IdentityResult idResult = um.Create(user, password);
            return idResult;
        }

        public Dictionary<string,string> GetAllRoles()
        {
            var rm =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new ApplicationDbContext(Config.GetConnectionString())));

            Dictionary<string, string> roles = rm.Roles.ToDictionary(k => k.Id, v => v.Name);
            return roles;
        }

        public ApplicationUser GetUser(string userName)
        {
            var um =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext(Config.GetConnectionString())));

            ApplicationUser user = um.Users.SingleOrDefault(i => i.UserName == userName);
            return user;
        }

        public Dictionary<string, List<string>> GetUserRoles(int skip, int pageSize)
        {
            var context = new ApplicationDbContext(Config.GetConnectionString());
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            List<IdentityRole> allRoles = rm.Roles.ToList();
            rm.Dispose();
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var retval = new Dictionary<string, List<string>>();
            List<ApplicationUser> users =
                um.Users.Include("Roles").OrderBy(u => u.UserName).Skip(skip).Take(pageSize).ToList();
            foreach (ApplicationUser user in users)
            {
                List<string> roles =
                    allRoles.Where(r => user.Roles.Any(i => i.RoleId == r.Id)).Select(j => j.Name).ToList();
                retval.Add(user.UserName, roles);
            }

            return retval;
        }

        public List<ApplicationUser> GetUsers()
        {
            var um =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext(Config.GetConnectionString())));

            IQueryable<ApplicationUser> users = um.Users;
            return users.ToList();
        }

        public bool IsUserInRole(string userName, string role)
        {
            var rm =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new ApplicationDbContext(Config.GetConnectionString())));

            string roleId = rm.Roles.Single(r => r.Name == role).Id;

            var um =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext(Config.GetConnectionString())));

            bool retVal = um.Users.Single(u => u.UserName == userName).Roles.Any(r => r.RoleId == roleId);
            return retVal;
        }

        public bool RoleExists(string name)
        {
            var rm =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new ApplicationDbContext(Config.GetConnectionString())));
            return rm.RoleExists(name);
        }

        #endregion

        public void AddUserNameToRole(string userName, string role)
        {
            var um =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext(Config.GetConnectionString())));

            ApplicationUser user = um.Users.Single(i => i.UserName == userName);
            um.AddToRole(user.Id, role);
        }
    }
}