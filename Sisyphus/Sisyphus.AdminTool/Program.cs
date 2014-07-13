using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sisyphus.Core;

namespace Sisyphus.AdminTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.Source = new AppConfigSource();
            RoleFunctions.AddRolesToUser(new List<string>() { "Writer", "Reader", "Admin" }, "themrtortoise@gmail.com");
        }
    }
}
