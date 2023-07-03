USE [master]
GO

IF DB_ID('EFCoreMasters.Session01') IS NOT NULL
   RETURN

-- Create Database
CREATE DATABASE [EFCoreMasters.Session01]
GO

USE [EFCoreMasters.Session01]
GO
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ShopId] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,

	[ReviewerName] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[NumberOfStars] [tinyint] NULL,

 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	
 CONSTRAINT [PK_Shop] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [Name], [ShopId]) VALUES (1, N'Mobile Phone', 1)
GO
INSERT [dbo].[Products] ([Id], [Name], [ShopId]) VALUES (2, N'Tablet', 1)
GO
INSERT [dbo].[Products] ([Id], [Name], [ShopId]) VALUES (3, N'Laptop', 2)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF

SET IDENTITY_INSERT [dbo].[Reviews] ON 
GO
INSERT [dbo].[Reviews] ([Id], [ProductId], [ReviewerName], [Comment], [NumberOfStars]) VALUES (1, 1, N'Jy', N'Nice', 5)
GO
INSERT [dbo].[Reviews] ([Id], [ProductId], [ReviewerName], [Comment], [NumberOfStars]) VALUES (2, 3, N'Fernandez', N'Good Job', 4)
GO
SET IDENTITY_INSERT [dbo].[Reviews] OFF

SET IDENTITY_INSERT [dbo].[Shops] ON 
GO
INSERT [dbo].[Shops] ([Id], [Name]) VALUES (1, N'Lazada')
GO
INSERT [dbo].[Shops] ([Id], [Name]) VALUES (2, N'Shoppee')
GO
SET IDENTITY_INSERT [dbo].[Shops] OFF

SET IDENTITY_INSERT [dbo].[Tags] ON 
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (1, N'Gadgets')
GO
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (2, N'Wires')
GO
SET IDENTITY_INSERT [dbo].[Tags] OFF

ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Shops_ShopId] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shops] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Shops_ShopId]
GO

ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Products_ProductId]
GO