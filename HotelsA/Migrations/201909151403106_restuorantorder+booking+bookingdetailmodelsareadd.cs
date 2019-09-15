namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restuorantorderbookingbookingdetailmodelsareadd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Registrations", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Registrations", "RestourantMenuId", "dbo.RestourantMenus");
            DropForeignKey("dbo.Registrations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.UserRols", "UserId", "dbo.Users");
            DropIndex("dbo.Registrations", new[] { "RoomId" });
            DropIndex("dbo.Registrations", new[] { "CustomerId" });
            DropIndex("dbo.Registrations", new[] { "RestourantMenuId" });
            DropIndex("dbo.UserRols", new[] { "UserId" });
            CreateTable(
                "dbo.BookingDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        IsDeleted = c.Boolean(),
                        BookingId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.BookingId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CheckedIn = c.DateTime(nullable: false),
                        CheckedOut = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RestourantOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                        FoodCount = c.Int(nullable: false),
                        IsDelete = c.Boolean(),
                        UserId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.FoodId)
                .Index(t => t.UserId)
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
            
            CreateTable(
                "dbo.BedTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "IsDelete", c => c.Boolean());
            AddColumn("dbo.Rooms", "BedTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "UserRolId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Passportcode", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Rooms", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.UserRols", "UserType", c => c.String(nullable: false, maxLength: 500));
            CreateIndex("dbo.Rooms", "BedTypeId");
            CreateIndex("dbo.Users", "UserRolId");
            AddForeignKey("dbo.Rooms", "BedTypeId", "dbo.BedTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "UserRolId", "dbo.UserRols", "Id", cascadeDelete: true);
            DropColumn("dbo.Rooms", "Type");
            DropColumn("dbo.UserRols", "UserId");
            DropTable("dbo.Registrations");
            DropTable("dbo.RestourantMenus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RestourantMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(),
                        Desc = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CheckedIn = c.DateTime(nullable: false),
                        CheckedOut = c.DateTime(nullable: false),
                        RoomId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        RestourantMenuId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserRols", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "Type", c => c.Int(nullable: false));
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropForeignKey("dbo.RestourantOrders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserRolId", "dbo.UserRols");
            DropForeignKey("dbo.RestourantOrders", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.BookingDetails", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "BedTypeId", "dbo.BedTypes");
            DropForeignKey("dbo.RestourantOrders", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Foods", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.RestourantOrders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.BookingDetails", "BookingId", "dbo.Bookings");
            DropIndex("dbo.Users", new[] { "UserRolId" });
            DropIndex("dbo.Rooms", new[] { "BedTypeId" });
            DropIndex("dbo.Foods", new[] { "CategoryId" });
            DropIndex("dbo.RestourantOrders", new[] { "RoomId" });
            DropIndex("dbo.RestourantOrders", new[] { "UserId" });
            DropIndex("dbo.RestourantOrders", new[] { "FoodId" });
            DropIndex("dbo.RestourantOrders", new[] { "CustomerId" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropIndex("dbo.BookingDetails", new[] { "RoomId" });
            DropIndex("dbo.BookingDetails", new[] { "BookingId" });
            AlterColumn("dbo.UserRols", "UserType", c => c.String());
            AlterColumn("dbo.Rooms", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.Customers", "Passportcode", c => c.String(nullable: false));
            DropColumn("dbo.Users", "UserRolId");
            DropColumn("dbo.Rooms", "BedTypeId");
            DropColumn("dbo.Customers", "IsDelete");
            DropTable("dbo.BedTypes");
            DropTable("dbo.Categories");
            DropTable("dbo.Foods");
            DropTable("dbo.RestourantOrders");
            DropTable("dbo.Bookings");
            DropTable("dbo.BookingDetails");
            CreateIndex("dbo.UserRols", "UserId");
            CreateIndex("dbo.Registrations", "RestourantMenuId");
            CreateIndex("dbo.Registrations", "CustomerId");
            CreateIndex("dbo.Registrations", "RoomId");
            AddForeignKey("dbo.UserRols", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Registrations", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Registrations", "RestourantMenuId", "dbo.RestourantMenus", "Id");
            AddForeignKey("dbo.Registrations", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
