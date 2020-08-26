namespace HelpingHand.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProviderService", newName: "Service");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Service", newName: "ProviderService");
        }
    }
}
