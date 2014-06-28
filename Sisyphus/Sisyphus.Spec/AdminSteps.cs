using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using NUnit.Framework;

    using Sisyphus.Core;
    using Sisyphus.Core.Repository;
    using Sisyphus.Core.Services;
    using Sisyphus.Web.Controllers;
    using Sisyphus.Web.Models;

    [Binding]
    public class AdminSteps
    {
        private const string usersListName = "users";

        [Given(@"I create a user with email ""(.*)"" with password ""(.*)""")]
        [Given(@"I have created a user ""(.*)"" with password ""(.*)""")]
        public void GivenIHaveCreatedAUserWithPassword(string userName, string password)
        {

            var controller = new AccountController();
            var t =  controller.Register(new RegisterViewModel() { ConfirmPassword = password, Email = userName, Password = password });

         //   Task.WaitAll(t);

            if (controller.ModelState[""] != null)
            {
                var message = controller.ModelState[""].Errors.First().ErrorMessage;
                if (!message.EndsWith(" is already taken."))
                {
                    throw new Exception(message);
                }
            }

            

        }

        [Then(@"I expect to be able to log in with the user ""(.*)"" and password ""(.*)""")]
        public void ThenIExpectToBeAbleToLogInWithTheUserAndPassword(string userName, string password)
        {
            var controller = new AccountController();
            var result = controller.Login(new LoginViewModel() { Email = userName, Password = password }, "none");
            Assert.IsFalse(controller.ModelState.ContainsKey(""));
        }


        [When(@"I get the user list")]
        public void WhenIGetTheUserList()
        {
            var controller = new AdminController();
            var users = (ViewResult)controller.List(0, 10);
            ScenarioContext.Current.Add(usersListName,(AdminViewModel)users.Model);
        }

        [When(@"I assign the following roles to user ""(.*)""")]
        public void WhenIAssignTheFollowingRolesToUser(string userName, Table table)
        {
            var ser = new IdentityService();
            var user = ser.GetUser(userName);
            Assert.IsNotNull(user);
            var controller = new AdminController();

            foreach (var tableRow in table.Rows)
            {
                controller.AssignRoleToUser(user.Id, tableRow[0]);
            }
        }

        [Then(@"I expect the user ""(.*)"" to exist")]
        public void ThenIExpectTheUserToExist(string userName)
        {
            var ser = new IdentityService();
            var user = ser.GetUser(userName);

            Assert.IsNotNull(user);
        }

        [Then(@"I expect the followign users to be in the user list")]
        public void ThenIExpectTheFollowignUsersToBeInTheUserList(Table table)
        {
            var users = (AdminViewModel)ScenarioContext.Current[usersListName];
            foreach (var tableRow in table.Rows)
            {
                Assert.IsTrue(users.Users.Select(u => u.UserName).Contains(tableRow[0]));
            }
        }

        [Then(@"I expect the user ""(.*)"" to have the following roles")]
        public void ThenIExpectTheUserToHaveTheFollowingRoles(string userName, Table table)
        {
            var ser = new IdentityService();

            foreach (var row in table.Rows)
            {
                Assert.IsTrue(ser.IsUserInRole(userName, row[0]));
            }
        }
    }
}
