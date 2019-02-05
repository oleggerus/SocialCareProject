namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedunusedkeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Administrations", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Administrations", "ContactId", "dbo.Users");
            DropForeignKey("dbo.Workers", "Administration_Id", "dbo.Administrations");
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.WorkerPersonAssignments", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "UserId", "dbo.Users");
            DropForeignKey("dbo.WorkerPersonAssignments", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.Workers", "UserId", "dbo.Users");
            DropForeignKey("dbo.PersonRequests", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Vendors", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Vendors", "ContactId", "dbo.Users");
            DropForeignKey("dbo.Offers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ReturnRequests", "OfferId", "dbo.Offers");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Administrations", new[] { "AddressId" });
            DropIndex("dbo.Administrations", new[] { "ContactId" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropIndex("dbo.WorkerPersonAssignments", new[] { "WorkerId" });
            DropIndex("dbo.WorkerPersonAssignments", new[] { "CustomerId" });
            DropIndex("dbo.WorkerPersonAssignments", new[] { "Worker_Id" });
            DropIndex("dbo.WorkerPersonAssignments", new[] { "Customer_Id" });
            DropIndex("dbo.Workers", new[] { "UserId" });
            DropIndex("dbo.Workers", new[] { "AdministrationId" });
            DropIndex("dbo.Workers", new[] { "Administration_Id" });
            DropIndex("dbo.PersonRequests", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Vendors", new[] { "AddressId" });
            DropIndex("dbo.Vendors", new[] { "ContactId" });
            DropIndex("dbo.Offers", new[] { "CustomerId" });
            DropIndex("dbo.ReturnRequests", new[] { "OfferId" });
            DropColumn("dbo.WorkerPersonAssignments", "Customer_Id");
            DropColumn("dbo.WorkerPersonAssignments", "Worker_Id");
            DropColumn("dbo.Workers", "Administration_Id");
            RenameColumn(table: "dbo.Addresses", name: "CreatedById", newName: "CreatedBy_Id");
            RenameColumn(table: "dbo.Addresses", name: "UpdatedById", newName: "UpdatedBy_Id");
            RenameColumn(table: "dbo.Users", name: "RoleId", newName: "Role_Id");
            RenameColumn(table: "dbo.Administrations", name: "AddressId", newName: "Address_Id");
            RenameColumn(table: "dbo.Administrations", name: "ContactId", newName: "Contact_Id");
            RenameColumn(table: "dbo.Administrations", name: "CreatedById", newName: "CreatedBy_Id");
            RenameColumn(table: "dbo.Administrations", name: "UpdatedById", newName: "UpdatedBy_Id");
            RenameColumn(table: "dbo.Customers", name: "AddressId", newName: "Address_Id");
            RenameColumn(table: "dbo.Customers", name: "CreatedById", newName: "CreatedBy_Id");
            RenameColumn(table: "dbo.Customers", name: "UpdatedById", newName: "UpdatedBy_Id");
            RenameColumn(table: "dbo.Customers", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.WorkerPersonAssignments", name: "CustomerId", newName: "Customer_Id");
            RenameColumn(table: "dbo.WorkerPersonAssignments", name: "WorkerId", newName: "Worker_Id");
            RenameColumn(table: "dbo.Workers", name: "AdministrationId", newName: "Administration_Id");
            RenameColumn(table: "dbo.Workers", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.PersonRequests", name: "CategoryId", newName: "Category_Id");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_Id");
            RenameColumn(table: "dbo.Products", name: "CreatedById", newName: "CreatedBy_Id");
            RenameColumn(table: "dbo.Vendors", name: "AddressId", newName: "Address_Id");
            RenameColumn(table: "dbo.Vendors", name: "ContactId", newName: "Contact_Id");
            RenameColumn(table: "dbo.Vendors", name: "CreatedById", newName: "CreatedBy_Id");
            RenameColumn(table: "dbo.Vendors", name: "UpdatedById", newName: "UpdatedBy_Id");
            RenameColumn(table: "dbo.Offers", name: "CreatedById", newName: "CreatedBy_Id");
            RenameColumn(table: "dbo.Offers", name: "CustomerId", newName: "Customer_Id");
            RenameColumn(table: "dbo.Offers", name: "ProductId", newName: "Product_Id");
            RenameColumn(table: "dbo.Offers", name: "ReviewedById", newName: "ReviewedBy_Id");
            RenameColumn(table: "dbo.Providers", name: "AddressId", newName: "Address_Id");
            RenameColumn(table: "dbo.Providers", name: "CreatedById", newName: "CreatedBy_Id");
            RenameColumn(table: "dbo.Providers", name: "UpdatedById", newName: "UpdatedBy_Id");
            RenameColumn(table: "dbo.Providers", name: "VendorId", newName: "Vendor_Id");
            RenameColumn(table: "dbo.ReturnRequests", name: "CreatedById", newName: "CreatedBy_Id");
            RenameColumn(table: "dbo.ReturnRequests", name: "OfferId", newName: "Offer_Id");
            RenameIndex(table: "dbo.Addresses", name: "IX_CreatedById", newName: "IX_CreatedBy_Id");
            RenameIndex(table: "dbo.Addresses", name: "IX_UpdatedById", newName: "IX_UpdatedBy_Id");
            RenameIndex(table: "dbo.Administrations", name: "IX_CreatedById", newName: "IX_CreatedBy_Id");
            RenameIndex(table: "dbo.Administrations", name: "IX_UpdatedById", newName: "IX_UpdatedBy_Id");
            RenameIndex(table: "dbo.Customers", name: "IX_CreatedById", newName: "IX_CreatedBy_Id");
            RenameIndex(table: "dbo.Customers", name: "IX_UpdatedById", newName: "IX_UpdatedBy_Id");
            RenameIndex(table: "dbo.Products", name: "IX_CreatedById", newName: "IX_CreatedBy_Id");
            RenameIndex(table: "dbo.Vendors", name: "IX_CreatedById", newName: "IX_CreatedBy_Id");
            RenameIndex(table: "dbo.Vendors", name: "IX_UpdatedById", newName: "IX_UpdatedBy_Id");
            RenameIndex(table: "dbo.Offers", name: "IX_CreatedById", newName: "IX_CreatedBy_Id");
            RenameIndex(table: "dbo.Offers", name: "IX_ProductId", newName: "IX_Product_Id");
            RenameIndex(table: "dbo.Offers", name: "IX_ReviewedById", newName: "IX_ReviewedBy_Id");
            RenameIndex(table: "dbo.Providers", name: "IX_AddressId", newName: "IX_Address_Id");
            RenameIndex(table: "dbo.Providers", name: "IX_CreatedById", newName: "IX_CreatedBy_Id");
            RenameIndex(table: "dbo.Providers", name: "IX_UpdatedById", newName: "IX_UpdatedBy_Id");
            RenameIndex(table: "dbo.Providers", name: "IX_VendorId", newName: "IX_Vendor_Id");
            RenameIndex(table: "dbo.ReturnRequests", name: "IX_CreatedById", newName: "IX_CreatedBy_Id");
            AddColumn("dbo.WorkerPersonAssignments", "StatusId", c => c.Int(nullable: false));
            AddColumn("dbo.WorkerPersonAssignments", "Administration_Id", c => c.Int());
            AddColumn("dbo.WorkerPersonAssignments", "ApprovedBy_Id", c => c.Int());
            AddColumn("dbo.WorkerPersonAssignments", "Customer_Id1", c => c.Int());
            AddColumn("dbo.Workers", "PositionId", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "Administration_Id1", c => c.Int());
            AddColumn("dbo.Providers", "UserId_Id", c => c.Int());
            AlterColumn("dbo.Users", "Role_Id", c => c.Int());
            AlterColumn("dbo.Administrations", "Address_Id", c => c.Int());
            AlterColumn("dbo.Administrations", "Contact_Id", c => c.Int());
            AlterColumn("dbo.Customers", "User_Id", c => c.Int());
            AlterColumn("dbo.Customers", "Address_Id", c => c.Int());
            AlterColumn("dbo.WorkerPersonAssignments", "Worker_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.WorkerPersonAssignments", "Customer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Workers", "User_Id", c => c.Int());
            AlterColumn("dbo.Workers", "Administration_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.PersonRequests", "Category_Id", c => c.Int());
            AlterColumn("dbo.Products", "Category_Id", c => c.Int());
            AlterColumn("dbo.Vendors", "Address_Id", c => c.Int());
            AlterColumn("dbo.Vendors", "Contact_Id", c => c.Int());
            AlterColumn("dbo.Offers", "Customer_Id", c => c.Int());
            AlterColumn("dbo.ReturnRequests", "Offer_Id", c => c.Int());
            CreateIndex("dbo.Users", "Role_Id");
            CreateIndex("dbo.Administrations", "Address_Id");
            CreateIndex("dbo.Administrations", "Contact_Id");
            CreateIndex("dbo.Customers", "Address_Id");
            CreateIndex("dbo.Customers", "User_Id");
            CreateIndex("dbo.WorkerPersonAssignments", "Administration_Id");
            CreateIndex("dbo.WorkerPersonAssignments", "ApprovedBy_Id");
            CreateIndex("dbo.WorkerPersonAssignments", "Customer_Id");
            CreateIndex("dbo.WorkerPersonAssignments", "Worker_Id");
            CreateIndex("dbo.WorkerPersonAssignments", "Customer_Id1");
            CreateIndex("dbo.Workers", "Administration_Id");
            CreateIndex("dbo.Workers", "User_Id");
            CreateIndex("dbo.Workers", "Administration_Id1");
            CreateIndex("dbo.PersonRequests", "Category_Id");
            CreateIndex("dbo.Products", "Category_Id");
            CreateIndex("dbo.Vendors", "Address_Id");
            CreateIndex("dbo.Vendors", "Contact_Id");
            CreateIndex("dbo.Offers", "Customer_Id");
            CreateIndex("dbo.Providers", "UserId_Id");
            CreateIndex("dbo.ReturnRequests", "Offer_Id");
            AddForeignKey("dbo.WorkerPersonAssignments", "Administration_Id", "dbo.Administrations", "Id");
            AddForeignKey("dbo.Providers", "UserId_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Role_Id", "dbo.Roles", "Id");
            AddForeignKey("dbo.Administrations", "Address_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Administrations", "Contact_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Workers", "Administration_Id1", "dbo.Administrations", "Id");
            AddForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.WorkerPersonAssignments", "Customer_Id1", "dbo.Customers", "Id");
            AddForeignKey("dbo.Customers", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.WorkerPersonAssignments", "ApprovedBy_Id", "dbo.Workers", "Id");
            AddForeignKey("dbo.Workers", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.PersonRequests", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Vendors", "Address_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Vendors", "Contact_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Offers", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.ReturnRequests", "Offer_Id", "dbo.Offers", "Id");
            DropColumn("dbo.Users", "CreatedById");
            DropColumn("dbo.Users", "UpdatedById");
            DropColumn("dbo.Workers", "Position");
            DropColumn("dbo.Providers", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Providers", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "Position", c => c.String());
            AddColumn("dbo.Users", "UpdatedById", c => c.Int());
            AddColumn("dbo.Users", "CreatedById", c => c.Int());
            DropForeignKey("dbo.ReturnRequests", "Offer_Id", "dbo.Offers");
            DropForeignKey("dbo.Offers", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Vendors", "Contact_Id", "dbo.Users");
            DropForeignKey("dbo.Vendors", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.PersonRequests", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Workers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.WorkerPersonAssignments", "ApprovedBy_Id", "dbo.Workers");
            DropForeignKey("dbo.Customers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.WorkerPersonAssignments", "Customer_Id1", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Workers", "Administration_Id1", "dbo.Administrations");
            DropForeignKey("dbo.Administrations", "Contact_Id", "dbo.Users");
            DropForeignKey("dbo.Administrations", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Providers", "UserId_Id", "dbo.Users");
            DropForeignKey("dbo.WorkerPersonAssignments", "Administration_Id", "dbo.Administrations");
            DropIndex("dbo.ReturnRequests", new[] { "Offer_Id" });
            DropIndex("dbo.Providers", new[] { "UserId_Id" });
            DropIndex("dbo.Offers", new[] { "Customer_Id" });
            DropIndex("dbo.Vendors", new[] { "Contact_Id" });
            DropIndex("dbo.Vendors", new[] { "Address_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.PersonRequests", new[] { "Category_Id" });
            DropIndex("dbo.Workers", new[] { "Administration_Id1" });
            DropIndex("dbo.Workers", new[] { "User_Id" });
            DropIndex("dbo.Workers", new[] { "Administration_Id" });
            DropIndex("dbo.WorkerPersonAssignments", new[] { "Customer_Id1" });
            DropIndex("dbo.WorkerPersonAssignments", new[] { "Worker_Id" });
            DropIndex("dbo.WorkerPersonAssignments", new[] { "Customer_Id" });
            DropIndex("dbo.WorkerPersonAssignments", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.WorkerPersonAssignments", new[] { "Administration_Id" });
            DropIndex("dbo.Customers", new[] { "User_Id" });
            DropIndex("dbo.Customers", new[] { "Address_Id" });
            DropIndex("dbo.Administrations", new[] { "Contact_Id" });
            DropIndex("dbo.Administrations", new[] { "Address_Id" });
            DropIndex("dbo.Users", new[] { "Role_Id" });
            AlterColumn("dbo.ReturnRequests", "Offer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Offers", "Customer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Vendors", "Contact_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Vendors", "Address_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Category_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.PersonRequests", "Category_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Workers", "Administration_Id", c => c.Int());
            AlterColumn("dbo.Workers", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.WorkerPersonAssignments", "Customer_Id", c => c.Int());
            AlterColumn("dbo.WorkerPersonAssignments", "Worker_Id", c => c.Int());
            AlterColumn("dbo.Customers", "Address_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Administrations", "Contact_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Administrations", "Address_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Role_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Providers", "UserId_Id");
            DropColumn("dbo.Workers", "Administration_Id1");
            DropColumn("dbo.Workers", "PositionId");
            DropColumn("dbo.WorkerPersonAssignments", "Customer_Id1");
            DropColumn("dbo.WorkerPersonAssignments", "ApprovedBy_Id");
            DropColumn("dbo.WorkerPersonAssignments", "Administration_Id");
            DropColumn("dbo.WorkerPersonAssignments", "StatusId");
            RenameIndex(table: "dbo.ReturnRequests", name: "IX_CreatedBy_Id", newName: "IX_CreatedById");
            RenameIndex(table: "dbo.Providers", name: "IX_Vendor_Id", newName: "IX_VendorId");
            RenameIndex(table: "dbo.Providers", name: "IX_UpdatedBy_Id", newName: "IX_UpdatedById");
            RenameIndex(table: "dbo.Providers", name: "IX_CreatedBy_Id", newName: "IX_CreatedById");
            RenameIndex(table: "dbo.Providers", name: "IX_Address_Id", newName: "IX_AddressId");
            RenameIndex(table: "dbo.Offers", name: "IX_ReviewedBy_Id", newName: "IX_ReviewedById");
            RenameIndex(table: "dbo.Offers", name: "IX_Product_Id", newName: "IX_ProductId");
            RenameIndex(table: "dbo.Offers", name: "IX_CreatedBy_Id", newName: "IX_CreatedById");
            RenameIndex(table: "dbo.Vendors", name: "IX_UpdatedBy_Id", newName: "IX_UpdatedById");
            RenameIndex(table: "dbo.Vendors", name: "IX_CreatedBy_Id", newName: "IX_CreatedById");
            RenameIndex(table: "dbo.Products", name: "IX_CreatedBy_Id", newName: "IX_CreatedById");
            RenameIndex(table: "dbo.Customers", name: "IX_UpdatedBy_Id", newName: "IX_UpdatedById");
            RenameIndex(table: "dbo.Customers", name: "IX_CreatedBy_Id", newName: "IX_CreatedById");
            RenameIndex(table: "dbo.Administrations", name: "IX_UpdatedBy_Id", newName: "IX_UpdatedById");
            RenameIndex(table: "dbo.Administrations", name: "IX_CreatedBy_Id", newName: "IX_CreatedById");
            RenameIndex(table: "dbo.Addresses", name: "IX_UpdatedBy_Id", newName: "IX_UpdatedById");
            RenameIndex(table: "dbo.Addresses", name: "IX_CreatedBy_Id", newName: "IX_CreatedById");
            RenameColumn(table: "dbo.ReturnRequests", name: "Offer_Id", newName: "OfferId");
            RenameColumn(table: "dbo.ReturnRequests", name: "CreatedBy_Id", newName: "CreatedById");
            RenameColumn(table: "dbo.Providers", name: "Vendor_Id", newName: "VendorId");
            RenameColumn(table: "dbo.Providers", name: "UpdatedBy_Id", newName: "UpdatedById");
            RenameColumn(table: "dbo.Providers", name: "CreatedBy_Id", newName: "CreatedById");
            RenameColumn(table: "dbo.Providers", name: "Address_Id", newName: "AddressId");
            RenameColumn(table: "dbo.Offers", name: "ReviewedBy_Id", newName: "ReviewedById");
            RenameColumn(table: "dbo.Offers", name: "Product_Id", newName: "ProductId");
            RenameColumn(table: "dbo.Offers", name: "Customer_Id", newName: "CustomerId");
            RenameColumn(table: "dbo.Offers", name: "CreatedBy_Id", newName: "CreatedById");
            RenameColumn(table: "dbo.Vendors", name: "UpdatedBy_Id", newName: "UpdatedById");
            RenameColumn(table: "dbo.Vendors", name: "CreatedBy_Id", newName: "CreatedById");
            RenameColumn(table: "dbo.Vendors", name: "Contact_Id", newName: "ContactId");
            RenameColumn(table: "dbo.Vendors", name: "Address_Id", newName: "AddressId");
            RenameColumn(table: "dbo.Products", name: "CreatedBy_Id", newName: "CreatedById");
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.PersonRequests", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Workers", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Workers", name: "Administration_Id", newName: "AdministrationId");
            RenameColumn(table: "dbo.WorkerPersonAssignments", name: "Worker_Id", newName: "WorkerId");
            RenameColumn(table: "dbo.WorkerPersonAssignments", name: "Customer_Id", newName: "CustomerId");
            RenameColumn(table: "dbo.Customers", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Customers", name: "UpdatedBy_Id", newName: "UpdatedById");
            RenameColumn(table: "dbo.Customers", name: "CreatedBy_Id", newName: "CreatedById");
            RenameColumn(table: "dbo.Customers", name: "Address_Id", newName: "AddressId");
            RenameColumn(table: "dbo.Administrations", name: "UpdatedBy_Id", newName: "UpdatedById");
            RenameColumn(table: "dbo.Administrations", name: "CreatedBy_Id", newName: "CreatedById");
            RenameColumn(table: "dbo.Administrations", name: "Contact_Id", newName: "ContactId");
            RenameColumn(table: "dbo.Administrations", name: "Address_Id", newName: "AddressId");
            RenameColumn(table: "dbo.Users", name: "Role_Id", newName: "RoleId");
            RenameColumn(table: "dbo.Addresses", name: "UpdatedBy_Id", newName: "UpdatedById");
            RenameColumn(table: "dbo.Addresses", name: "CreatedBy_Id", newName: "CreatedById");
            AddColumn("dbo.Workers", "Administration_Id", c => c.Int());
            AddColumn("dbo.WorkerPersonAssignments", "Worker_Id", c => c.Int());
            AddColumn("dbo.WorkerPersonAssignments", "Customer_Id", c => c.Int());
            CreateIndex("dbo.ReturnRequests", "OfferId");
            CreateIndex("dbo.Offers", "CustomerId");
            CreateIndex("dbo.Vendors", "ContactId");
            CreateIndex("dbo.Vendors", "AddressId");
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.PersonRequests", "CategoryId");
            CreateIndex("dbo.Workers", "Administration_Id");
            CreateIndex("dbo.Workers", "AdministrationId");
            CreateIndex("dbo.Workers", "UserId");
            CreateIndex("dbo.WorkerPersonAssignments", "Customer_Id");
            CreateIndex("dbo.WorkerPersonAssignments", "Worker_Id");
            CreateIndex("dbo.WorkerPersonAssignments", "CustomerId");
            CreateIndex("dbo.WorkerPersonAssignments", "WorkerId");
            CreateIndex("dbo.Customers", "AddressId");
            CreateIndex("dbo.Customers", "UserId");
            CreateIndex("dbo.Administrations", "ContactId");
            CreateIndex("dbo.Administrations", "AddressId");
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.ReturnRequests", "OfferId", "dbo.Offers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Offers", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vendors", "ContactId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vendors", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonRequests", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Workers", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkerPersonAssignments", "Worker_Id", "dbo.Workers", "Id");
            AddForeignKey("dbo.Customers", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkerPersonAssignments", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Customers", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Workers", "Administration_Id", "dbo.Administrations", "Id");
            AddForeignKey("dbo.Administrations", "ContactId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Administrations", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
    }
}