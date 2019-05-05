namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_CareRequest_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CareRequests", "Answer", c => c.String());
            AddColumn("dbo.CareRequests", "ReviewedById", c => c.Int());
            AddColumn("dbo.CareRequests", "ReviewedOn", c => c.DateTime());
            CreateIndex("dbo.CareRequests", "ReviewedById");
            AddForeignKey("dbo.CareRequests", "ReviewedById", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CareRequests", "ReviewedById", "dbo.Customers");
            DropIndex("dbo.CareRequests", new[] { "ReviewedById" });
            DropColumn("dbo.CareRequests", "ReviewedOn");
            DropColumn("dbo.CareRequests", "ReviewedById");
            DropColumn("dbo.CareRequests", "Answer");
        }
    }
}
