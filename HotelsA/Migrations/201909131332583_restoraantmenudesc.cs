namespace HotelsA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restoraantmenudesc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BedTypes", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "Type_Id", "dbo.BedTypes");
            DropForeignKey("dbo.Rooms", "BedType_Id", "dbo.BedTypes");
            DropIndex("dbo.Rooms", new[] { "BedType_Id" });
            DropIndex("dbo.Rooms", new[] { "Type_Id" });
            DropIndex("dbo.BedTypes", new[] { "Room_Id" });
            DropColumn("dbo.Rooms", "BedTypeId");
            RenameColumn(table: "dbo.Rooms", name: "BedType_Id", newName: "BedTypeId");
            AlterColumn("dbo.RestourantMenus", "Desc", c => c.String(maxLength: 500));
            AlterColumn("dbo.Rooms", "BedTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "BedTypeId");
            AddForeignKey("dbo.Rooms", "BedTypeId", "dbo.BedTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Rooms", "Type_Id");
            DropColumn("dbo.BedTypes", "Room_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BedTypes", "Room_Id", c => c.Int());
            AddColumn("dbo.Rooms", "Type_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rooms", "BedTypeId", "dbo.BedTypes");
            DropIndex("dbo.Rooms", new[] { "BedTypeId" });
            AlterColumn("dbo.Rooms", "BedTypeId", c => c.Int());
            AlterColumn("dbo.RestourantMenus", "Desc", c => c.String(maxLength: 50));
            RenameColumn(table: "dbo.Rooms", name: "BedTypeId", newName: "BedType_Id");
            AddColumn("dbo.Rooms", "BedTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.BedTypes", "Room_Id");
            CreateIndex("dbo.Rooms", "Type_Id");
            CreateIndex("dbo.Rooms", "BedType_Id");
            AddForeignKey("dbo.Rooms", "BedType_Id", "dbo.BedTypes", "Id");
            AddForeignKey("dbo.Rooms", "Type_Id", "dbo.BedTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BedTypes", "Room_Id", "dbo.Rooms", "Id");
        }
    }
}
