namespace Sisyphus.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;
    using Sisyphus.Web.Models;

    public sealed class Configuration : DbMigrationsConfiguration<Sisyphus.Core.Repository.SisyphusContext>
    {

        private const string AdminRole = "Admin";

        private const string WriterRole = "Writer";

        private const string ReaderRole = "Reader";

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Sisyphus.Core.Repository.SisyphusContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            using (var roleMan = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
            {
                roleMan.Create(new IdentityRole(AdminRole));
                roleMan.Create(new IdentityRole(WriterRole));
                roleMan.Create(new IdentityRole(ReaderRole));
            }

            using (var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
            {
                var user = new ApplicationUser { UserName = "test@test.com", Email = "test@test.com" };
                Task<IdentityResult> result = manager.CreateAsync(user);
                Task.WaitAll(result);
                context.SaveChanges();

                user = context.Users.Single(u => u.UserName == "test@test.com");
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
