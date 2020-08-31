namespace HelpingHand.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateServicesTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Service", "ID", c => c.Guid(nullable: false));
            AddColumn("dbo.Service", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Service", "Category");
            DropColumn("dbo.Service", "ID");
        }
    }
}
