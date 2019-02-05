namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefinedAllEntities1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkerPersonAssignments", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.WorkerPersonAssignments", "WorkerId", "dbo.Workers");
            AddColumn("dbo.WorkerPersonAssignments", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.WorkerPersonAssignments", "Worker_Id", c => c.Int());
            CreateIndex("dbo.WorkerPersonAssignments", "CustomerId");
            CreateIndex("dbo.WorkerPersonAssignments", "Worker_Id");
            AddForeignKey("dbo.WorkerPersonAssignments", "Worker_Id", "dbo.Workers", "Id");
            AddForeignKey("dbo.WorkerPersonAssignments", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.WorkerPersonAssignments", "CustomerId", "dbo.Customers", "Id");
            AddForeignKey("dbo.WorkerPersonAssignments", "WorkerId", "dbo.Workers", "Id");
            DropColumn("dbo.WorkerPersonAssignments", "PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkerPersonAssignments", "PersonId", c => c.Int(nullable: false));
            DropForeignKey("dbo.WorkerPersonAssignments", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.WorkerPersonAssignments", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.WorkerPersonAssignments", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.WorkerPersonAssignments", "Worker_Id", "dbo.Workers");
            DropIndex("dbo.WorkerPersonAssignments", new[] { "Worker_Id" });
            DropIndex("dbo.WorkerPersonAssignments", new[] { "CustomerId" });
            DropColumn("dbo.WorkerPersonAssignments", "Worker_Id");
            DropColumn("dbo.WorkerPersonAssignments", "CustomerId");
            AddForeignKey("dbo.WorkerPersonAssignments", "WorkerId", "dbo.Workers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkerPersonAssignments", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
