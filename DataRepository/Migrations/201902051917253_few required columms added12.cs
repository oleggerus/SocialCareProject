namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewrequiredcolummsadded12 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "Administration_Id", newName: "AdministrationId");
            RenameIndex(table: "dbo.Customers", name: "IX_Administration_Id", newName: "IX_AdministrationId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Customers", name: "IX_AdministrationId", newName: "IX_Administration_Id");
            RenameColumn(table: "dbo.Customers", name: "AdministrationId", newName: "Administration_Id");
        }
    }
}
