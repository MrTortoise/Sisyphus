namespace Sisyphus.Web.Controllers
{
    using System.Web.Mvc;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;

    public class TimeController : Controller
    {
        public void CreateTimeUnit(TimeUnit timeUnit)
        {
            var timeService = new TimeService();
            timeService.CreateTimeUnit(timeUnit);
        }
    }
}