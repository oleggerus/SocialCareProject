namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstdatainizialization2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            AddForeignKey("dbo.Users", "Role_Id", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            AddForeignKey("dbo.Users", "Role_Id", "dbo.Roles", "Id", cascadeDelete: true);
        }
    }
}
