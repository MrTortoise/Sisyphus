namespace Sisyphus.Core.Repository
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using Sisyphus.Web.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Constructors and Destructors

        public ApplicationDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public ApplicationDbContext()
            : base(Config.GetConnectionString())
        {
        }

        #endregion

        #region Public Methods and Operators

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext(Config.GetConnectionString());
        }

        #endregion
    }
}