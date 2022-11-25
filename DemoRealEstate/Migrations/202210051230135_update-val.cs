namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateval : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requests", "From", c => c.String());
            AlterColumn("dbo.Requests", "To", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Requests", "To", c => c.String(nullable: false));
            AlterColumn("dbo.Requests", "From", c => c.String(nullable: false));
        }
    }
}
