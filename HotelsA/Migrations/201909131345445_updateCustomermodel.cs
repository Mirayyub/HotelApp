namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCustomermodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Passportcode", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Passportcode", c => c.String(nullable: false));
        }
    }
}
