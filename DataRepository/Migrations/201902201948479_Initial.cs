namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseNameRoomNumber = c.String(),
                        Street = c.String(),
                        Email = c.String(),
                        RegionId = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        ZipPostalCode = c.String(),
                        PhoneNumber = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(),
                        CreatedBy_Id = c.Int(),
                        UpdatedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Users", t => t.UpdatedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.UpdatedBy_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MiddleName = c.String(),
                        Email = c.String(nullable: false),
                        Username = c.String(),
                        Password = c.String(nullable: false),
                        PasswordSalt = c.String(nullable: false),
                        NoAttempts = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Phone = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        Avatar = c.Binary(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Administrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Url = c.String(),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Logo = c.Binary(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(),
                        Address_Id = c.Int(nullable: false),
                        Contact_Id = c.Int(),
                        CreatedBy_Id = c.Int(),
                        UpdatedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Contact_Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Users", t => t.UpdatedBy_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.Contact_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.UpdatedBy_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdministrationId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Info = c.String(),
                        IsSelfPaid = c.Boolean(nullable: false),
                        IsInvalid = c.Boolean(nullable: false),
                        StatusId = c.Int(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(),
                        CreatedBy_Id = c.Int(),
                        UpdatedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Users", t => t.UpdatedBy_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Administrations", t => t.AdministrationId)
                .Index(t => t.AdministrationId)
                .Index(t => t.AddressId)
                .Index(t => t.UserId)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.UpdatedBy_Id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PositionId = c.Int(nullable: false),
                        IsLead = c.Boolean(nullable: false),
                        StatusId = c.Int(),
                        User_Id = c.Int(nullable: false),
                        Administration_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Administrations", t => t.Administration_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Administration_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        IsNew = c.Boolean(nullable: false),
                        IsGift = c.Boolean(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Manufacturer = c.String(),
                        Price = c.Double(nullable: false),
                        PriceFrom = c.Double(nullable: false),
                        PriceTo = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Length = c.Double(nullable: false),
                        Width = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        ScheduleId = c.Int(),
                        StatusId = c.Int(nullable: false),
                        Picture = c.Binary(),
                        CategoryId = c.Int(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.CreatedById)
                .ForeignKey("dbo.ProductSchedules", t => t.ScheduleId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.ScheduleId)
                .Index(t => t.CategoryId)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(),
                        PositionId = c.Int(),
                        UserId = c.Int(nullable: false),
                        VendorId = c.Int(),
                        Address_Id = c.Int(),
                        CreatedBy_Id = c.Int(),
                        UpdatedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Users", t => t.UpdatedBy_Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Vendors", t => t.VendorId)
                .Index(t => t.UserId)
                .Index(t => t.VendorId)
                .Index(t => t.Address_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.UpdatedBy_Id);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Url = c.String(),
                        Phone = c.String(),
                        Email = c.String(nullable: false),
                        Logo = c.Binary(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(),
                        Address_Id = c.Int(nullable: false),
                        Contact_Id = c.Int(),
                        CreatedBy_Id = c.Int(),
                        UpdatedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .ForeignKey("dbo.Providers", t => t.Contact_Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Users", t => t.UpdatedBy_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.Contact_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.UpdatedBy_Id);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedById = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        ReviewedOnUtc = c.DateTime(),
                        Customer_Id = c.Int(nullable: false),
                        ReviewedBy_Id = c.Int(),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.CreatedById, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ReviewedBy_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.CreatedById)
                .Index(t => t.Customer_Id)
                .Index(t => t.ReviewedBy_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.ProductSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsRecurring = c.Boolean(nullable: false),
                        BasedOnWeek = c.Boolean(nullable: false),
                        NumberOfCycles = c.Int(),
                        NumberOfWeeksForRepeating = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        AvailableOnMonday = c.Boolean(nullable: false),
                        AvailableOnTuesday = c.Boolean(nullable: false),
                        AvailableOnWednesday = c.Boolean(nullable: false),
                        AvailableOnFriday = c.Boolean(nullable: false),
                        AvailableOnSaturday = c.Boolean(nullable: false),
                        AvailableOnSunday = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        StatusId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CreatedById)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CreatedById)
                .Index(t => t.CustomerId)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.ReturnRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedById = c.Int(nullable: false),
                        Reason = c.String(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        Offer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById, cascadeDelete: true)
                .ForeignKey("dbo.Offers", t => t.Offer_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.Offer_Id);
            
            CreateTable(
                "dbo.WorkerPersonAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        AssignmentStatusId = c.Int(nullable: false),
                        ApprovedBy_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                        Worker_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.ApprovedBy_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .Index(t => t.ApprovedBy_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Worker_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkerPersonAssignments", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.WorkerPersonAssignments", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.WorkerPersonAssignments", "ApprovedBy_Id", "dbo.Workers");
            DropForeignKey("dbo.ReturnRequests", "Offer_Id", "dbo.Offers");
            DropForeignKey("dbo.ReturnRequests", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.PersonRequests", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PersonRequests", "CreatedById", "dbo.Customers");
            DropForeignKey("dbo.PersonRequests", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "ScheduleId", "dbo.ProductSchedules");
            DropForeignKey("dbo.Offers", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Offers", "ReviewedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Offers", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Offers", "CreatedById", "dbo.Providers");
            DropForeignKey("dbo.Products", "CreatedById", "dbo.Providers");
            DropForeignKey("dbo.Vendors", "UpdatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Providers", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Vendors", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Vendors", "Contact_Id", "dbo.Providers");
            DropForeignKey("dbo.Vendors", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Providers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Providers", "UpdatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Providers", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Providers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Workers", "Administration_Id", "dbo.Administrations");
            DropForeignKey("dbo.Workers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Administrations", "UpdatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Customers", "AdministrationId", "dbo.Administrations");
            DropForeignKey("dbo.Customers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Customers", "UpdatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Customers", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Administrations", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Administrations", "Contact_Id", "dbo.Users");
            DropForeignKey("dbo.Administrations", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "UpdatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Addresses", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Permissions", "Role_Id", "dbo.Roles");
            DropIndex("dbo.WorkerPersonAssignments", new[] { "Worker_Id" });
            DropIndex("dbo.WorkerPersonAssignments", new[] { "Customer_Id" });
            DropIndex("dbo.WorkerPersonAssignments", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.ReturnRequests", new[] { "Offer_Id" });
            DropIndex("dbo.ReturnRequests", new[] { "CreatedById" });
            DropIndex("dbo.PersonRequests", new[] { "Category_Id" });
            DropIndex("dbo.PersonRequests", new[] { "CustomerId" });
            DropIndex("dbo.PersonRequests", new[] { "CreatedById" });
            DropIndex("dbo.Offers", new[] { "Product_Id" });
            DropIndex("dbo.Offers", new[] { "ReviewedBy_Id" });
            DropIndex("dbo.Offers", new[] { "Customer_Id" });
            DropIndex("dbo.Offers", new[] { "CreatedById" });
            DropIndex("dbo.Vendors", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.Vendors", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Vendors", new[] { "Contact_Id" });
            DropIndex("dbo.Vendors", new[] { "Address_Id" });
            DropIndex("dbo.Providers", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.Providers", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Providers", new[] { "Address_Id" });
            DropIndex("dbo.Providers", new[] { "VendorId" });
            DropIndex("dbo.Providers", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "CreatedById" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "ScheduleId" });
            DropIndex("dbo.Workers", new[] { "Administration_Id" });
            DropIndex("dbo.Workers", new[] { "User_Id" });
            DropIndex("dbo.Customers", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.Customers", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropIndex("dbo.Customers", new[] { "AdministrationId" });
            DropIndex("dbo.Administrations", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.Administrations", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Administrations", new[] { "Contact_Id" });
            DropIndex("dbo.Administrations", new[] { "Address_Id" });
            DropIndex("dbo.Permissions", new[] { "Role_Id" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Addresses", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.Addresses", new[] { "CreatedBy_Id" });
            DropTable("dbo.WorkerPersonAssignments");
            DropTable("dbo.ReturnRequests");
            DropTable("dbo.PersonRequests");
            DropTable("dbo.ProductSchedules");
            DropTable("dbo.Offers");
            DropTable("dbo.Vendors");
            DropTable("dbo.Providers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Workers");
            DropTable("dbo.Customers");
            DropTable("dbo.Administrations");
            DropTable("dbo.Permissions");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Addresses");
        }
    }
}
