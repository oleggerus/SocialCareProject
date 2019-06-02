namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_notifications_date : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "CreatedOnUtc", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "CreatedOnUtc");
        }
    }
}
