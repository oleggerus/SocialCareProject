namespace DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedfewentities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
            AddColumn("dbo.Users", "Firstname", c => c.String(nullable: false));
            AddColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Users", "MiddleName", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "Username", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "NoAttempts", c => c.Int());
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Phone", c => c.String());
            AddColumn("dbo.Users", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "IsMale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Avatar", c => c.Binary());
            AddColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "CreatedById", c => c.Int());
            AddColumn("dbo.Users", "UpdatedById", c => c.Int());
            AddColumn("dbo.Users", "CreatedOnUtc", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "UpdatedOnUtc", c => c.DateTime());
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            DropColumn("dbo.Users", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Name", c => c.String());
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Permissions", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Permissions", new[] { "Role_Id" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropColumn("dbo.Users", "UpdatedOnUtc");
            DropColumn("dbo.Users", "CreatedOnUtc");
            DropColumn("dbo.Users", "UpdatedById");
            DropColumn("dbo.Users", "CreatedById");
            DropColumn("dbo.Users", "RoleId");
            DropColumn("dbo.Users", "Avatar");
            DropColumn("dbo.Users", "IsMale");
            DropColumn("dbo.Users", "DateOfBirth");
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "IsDeleted");
            DropColumn("dbo.Users", "IsActive");
            DropColumn("dbo.Users", "NoAttempts");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Username");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "MiddleName");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "Firstname");
            DropTable("dbo.Permissions");
            DropTable("dbo.Roles");
        }
    }
}
