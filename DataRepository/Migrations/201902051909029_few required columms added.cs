namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewrequiredcolummsadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Administrations", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Administrations", "Contact_Id", "dbo.Users");
            DropIndex("dbo.Administrations", new[] { "Address_Id" });
            DropIndex("dbo.Administrations", new[] { "Contact_Id" });
            AlterColumn("dbo.Addresses", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Administrations", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Administrations", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Administrations", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Administrations", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Administrations", "Address_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Administrations", "Contact_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Administrations", "Address_Id");
            CreateIndex("dbo.Administrations", "Contact_Id");
            AddForeignKey("dbo.Administrations", "Address_Id", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Administrations", "Contact_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Administrations", "Contact_Id", "dbo.Users");
            DropForeignKey("dbo.Administrations", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Administrations", new[] { "Contact_Id" });
            DropIndex("dbo.Administrations", new[] { "Address_Id" });
            AlterColumn("dbo.Administrations", "Contact_Id", c => c.Int());
            AlterColumn("dbo.Administrations", "Address_Id", c => c.Int());
            AlterColumn("dbo.Administrations", "Email", c => c.String());
            AlterColumn("dbo.Administrations", "Phone", c => c.String());
            AlterColumn("dbo.Administrations", "Description", c => c.String());
            AlterColumn("dbo.Administrations", "Name", c => c.String());
            AlterColumn("dbo.Addresses", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String());
            AlterColumn("dbo.Addresses", "Email", c => c.String());
            CreateIndex("dbo.Administrations", "Contact_Id");
            CreateIndex("dbo.Administrations", "Address_Id");
            AddForeignKey("dbo.Administrations", "Contact_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Administrations", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
