namespace Sisyphus.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class outcomeTweak : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Outcomes", new[] { "GameEvent_Id" });
            RenameColumn(table: "dbo.Outcomes", name: "GameEvent_Id", newName: "GameEventId");
            AlterColumn("dbo.Outcomes", "GameEventId", c => c.Int(nullable: false));
            CreateIndex("dbo.Outcomes", "GameEventId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Outcomes", new[] { "GameEventId" });
            AlterColumn("dbo.Outcomes", "GameEventId", c => c.Int());
            RenameColumn(table: "dbo.Outcomes", name: "GameEventId", newName: "GameEvent_Id");
            CreateIndex("dbo.Outcomes", "GameEvent_Id");
        }
    }
}
