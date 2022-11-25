namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModels1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyers", "Surname", c => c.String());
            AddColumn("dbo.Properties", "PropertyName", c => c.String());
            AddColumn("dbo.Properties", "PropertyType", c => c.String());
            AddColumn("dbo.Properties", "Province", c => c.String());
            AddColumn("dbo.Properties", "CityorSuburb", c => c.String());
            AddColumn("dbo.Properties", "postalCode", c => c.String());
            AddColumn("dbo.Properties", "Address", c => c.String());
            AddColumn("dbo.Properties", "AgentName", c => c.String());
            AddColumn("dbo.Properties", "AgentId", c => c.String(nullable: false));
            AddColumn("dbo.Properties", "PropertyInf", c => c.String());
            AddColumn("dbo.Properties", "Sold", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sellers", "Surname", c => c.String());
            DropColumn("dbo.Properties", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Properties", "Name", c => c.String());
            DropColumn("dbo.Sellers", "Surname");
            DropColumn("dbo.Properties", "Sold");
            DropColumn("dbo.Properties", "PropertyInf");
            DropColumn("dbo.Properties", "AgentId");
            DropColumn("dbo.Properties", "AgentName");
            DropColumn("dbo.Properties", "Address");
            DropColumn("dbo.Properties", "postalCode");
            DropColumn("dbo.Properties", "CityorSuburb");
            DropColumn("dbo.Properties", "Province");
            DropColumn("dbo.Properties", "PropertyType");
            DropColumn("dbo.Properties", "PropertyName");
            DropColumn("dbo.Buyers", "Surname");
        }
    }
}
