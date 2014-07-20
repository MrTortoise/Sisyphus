namespace Sisyphus.Web
{
    using System.Web.Mvc;

    using Microsoft.Owin.Security;

    public interface IContextWrapper
    {
        string UserName { get; }

        IAuthenticationManager GetAuthenticationManager(Controller controller);
    }
}