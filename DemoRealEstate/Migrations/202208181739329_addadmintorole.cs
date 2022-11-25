namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addadmintorole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c1d13212-9d5b-4097-ab2f-1cf610ec8069', N'1395cd40-6d80-4718-8ca5-a4213f36a447')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e4e4de79-1e30-4ec8-bf5f-df401e27b52c', N'1395cd40-6d80-4718-8ca5-a4213f36a447')

             ");
        }
        
        public override void Down()
        {
        }
    }
}
