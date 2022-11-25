namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addval : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requests", "Message", c => c.String(nullable: false));
            AlterColumn("dbo.Requests", "From", c => c.String(nullable: false));
            AlterColumn("dbo.Requests", "To", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Requests", "To", c => c.String());
            AlterColumn("dbo.Requests", "From", c => c.String());
            AlterColumn("dbo.Requests", "Message", c => c.String());
        }
    }
}
