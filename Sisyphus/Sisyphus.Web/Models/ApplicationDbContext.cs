namespace Sisyphus.Web.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using Sisyphus.Core;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext(Config.GetConnectionString());
        }
    }
}