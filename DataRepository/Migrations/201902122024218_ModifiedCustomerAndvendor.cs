namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedCustomerAndvendor : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "Role_Id", newName: "RoleId");
            RenameColumn(table: "dbo.Customers", name: "Address_Id", newName: "AddressId");
            RenameColumn(table: "dbo.Customers", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Providers", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Providers", name: "Vendor_Id", newName: "VendorId");
            RenameIndex(table: "dbo.Users", name: "IX_Role_Id", newName: "IX_RoleId");
            RenameIndex(table: "dbo.Customers", name: "IX_Address_Id", newName: "IX_AddressId");
            RenameIndex(table: "dbo.Customers", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.Providers", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.Providers", name: "IX_Vendor_Id", newName: "IX_VendorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Providers", name: "IX_VendorId", newName: "IX_Vendor_Id");
            RenameIndex(table: "dbo.Providers", name: "IX_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Customers", name: "IX_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Customers", name: "IX_AddressId", newName: "IX_Address_Id");
            RenameIndex(table: "dbo.Users", name: "IX_RoleId", newName: "IX_Role_Id");
            RenameColumn(table: "dbo.Providers", name: "VendorId", newName: "Vendor_Id");
            RenameColumn(table: "dbo.Providers", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Customers", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Customers", name: "AddressId", newName: "Address_Id");
            RenameColumn(table: "dbo.Users", name: "RoleId", newName: "Role_Id");
        }
    }
}
