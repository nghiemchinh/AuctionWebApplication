USE [DBAuction]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/11/2023 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 8/11/2023 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 8/11/2023 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 8/11/2023 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 8/11/2023 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 8/11/2023 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 8/11/2023 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 8/11/2023 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Auction]    Script Date: 8/11/2023 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auction](
	[auction_id] [int] IDENTITY(1,1) NOT NULL,
	[seller_id] [nvarchar](450) NOT NULL,
	[auction_name] [varchar](50) NOT NULL,
	[auction_desription] [text] NULL,
	[start_price] [decimal](12, 2) NOT NULL,
	[end_time] [datetime] NOT NULL,
	[Image] [varchar](100) NULL,
	[CategoryId] [nvarchar](450) NULL,
	[bid_id] [int] NULL,
 CONSTRAINT [PK_Auction] PRIMARY KEY CLUSTERED 
(
	[auction_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuctionsComments]    Script Date: 8/11/2023 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuctionsComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[CommentOn] [datetime2](7) NULL,
	[AuctionId] [int] NULL,
	[Rating] [int] NULL,
 CONSTRAINT [PK_AuctionsComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bid]    Script Date: 8/11/2023 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bid](
	[bid_id] [int] IDENTITY(1,1) NOT NULL,
	[auction_id] [int] NOT NULL,
	[bidder_id] [nvarchar](450) NOT NULL,
	[price] [decimal](12, 2) NOT NULL,
	[bid_time] [datetime] NOT NULL,
 CONSTRAINT [PK_Bid] PRIMARY KEY CLUSTERED 
(
	[bid_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 8/11/2023 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SoldItem]    Script Date: 8/11/2023 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoldItem](
	[auction_id] [int] NOT NULL,
	[final_price] [decimal](12, 2) NULL,
	[bidder_id] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_SoldItem] PRIMARY KEY CLUSTERED 
(
	[auction_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/11/2023 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [nvarchar](450) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[balance] [decimal](12, 2) NOT NULL,
	[freeze] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230801133011_identity', N'7.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230801133026_iniasdsad', N'7.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230803122344_updaterating', N'7.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230803124459_updaterating1', N'7.0.5')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'483230cd-b262-44f1-9e69-267966b707b3', N'block', N'BLOCK', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'683cc625-4efe-4671-bd4b-3f989e22b705', N'user', N'USER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'71f50d8b-8f6d-4bba-a129-026cc85f45c0', N'admin', N'ADMIN', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'Admin01', N'71f50d8b-8f6d-4bba-a129-026cc85f45c0')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'63645296-7926-4567-89eb-f0b46e7d87dd', N'Tom@gmail.com', N'TOM@GMAIL.COM', N'Tom@gmail.com', N'TOM@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAELrLlqflnCX4TfW9WRTSfUIIuJVhOHyYV8O5Vri/HkWAsuKCRguKUBC5Mp8QI70pHg==', N'ZWFMMBIJ4DKTQTDH234NPDFT2BVQN7W7', N'ef7443b3-e4ce-42ae-a175-da4dfd9dd084', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7c9dade8-06a7-47f7-8599-0eed1165e4ef', N'jack@gmail.com', N'JACK@GMAIL.COM', N'jack@gmail.com', N'JACK@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEOPJklPJD80YSUwy6B7OABIa7lR0oLFi3vofJ2fkOl69LCZlEhUldhgLUQYgK9hgHw==', N'NQ2JJ6OBRN5RIYJ43HNMVPERWQIY5LYP', N'ce94b2fd-d9b3-448a-ae4d-e1fc9e7d0443', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'Admin01', N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEBrwKOSUHwq35l4lScimv3LRm7CoB5QEtmqvEVdWrsZytsDl3DgiYG51z3oIM2M3dQ==', N'EYID4TJ575D7SZVUJJP7LHKINMIQXX3W', N'73b9d6cc-5ae7-4444-b49d-51f0870e1910', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Auction] ON 

INSERT [dbo].[Auction] ([auction_id], [seller_id], [auction_name], [auction_desription], [start_price], [end_time], [Image], [CategoryId], [bid_id]) VALUES (3, N'Admin01', N'dinner table', N'Compact and easy-to-assemble dining table suitable for all families', CAST(100.00 AS Decimal(12, 2)), CAST(N'2023-11-30T19:39:00.000' AS DateTime), N'update/OIP (2).jpg', N'interior', NULL)
INSERT [dbo].[Auction] ([auction_id], [seller_id], [auction_name], [auction_desription], [start_price], [end_time], [Image], [CategoryId], [bid_id]) VALUES (4, N'Admin01', N'leather car interior', N'N?i th?t da ô tô giúp ô tô tr? nên sáng d?p, sang tr?ng', CAST(1000.00 AS Decimal(12, 2)), CAST(N'2024-01-10T19:56:00.000' AS DateTime), N'update/download.jpg', N'car interior', NULL)
INSERT [dbo].[Auction] ([auction_id], [seller_id], [auction_name], [auction_desription], [start_price], [end_time], [Image], [CategoryId], [bid_id]) VALUES (5, N'Admin01', N'clock', N'beautiful, luxurious watches', CAST(1000.00 AS Decimal(12, 2)), CAST(N'2024-01-10T20:03:00.000' AS DateTime), N'update/RE-AV0B03B00B-000 (1).jpg', N'clock', NULL)
INSERT [dbo].[Auction] ([auction_id], [seller_id], [auction_name], [auction_desription], [start_price], [end_time], [Image], [CategoryId], [bid_id]) VALUES (6, N'Admin01', N'electronic', N'Beautiful, luxurious headphones for all ages', CAST(100.00 AS Decimal(12, 2)), CAST(N'2024-01-10T20:09:00.000' AS DateTime), N'update/pngtree-earphone-electronics-accessories-transparent-png-image_6687265.png', N'electronic accessories', NULL)
INSERT [dbo].[Auction] ([auction_id], [seller_id], [auction_name], [auction_desription], [start_price], [end_time], [Image], [CategoryId], [bid_id]) VALUES (7, N'Admin01', N'chair', N'Luxurious chairs made of high quality wood', CAST(100.00 AS Decimal(12, 2)), CAST(N'2024-01-10T20:17:00.000' AS DateTime), N'update/OIP (6).jpg', N'interior', NULL)
INSERT [dbo].[Auction] ([auction_id], [seller_id], [auction_name], [auction_desription], [start_price], [end_time], [Image], [CategoryId], [bid_id]) VALUES (8, N'Admin01', N'Headphone box', N'Headphone case helps carry large headphones', CAST(80.00 AS Decimal(12, 2)), CAST(N'2024-01-10T20:23:00.000' AS DateTime), N'update/1677df58f245296c1711fb67d74864af.jpg', N'electronic accessories', NULL)
INSERT [dbo].[Auction] ([auction_id], [seller_id], [auction_name], [auction_desription], [start_price], [end_time], [Image], [CategoryId], [bid_id]) VALUES (9, N'Admin01', N'Taplo car phone holder', N'Beautiful luxury car taplo phone holder', CAST(160.00 AS Decimal(12, 2)), CAST(N'2024-01-10T20:35:00.000' AS DateTime), N'update/gia-do-dien-thoai-o-to-mau-120-1.jpg', N'car interior', NULL)
INSERT [dbo].[Auction] ([auction_id], [seller_id], [auction_name], [auction_desription], [start_price], [end_time], [Image], [CategoryId], [bid_id]) VALUES (10, N'Admin01', N'wall clock ', N'wall clock compact and elegant', CAST(140.00 AS Decimal(12, 2)), CAST(N'2024-01-10T20:39:00.000' AS DateTime), N'update/Dong-ho-treo-tuong-thong-minh-Citizen-1024x1024.jpg', N'clock', NULL)
INSERT [dbo].[Auction] ([auction_id], [seller_id], [auction_name], [auction_desription], [start_price], [end_time], [Image], [CategoryId], [bid_id]) VALUES (11, N'Admin01', N'dinner table', N'Beautiful elegant compact dining table', CAST(1000.00 AS Decimal(12, 2)), CAST(N'2024-01-10T20:47:00.000' AS DateTime), N'update/mot-so-mau-ban-an-cao-cap-tai-vuong-quoc-noi-that-ban-chay (2).jpg', N'interior', NULL)
INSERT [dbo].[Auction] ([auction_id], [seller_id], [auction_name], [auction_desription], [start_price], [end_time], [Image], [CategoryId], [bid_id]) VALUES (12, N'Admin01', N'dinner table', N'Beautiful elegant compact dining table', CAST(1000.00 AS Decimal(12, 2)), CAST(N'2023-08-10T21:47:00.000' AS DateTime), N'update/download (1).jpg', N'interior', NULL)
INSERT [dbo].[Auction] ([auction_id], [seller_id], [auction_name], [auction_desription], [start_price], [end_time], [Image], [CategoryId], [bid_id]) VALUES (13, N'Admin01', N'clock', N'clockwatcher style is young, beautiful and luxurious', CAST(1650.00 AS Decimal(12, 2)), CAST(N'2023-08-10T21:40:00.000' AS DateTime), N'update/download (2).jpg', N'clock', NULL)
SET IDENTITY_INSERT [dbo].[Auction] OFF
GO
INSERT [dbo].[Categories] ([CategoryId]) VALUES (N'car interior')
INSERT [dbo].[Categories] ([CategoryId]) VALUES (N'clock')
INSERT [dbo].[Categories] ([CategoryId]) VALUES (N'electronic accessories')
INSERT [dbo].[Categories] ([CategoryId]) VALUES (N'interior')
GO
INSERT [dbo].[SoldItem] ([auction_id], [final_price], [bidder_id]) VALUES (12, CAST(1100.00 AS Decimal(12, 2)), N'63645296-7926-4567-89eb-f0b46e7d87dd')
INSERT [dbo].[SoldItem] ([auction_id], [final_price], [bidder_id]) VALUES (13, CAST(2000.00 AS Decimal(12, 2)), N'7c9dade8-06a7-47f7-8599-0eed1165e4ef')
GO
INSERT [dbo].[User] ([user_id], [name], [balance], [freeze]) VALUES (N'63645296-7926-4567-89eb-f0b46e7d87dd', N'Tom', CAST(8900.00 AS Decimal(12, 2)), CAST(0.00 AS Decimal(12, 2)))
INSERT [dbo].[User] ([user_id], [name], [balance], [freeze]) VALUES (N'7c9dade8-06a7-47f7-8599-0eed1165e4ef', N'Jack', CAST(8000.00 AS Decimal(12, 2)), CAST(0.00 AS Decimal(12, 2)))
INSERT [dbo].[User] ([user_id], [name], [balance], [freeze]) VALUES (N'Admin01', N'Admin', CAST(103100.00 AS Decimal(12, 2)), CAST(0.00 AS Decimal(12, 2)))
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Auction]  WITH CHECK ADD  CONSTRAINT [FK_Auction_Bid] FOREIGN KEY([bid_id])
REFERENCES [dbo].[Bid] ([bid_id])
GO
ALTER TABLE [dbo].[Auction] CHECK CONSTRAINT [FK_Auction_Bid]
GO
ALTER TABLE [dbo].[Auction]  WITH CHECK ADD  CONSTRAINT [FK_Auction_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Auction] CHECK CONSTRAINT [FK_Auction_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Auction]  WITH CHECK ADD  CONSTRAINT [FK_Auction_User] FOREIGN KEY([seller_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Auction] CHECK CONSTRAINT [FK_Auction_User]
GO
ALTER TABLE [dbo].[AuctionsComments]  WITH CHECK ADD  CONSTRAINT [FK_AuctionsComments_Auction_AuctionId] FOREIGN KEY([AuctionId])
REFERENCES [dbo].[Auction] ([auction_id])
GO
ALTER TABLE [dbo].[AuctionsComments] CHECK CONSTRAINT [FK_AuctionsComments_Auction_AuctionId]
GO
ALTER TABLE [dbo].[Bid]  WITH CHECK ADD  CONSTRAINT [FK_Bid_User] FOREIGN KEY([bidder_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Bid] CHECK CONSTRAINT [FK_Bid_User]
GO
ALTER TABLE [dbo].[SoldItem]  WITH CHECK ADD  CONSTRAINT [FK_SoldItem_Auction] FOREIGN KEY([auction_id])
REFERENCES [dbo].[Auction] ([auction_id])
GO
ALTER TABLE [dbo].[SoldItem] CHECK CONSTRAINT [FK_SoldItem_Auction]
GO
ALTER TABLE [dbo].[SoldItem]  WITH CHECK ADD  CONSTRAINT [FK_SoldItem_User] FOREIGN KEY([bidder_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[SoldItem] CHECK CONSTRAINT [FK_SoldItem_User]
GO
