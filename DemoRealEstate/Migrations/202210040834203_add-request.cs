namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Message = c.String(),
                        User_id = c.String(),
                        AgentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agents", t => t.AgentId, cascadeDelete: true)
                .Index(t => t.AgentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "AgentId", "dbo.Agents");
            DropIndex("dbo.Requests", new[] { "AgentId" });
            DropTable("dbo.Requests");
        }
    }
}
