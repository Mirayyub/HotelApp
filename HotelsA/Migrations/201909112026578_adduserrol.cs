namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduserrol : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserType = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Registrations", "CheckedIn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Registrations", "CheckedOut", c => c.DateTime(nullable: false));
            DropColumn("dbo.Registrations", "Start");
            DropColumn("dbo.Registrations", "End");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Registrations", "End", c => c.DateTime(nullable: false));
            AddColumn("dbo.Registrations", "Start", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.UserRols", "UserId", "dbo.Users");
            DropIndex("dbo.UserRols", new[] { "UserId" });
            DropColumn("dbo.Registrations", "CheckedOut");
            DropColumn("dbo.Registrations", "CheckedIn");
            DropTable("dbo.UserRols");
        }
    }
}
