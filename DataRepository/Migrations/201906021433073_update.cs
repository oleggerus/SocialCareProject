namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PersonRequests", name: "Category_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.PersonRequests", name: "IX_Category_Id", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PersonRequests", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.PersonRequests", name: "CategoryId", newName: "Category_Id");
        }
    }
}
