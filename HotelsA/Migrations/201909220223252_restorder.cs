namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "RestourantOrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "RestourantOrderId");
            AddForeignKey("dbo.Bookings", "RestourantOrderId", "dbo.RestourantOrders", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "RestourantOrderId", "dbo.RestourantOrders");
            DropIndex("dbo.Bookings", new[] { "RestourantOrderId" });
            DropColumn("dbo.Bookings", "RestourantOrderId");
        }
    }
}
