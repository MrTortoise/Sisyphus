using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisyphus.Spec
{

    using System.Data.Entity;

    using Sisyphus.Core.Repository;
    using Sisyphus.Web.Migrations;
    using System.Data.Entity.Migrations;

    using Sisyphus.Web.Models;

    class StageDatabase
    {
        public static void Stage()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
    }
}
