namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBuyer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Properties", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Properties", new[] { "User_Id" });
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
            DropColumn("dbo.Properties", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Properties", "User_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Buyers", "PropertyId", "dbo.Properties");
            DropIndex("dbo.Buyers", new[] { "PropertyId" });
            DropTable("dbo.Buyers");
            CreateIndex("dbo.Properties", "User_Id");
            AddForeignKey("dbo.Properties", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
