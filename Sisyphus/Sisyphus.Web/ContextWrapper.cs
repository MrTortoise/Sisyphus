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
    }
}