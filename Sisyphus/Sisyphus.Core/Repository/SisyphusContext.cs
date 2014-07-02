namespace Sisyphus.Core.Repository
{
    using System.Data.Entity;

    using Sisyphus.Core.Model;

    public class SisyphusContext : DbContext
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
    }
}