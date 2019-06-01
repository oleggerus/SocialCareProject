namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagetype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ImageMimeType");
        }
    }
}
