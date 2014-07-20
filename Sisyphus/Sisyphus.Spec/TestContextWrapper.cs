namespace Sisyphus.Spec
{
    using System.Web.Mvc;

    using Microsoft.Owin.Security;

    using Sisyphus.Web;

    public class TestContextWrapper : IContextWrapper
    {
        public string UserName { get; set; }

        public IAuthenticationManager AuthenticationManager { get; set; }

        public IAuthenticationManager GetAuthenticationManager(Controller controller)
        {
            return AuthenticationManager;
        }
    }
}