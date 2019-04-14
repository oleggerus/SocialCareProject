namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCareRequsttable2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CareRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reason = c.String(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CareRequests", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CareRequests", new[] { "CustomerId" });
            DropTable("dbo.CareRequests");
        }
    }
}
