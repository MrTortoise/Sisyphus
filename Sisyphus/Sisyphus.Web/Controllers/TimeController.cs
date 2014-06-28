namespace Sisyphus.Web.Controllers
{
    using System.Web.Mvc;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;

    [Authorize(Roles = "Writer")]
    public class TimeController : Controller
    {
        [Authorize(Roles = "Writer")]
        public void CreateTimeUnit(TimeUnit timeUnit)
        {
            var timeService = new TimeService();
            timeService.CreateTimeUnit(timeUnit);
        }
    }
}