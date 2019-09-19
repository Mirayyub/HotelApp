namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tokenadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "token", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "token");
        }
    }
}
