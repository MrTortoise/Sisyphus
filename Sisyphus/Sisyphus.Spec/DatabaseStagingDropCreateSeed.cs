using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisyphus.Spec
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Sisyphus.Core;
    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;
    using Sisyphus.Core.Services;
    using Sisyphus.Web.Models;

    public class DatabaseStagingDropCreateSeed : DropCreateDatabaseAlways<SisyphusContext>
    {
        private const string AdminRole = "Admin";

        private const string WriterRole = "Writer";

        private const string ReaderRole = "Reader";

        public DatabaseStagingDropCreateSeed()
            
        {
         
        }

        protected override void Seed(SisyphusContext context)
        {
            using (var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
            {
                using (var idManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                {
                    idManager.Create(new IdentityRole() { Name = AdminRole });
                    idManager.Create(new IdentityRole() { Name = WriterRole });
                    idManager.Create(new IdentityRole() { Name = ReaderRole });
                }

                var user = new ApplicationUser { UserName = "Admin", Email = "test@test.com" };
                Task<IdentityResult> result = manager.CreateAsync(user);
                Task.WaitAll(result);
                context.SaveChanges();

                user = context.Users.Single(u => u.UserName == "Admin");

                string pw = manager.PasswordHasher.HashPassword("test");
                user.PasswordHash = pw;
                context.SaveChanges();

                manager.AddToRole(user.Id, AdminRole);
                manager.AddToRole(user.Id, WriterRole);
                manager.AddToRole(user.Id, ReaderRole);
            }
        }
    }
}
