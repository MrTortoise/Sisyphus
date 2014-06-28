using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sisyphus.Web.Models
{
    public class AdminViewModel
    {
        public AdminViewModel()
        {
            
        }

        public AdminViewModel(int skip, int pageSize, Dictionary<string, List<string>> userRoles)
        {
            this.Skip = skip;
            this.PageSize = pageSize;
            Users = new List<UserModel>();
            foreach (var item in userRoles)
            {
                Users.Add(new UserModel() { UserName = item.Key, Roles = item.Value.ToList() });
            }
        }

        public int PageSize { get; set; }
        public int Skip { get; set; }
        public List<UserModel> Users { get; set; }
    }
}