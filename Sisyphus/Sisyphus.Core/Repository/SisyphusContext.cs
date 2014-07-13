namespace Sisyphus.Core.Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

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

        public DbSet<Race> Races { get; set; }

        public DbSet<Sex> Sexes { get; set; }

        #endregion

        public static SisyphusContext Create()
        {
            return new SisyphusContext(Config.GetConnectionString());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}