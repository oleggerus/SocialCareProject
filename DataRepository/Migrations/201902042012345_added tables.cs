namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        StatusId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonRequests", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.PersonRequests", "Category_Id", "dbo.Categories");
            DropIndex("dbo.PersonRequests", new[] { "Customer_Id" });
            DropIndex("dbo.PersonRequests", new[] { "Category_Id" });
            DropTable("dbo.PersonRequests");
        }
    }
}
