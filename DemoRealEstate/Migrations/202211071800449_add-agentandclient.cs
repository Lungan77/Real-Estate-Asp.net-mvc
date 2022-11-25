namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addagentandclient : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                
                SET IDENTITY_INSERT [dbo].[Clients] ON
                INSERT INTO [dbo].[Clients] ([Id], [Name], [Surname], [Email], [User_Id], [Phone_number]) VALUES (1, N'No Client', NULL, N'', N'nouser', N'87')
                INSERT INTO [dbo].[Clients] ([Id], [Name], [Surname], [Email], [User_Id], [Phone_number]) VALUES (2, N'Lungani buthelezi', NULL, N'lungani@gmail.com', N'16796f93-4f48-4a52-acb2-9ceb0aac44b8', N'0885654333')
                INSERT INTO [dbo].[Clients] ([Id], [Name], [Surname], [Email], [User_Id], [Phone_number]) VALUES (3, N'Ntuthuko Bethelezi', NULL, N'lunganintuthuko1@gmail.com', N'50017b7b-c757-4675-bfa4-336d55d75694', N'082447475')
                SET IDENTITY_INSERT [dbo].[Clients] OFF

                SET IDENTITY_INSERT [dbo].[Agents] ON
                INSERT INTO [dbo].[Agents] ([Id], [Name], [Surname], [Email], [PhoneNumber], [UserId], [Agent_share]) VALUES (1, N'Ntuthuko', N'Buthelezi', N'ntuthiko2@gmail.com', N'08222000', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71', 10)
                SET IDENTITY_INSERT [dbo].[Agents] OFF

            ");
        }
        
        public override void Down()
        {
        }
    }
}
