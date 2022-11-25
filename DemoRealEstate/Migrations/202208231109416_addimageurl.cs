namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimageurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "ImageURL");
        }
    }
}
