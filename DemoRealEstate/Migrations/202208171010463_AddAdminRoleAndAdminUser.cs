namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminRoleAndAdminUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                    INSERT INTO[dbo].[AspNetRoles]([Id], [Name]) VALUES(N'1395cd40-6d80-4718-8ca5-a4213f36a447', N'Admin')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a8739cb9-0dea-4b01-999d-d70abc8557a5', N'Agent')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1b0b2613-ccc6-49bc-a0ca-93ddd6e143a6', N'Client') 

                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e4e4de79-1e30-4ec8-bf5f-df401e27b52c', N'admin1@example.com', 0, N'APgobxrIis8lm2sMoCzLQ+61F2sFwV+X2tijw9j52aQPT/VZFWdY5+HQLc1fxh/Afg==', N'73633567-fd5e-421f-a002-d3c241e73e62', NULL, 0, 0, NULL, 1, 0, N'admin1@example.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c1d13212-9d5b-4097-ab2f-1cf610ec8069', N'admin@admin', 0, N'APgobxrIis8lm2sMoCzLQ+61F2sFwV+X2tijw9j52aQPT/VZFWdY5+HQLc1fxh/Afg==', N'a7234546-e330-4b0c-994e-239a27c113df', NULL, 0, 0, NULL, 1, 0, N'admin@admin')
            
            ");

        }
        
        public override void Down()
        {
        }
    }
}
