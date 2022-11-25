namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addagentshare : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agents", "Agent_share", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agents", "Agent_share");
        }
    }
}
