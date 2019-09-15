namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class room : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Photo", c => c.String());
        }
    }
}
