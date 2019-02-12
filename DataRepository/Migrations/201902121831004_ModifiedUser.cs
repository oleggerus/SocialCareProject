namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Gender", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "IsMale");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsMale", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "Gender");
        }
    }
}
