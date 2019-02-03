namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewmoreentities12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseNameRoomNumber = c.String(),
                        Email = c.String(),
                        RegionId = c.Int(nullable: false),
                        City = c.String(),
                        ZipPostalCode = c.String(),
                        PhoneNumber = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedById = c.Int(),
                        UpdatedById = c.Int(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById);
            
            CreateTable(
                "dbo.Administrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        AddressId = c.Int(nullable: false),
                        Url = c.String(),
                        ContactId = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Logo = c.Binary(),
                        CreatedById = c.Int(),
                        UpdatedById = c.Int(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .Index(t => t.AddressId)
                .Index(t => t.ContactId)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AdministrationId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        Info = c.String(),
                        IsSelfPaid = c.Boolean(),
                        IsInvalid = c.Boolean(),
                        StatusId = c.Int(),
                        CreatedById = c.Int(),
                        UpdatedById = c.Int(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(),
                        Administration_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Administrations", t => t.AdministrationId)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Administrations", t => t.Administration_Id)
                .Index(t => t.UserId)
                .Index(t => t.AdministrationId)
                .Index(t => t.AddressId)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById)
                .Index(t => t.Administration_Id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AdministrationId = c.Int(nullable: false),
                        Position = c.String(),
                        IsLead = c.Boolean(nullable: false),
                        StatusId = c.Int(),
                        Administration_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Administrations", t => t.AdministrationId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Administrations", t => t.Administration_Id)
                .Index(t => t.UserId)
                .Index(t => t.AdministrationId)
                .Index(t => t.Administration_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        AddressId = c.Int(nullable: false),
                        Url = c.String(),
                        ContactId = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Logo = c.Binary(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedById = c.Int(),
                        UpdatedById = c.Int(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .Index(t => t.AddressId)
                .Index(t => t.ContactId)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        StatusId = c.Int(nullable: false),
                        ReviewedById = c.Int(),
                        CreatedById = c.Int(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        ReviewedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ReviewedById)
                .Index(t => t.ReviewedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedById = c.Int(),
                        UpdatedById = c.Int(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById);
            
            CreateTable(
                "dbo.ProductSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReturnRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkerPersonAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkerId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.WorkerId)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.VendorCategories",
                c => new
                    {
                        Vendor_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vendor_Id, t.Category_Id })
                .ForeignKey("dbo.Vendors", t => t.Vendor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Vendor_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkerPersonAssignments", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.WorkerPersonAssignments", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Products", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.Products", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Offers", "ReviewedById", "dbo.Users");
            DropForeignKey("dbo.Offers", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Vendors", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.Vendors", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Vendors", "ContactId", "dbo.Users");
            DropForeignKey("dbo.VendorCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.VendorCategories", "Vendor_Id", "dbo.Vendors");
            DropForeignKey("dbo.Vendors", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Workers", "Administration_Id", "dbo.Administrations");
            DropForeignKey("dbo.Workers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Workers", "AdministrationId", "dbo.Administrations");
            DropForeignKey("dbo.Administrations", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.Customers", "Administration_Id", "dbo.Administrations");
            DropForeignKey("dbo.Customers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Customers", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.Customers", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Customers", "AdministrationId", "dbo.Administrations");
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Administrations", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Administrations", "ContactId", "dbo.Users");
            DropForeignKey("dbo.Administrations", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.Addresses", "CreatedById", "dbo.Users");
            DropIndex("dbo.VendorCategories", new[] { "Category_Id" });
            DropIndex("dbo.VendorCategories", new[] { "Vendor_Id" });
            DropIndex("dbo.WorkerPersonAssignments", new[] { "Customer_Id" });
            DropIndex("dbo.WorkerPersonAssignments", new[] { "WorkerId" });
            DropIndex("dbo.Products", new[] { "UpdatedById" });
            DropIndex("dbo.Products", new[] { "CreatedById" });
            DropIndex("dbo.Offers", new[] { "CreatedById" });
            DropIndex("dbo.Offers", new[] { "ReviewedById" });
            DropIndex("dbo.Vendors", new[] { "UpdatedById" });
            DropIndex("dbo.Vendors", new[] { "CreatedById" });
            DropIndex("dbo.Vendors", new[] { "ContactId" });
            DropIndex("dbo.Vendors", new[] { "AddressId" });
            DropIndex("dbo.Workers", new[] { "Administration_Id" });
            DropIndex("dbo.Workers", new[] { "AdministrationId" });
            DropIndex("dbo.Workers", new[] { "UserId" });
            DropIndex("dbo.Customers", new[] { "Administration_Id" });
            DropIndex("dbo.Customers", new[] { "UpdatedById" });
            DropIndex("dbo.Customers", new[] { "CreatedById" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropIndex("dbo.Customers", new[] { "AdministrationId" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropIndex("dbo.Administrations", new[] { "UpdatedById" });
            DropIndex("dbo.Administrations", new[] { "CreatedById" });
            DropIndex("dbo.Administrations", new[] { "ContactId" });
            DropIndex("dbo.Administrations", new[] { "AddressId" });
            DropIndex("dbo.Addresses", new[] { "UpdatedById" });
            DropIndex("dbo.Addresses", new[] { "CreatedById" });
            DropTable("dbo.VendorCategories");
            DropTable("dbo.WorkerPersonAssignments");
            DropTable("dbo.ReturnRequests");
            DropTable("dbo.ProductSchedules");
            DropTable("dbo.Products");
            DropTable("dbo.Offers");
            DropTable("dbo.Vendors");
            DropTable("dbo.Categories");
            DropTable("dbo.Workers");
            DropTable("dbo.Customers");
            DropTable("dbo.Administrations");
            DropTable("dbo.Addresses");
        }
    }
}
