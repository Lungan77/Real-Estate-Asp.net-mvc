namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addphone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Phone_number", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Phone_number");
        }
    }
}
