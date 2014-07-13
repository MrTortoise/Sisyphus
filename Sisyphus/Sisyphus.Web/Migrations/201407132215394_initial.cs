namespace Sisyphus.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BackStory = c.String(),
                        SexId = c.Int(nullable: false),
                        RaceId = c.Int(nullable: false),
                        CharacterName = c.String(nullable: false, maxLength: 40),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        StoryId = c.Int(nullable: false),
                        GameEvent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameEvents", t => t.GameEvent_Id)
                .ForeignKey("dbo.Races", t => t.RaceId)
                .ForeignKey("dbo.Sexes", t => t.SexId)
                .ForeignKey("dbo.Stories", t => t.StoryId)
                .Index(t => t.SexId)
                .Index(t => t.RaceId)
                .Index(t => new { t.CharacterName, t.StoryId }, unique: true, name: "CharacterUnique")
                .Index(t => t.GameEvent_Id);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RaceName = c.String(nullable: false, maxLength: 25),
                        BackStory = c.String(),
                        StoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stories", t => t.StoryId)
                .Index(t => new { t.RaceName, t.StoryId }, unique: true, name: "SexUnique");
            
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
                "dbo.GameEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameEventName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        Duration = c.Int(nullable: false),
                        EventType = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        StoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stories", t => t.StoryId)
                .Index(t => new { t.GameEventName, t.StoryId }, unique: true, name: "GameEventUnique");
            
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
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaceName = c.String(nullable: false, maxLength: 100),
                        History = c.String(),
                        StoryId = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        GameEvent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stories", t => t.StoryId)
                .ForeignKey("dbo.GameEvents", t => t.GameEvent_Id)
                .Index(t => new { t.PlaceName, t.StoryId }, unique: true, name: "PlaceUniquw")
                .Index(t => t.GameEvent_Id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        StoryId = c.Int(),
                        UserId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stories", t => t.StoryId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.StoryId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TimeUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Bit = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                        Value = c.Int(nullable: false),
                        StoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stories", t => t.StoryId)
                .Index(t => new { t.Bit, t.Value, t.StoryId }, unique: true, name: "bitValue");
            
            CreateTable(
                "dbo.Sexes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SexName = c.String(nullable: false, maxLength: 25),
                        Description = c.String(),
                        StoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stories", t => t.StoryId)
                .Index(t => new { t.SexName, t.StoryId }, unique: true, name: "SexUnique");
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Characters", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Characters", "SexId", "dbo.Sexes");
            DropForeignKey("dbo.Sexes", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Characters", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Races", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.TimeUnits", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Sessions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sessions", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.GameEvents", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Places", "GameEvent_Id", "dbo.GameEvents");
            DropForeignKey("dbo.Places", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Outcomes", "GameEvent_Id", "dbo.GameEvents");
            DropForeignKey("dbo.Characters", "GameEvent_Id", "dbo.GameEvents");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Sexes", "SexUnique");
            DropIndex("dbo.TimeUnits", "bitValue");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Sessions", new[] { "User_Id" });
            DropIndex("dbo.Sessions", new[] { "StoryId" });
            DropIndex("dbo.Places", new[] { "GameEvent_Id" });
            DropIndex("dbo.Places", "PlaceUniquw");
            DropIndex("dbo.Outcomes", new[] { "GameEvent_Id" });
            DropIndex("dbo.GameEvents", "GameEventUnique");
            DropIndex("dbo.Stories", new[] { "StoryName" });
            DropIndex("dbo.Races", "SexUnique");
            DropIndex("dbo.Characters", new[] { "GameEvent_Id" });
            DropIndex("dbo.Characters", "CharacterUnique");
            DropIndex("dbo.Characters", new[] { "RaceId" });
            DropIndex("dbo.Characters", new[] { "SexId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Sexes");
            DropTable("dbo.TimeUnits");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Sessions");
            DropTable("dbo.Places");
            DropTable("dbo.Outcomes");
            DropTable("dbo.GameEvents");
            DropTable("dbo.Stories");
            DropTable("dbo.Races");
            DropTable("dbo.Characters");
        }
    }
}
