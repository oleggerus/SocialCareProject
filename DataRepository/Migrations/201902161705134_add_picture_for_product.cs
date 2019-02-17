namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_picture_for_product : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Products", name: "CreatedBy_Id", newName: "CreatedById");
            RenameIndex(table: "dbo.Products", name: "IX_Category_Id", newName: "IX_CategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_CreatedBy_Id", newName: "IX_CreatedById");
            AddColumn("dbo.Products", "Picture", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Picture");
            RenameIndex(table: "dbo.Products", name: "IX_CreatedById", newName: "IX_CreatedBy_Id");
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Products", name: "CreatedById", newName: "CreatedBy_Id");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_Id");
        }
    }
}
