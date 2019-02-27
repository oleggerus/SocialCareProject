namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdddatetoPersonRequestEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonRequests", "CreatedOnUtc", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonRequests", "CreatedOnUtc");
        }
    }
}
