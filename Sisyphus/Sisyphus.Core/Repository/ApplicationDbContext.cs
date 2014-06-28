namespace Sisyphus.Core.Repository
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using Sisyphus.Core;
    using Sisyphus.Web.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public ApplicationDbContext()
            :base(Config.GetConnectionString())
        { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext(Config.GetConnectionString());
        }
    }
}