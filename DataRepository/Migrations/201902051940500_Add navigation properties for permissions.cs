namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addnavigationpropertiesforpermissions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Permissions", "Role_Id", c => c.Int());
            CreateIndex("dbo.Permissions", "Role_Id");
            AddForeignKey("dbo.Permissions", "Role_Id", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permissions", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Permissions", new[] { "Role_Id" });
            DropColumn("dbo.Permissions", "Role_Id");
        }
    }
}
