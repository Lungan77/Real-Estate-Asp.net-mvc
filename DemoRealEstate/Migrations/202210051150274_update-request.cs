namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updaterequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "From", c => c.String());
            AddColumn("dbo.Requests", "To", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "To");
            DropColumn("dbo.Requests", "From");
        }
    }
}
