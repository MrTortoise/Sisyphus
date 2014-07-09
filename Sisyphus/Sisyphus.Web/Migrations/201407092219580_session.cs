namespace Sisyphus.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class session : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoryName = c.String(nullable: false, maxLength: 4000),
                        BackStory = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.StoryName, unique: true);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Story_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stories", t => t.Story_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Story_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Characters", "Story_Id", c => c.Int());
            AddColumn("dbo.Places", "Story_Id", c => c.Int());
            AddColumn("dbo.GameEvents", "Story_Id", c => c.Int());
            AddColumn("dbo.TimeUnits", "Story_Id", c => c.Int());
            CreateIndex("dbo.Characters", "Story_Id");
            CreateIndex("dbo.Places", "Story_Id");
            CreateIndex("dbo.GameEvents", "Story_Id");
            CreateIndex("dbo.TimeUnits", "Story_Id");
            AddForeignKey("dbo.Characters", "Story_Id", "dbo.Stories", "Id");
            AddForeignKey("dbo.GameEvents", "Story_Id", "dbo.Stories", "Id");
            AddForeignKey("dbo.Places", "Story_Id", "dbo.Stories", "Id");
            AddForeignKey("dbo.TimeUnits", "Story_Id", "dbo.Stories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeUnits", "Story_Id", "dbo.Stories");
            DropForeignKey("dbo.Sessions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sessions", "Story_Id", "dbo.Stories");
            DropForeignKey("dbo.Places", "Story_Id", "dbo.Stories");
            DropForeignKey("dbo.GameEvents", "Story_Id", "dbo.Stories");
            DropForeignKey("dbo.Characters", "Story_Id", "dbo.Stories");
            DropIndex("dbo.TimeUnits", new[] { "Story_Id" });
            DropIndex("dbo.Sessions", new[] { "User_Id" });
            DropIndex("dbo.Sessions", new[] { "Story_Id" });
            DropIndex("dbo.GameEvents", new[] { "Story_Id" });
            DropIndex("dbo.Stories", new[] { "StoryName" });
            DropIndex("dbo.Places", new[] { "Story_Id" });
            DropIndex("dbo.Characters", new[] { "Story_Id" });
            DropColumn("dbo.TimeUnits", "Story_Id");
            DropColumn("dbo.GameEvents", "Story_Id");
            DropColumn("dbo.Places", "Story_Id");
            DropColumn("dbo.Characters", "Story_Id");
            DropTable("dbo.Sessions");
            DropTable("dbo.Stories");
        }
    }
}
