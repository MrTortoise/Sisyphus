using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisyphus.Spec
{
    using System.Web.Mvc;

    using NUnit.Framework;

    using TechTalk.SpecFlow;

    [Binding]
    public class ActionStepsHelpers
    {
        public const string ReturnedResult = "returned";

        [Then(@"The resulting RedirectToRouteResult should be to controller ""(.*)"" action ""(.*)""")]
        public void ThenTheResultingRedirectToRouteResultShouldBeToControllerAction(string controller, string action)
        {
            var result = ScenarioContext.Current[ReturnedResult] as RedirectToRouteResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(controller, result.RouteValues["controller"]);
            Assert.AreEqual(action, result.RouteValues["action"]);
        }
    }
}
