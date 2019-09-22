namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restorderidnull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "RestourantOrderId", "dbo.RestourantOrders");
            DropIndex("dbo.Bookings", new[] { "RestourantOrderId" });
            AlterColumn("dbo.Bookings", "RestourantOrderId", c => c.Int());
            CreateIndex("dbo.Bookings", "RestourantOrderId");
            AddForeignKey("dbo.Bookings", "RestourantOrderId", "dbo.RestourantOrders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "RestourantOrderId", "dbo.RestourantOrders");
            DropIndex("dbo.Bookings", new[] { "RestourantOrderId" });
            AlterColumn("dbo.Bookings", "RestourantOrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "RestourantOrderId");
            AddForeignKey("dbo.Bookings", "RestourantOrderId", "dbo.RestourantOrders", "Id", cascadeDelete: true);
        }
    }
}
