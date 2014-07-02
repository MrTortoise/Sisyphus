namespace Sisyphus.Web.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class UserRoleViewModel
    {
        public string UserName { get; set; }

        public List<string> Roles { get; set; }

        public List<SelectListItem> AllRoles { get; set; }
    }
}