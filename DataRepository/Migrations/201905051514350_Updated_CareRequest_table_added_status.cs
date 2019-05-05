namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_CareRequest_table_added_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CareRequests", "StatusId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CareRequests", "StatusId");
        }
    }
}
