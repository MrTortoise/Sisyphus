namespace Sisyphus.Core.Repository
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Sisyphus.Core.Model;

    public class SisyphusContext : DbContext
    {
        public SisyphusContext(string connectionString)
            : base(connectionString)
        { }

        public DbSet<Place> Places { get; set; }

        public DbSet<TimeUnit> TimeUnits { get; set; }
    }
}