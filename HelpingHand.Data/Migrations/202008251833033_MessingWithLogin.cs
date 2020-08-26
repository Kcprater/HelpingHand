namespace HelpingHand.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessingWithLogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "UserType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "UserType");
        }
    }
}
