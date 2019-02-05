namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedunusedkeys2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkerPersonAssignments", "Customer_Id1", "dbo.Customers");
            DropIndex("dbo.WorkerPersonAssignments", new[] { "Customer_Id1" });
            DropColumn("dbo.WorkerPersonAssignments", "Customer_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkerPersonAssignments", "Customer_Id1", c => c.Int());
            CreateIndex("dbo.WorkerPersonAssignments", "Customer_Id1");
            AddForeignKey("dbo.WorkerPersonAssignments", "Customer_Id1", "dbo.Customers", "Id");
        }
    }
}
