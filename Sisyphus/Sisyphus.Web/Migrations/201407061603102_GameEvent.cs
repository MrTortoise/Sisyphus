namespace Sisyphus.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameEvent : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Places", name: "Name", newName: "PlaceName");
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BackStory = c.String(),
                        Race = c.String(maxLength: 40),
                        Sex = c.String(maxLength: 40),
                        CharacterName = c.String(nullable: false, maxLength: 40),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Place_Id = c.Int(nullable: false),
                        GameEvent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Places", t => t.Place_Id, cascadeDelete: true)
                .ForeignKey("dbo.GameEvents", t => t.GameEvent_Id)
                .Index(t => t.CharacterName, unique: true, name: "CharacterName")
                .Index(t => t.Place_Id)
                .Index(t => t.GameEvent_Id);
            
            CreateTable(
                "dbo.GameEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameEventName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        Duration = c.Int(nullable: false),
                        EventType = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.GameEventName, unique: true);
            
            CreateTable(
                "dbo.Outcomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OutcomeName = c.String(nullable: false, maxLength: 4000),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        GameEvent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameEvents", t => t.GameEvent_Id)
                .Index(t => t.GameEvent_Id);
            
            AddColumn("dbo.Places", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Places", "GameEvent_Id", c => c.Int());
            AddColumn("dbo.TimeUnits", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AlterColumn("dbo.Places", "PlaceName", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.TimeUnits", "Text", c => c.String(nullable: false));
            CreateIndex("dbo.Places", "PlaceName", unique: true);
            CreateIndex("dbo.Places", "GameEvent_Id");
            CreateIndex("dbo.TimeUnits", new[] { "Bit", "Value" }, unique: true, name: "bitValue");
            AddForeignKey("dbo.Places", "GameEvent_Id", "dbo.GameEvents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "GameEvent_Id", "dbo.GameEvents");
            DropForeignKey("dbo.Outcomes", "GameEvent_Id", "dbo.GameEvents");
            DropForeignKey("dbo.Characters", "GameEvent_Id", "dbo.GameEvents");
            DropForeignKey("dbo.Characters", "Place_Id", "dbo.Places");
            DropIndex("dbo.TimeUnits", "bitValue");
            DropIndex("dbo.Outcomes", new[] { "GameEvent_Id" });
            DropIndex("dbo.GameEvents", new[] { "GameEventName" });
            DropIndex("dbo.Places", new[] { "GameEvent_Id" });
            DropIndex("dbo.Places", new[] { "PlaceName" });
            DropIndex("dbo.Characters", new[] { "GameEvent_Id" });
            DropIndex("dbo.Characters", new[] { "Place_Id" });
            DropIndex("dbo.Characters", "CharacterName");
            AlterColumn("dbo.TimeUnits", "Text", c => c.String());
            AlterColumn("dbo.Places", "PlaceName", c => c.String());
            DropColumn("dbo.TimeUnits", "TimeStamp");
            DropColumn("dbo.Places", "GameEvent_Id");
            DropColumn("dbo.Places", "TimeStamp");
            DropTable("dbo.Outcomes");
            DropTable("dbo.GameEvents");
            DropTable("dbo.Characters");
            RenameColumn(table: "dbo.Places", name: "PlaceName", newName: "Name");
        }
    }
}
