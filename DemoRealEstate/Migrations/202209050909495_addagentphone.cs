namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addagentphone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "AgentPhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "AgentPhoneNumber");
        }
    }
}
