using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisyphus.AdminTool
{
    using Sisyphus.Core.Services;

    public class RoleFunctions
    {
       public static void AddRolesToUser(List<string> roles, string user)
       {
           var service = new IdentityService();
           foreach (var role in roles)
           {
               service.AddUserNameToRole(user, role);
           }
       }
    }
}
