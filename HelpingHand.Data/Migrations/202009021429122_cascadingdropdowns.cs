namespace HelpingHand.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadingdropdowns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Service", "Subcategory", c => c.String(nullable: false));
            AlterColumn("dbo.Service", "Category", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Service", "Category", c => c.Int(nullable: false));
            DropColumn("dbo.Service", "Subcategory");
        }
    }
}
