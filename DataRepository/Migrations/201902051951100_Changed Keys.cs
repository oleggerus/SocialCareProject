namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedKeys : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Offers", name: "CreatedBy_Id", newName: "CreatedById");
            RenameColumn(table: "dbo.ReturnRequests", name: "CreatedBy_Id", newName: "CreatedById");
            RenameIndex(table: "dbo.Offers", name: "IX_CreatedBy_Id", newName: "IX_CreatedById");
            RenameIndex(table: "dbo.ReturnRequests", name: "IX_CreatedBy_Id", newName: "IX_CreatedById");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ReturnRequests", name: "IX_CreatedById", newName: "IX_CreatedBy_Id");
            RenameIndex(table: "dbo.Offers", name: "IX_CreatedById", newName: "IX_CreatedBy_Id");
            RenameColumn(table: "dbo.ReturnRequests", name: "CreatedById", newName: "CreatedBy_Id");
            RenameColumn(table: "dbo.Offers", name: "CreatedById", newName: "CreatedBy_Id");
        }
    }
}
