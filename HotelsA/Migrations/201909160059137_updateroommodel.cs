namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateroommodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookingDetails", "RoomId", "dbo.Rooms");
            DropIndex("dbo.BookingDetails", new[] { "RoomId" });
            DropColumn("dbo.BookingDetails", "RoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingDetails", "RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookingDetails", "RoomId");
            AddForeignKey("dbo.BookingDetails", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
        }
    }
}
