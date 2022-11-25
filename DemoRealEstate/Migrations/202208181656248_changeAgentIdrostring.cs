namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeAgentIdrostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Properties", "AgentId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Properties", "AgentId", c => c.Int(nullable: false));
        }
    }
}
