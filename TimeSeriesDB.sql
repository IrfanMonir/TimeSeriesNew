USE [TimeSeriesNewDB]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 8/6/21 02:24:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buildings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
 CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataFields]    Script Date: 8/6/21 02:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataFields](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_DataFields] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Objects]    Script Date: 8/6/21 02:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Objects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Objects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Readings]    Script Date: 8/6/21 02:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Readings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuildingId] [int] NOT NULL,
	[ObjectId] [int] NOT NULL,
	[DataFieldId] [int] NOT NULL,
	[Value] [float] NOT NULL,
	[TimeStamp] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Readings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Buildings] ON 

INSERT [dbo].[Buildings] ([Id], [Name], [Location]) VALUES (1, N'A', N'ctg')
INSERT [dbo].[Buildings] ([Id], [Name], [Location]) VALUES (2, N'B', N'Feni')
SET IDENTITY_INSERT [dbo].[Buildings] OFF
SET IDENTITY_INSERT [dbo].[DataFields] ON 

INSERT [dbo].[DataFields] ([Id], [Name]) VALUES (1, N'AC')
INSERT [dbo].[DataFields] ([Id], [Name]) VALUES (2, N'Non AC')
SET IDENTITY_INSERT [dbo].[DataFields] OFF
SET IDENTITY_INSERT [dbo].[Objects] ON 

INSERT [dbo].[Objects] ([Id], [Name]) VALUES (1, N'Delux')
INSERT [dbo].[Objects] ([Id], [Name]) VALUES (2, N'VIP')
SET IDENTITY_INSERT [dbo].[Objects] OFF
SET IDENTITY_INSERT [dbo].[Readings] ON 

INSERT [dbo].[Readings] ([Id], [BuildingId], [ObjectId], [DataFieldId], [Value], [TimeStamp]) VALUES (1, 1, 1, 1, 10.12, CAST(N'2021-08-05T22:56:00.0000000' AS DateTime2))
INSERT [dbo].[Readings] ([Id], [BuildingId], [ObjectId], [DataFieldId], [Value], [TimeStamp]) VALUES (2, 1, 1, 1, 12.55, CAST(N'2021-08-05T22:57:00.0000000' AS DateTime2))
INSERT [dbo].[Readings] ([Id], [BuildingId], [ObjectId], [DataFieldId], [Value], [TimeStamp]) VALUES (3, 2, 2, 2, 12.55, CAST(N'2021-08-06T22:57:00.0000000' AS DateTime2))
INSERT [dbo].[Readings] ([Id], [BuildingId], [ObjectId], [DataFieldId], [Value], [TimeStamp]) VALUES (4, 2, 2, 2, 13.55, CAST(N'2021-08-06T22:58:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Readings] OFF
ALTER TABLE [dbo].[Readings]  WITH CHECK ADD  CONSTRAINT [FK_Readings_Buildings_BuildingId] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Readings] CHECK CONSTRAINT [FK_Readings_Buildings_BuildingId]
GO
ALTER TABLE [dbo].[Readings]  WITH CHECK ADD  CONSTRAINT [FK_Readings_DataFields_DataFieldId] FOREIGN KEY([DataFieldId])
REFERENCES [dbo].[DataFields] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Readings] CHECK CONSTRAINT [FK_Readings_DataFields_DataFieldId]
GO
ALTER TABLE [dbo].[Readings]  WITH CHECK ADD  CONSTRAINT [FK_Readings_Objects_ObjectId] FOREIGN KEY([ObjectId])
REFERENCES [dbo].[Objects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Readings] CHECK CONSTRAINT [FK_Readings_Objects_ObjectId]
GO
