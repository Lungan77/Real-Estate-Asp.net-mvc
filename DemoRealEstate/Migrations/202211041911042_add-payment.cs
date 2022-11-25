namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Payments", "ClientId", "dbo.Clients");
            DropIndex("dbo.Payments", new[] { "ClientId" });
            DropIndex("dbo.Payments", new[] { "PropertyId" });
            DropTable("dbo.Payments");
        }
    }
}
