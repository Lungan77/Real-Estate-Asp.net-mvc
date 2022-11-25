namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImageURLs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "ImageURL1", c => c.String());
            AddColumn("dbo.Properties", "ImageURL2", c => c.String());
            AddColumn("dbo.Properties", "ImageURL3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "ImageURL3");
            DropColumn("dbo.Properties", "ImageURL2");
            DropColumn("dbo.Properties", "ImageURL1");
        }
    }
}
