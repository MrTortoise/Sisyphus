using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sisyphus.Web.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}