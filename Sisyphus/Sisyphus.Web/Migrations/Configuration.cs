namespace Sisyphus.Web.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Sisyphus.Core;
    using Sisyphus.Core.Repository;
    using Sisyphus.Core.Services;
    using Sisyphus.Web.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private const string AdminRole = "Admin";

        private const string WriterRole = "Writer";

        private const string ReaderRole = "Reader";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "Sisyphus.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
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

            var manager =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext(Config.GetConnectionString())));

            var idManager = new IdentityService();
            idManager.CreateRole(AdminRole);
            idManager.CreateRole(WriterRole);
            idManager.CreateRole(ReaderRole);

            var user = new ApplicationUser { UserName = "Admin", Email = "test@test.com" };
            Task<IdentityResult> result = manager.CreateAsync(user);
            Task.WaitAll(result);
            context.SaveChanges();

            user = context.Users.Single(u => u.UserName == "Admin");

            string pw = manager.PasswordHasher.HashPassword("test");
            user.PasswordHash = pw;
            context.SaveChanges();

            idManager.AddUserToRole(user.Id, AdminRole);
            idManager.AddUserToRole(user.Id, WriterRole);
            idManager.AddUserToRole(user.Id, ReaderRole);
        }
    }
}