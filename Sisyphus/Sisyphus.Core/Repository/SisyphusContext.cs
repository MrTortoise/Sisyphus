namespace Sisyphus.Core.Repository
{
    using System;
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;

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

        public DbSet<Character> Characters { get; set; }

        public DbSet<GameEvent> GameEvents { get; set; }

        public DbSet<Story> Stories { get; set; }

        public DbSet<Session> Sessions { get; set; }

        #endregion

        public static SisyphusContext Create()
        {
            return new SisyphusContext(Config.GetConnectionString());
        }
    }
}