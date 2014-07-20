namespace Sisyphus.Web
{
    using System.Web;

    public class ContextWrapper : IContextWrapper
    {
        public static IContextWrapper Instance { get; set; }

        public string UserName
        {
            get
            {
                return HttpContext.Current.User.Identity.Name;
            }
        }


        public Microsoft.Owin.Security.IAuthenticationManager GetAuthenticationManager(System.Web.Mvc.Controller controller)
        {
            return controller.HttpContext.GetOwinContext().Authentication;
        }
    }
}