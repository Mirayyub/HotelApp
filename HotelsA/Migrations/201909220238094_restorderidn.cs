namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restorderidn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "RestourantOrderId", "dbo.RestourantOrders");
            DropIndex("dbo.Bookings", new[] { "RestourantOrderId" });
            AddColumn("dbo.RestourantOrders", "BookingId", c => c.Int());
            CreateIndex("dbo.RestourantOrders", "BookingId");
            AddForeignKey("dbo.RestourantOrders", "BookingId", "dbo.Bookings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestourantOrders", "BookingId", "dbo.Bookings");
            DropIndex("dbo.RestourantOrders", new[] { "BookingId" });
            DropColumn("dbo.RestourantOrders", "BookingId");
            CreateIndex("dbo.Bookings", "RestourantOrderId");
            AddForeignKey("dbo.Bookings", "RestourantOrderId", "dbo.RestourantOrders", "Id");
        }
    }
}
