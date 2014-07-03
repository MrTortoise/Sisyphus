namespace Sisyphus.Web.Models
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    public class AdminViewModel
    {
        public AdminViewModel()
        {
        }

        public AdminViewModel(
            int skip,
            int pageSize,
            Dictionary<string, List<string>> userRoles,
            Dictionary<string, string> allRoles)
        {
            this.Skip = skip;
            this.PageSize = pageSize;
            this.Users = new List<UserRoleViewModel>();

            var roles =
                allRoles.Select(i => new SelectListItem() { Selected = false, Value = i.Value, Text = i.Value }).ToList();
            roles[0].Selected = true;

            foreach (var item in userRoles)
            {
                this.Users.Add(
                    new UserRoleViewModel { UserName = item.Key, Roles = item.Value.ToList(), AllRoles = roles });
            }
        }

        public int PageSize { get; set; }

        public int Skip { get; set; }

        public List<UserRoleViewModel> Users { get; set; }
    }
}