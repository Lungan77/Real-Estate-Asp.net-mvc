namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removesurname : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buyers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Buyers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Sellers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Sellers", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Buyers", "Surname");
            DropColumn("dbo.Sellers", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sellers", "Surname", c => c.String());
            AddColumn("dbo.Buyers", "Surname", c => c.String());
            AlterColumn("dbo.Sellers", "Email", c => c.String());
            AlterColumn("dbo.Sellers", "Name", c => c.String());
            AlterColumn("dbo.Buyers", "Email", c => c.String());
            AlterColumn("dbo.Buyers", "Name", c => c.String());
        }
    }
}
