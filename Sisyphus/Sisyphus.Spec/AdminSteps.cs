namespace Sisyphus.Spec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;

    using Moq;

    using NUnit.Framework;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Services;
    using Sisyphus.Web;
    using Sisyphus.Web.Controllers;
    using Sisyphus.Web.Models;

    using TechTalk.SpecFlow;

    [Binding]
    public class AdminSteps
    {
        private const string usersListName = "users";

        private const string AllRoles = "allRoles";

        public const string LoggedInUser = "userName";

        [When(@"I create a user with email ""(.*)"" with password ""(.*)""")]
        [When(@"I have created a user ""(.*)"" with password ""(.*)""")]
        [Given(@"I create a user with email ""(.*)"" with password ""(.*)""")]
        [Given(@"I have created a user ""(.*)"" with password ""(.*)""")]
        public void GivenIHaveCreatedAUserWithPassword(string userName, string password)
        {
            var controller = new AccountController();
            Task<ActionResult> t =
                controller.Register(
                    new RegisterViewModel { ConfirmPassword = password, Email = userName, Password = password });

            //   Task.WaitAll(t);

            if (controller.ModelState[""] != null)
            {
                string message = controller.ModelState[""].Errors.First().ErrorMessage;
                if (!message.EndsWith(" is already taken."))
                {
                    throw new Exception(message);
                }
            }
        }

        [Given(@"I log in with the user ""(.*)"" and password ""(.*)""")]
        [Then(@"I log in with the user ""(.*)"" and password ""(.*)""")]
        [When(@"I log in with the user ""(.*)"" and password ""(.*)""")]
        public void ThenIExpectToBeAbleToLogInWithTheUserAndPassword(string userName, string password)
        {
            var controller = new AccountController();

            var am = new Mock<IAuthenticationManager>();
            am.Setup(m => m.SignIn(It.IsAny<AuthenticationProperties>(), It.IsAny<ClaimsIdentity>()));
            am.Setup(m => m.SignOut());

            var wrapper = (TestContextWrapper)ContextWrapper.Instance;
            wrapper.AuthenticationManager = am.Object;

            controller.UserManager = ApplicationUserManager.Create(
                new IdentityFactoryOptions<ApplicationUserManager>(),
                null);
            Task<ActionResult> result = controller.Login(
                new LoginViewModel { Email = userName, Password = password },
                "none");
            result.Wait();
            Assert.IsFalse(controller.ModelState.ContainsKey(""));

            ScenarioContext.Current.Add(LoggedInUser,userName);
        }

        [When(@"I get the user list")]
        public void WhenIGetTheUserList()
        {
            var controller = new AdminController();
            var users = (ViewResult)controller.List(0, 10);
            ScenarioContext.Current.Add(usersListName, users.Model);
        }

        [Given(@"I assign the following roles to user ""(.*)""")]
        [When(@"I assign the following roles to user ""(.*)""")]
        public void WhenIAssignTheFollowingRolesToUser(string userName, Table table)
        {
            var ser = new IdentityService();
            ApplicationUser user = ser.GetUser(userName);
            Assert.IsNotNull(user);
            var controller = new AdminController();

            foreach (TableRow tableRow in table.Rows)
            {
                controller.AssignRoleToUser(user.Id, tableRow[0]);
            }
        }

        [Then(@"I expect the user ""(.*)"" to exist")]
        public void ThenIExpectTheUserToExist(string userName)
        {
            var ser = new IdentityService();
            ApplicationUser user = ser.GetUser(userName);

            Assert.IsNotNull(user);
        }

        [Then(@"I expect the followign users to be in the user list")]
        public void ThenIExpectTheFollowignUsersToBeInTheUserList(Table table)
        {
            var users = (AdminViewModel)ScenarioContext.Current[usersListName];
            foreach (TableRow tableRow in table.Rows)
            {
                Assert.IsTrue(users.Users.Select(u => u.UserName).Contains(tableRow[0]));
            }
        }

        [Then(@"I expect the user ""(.*)"" to have the following roles")]
        public void ThenIExpectTheUserToHaveTheFollowingRoles(string userName, Table table)
        {
            var ser = new IdentityService();

            foreach (TableRow row in table.Rows)
            {
                Assert.IsTrue(ser.IsUserInRole(userName, row[0]));
            }
        }

        [When(@"I get the role list")]
        public void WhenIGetTheRoleList()
        {
            var service = new IdentityService();
            Dictionary<string, string> rolesResult = service.GetAllRoles();
            ScenarioContext.Current.Add(AllRoles, rolesResult);
        }

        [Then(@"I expect there to be the following roles")]
        public void ThenIExpectThereToBeTheFollowingRoles(Table table)
        {
            var roles = (Dictionary<string, string>)ScenarioContext.Current[AllRoles];
            foreach (TableRow tableRow in table.Rows)
            {
                Assert.IsTrue(roles.Values.Contains(tableRow[0]));
            }
        }
    }
}