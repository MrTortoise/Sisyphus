namespace Sisyphus.Spec
{
    using System.Data.Entity;

    using Sisyphus.Core.Repository;
    using Sisyphus.Web.Migrations;

    internal class StageDatabase
    {
        public static void Stage()
        {
            //Database.SetInitializer(new  MigrateDatabaseToLatestVersion<SisyphusContext, Configuration>());
            Database.SetInitializer(new DatabaseStagingDropCreateSeed());
        }
    }
}