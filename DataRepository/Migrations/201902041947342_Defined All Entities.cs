namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefinedAllEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "UpdatedById", "dbo.Users");
            DropIndex("dbo.Products", new[] { "UpdatedById" });
            CreateTable(
                "dbo.PersonRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Description = c.String(),
                        StatusId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        VendorId = c.Int(),
                        AddressId = c.Int(),
                        CreatedById = c.Int(),
                        UpdatedById = c.Int(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .ForeignKey("dbo.Vendors", t => t.VendorId)
                .Index(t => t.VendorId)
                .Index(t => t.AddressId)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById);
            
            AddColumn("dbo.Offers", "Description", c => c.String());
            AddColumn("dbo.Offers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Offers", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Name", c => c.String());
            AddColumn("dbo.Products", "Description", c => c.String());
            AddColumn("dbo.Products", "IsNew", c => c.Boolean());
            AddColumn("dbo.Products", "IsGift", c => c.Boolean());
            AddColumn("dbo.Products", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "Manufacturer", c => c.String());
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "PriceFrom", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "PriceTo", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Weight", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Length", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Width", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Height", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "ScheduleId", c => c.Int());
            AddColumn("dbo.Products", "StatusId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.ReturnRequests", "OfferId", c => c.Int(nullable: false));
            AddColumn("dbo.ReturnRequests", "Reason", c => c.String());
            AddColumn("dbo.ReturnRequests", "CreatedById", c => c.Int());
            AddColumn("dbo.ReturnRequests", "CreatedOnUtc", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Products", "ScheduleId");
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Offers", "ProductId");
            CreateIndex("dbo.Offers", "CustomerId");
            CreateIndex("dbo.ReturnRequests", "OfferId");
            CreateIndex("dbo.ReturnRequests", "CreatedById");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "ScheduleId", "dbo.ProductSchedules", "Id");
            AddForeignKey("dbo.Offers", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Offers", "ProductId", "dbo.Products", "Id");
            AddForeignKey("dbo.ReturnRequests", "CreatedById", "dbo.Users", "Id");
            AddForeignKey("dbo.ReturnRequests", "OfferId", "dbo.Offers", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "UpdatedById");
            DropColumn("dbo.Products", "UpdatedOnUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "UpdatedOnUtc", c => c.DateTime());
            AddColumn("dbo.Products", "UpdatedById", c => c.Int());
            DropForeignKey("dbo.ReturnRequests", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.ReturnRequests", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Offers", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Offers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Providers", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Providers", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.Providers", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Providers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Products", "ScheduleId", "dbo.ProductSchedules");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.PersonRequests", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ReturnRequests", new[] { "CreatedById" });
            DropIndex("dbo.ReturnRequests", new[] { "OfferId" });
            DropIndex("dbo.Providers", new[] { "UpdatedById" });
            DropIndex("dbo.Providers", new[] { "CreatedById" });
            DropIndex("dbo.Providers", new[] { "AddressId" });
            DropIndex("dbo.Providers", new[] { "VendorId" });
            DropIndex("dbo.Offers", new[] { "CustomerId" });
            DropIndex("dbo.Offers", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "ScheduleId" });
            DropIndex("dbo.PersonRequests", new[] { "CategoryId" });
            DropColumn("dbo.ReturnRequests", "CreatedOnUtc");
            DropColumn("dbo.ReturnRequests", "CreatedById");
            DropColumn("dbo.ReturnRequests", "Reason");
            DropColumn("dbo.ReturnRequests", "OfferId");
            DropColumn("dbo.Products", "CategoryId");
            DropColumn("dbo.Products", "StatusId");
            DropColumn("dbo.Products", "ScheduleId");
            DropColumn("dbo.Products", "Height");
            DropColumn("dbo.Products", "Width");
            DropColumn("dbo.Products", "Length");
            DropColumn("dbo.Products", "Weight");
            DropColumn("dbo.Products", "PriceTo");
            DropColumn("dbo.Products", "PriceFrom");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "Manufacturer");
            DropColumn("dbo.Products", "IsDeleted");
            DropColumn("dbo.Products", "IsActive");
            DropColumn("dbo.Products", "IsGift");
            DropColumn("dbo.Products", "IsNew");
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Products", "Name");
            DropColumn("dbo.Offers", "CustomerId");
            DropColumn("dbo.Offers", "IsDeleted");
            DropColumn("dbo.Offers", "Description");
            DropTable("dbo.Providers");
            DropTable("dbo.PersonRequests");
            CreateIndex("dbo.Products", "UpdatedById");
            AddForeignKey("dbo.Products", "UpdatedById", "dbo.Users", "Id");
        }
    }
}
