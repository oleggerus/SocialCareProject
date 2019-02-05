namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewrequiredcolummsadded1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "User_Id", "dbo.Users");
            DropIndex("dbo.Customers", new[] { "Address_Id" });
            DropIndex("dbo.Customers", new[] { "User_Id" });
            RenameColumn(table: "dbo.Customers", name: "AdministrationId", newName: "Administration_Id");
            RenameIndex(table: "dbo.Customers", name: "IX_AdministrationId", newName: "IX_Administration_Id");
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "IsSelfPaid", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customers", "IsInvalid", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customers", "StatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Address_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "User_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "Address_Id");
            CreateIndex("dbo.Customers", "User_Id");
            AddForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "User_Id" });
            DropIndex("dbo.Customers", new[] { "Address_Id" });
            AlterColumn("dbo.Customers", "User_Id", c => c.Int());
            AlterColumn("dbo.Customers", "Address_Id", c => c.Int());
            AlterColumn("dbo.Customers", "StatusId", c => c.Int());
            AlterColumn("dbo.Customers", "IsInvalid", c => c.Boolean());
            AlterColumn("dbo.Customers", "IsSelfPaid", c => c.Boolean());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            RenameIndex(table: "dbo.Customers", name: "IX_Administration_Id", newName: "IX_AdministrationId");
            RenameColumn(table: "dbo.Customers", name: "Administration_Id", newName: "AdministrationId");
            CreateIndex("dbo.Customers", "User_Id");
            CreateIndex("dbo.Customers", "Address_Id");
            AddForeignKey("dbo.Customers", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
