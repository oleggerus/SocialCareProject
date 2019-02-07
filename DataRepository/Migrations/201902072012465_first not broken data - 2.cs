namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstnotbrokendata2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vendors", "Contact_Id", "dbo.Providers");
            DropIndex("dbo.Vendors", new[] { "Contact_Id" });
            AddColumn("dbo.Providers", "PositionId", c => c.Int());
            AlterColumn("dbo.Vendors", "Contact_Id", c => c.Int());
            CreateIndex("dbo.Vendors", "Contact_Id");
            AddForeignKey("dbo.Vendors", "Contact_Id", "dbo.Providers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendors", "Contact_Id", "dbo.Providers");
            DropIndex("dbo.Vendors", new[] { "Contact_Id" });
            AlterColumn("dbo.Vendors", "Contact_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Providers", "PositionId");
            CreateIndex("dbo.Vendors", "Contact_Id");
            AddForeignKey("dbo.Vendors", "Contact_Id", "dbo.Providers", "Id", cascadeDelete: true);
        }
    }
}
