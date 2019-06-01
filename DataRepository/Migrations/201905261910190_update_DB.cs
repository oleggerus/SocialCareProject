namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_DB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSchedules", "AvailableOnThursday", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductSchedules", "AvailableOnThursday");
        }
    }
}
