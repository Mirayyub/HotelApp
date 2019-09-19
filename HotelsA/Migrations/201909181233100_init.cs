namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BedTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Status = c.Boolean(nullable: false),
                        PersonCapacity = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                        ChildCapacity = c.Int(nullable: false),
                        Desc = c.String(nullable: false, maxLength: 500),
                        BedTypeId = c.Int(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BedTypes", t => t.BedTypeId, cascadeDelete: true)
                .Index(t => t.BedTypeId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CheckedIn = c.DateTime(nullable: false),
                        CheckedOut = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        RoomId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.RoomId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BookingDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        IsDeleted = c.Boolean(),
                        BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .Index(t => t.BookingId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Phonenumber = c.String(nullable: false, maxLength: 15),
                        Passportcode = c.String(nullable: false, maxLength: 15),
                        IsDelete = c.Boolean(),
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
                        UserRolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserRols", t => t.UserRolId, cascadeDelete: true)
                .Index(t => t.UserRolId);
            
            CreateTable(
                "dbo.UserRols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserType = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestourantOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodId = c.Int(nullable: false),
                        FoodCount = c.Int(nullable: false),
                        IsDelete = c.Boolean(),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        IsDelete = c.Boolean(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestourantOrders", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RestourantOrders", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Foods", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserRolId", "dbo.UserRols");
            DropForeignKey("dbo.Bookings", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.BookingDetails", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Rooms", "BedTypeId", "dbo.BedTypes");
            DropIndex("dbo.Foods", new[] { "CategoryId" });
            DropIndex("dbo.RestourantOrders", new[] { "RoomId" });
            DropIndex("dbo.RestourantOrders", new[] { "FoodId" });
            DropIndex("dbo.Users", new[] { "UserRolId" });
            DropIndex("dbo.BookingDetails", new[] { "BookingId" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropIndex("dbo.Bookings", new[] { "RoomId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropIndex("dbo.Rooms", new[] { "BedTypeId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Foods");
            DropTable("dbo.RestourantOrders");
            DropTable("dbo.UserRols");
            DropTable("dbo.Users");
            DropTable("dbo.Customers");
            DropTable("dbo.BookingDetails");
            DropTable("dbo.Bookings");
            DropTable("dbo.Rooms");
            DropTable("dbo.BedTypes");
        }
    }
}
