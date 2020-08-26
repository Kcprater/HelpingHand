namespace HelpingHand.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "Name_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ApplicationUser", "Name_Id");
            AddForeignKey("dbo.ApplicationUser", "Name_Id", "dbo.IdentityRole", "Id");
            DropColumn("dbo.ApplicationUser", "UserType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "UserType", c => c.String());
            DropForeignKey("dbo.ApplicationUser", "Name_Id", "dbo.IdentityRole");
            DropIndex("dbo.ApplicationUser", new[] { "Name_Id" });
            DropColumn("dbo.ApplicationUser", "Name_Id");
        }
    }
}
