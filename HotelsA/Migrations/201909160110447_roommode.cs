namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roommode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "IsDeleted", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "IsDeleted");
        }
    }
}
