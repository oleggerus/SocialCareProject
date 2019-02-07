namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstnotbrokendata : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "StatusId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "StatusId", c => c.Int(nullable: false));
        }
    }
}
