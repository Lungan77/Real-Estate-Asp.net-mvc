namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addshareR : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "Agent_share", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "Agent_share");
        }
    }
}
