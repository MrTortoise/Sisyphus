namespace Sisyphus.Core.Repository
{
    using System;
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Sisyphus.Core.Model;
    using Sisyphus.Web.Models;

    public class SisyphusContext : IdentityDbContext<ApplicationUser>
    {
        #region Constructors and Destructors

        public SisyphusContext(string connectionString)
            : base(connectionString)
        {
        }

        #endregion

        #region Public Properties

        public DbSet<Place> Places { get; set; }

        public DbSet<TimeUnit> TimeUnits { get; set; }

        #endregion

        public static SisyphusContext Create()
        {
            return new SisyphusContext(Config.GetConnectionString());
        }
    }
}