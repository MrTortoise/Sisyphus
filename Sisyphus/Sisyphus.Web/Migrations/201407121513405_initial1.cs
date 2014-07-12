namespace Sisyphus.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Characters", "Story_Id", "dbo.Stories");
            DropForeignKey("dbo.GameEvents", "Story_Id", "dbo.Stories");
            DropForeignKey("dbo.TimeUnits", "Story_Id", "dbo.Stories");
            DropForeignKey("dbo.Races", "Story_Id", "dbo.Stories");
            DropIndex("dbo.Characters", "CharacterName");
            DropIndex("dbo.Characters", new[] { "Story_Id" });
            DropIndex("dbo.GameEvents", new[] { "GameEventName" });
            DropIndex("dbo.GameEvents", new[] { "Story_Id" });
            DropIndex("dbo.Places", new[] { "PlaceName" });
            DropIndex("dbo.Places", new[] { "StoryId" });
            DropIndex("dbo.TimeUnits", "bitValue");
            DropIndex("dbo.TimeUnits", new[] { "Story_Id" });
            DropIndex("dbo.Races", new[] { "Story_Id" });
            RenameColumn(table: "dbo.Races", name: "Name", newName: "RaceName");
            RenameColumn(table: "dbo.Characters", name: "Story_Id", newName: "StoryId");
            RenameColumn(table: "dbo.GameEvents", name: "Story_Id", newName: "StoryId");
            RenameColumn(table: "dbo.TimeUnits", name: "Story_Id", newName: "StoryId");
            RenameColumn(table: "dbo.Races", name: "Story_Id", newName: "StoryId");
            CreateTable(
                "dbo.Sexes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SexName = c.String(maxLength: 25),
                        Description = c.String(),
                        StoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .Index(t => new { t.SexName, t.StoryId }, unique: true, name: "SexUnique");
            
            AddColumn("dbo.Characters", "Race_Id", c => c.Int());
            AddColumn("dbo.Characters", "Sex_Id", c => c.Int());
            AlterColumn("dbo.Characters", "StoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.GameEvents", "StoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.TimeUnits", "StoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Races", "RaceName", c => c.String(maxLength: 25));
            AlterColumn("dbo.Races", "StoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Characters", new[] { "CharacterName", "StoryId" }, unique: true, name: "CharacterUnique");
            CreateIndex("dbo.Characters", "Race_Id");
            CreateIndex("dbo.Characters", "Sex_Id");
            CreateIndex("dbo.Races", new[] { "RaceName", "StoryId" }, unique: true, name: "SexUnique");
            CreateIndex("dbo.GameEvents", new[] { "GameEventName", "StoryId" }, unique: true, name: "GameEventUnique");
            CreateIndex("dbo.Places", new[] { "PlaceName", "StoryId" }, unique: true, name: "PlaceUniquw");
            CreateIndex("dbo.TimeUnits", new[] { "Bit", "Value", "StoryId" }, unique: true, name: "bitValue");
            AddForeignKey("dbo.Characters", "Race_Id", "dbo.Races", "Id");
            AddForeignKey("dbo.Characters", "Sex_Id", "dbo.Sexes", "Id");
            AddForeignKey("dbo.Characters", "StoryId", "dbo.Stories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GameEvents", "StoryId", "dbo.Stories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TimeUnits", "StoryId", "dbo.Stories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Races", "StoryId", "dbo.Stories", "Id", cascadeDelete: true);
            DropColumn("dbo.Characters", "Race");
            DropColumn("dbo.Characters", "Sex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Characters", "Sex", c => c.String(maxLength: 40));
            AddColumn("dbo.Characters", "Race", c => c.String(maxLength: 40));
            DropForeignKey("dbo.Races", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.TimeUnits", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.GameEvents", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Characters", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Characters", "Sex_Id", "dbo.Sexes");
            DropForeignKey("dbo.Sexes", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Characters", "Race_Id", "dbo.Races");
            DropIndex("dbo.Sexes", "SexUnique");
            DropIndex("dbo.TimeUnits", "bitValue");
            DropIndex("dbo.Places", "PlaceUniquw");
            DropIndex("dbo.GameEvents", "GameEventUnique");
            DropIndex("dbo.Races", "SexUnique");
            DropIndex("dbo.Characters", new[] { "Sex_Id" });
            DropIndex("dbo.Characters", new[] { "Race_Id" });
            DropIndex("dbo.Characters", "CharacterUnique");
            AlterColumn("dbo.Races", "StoryId", c => c.Int());
            AlterColumn("dbo.Races", "RaceName", c => c.String());
            AlterColumn("dbo.TimeUnits", "StoryId", c => c.Int());
            AlterColumn("dbo.GameEvents", "StoryId", c => c.Int());
            AlterColumn("dbo.Characters", "StoryId", c => c.Int());
            DropColumn("dbo.Characters", "Sex_Id");
            DropColumn("dbo.Characters", "Race_Id");
            DropTable("dbo.Sexes");
            RenameColumn(table: "dbo.Races", name: "StoryId", newName: "Story_Id");
            RenameColumn(table: "dbo.TimeUnits", name: "StoryId", newName: "Story_Id");
            RenameColumn(table: "dbo.GameEvents", name: "StoryId", newName: "Story_Id");
            RenameColumn(table: "dbo.Characters", name: "StoryId", newName: "Story_Id");
            RenameColumn(table: "dbo.Races", name: "RaceName", newName: "Name");
            CreateIndex("dbo.Races", "Story_Id");
            CreateIndex("dbo.TimeUnits", "Story_Id");
            CreateIndex("dbo.TimeUnits", new[] { "Bit", "Value" }, unique: true, name: "bitValue");
            CreateIndex("dbo.Places", "StoryId");
            CreateIndex("dbo.Places", "PlaceName", unique: true);
            CreateIndex("dbo.GameEvents", "Story_Id");
            CreateIndex("dbo.GameEvents", "GameEventName", unique: true);
            CreateIndex("dbo.Characters", "Story_Id");
            CreateIndex("dbo.Characters", "CharacterName", unique: true, name: "CharacterName");
            AddForeignKey("dbo.Races", "Story_Id", "dbo.Stories", "Id");
            AddForeignKey("dbo.TimeUnits", "Story_Id", "dbo.Stories", "Id");
            AddForeignKey("dbo.GameEvents", "Story_Id", "dbo.Stories", "Id");
            AddForeignKey("dbo.Characters", "Story_Id", "dbo.Stories", "Id");
        }
    }
}
