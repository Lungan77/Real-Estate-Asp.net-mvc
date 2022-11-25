namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAgentUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyers", "AgentUserId", c => c.String());
            AddColumn("dbo.Sellers", "AgentUserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sellers", "AgentUserId");
            DropColumn("dbo.Buyers", "AgentUserId");
        }
    }
}
