namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dellrestoran : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RestourantOrders", "BookingId", "dbo.Bookings");
            DropIndex("dbo.RestourantOrders", new[] { "BookingId" });
            DropColumn("dbo.RestourantOrders", "BookingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestourantOrders", "BookingId", c => c.Int());
            CreateIndex("dbo.RestourantOrders", "BookingId");
            AddForeignKey("dbo.RestourantOrders", "BookingId", "dbo.Bookings", "Id");
        }
    }
}
