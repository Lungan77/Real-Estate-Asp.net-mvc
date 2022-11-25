namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClientId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "ClientId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "ClientId");
        }
    }
}
