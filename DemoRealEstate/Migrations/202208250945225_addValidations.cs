namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Properties", "PropertyName", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "PropertyType", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "Province", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "CityorSuburb", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "PostalCode", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Properties", "Address", c => c.String());
            AlterColumn("dbo.Properties", "PostalCode", c => c.String());
            AlterColumn("dbo.Properties", "CityorSuburb", c => c.String());
            AlterColumn("dbo.Properties", "Province", c => c.String());
            AlterColumn("dbo.Properties", "PropertyType", c => c.String());
            AlterColumn("dbo.Properties", "PropertyName", c => c.String());
        }
    }
}
