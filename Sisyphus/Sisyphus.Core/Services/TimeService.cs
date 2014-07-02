namespace Sisyphus.Core.Services
{
    using System.Data.Entity;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class TimeService
    {
        #region Public Methods and Operators

        public void CreateTimeUnit(TimeUnit timeUnit)
        {
            string conString = Config.GetConnectionString();
            var context = new SisyphusContext(conString);
            using (DbContextTransaction tran = context.Database.BeginTransaction())
            {
                context.TimeUnits.Add(timeUnit);
                context.SaveChanges();
                tran.Commit();
            }
        }

        #endregion
    }
}