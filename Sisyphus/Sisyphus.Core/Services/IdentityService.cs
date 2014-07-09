namespace Sisyphus.Core.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class IdentityService
    {
        #region Public Methods and Operators

        public bool AddUserToRole(string userId, string roleName)
        {
            using (var sisyphusContext = new SisyphusContext(Config.GetConnectionString()))
            {
                using (var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(sisyphusContext)))
                {
                    IdentityResult idResult = um.AddToRole(userId, roleName);
                    return idResult.Succeeded;
                }
            }
        }

        public void ClearUserRoles(string userId)
        {
            using (var sisyphusContext = new SisyphusContext(Config.GetConnectionString()))
            {
                using (var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(sisyphusContext)))
                {
                    Task<IList<string>> role = um.GetRolesAsync(userId);
                    Task.WaitAll(role);

                    IList<string> roles = role.Result;

                    foreach (string r in roles)
                    {
                        um.RemoveFromRole(userId, r);
                    }
                }
            }
        }

        public bool CreateRole(string name)
        {
            using (var sisyphusContext = new SisyphusContext(Config.GetConnectionString()))
            {
                using (var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(sisyphusContext)))
                {
                    IdentityResult idResult = rm.Create(new IdentityRole(name));
                    return idResult.Succeeded;
                }
            }
        }

        public IdentityResult CreateUser(ApplicationUser user, string password)
        {
            using (var sisyphusContext = new SisyphusContext(Config.GetConnectionString()))
            {
                using (var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(sisyphusContext)))
                {
                    IdentityResult idResult = um.Create(user, password);
                    return idResult;
                }
            }
        }

        public Dictionary<string,string> GetAllRoles()
        {
            using (var sisyphusContext = new SisyphusContext(Config.GetConnectionString()))
            {
                using (var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(sisyphusContext)))
                {
                    Dictionary<string, string> roles = rm.Roles.ToDictionary(k => k.Id, v => v.Name);
                    return roles;
                }
            }
        }

        public ApplicationUser GetUser(string userName)
        {
            using (var sisyphusContext = new SisyphusContext(Config.GetConnectionString()))
            {
                using (var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(sisyphusContext)))
                {
                    ApplicationUser user = um.Users.SingleOrDefault(i => i.UserName == userName);
                    return user;
                }
            }
        }

        public Dictionary<string, List<string>> GetUserRoles(int skip, int pageSize)
        {
            using (var context = new SisyphusContext(Config.GetConnectionString()))
            {
                List<IdentityRole> allRoles;
                using (var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                {
                    allRoles = rm.Roles.ToList();
                }
                using (var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    var retval = new Dictionary<string, List<string>>();
                    var users = um.Users.Include("Roles").OrderBy(u => u.UserName).Skip(skip).Take(pageSize).ToList();
                    foreach (ApplicationUser user in users)
                    {
                        var roles =
                            allRoles.Where(r => user.Roles.Any(i => i.RoleId == r.Id)).Select(j => j.Name).ToList();
                        retval.Add(user.UserName, roles);
                    }
                    return retval;
                }
            }
        }

        public List<ApplicationUser> GetUsers()
        {
            using (var sisyphusContext = new SisyphusContext(Config.GetConnectionString()))
            {
                using (var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(sisyphusContext)))
                {
                    var users = um.Users;
                    return users.ToList();
                }
            }
        }

        public bool IsUserInRole(string userName, string role)
        {
            using (var sisyphusContext = new SisyphusContext(Config.GetConnectionString()))
            {
                string roleId;
                using (var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(sisyphusContext)))
                {
                    roleId = rm.Roles.Single(r => r.Name == role).Id;
                }

                using (var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(sisyphusContext)))
                {
                    bool retVal = um.Users.Single(u => u.UserName == userName).Roles.Any(r => r.RoleId == roleId);
                    return retVal;
                }
            }
        }

        public bool RoleExists(string name)
        {
            using (var sisyphusContext = new SisyphusContext(Config.GetConnectionString()))
            {
                using (var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(sisyphusContext)))
                {
                    return rm.RoleExists(name);
                }
            }
        }

        #endregion

        public void AddUserNameToRole(string userName, string role)
        {
            using (var sisyphusContext = new SisyphusContext(Config.GetConnectionString()))
            {
                using (var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(sisyphusContext)))
                {
                    ApplicationUser user = um.Users.Single(i => i.UserName == userName);
                    um.AddToRole(user.Id, role);
                }
            }
        }

        public void RemoveRoleFromUser(string role, string userName)
        {
            using (var sisyphusContext = new SisyphusContext(Config.GetConnectionString()))
            {
                using (var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(sisyphusContext)))
                {
                    ApplicationUser user = um.Users.Single(i => i.UserName == userName);
                    um.RemoveFromRole(user.Id, role);
                }
            }
        }
    }
}