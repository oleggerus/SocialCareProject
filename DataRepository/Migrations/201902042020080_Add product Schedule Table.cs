namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddproductScheduleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSchedules", "IsRecurring", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductSchedules", "BasedOnWeek", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductSchedules", "NumberOfCycles", c => c.Int());
            AddColumn("dbo.ProductSchedules", "NumberOfWeeksForRepeating", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchedules", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductSchedules", "EndDate", c => c.DateTime());
            AddColumn("dbo.ProductSchedules", "AvailableOnMonday", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductSchedules", "AvailableOnTuesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductSchedules", "AvailableOnWednesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductSchedules", "AvailableOnThursday", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductSchedules", "AvailableOnFriday", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductSchedules", "AvailableOnSaturday", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductSchedules", "AvailableOnSunday", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductSchedules", "AvailableOnSunday");
            DropColumn("dbo.ProductSchedules", "AvailableOnSaturday");
            DropColumn("dbo.ProductSchedules", "AvailableOnFriday");
            DropColumn("dbo.ProductSchedules", "AvailableOnThursday");
            DropColumn("dbo.ProductSchedules", "AvailableOnWednesday");
            DropColumn("dbo.ProductSchedules", "AvailableOnTuesday");
            DropColumn("dbo.ProductSchedules", "AvailableOnMonday");
            DropColumn("dbo.ProductSchedules", "EndDate");
            DropColumn("dbo.ProductSchedules", "StartDate");
            DropColumn("dbo.ProductSchedules", "NumberOfWeeksForRepeating");
            DropColumn("dbo.ProductSchedules", "NumberOfCycles");
            DropColumn("dbo.ProductSchedules", "BasedOnWeek");
            DropColumn("dbo.ProductSchedules", "IsRecurring");
        }
    }
}
