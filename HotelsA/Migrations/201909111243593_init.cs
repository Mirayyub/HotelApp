namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Phonenumber = c.String(nullable: false, maxLength: 15),
                        Passportcode = c.String(nullable: false),
                        CreatedDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        RoomId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
                        PersonCapacity = c.Int(nullable: false),
                        ChildCapacity = c.Int(nullable: false),
                        Desc = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 30),
                        UserName = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Registrations", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Registrations", new[] { "CustomerId" });
            DropIndex("dbo.Registrations", new[] { "RoomId" });
            DropTable("dbo.Users");
            DropTable("dbo.Rooms");
            DropTable("dbo.Registrations");
            DropTable("dbo.Customers");
        }
    }
}
