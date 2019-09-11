namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registrationnulablerestoranid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Registrations", "RestourantMenuId", "dbo.RestourantMenus");
            DropIndex("dbo.Registrations", new[] { "RestourantMenuId" });
            AlterColumn("dbo.Registrations", "RestourantMenuId", c => c.Int());
            CreateIndex("dbo.Registrations", "RestourantMenuId");
            AddForeignKey("dbo.Registrations", "RestourantMenuId", "dbo.RestourantMenus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrations", "RestourantMenuId", "dbo.RestourantMenus");
            DropIndex("dbo.Registrations", new[] { "RestourantMenuId" });
            AlterColumn("dbo.Registrations", "RestourantMenuId", c => c.Int(nullable: false));
            CreateIndex("dbo.Registrations", "RestourantMenuId");
            AddForeignKey("dbo.Registrations", "RestourantMenuId", "dbo.RestourantMenus", "Id", cascadeDelete: true);
        }
    }
}
