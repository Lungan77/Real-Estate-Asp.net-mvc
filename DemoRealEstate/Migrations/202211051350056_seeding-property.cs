namespace DemoRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingproperty : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                  SET IDENTITY_INSERT [dbo].[Sellers] ON
                  INSERT INTO [dbo].[Sellers] ([Id], [Name], [Email], [AgentUserId]) VALUES (1, N'Lungani', N'triplessimphiweeh3@gmail.com', NULL)
                  INSERT INTO [dbo].[Sellers] ([Id], [Name], [Email], [AgentUserId]) VALUES (2, N'Test Seller', N'test@test', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71')
                  INSERT INTO [dbo].[Sellers] ([Id], [Name], [Email], [AgentUserId]) VALUES (3, N'Agent1 Seller', N'test@test', N'e1413146-1c2e-4be5-b097-212e91fb42d1')
                  INSERT INTO [dbo].[Sellers] ([Id], [Name], [Email], [AgentUserId]) VALUES (4, N'Ntuthuko', N'ntuthiko2@gmail.com', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71')
                  INSERT INTO [dbo].[Sellers] ([Id], [Name], [Email], [AgentUserId]) VALUES (5, N'Ntuthuko', N'ntuthiko2@gmail.com', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71')
                  INSERT INTO [dbo].[Sellers] ([Id], [Name], [Email], [AgentUserId]) VALUES (6, N'Nsindiso', N'nsindiso@gmail.com', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71')
                  INSERT INTO [dbo].[Sellers] ([Id], [Name], [Email], [AgentUserId]) VALUES (7, N'Sfiso', N'nsindiso@gmail.com', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71')
                  INSERT INTO [dbo].[Sellers] ([Id], [Name], [Email], [AgentUserId]) VALUES (8, N'Lungan', N'ntuthiko2@gmail.com', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71')
                  INSERT INTO [dbo].[Sellers] ([Id], [Name], [Email], [AgentUserId]) VALUES (9, N'Lucus', N'nsindiso@gmail.com', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71')
                  INSERT INTO [dbo].[Sellers] ([Id], [Name], [Email], [AgentUserId]) VALUES (10, N'Ngcebo', N'nsindiso@gmail.com', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71')
                  INSERT INTO [dbo].[Sellers] ([Id], [Name], [Email], [AgentUserId]) VALUES (11, N'Sesethu Mjoli', N'admin@admin', N'62b0b173-3329-4fb9-a3cd-5c13f5c11b6d')
                  INSERT INTO [dbo].[Sellers] ([Id], [Name], [Email], [AgentUserId]) VALUES (12, N'LUNGELO', N'lungani@gmail.com', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71')
                  SET IDENTITY_INSERT [dbo].[Sellers] OFF


                  SET IDENTITY_INSERT [dbo].[Properties] ON
                  INSERT INTO [dbo].[Properties] ([Id], [Price], [SellerId], [PropertyName], [PropertyType], [Province], [CityorSuburb], [postalCode], [Address], [AgentName], [AgentId], [PropertyInf], [Sold], [ImageURL], [ImageURL1], [ImageURL2], [ImageURL3], [AgentPhoneNumber], [Agent_share], [Balance]) VALUES (2, 400000, 1, N'3 badroom', N'apartment', N'KWAZULU NATAL', N'Durban', N'4000', N'81 street', N'King', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71', N'good property', 0, N'https://architecturebeast.com/wp-content/uploads/2014/08/Top_50_Modern_House_Designs_Ever_Built_featured_on_architecture_beast_06.jpg', N'https://oceanhomemag.wpenginepowered.com/wp-content/uploads/2020/02/burnham.jpg', N'https://oceanhomemag.wpenginepowered.com/wp-content/uploads/2020/02/brittocharette.jpg', N'https://oceanhomemag.wpenginepowered.com/wp-content/uploads/2020/02/bassman.jpg', N'08233981', 40000, 0)
                  INSERT INTO [dbo].[Properties] ([Id], [Price], [SellerId], [PropertyName], [PropertyType], [Province], [CityorSuburb], [postalCode], [Address], [AgentName], [AgentId], [PropertyInf], [Sold], [ImageURL], [ImageURL1], [ImageURL2], [ImageURL3], [AgentPhoneNumber], [Agent_share], [Balance]) VALUES (7, 40000, 4, N'king', N'House', N'WESTERN CAPE', N'CAPE TOWN', N'4001', N'81 street', N'Ntuthuko', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71', N'hhhhttt', 0, N'https://th.bing.com/th/id/R.24dad937e1e626cacf4f38abb4e2778d?rik=vyn%2bfHI%2fyeE6Qw&pid=ImgRaw&r=0', N'https://oceanhomemag.wpenginepowered.com/wp-content/uploads/2020/02/max-rindley-759x500.jpg', N'https://oceanhomemag.wpenginepowered.com/wp-content/uploads/2020/02/ariades.jpg', N'https://oceanhomemag.wpenginepowered.com/wp-content/uploads/2020/02/bang.jpg', N'072333462', 4000, 0)
                  INSERT INTO [dbo].[Properties] ([Id], [Price], [SellerId], [PropertyName], [PropertyType], [Province], [CityorSuburb], [postalCode], [Address], [AgentName], [AgentId], [PropertyInf], [Sold], [ImageURL], [ImageURL1], [ImageURL2], [ImageURL3], [AgentPhoneNumber], [Agent_share], [Balance]) VALUES (8, 40000, 2, N'king', N'3 bedroom', N'GAUTENG', N'Durban', N'4001', N'81 street', N'Ntuthuko', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71', N'include a pool', 0, N'https://www.technocrazed.com/wp-content/uploads/2015/12/Home-Wallpaper-30-640x360.jpg', NULL, NULL, NULL, N'082626252', 2332, 0)
                  INSERT INTO [dbo].[Properties] ([Id], [Price], [SellerId], [PropertyName], [PropertyType], [Province], [CityorSuburb], [postalCode], [Address], [AgentName], [AgentId], [PropertyInf], [Sold], [ImageURL], [ImageURL1], [ImageURL2], [ImageURL3], [AgentPhoneNumber], [Agent_share], [Balance]) VALUES (9, 40000, 2, N'3 badroom', N'Apartment', N'NORTH WEST', N'Durban', N'4001', N'81 street', N'Ntuthuko', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71', N'include a pool', 1, N'https://th.bing.com/th/id/R.24dad937e1e626cacf4f38abb4e2778d?rik=vyn%2bfHI%2fyeE6Qw&pid=ImgRaw&r=0', NULL, NULL, NULL, N'039777711', 2443, 0)
                  INSERT INTO [dbo].[Properties] ([Id], [Price], [SellerId], [PropertyName], [PropertyType], [Province], [CityorSuburb], [postalCode], [Address], [AgentName], [AgentId], [PropertyInf], [Sold], [ImageURL], [ImageURL1], [ImageURL2], [ImageURL3], [AgentPhoneNumber], [Agent_share], [Balance]) VALUES (10, 500000, 8, N'1 bedroom', N'house', N'EASTERN CAPE', N'Port elizabert', N'4001', N'81 street', N'Ntuthuko', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71', N'include a pool', 1, N'https://jooinn.com/images1280_/autumn-cottage.jpg', NULL, NULL, NULL, N'08276253', 50000, 0)
                  INSERT INTO [dbo].[Properties] ([Id], [Price], [SellerId], [PropertyName], [PropertyType], [Province], [CityorSuburb], [postalCode], [Address], [AgentName], [AgentId], [PropertyInf], [Sold], [ImageURL], [ImageURL1], [ImageURL2], [ImageURL3], [AgentPhoneNumber], [Agent_share], [Balance]) VALUES (11, 11000000, 8, N'4 bedroom', N'Apartment', N'WESTERN CAPE', N'Cape Town', N'4001', N'81 street', N'Ntuthuko', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71', N'include a pool', 1, N'https://jooinn.com/images1280_/autumn-cottage.jpg', N'https://jooinn.com/images1280_/autumn-cottage.jpg', NULL, NULL, N'08172653', 1100000, 0)
                  INSERT INTO [dbo].[Properties] ([Id], [Price], [SellerId], [PropertyName], [PropertyType], [Province], [CityorSuburb], [postalCode], [Address], [AgentName], [AgentId], [PropertyInf], [Sold], [ImageURL], [ImageURL1], [ImageURL2], [ImageURL3], [AgentPhoneNumber], [Agent_share], [Balance]) VALUES (34, 11000000, 9, N'2 bedroom', N'APARTMENT', N'NORTH WEST', N'Pretoria', N'4001', N'81 street', N'Ntuthuko', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71', N'include a pool', 0, N'https://www.architectureartdesigns.com/wp-content/uploads/2014/12/1457-630x472.jpg', N'https://www.architectureartdesigns.com/wp-content/uploads/2014/12/1457-630x472.jpg', N'https://www.architectureartdesigns.com/wp-content/uploads/2014/12/1457-630x472.jpg', N'https://www.architectureartdesigns.com/wp-content/uploads/2014/12/1457-630x472.jpg', N'08222000', 336, 0)
                  INSERT INTO [dbo].[Properties] ([Id], [Price], [SellerId], [PropertyName], [PropertyType], [Province], [CityorSuburb], [postalCode], [Address], [AgentName], [AgentId], [PropertyInf], [Sold], [ImageURL], [ImageURL1], [ImageURL2], [ImageURL3], [AgentPhoneNumber], [Agent_share], [Balance]) VALUES (36, 450000, 2, N'2 bedroom', N'APARTMENT', N'KWAZULU NATAL', N'DURBAN', N'4001', N'84 Gillespie street', N'Ntuthuko', N'88ec3912-f4d6-4aef-afbe-8869b1c89d71', N'new building', 0, N'https://architecturebeast.com/wp-content/uploads/2014/08/Top_50_Modern_House_Designs_Ever_Built_featured_on_architecture_beast_06.jpg', NULL, NULL, NULL, N'08222000', 0, 0)
                  SET IDENTITY_INSERT [dbo].[Properties] OFF
            ");
        }
        
        public override void Down()
        {
        }
    }
}
