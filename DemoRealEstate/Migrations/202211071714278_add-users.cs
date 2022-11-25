namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                  SET IDENTITY_INSERT [dbo].[Properties] ON
                 INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FullName], [Title]) VALUES (N'16796f93-4f48-4a52-acb2-9ceb0aac44b8', N'lungani@gmail.com', 0, N'AHSqQgBQof8uN3BhiSAeAdXZDNbELHKho+3NU7Zj29QLANfVnHxBGLCSj6sQvpsVNA==', N'eddb8363-50ad-425f-9072-3e3994dc1cfe', N'0885654333', 0, 0, NULL, 1, 0, N'lungani@gmail.com', N'Lungani buthelezi', N'Mr')
                 INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FullName], [Title]) VALUES (N'50017b7b-c757-4675-bfa4-336d55d75694', N'lunganintuthuko1@gmail.com', 1, N'AHs0wVVUY8se1OznQBWWVCor6DIBt7v7FPl4SOl5Vl174h5/QglyVQxPrdNDMLdWEw==', N'd8820f28-7222-46a8-a1ab-9cf66ee14a7a', N'082447475', 0, 0, NULL, 1, 0, N'lunganintuthuko1@gmail.com', N'Ntuthuko Bethelezi', N'Mr')
                 INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FullName], [Title]) VALUES (N'88ec3912-f4d6-4aef-afbe-8869b1c89d71', N'agent@agent', 0, N'ABqm4M8E306rqpmN9RexdU+k23cmryn1rN8WQb6SVrAmCHecJ8VW+3k6mYsliHTg5w==', N'7f5ca82c-a2e8-4193-8428-6fde0d50673b', NULL, 0, 0, NULL, 1, 0, N'agent@agent', N'', N'')

                 INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'16796f93-4f48-4a52-acb2-9ceb0aac44b8', N'1b0b2613-ccc6-49bc-a0ca-93ddd6e143a6')
                 INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'50017b7b-c757-4675-bfa4-336d55d75694', N'1b0b2613-ccc6-49bc-a0ca-93ddd6e143a6')
                 INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'88ec3912-f4d6-4aef-afbe-8869b1c89d71', N'a8739cb9-0dea-4b01-999d-d70abc8557a5')
                 SET IDENTITY_INSERT [dbo].[Properties] OFF
            ");
        }
        
        public override void Down()
        {
        }
    }
}
