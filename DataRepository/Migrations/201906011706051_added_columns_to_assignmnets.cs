namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_columns_to_assignmnets : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkerPersonAssignments", "ApprovedBy_Id", "dbo.Workers");
            DropIndex("dbo.WorkerPersonAssignments", new[] { "ApprovedBy_Id" });
            RenameColumn(table: "dbo.WorkerPersonAssignments", name: "Customer_Id", newName: "CustomerId");
            RenameColumn(table: "dbo.WorkerPersonAssignments", name: "Worker_Id", newName: "WorkerId");
            RenameIndex(table: "dbo.WorkerPersonAssignments", name: "IX_Worker_Id", newName: "IX_WorkerId");
            RenameIndex(table: "dbo.WorkerPersonAssignments", name: "IX_Customer_Id", newName: "IX_CustomerId");
            AddColumn("dbo.WorkerPersonAssignments", "ReviewedByUserId", c => c.Int(nullable: false));
            DropColumn("dbo.WorkerPersonAssignments", "ApprovedBy_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkerPersonAssignments", "ApprovedBy_Id", c => c.Int(nullable: false));
            DropColumn("dbo.WorkerPersonAssignments", "ReviewedByUserId");
            RenameIndex(table: "dbo.WorkerPersonAssignments", name: "IX_CustomerId", newName: "IX_Customer_Id");
            RenameIndex(table: "dbo.WorkerPersonAssignments", name: "IX_WorkerId", newName: "IX_Worker_Id");
            RenameColumn(table: "dbo.WorkerPersonAssignments", name: "WorkerId", newName: "Worker_Id");
            RenameColumn(table: "dbo.WorkerPersonAssignments", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.WorkerPersonAssignments", "ApprovedBy_Id");
            AddForeignKey("dbo.WorkerPersonAssignments", "ApprovedBy_Id", "dbo.Workers", "Id", cascadeDelete: true);
        }
    }
}
