namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delcustomerdate : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.Registrations", "RestourantMenuId", c => c.Int(nullable: false));
            CreateIndex("dbo.Registrations", "RestourantMenuId");
            AddForeignKey("dbo.Registrations", "RestourantMenuId", "dbo.RestourantMenus", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "CreatedDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CreatedDay", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Registrations", "RestourantMenuId", "dbo.RestourantMenus");
            DropIndex("dbo.Registrations", new[] { "RestourantMenuId" });
            DropColumn("dbo.Registrations", "RestourantMenuId");
            DropTable("dbo.RestourantMenus");
        }
    }
}
