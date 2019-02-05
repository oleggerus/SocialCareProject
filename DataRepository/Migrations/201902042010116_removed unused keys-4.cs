namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedunusedkeys4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Permissions", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Workers", "Administration_Id1", "dbo.Administrations");
            DropForeignKey("dbo.PersonRequests", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.VendorCategories", "Vendor_Id", "dbo.Vendors");
            DropForeignKey("dbo.VendorCategories", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Permissions", new[] { "Role_Id" });
            DropIndex("dbo.Workers", new[] { "Administration_Id1" });
            DropIndex("dbo.PersonRequests", new[] { "Category_Id" });
            DropIndex("dbo.VendorCategories", new[] { "Vendor_Id" });
            DropIndex("dbo.VendorCategories", new[] { "Category_Id" });
            DropColumn("dbo.Permissions", "Role_Id");
            DropColumn("dbo.Workers", "Administration_Id1");
            DropTable("dbo.PersonRequests");
            DropTable("dbo.VendorCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VendorCategories",
                c => new
                    {
                        Vendor_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vendor_Id, t.Category_Id });
            
            CreateTable(
                "dbo.PersonRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        StatusId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Workers", "Administration_Id1", c => c.Int());
            AddColumn("dbo.Permissions", "Role_Id", c => c.Int());
            CreateIndex("dbo.VendorCategories", "Category_Id");
            CreateIndex("dbo.VendorCategories", "Vendor_Id");
            CreateIndex("dbo.PersonRequests", "Category_Id");
            CreateIndex("dbo.Workers", "Administration_Id1");
            CreateIndex("dbo.Permissions", "Role_Id");
            AddForeignKey("dbo.VendorCategories", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VendorCategories", "Vendor_Id", "dbo.Vendors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonRequests", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Workers", "Administration_Id1", "dbo.Administrations", "Id");
            AddForeignKey("dbo.Permissions", "Role_Id", "dbo.Roles", "Id");
        }
    }
}
