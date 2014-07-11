namespace Sisyphus.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BetterForeignRelatinos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Characters", "Place_Id", "dbo.Places");
            DropForeignKey("dbo.Places", "Story_Id", "dbo.Stories");
            DropIndex("dbo.Characters", new[] { "Place_Id" });
            DropIndex("dbo.Places", new[] { "Story_Id" });
            RenameColumn(table: "dbo.Places", name: "Story_Id", newName: "StoryId");
            RenameColumn(table: "dbo.Sessions", name: "Story_Id", newName: "StoryId");
            RenameIndex(table: "dbo.Sessions", name: "IX_Story_Id", newName: "IX_StoryId");
            AddColumn("dbo.Sessions", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Places", "StoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Places", "StoryId");
            AddForeignKey("dbo.Places", "StoryId", "dbo.Stories", "Id", cascadeDelete: true);
            DropColumn("dbo.Characters", "Place_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Characters", "Place_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Places", "StoryId", "dbo.Stories");
            DropIndex("dbo.Places", new[] { "StoryId" });
            AlterColumn("dbo.Places", "StoryId", c => c.Int());
            DropColumn("dbo.Sessions", "UserId");
            RenameIndex(table: "dbo.Sessions", name: "IX_StoryId", newName: "IX_Story_Id");
            RenameColumn(table: "dbo.Sessions", name: "StoryId", newName: "Story_Id");
            RenameColumn(table: "dbo.Places", name: "StoryId", newName: "Story_Id");
            CreateIndex("dbo.Places", "Story_Id");
            CreateIndex("dbo.Characters", "Place_Id");
            AddForeignKey("dbo.Places", "Story_Id", "dbo.Stories", "Id");
            AddForeignKey("dbo.Characters", "Place_Id", "dbo.Places", "Id", cascadeDelete: true);
        }
    }
}
