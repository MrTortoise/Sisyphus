namespace Sisyphus.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paddedRaceCharacter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BackStory = c.String(),
                        Story_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stories", t => t.Story_Id)
                .Index(t => t.Story_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Races", "Story_Id", "dbo.Stories");
            DropIndex("dbo.Races", new[] { "Story_Id" });
            DropTable("dbo.Races");
        }
    }
}
