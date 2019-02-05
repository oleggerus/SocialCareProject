namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedunusedkeys3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Administration_Id", "dbo.Administrations");
            DropIndex("dbo.Customers", new[] { "Administration_Id" });
            DropColumn("dbo.Customers", "Administration_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Administration_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Administration_Id");
            AddForeignKey("dbo.Customers", "Administration_Id", "dbo.Administrations", "Id");
        }
    }
}
