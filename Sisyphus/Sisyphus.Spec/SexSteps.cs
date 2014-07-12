using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.Security.Cryptography;
    using System.Web.Mvc;
    using System.Web.UI;

    using NUnit.Framework;

    using Sisyphus.Core.Model;
    using Sisyphus.Web.Controllers;

    [Binding]
    public class SexSteps
    {
        [Given(@"I create the following sexes")]
        [When(@"I create the following sexes")]
        public void WhenICreateTheFollowingSexes(Table table)
        {
            var controller = new SexController();
            foreach (var row in table.Rows)
            {
                string sex = row[0];
                string descripton = row[1];
                controller.Create(sex, descripton);
            }
        }

        [Then(@"I expect the following sexes to exist")]
        public void ThenIExpectTheFollowingSexesToExist(Table table)
        {
            var controller = new SexController();
            foreach (var row in table.Rows)
            {
                var name = row[0];
                var description = row[1];
                var result = (ViewResult)controller.Edit(name);
                var model = (Sex)result.Model;
                Assert.AreEqual(description, model.Description);
            }
        }

        [When(@"I edit the sex ""(.*)"" to have name ""(.*)"" and description ""(.*)""")]
        public void WhenIEditTheSexToHaveNameAndDescription(string origionalName, string newName, string newDescription)
        {
            var controller = new SexController();
            var result = (ViewResult)controller.Edit(origionalName);
            var model = (Sex)result.Model;
            model.Name = newName;
            model.Description = newDescription;

            controller.Edit(model);
        }

    }
}
