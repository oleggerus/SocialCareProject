namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddnametoPersonRequestEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonRequests", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonRequests", "Name");
        }
    }
}
