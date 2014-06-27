namespace Sisyphus.Core.Services
{
    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class TimeService    
    {
        public void CreateTimeUnit(TimeUnit timeUnit)
        {
            var conString = Config.GetConnectionString(Config.ConnectionString);
            var context = new SisyphusContext(conString.ConnectionString);
            using (var tran = context.Database.BeginTransaction())
            {
                context.TimeUnits.Add(timeUnit);
                context.SaveChanges();
                tran.Commit();
            }
        }
    }
}