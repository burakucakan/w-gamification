USE [wanda_wsrvlocator]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

SET IDENTITY_INSERT [dbo].[WebServices] ON
INSERT [dbo].[WebServices] ([Id], [Naming], [ConfigName], [ServiceUrl], [PlatformType], [CreatedAt], [ModifiedAt]) VALUES (1, N'wsVeriIslemeIzni', N'PermissionServiceSTB', N'', 1, CAST(0x0000A229011C0AC4 AS DateTime), NULL)
INSERT [dbo].[WebServices] ([Id], [Naming], [ConfigName], [ServiceUrl], [PlatformType], [CreatedAt], [ModifiedAt]) VALUES (2, N'wsVeriIslemeIzni', N'PermissionServiceSTB', N'http://extstable2.sd.turkcell.com.tr/ccrl/ws/permissionWs', 2, CAST(0x0000A229011C0AC4 AS DateTime), NULL)
INSERT [dbo].[WebServices] ([Id], [Naming], [ConfigName], [ServiceUrl], [PlatformType], [CreatedAt], [ModifiedAt]) VALUES (3, N'wsVeriIslemeIzni', N'PermissionServicePRP', N'http://extprpws.turkcell.com.tr/ccrl/ws/permissionWs', 3, CAST(0x0000A229011C0AC4 AS DateTime), NULL)
INSERT [dbo].[WebServices] ([Id], [Naming], [ConfigName], [ServiceUrl], [PlatformType], [CreatedAt], [ModifiedAt]) VALUES (4, N'wsVeriIslemeIzni', N'PermissionServiceProd', N'http://extraflats10.turkcell.com.tr/ccrl/ws/permissionWs', 4, CAST(0x0000A229011C0AC4 AS DateTime), NULL)

INSERT [dbo].[WebServices] ([Id], [Naming], [ConfigName], [ServiceUrl], [PlatformType], [CreatedAt], [ModifiedAt]) VALUES (5, N'wsPennaSmsGonder', N'PennaSmsService', N'', 1, CAST(0x0000A229011C0AC4 AS DateTime), NULL)
INSERT [dbo].[WebServices] ([Id], [Naming], [ConfigName], [ServiceUrl], [PlatformType], [CreatedAt], [ModifiedAt]) VALUES (6, N'wsPennaSmsGonder', N'PennaSmsService', N'', 2, CAST(0x0000A229011C0AC4 AS DateTime), NULL)
INSERT [dbo].[WebServices] ([Id], [Naming], [ConfigName], [ServiceUrl], [PlatformType], [CreatedAt], [ModifiedAt]) VALUES (7, N'wsPennaSmsGonder', N'PennaSmsService', N'', 3, CAST(0x0000A229011C0AC4 AS DateTime), NULL)
INSERT [dbo].[WebServices] ([Id], [Naming], [ConfigName], [ServiceUrl], [PlatformType], [CreatedAt], [ModifiedAt]) VALUES (8, N'wsPennaSmsGonder', N'PennaSmsService', N'', 4, CAST(0x0000A229011C0AC4 AS DateTime), NULL)

INSERT [dbo].[WebServices] ([Id], [Naming], [ConfigName], [ServiceUrl], [PlatformType], [CreatedAt], [ModifiedAt]) VALUES (9, N'wsClubMembershipSearch', N'ToskaClubMembershipBulkStable', N'http://extstablews.sd.turkcell.com.tr:80/webServices/toskaClubMembershipSearchOperationsWs', 1, CAST(0x0000A229011C0AC4 AS DateTime), NULL)
INSERT [dbo].[WebServices] ([Id], [Naming], [ConfigName], [ServiceUrl], [PlatformType], [CreatedAt], [ModifiedAt]) VALUES (10, N'wsClubMembershipSearch', N'ToskaClubMembershipBulkStable', N'http://extstablews.sd.turkcell.com.tr:80/webServices/toskaClubMembershipSearchOperationsWs', 2, CAST(0x0000A229011C0AC4 AS DateTime), NULL)
INSERT [dbo].[WebServices] ([Id], [Naming], [ConfigName], [ServiceUrl], [PlatformType], [CreatedAt], [ModifiedAt]) VALUES (11, N'wsClubMembershipSearch', N'ToskaClubMembershipBulkPRP', N'', 3, CAST(0x0000A229011C0AC4 AS DateTime), NULL)
INSERT [dbo].[WebServices] ([Id], [Naming], [ConfigName], [ServiceUrl], [PlatformType], [CreatedAt], [ModifiedAt]) VALUES (12, N'wsClubMembershipSearch', N'ToskaClubMembershipBulkProd', N'', 4, CAST(0x0000A229011C0AC4 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[WebServices] OFF

SET IDENTITY_INSERT [dbo].[QDBOfferList] ON
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (1, N'601515014', N'gsmNar150heryone', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (2, N'601090014', N'gsmNar100turkcell', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (3, N'602945080', N'gsmNar100heryone', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (4, N'602965084', N'gsmhaftadk', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (5, N'602970202', N'gsmBenyaptim400dk', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (6, N'602950049', N'gsmBenyaptim500dk', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (7, N'602955443', N'gsmBenyaptim700dk', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (8, N'602945269', N'gsmBenyaptim1500smshy', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (9, N'602945271', N'gsmBenyaptimsmstcl', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (10, N'602945270', N'gsmBenyaptimdata500', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (11, N'602955240', N'gsmBanauyan', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (12, N'602955345', N'gsmGecesms', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (13, N'602955258', N'gsmAskpaketi', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (14, N'602945320', N'gsmSupersms', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (15, N'602955468', N'gsmHeryöne5000sms', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (16, N'601855014', N'gsmFacepaketi', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (17, N'602955204', N'gsmTwitterpaketi', 1, CAST(0x0000A229011C0AC4 AS DateTime))
INSERT [dbo].[QDBOfferList] ([Id], [OfferId], [OfferUniqueName], [FilterStatus], [CreatedAt]) VALUES (18, N'602955359', N'gsmSosyalmedyapaketi', 1, CAST(0x0000A229011C0AC4 AS DateTime))
SET IDENTITY_INSERT [dbo].[QDBOfferList] OFF