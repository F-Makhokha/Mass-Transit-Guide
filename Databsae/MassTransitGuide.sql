USE [MassTransitGuide_Efe]
GO
/****** Object:  Table [dbo].[BusNumbers]    Script Date: 23.07.2018 11:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusNumbers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Bus_Selection] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Date] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BusNumbers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Busses]    Script Date: 23.07.2018 11:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Busses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Plaka_No] [varchar](50) NOT NULL,
	[Bus_Selection] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Date] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Busses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusStops]    Script Date: 23.07.2018 11:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusStops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Durak_Adi] [varchar](50) NOT NULL,
	[Enlem] [varchar](50) NOT NULL,
	[Boylam] [varchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[Date] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BusStops] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 23.07.2018 11:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drivers](
	[TC] [bigint] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Bus_Selection] [int] NOT NULL,
	[Status] [int] NULL,
	[Date] [varchar](50) NULL,
 CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED 
(
	[TC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guzergah]    Script Date: 23.07.2018 11:49:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guzergah](
	[Guzergah_Id] [int] IDENTITY(1,1) NOT NULL,
	[Guzergah_Adi] [varchar](50) NOT NULL,
	[Gidis_Donus] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Date] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Guzergah] PRIMARY KEY CLUSTERED 
(
	[Guzergah_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuzergahDurak]    Script Date: 23.07.2018 11:49:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuzergahDurak](
	[GuzergahDurak_Id] [int] IDENTITY(1,1) NOT NULL,
	[Guzergah_Id] [int] NULL,
	[Id] [int] NULL,
	[Siralama] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GuzergahDurak_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23.07.2018 11:49:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] NOT NULL,
	[username] [varchar](50) NOT NULL,
	[pwd] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BusNumbers] ON 

INSERT [dbo].[BusNumbers] ([Id], [Bus_Selection], [Status], [Date]) VALUES (1, 510, 0, N'28-06-18 16:35:08')
INSERT [dbo].[BusNumbers] ([Id], [Bus_Selection], [Status], [Date]) VALUES (2, 216, 1, N'28-06-18 17:00:18')
INSERT [dbo].[BusNumbers] ([Id], [Bus_Selection], [Status], [Date]) VALUES (3, 510, 0, N'28-06-18 17:15:18')
INSERT [dbo].[BusNumbers] ([Id], [Bus_Selection], [Status], [Date]) VALUES (4, 510, 0, N'28-06-18 17:15:27')
INSERT [dbo].[BusNumbers] ([Id], [Bus_Selection], [Status], [Date]) VALUES (5, 510, 0, N'28-06-18 17:18:20')
INSERT [dbo].[BusNumbers] ([Id], [Bus_Selection], [Status], [Date]) VALUES (6, 510, 1, N'28-06-18 17:18:46')
INSERT [dbo].[BusNumbers] ([Id], [Bus_Selection], [Status], [Date]) VALUES (7, 480, 1, N'28-06-18 17:23:32')
INSERT [dbo].[BusNumbers] ([Id], [Bus_Selection], [Status], [Date]) VALUES (8, 169, 1, N'28-06-18 17:23:35')
INSERT [dbo].[BusNumbers] ([Id], [Bus_Selection], [Status], [Date]) VALUES (9, 554, 1, N'28-06-18 17:23:41')
INSERT [dbo].[BusNumbers] ([Id], [Bus_Selection], [Status], [Date]) VALUES (10, 8, 1, N'28-06-18 17:24:47')
INSERT [dbo].[BusNumbers] ([Id], [Bus_Selection], [Status], [Date]) VALUES (11, 969, 1, N'28-06-18 17:27:14')
INSERT [dbo].[BusNumbers] ([Id], [Bus_Selection], [Status], [Date]) VALUES (12, 121, 1, N'28-06-18 17:27:18')
INSERT [dbo].[BusNumbers] ([Id], [Bus_Selection], [Status], [Date]) VALUES (13, 90, 1, N'28-06-18 17:27:27')
INSERT [dbo].[BusNumbers] ([Id], [Bus_Selection], [Status], [Date]) VALUES (14, 72, 1, N'28-06-18 17:27:29')
SET IDENTITY_INSERT [dbo].[BusNumbers] OFF
SET IDENTITY_INSERT [dbo].[Busses] ON 

INSERT [dbo].[Busses] ([Id], [Plaka_No], [Bus_Selection], [Status], [Date]) VALUES (1, N'', 343, 0, N'28-06-18 14:18:34')
INSERT [dbo].[Busses] ([Id], [Plaka_No], [Bus_Selection], [Status], [Date]) VALUES (2, N'35 efe 35', 292, 1, N'28-06-18 15:41:11')
INSERT [dbo].[Busses] ([Id], [Plaka_No], [Bus_Selection], [Status], [Date]) VALUES (3, N'35 fffeeeef', 2112, 0, N'29-06-18 08:42:09')
INSERT [dbo].[Busses] ([Id], [Plaka_No], [Bus_Selection], [Status], [Date]) VALUES (4, N'32232efe', 969, 1, N'29-06-18 09:45:58')
INSERT [dbo].[Busses] ([Id], [Plaka_No], [Bus_Selection], [Status], [Date]) VALUES (5, N'32232efe', 169, 0, N'29-06-18 09:55:46')
INSERT [dbo].[Busses] ([Id], [Plaka_No], [Bus_Selection], [Status], [Date]) VALUES (6, N'124324dfsf', 72, 1, N'29-06-18 10:02:09')
INSERT [dbo].[Busses] ([Id], [Plaka_No], [Bus_Selection], [Status], [Date]) VALUES (7, N'35 abc 3333', 510, 1, N'29-06-18 11:20:27')
INSERT [dbo].[Busses] ([Id], [Plaka_No], [Bus_Selection], [Status], [Date]) VALUES (8, N'34 rer 22', 510, 1, N'29-06-18 11:20:42')
INSERT [dbo].[Busses] ([Id], [Plaka_No], [Bus_Selection], [Status], [Date]) VALUES (9, N'35 ee 654', 480, 1, N'29-06-18 13:13:26')
SET IDENTITY_INSERT [dbo].[Busses] OFF
SET IDENTITY_INSERT [dbo].[BusStops] ON 

INSERT [dbo].[BusStops] ([Id], [Durak_Adi], [Enlem], [Boylam], [Status], [Date]) VALUES (8, N'Biyotip', N'38.39533', N'27.02771', 1, N'28-06-18 13:17:50')
INSERT [dbo].[BusStops] ([Id], [Durak_Adi], [Enlem], [Boylam], [Status], [Date]) VALUES (11, N'Haberr', N'38.39129', N'27.03953', 1, N'28-06-18 13:08:40')
INSERT [dbo].[BusStops] ([Id], [Durak_Adi], [Enlem], [Boylam], [Status], [Date]) VALUES (12, N'Turkan Saylan', N'38.39118', N'27.02230', 1, N'29-06-18 13:06:23')
INSERT [dbo].[BusStops] ([Id], [Durak_Adi], [Enlem], [Boylam], [Status], [Date]) VALUES (13, N'Adana', N'38.39293', N'27.04890', 1, N'05-07-18 16:34:31')
INSERT [dbo].[BusStops] ([Id], [Durak_Adi], [Enlem], [Boylam], [Status], [Date]) VALUES (14, N'Efe', N'38.38442', N'27.02877', 1, N'29-06-18 15:11:55')
INSERT [dbo].[BusStops] ([Id], [Durak_Adi], [Enlem], [Boylam], [Status], [Date]) VALUES (15, N'Akehir', N'38.39234', N'27.03096', 1, N'05-07-18 16:35:37')
INSERT [dbo].[BusStops] ([Id], [Durak_Adi], [Enlem], [Boylam], [Status], [Date]) VALUES (20, N'Bursa', N'38.38682', N'27.03881', 1, N'05-07-18 16:34:45')
INSERT [dbo].[BusStops] ([Id], [Durak_Adi], [Enlem], [Boylam], [Status], [Date]) VALUES (21, N'Antalya', N'38.39217', N'27.03580', 1, N'05-07-18 16:35:02')
INSERT [dbo].[BusStops] ([Id], [Durak_Adi], [Enlem], [Boylam], [Status], [Date]) VALUES (22, N'Effe', N'38.40041', N'27.04439', 1, N'02-07-18 14:07:55')
INSERT [dbo].[BusStops] ([Id], [Durak_Adi], [Enlem], [Boylam], [Status], [Date]) VALUES (23, N'Beytepe', N'38.39843', N'27.03152', 1, N'05-07-18 16:35:18')
INSERT [dbo].[BusStops] ([Id], [Durak_Adi], [Enlem], [Boylam], [Status], [Date]) VALUES (24, N'll', N'38.39551', N'27.04448', 1, N'13-07-18 13:10:53')
SET IDENTITY_INSERT [dbo].[BusStops] OFF
INSERT [dbo].[Drivers] ([TC], [Name], [Surname], [Bus_Selection], [Status], [Date]) VALUES (20513059500, N'Ersoy Efe', N'Uruk', 969, 1, N'29-06-18 13:43:25')
SET IDENTITY_INSERT [dbo].[Guzergah] ON 

INSERT [dbo].[Guzergah] ([Guzergah_Id], [Guzergah_Adi], [Gidis_Donus], [Status], [Date]) VALUES (7, N'fsdfsf', 1, 0, N'02-07-18 17:26:41')
INSERT [dbo].[Guzergah] ([Guzergah_Id], [Guzergah_Adi], [Gidis_Donus], [Status], [Date]) VALUES (8, N'sdfs', 0, 1, N'02-07-18 17:26:51')
INSERT [dbo].[Guzergah] ([Guzergah_Id], [Guzergah_Adi], [Gidis_Donus], [Status], [Date]) VALUES (9, N'a', 1, 1, N'09-07-18 10:25:42')
INSERT [dbo].[Guzergah] ([Guzergah_Id], [Guzergah_Adi], [Gidis_Donus], [Status], [Date]) VALUES (11, N'dsfs', 0, 1, N'10-07-18 10:26:07')
INSERT [dbo].[Guzergah] ([Guzergah_Id], [Guzergah_Adi], [Gidis_Donus], [Status], [Date]) VALUES (12, N'Buca', 1, 1, N'10-07-18 10:34:53')
INSERT [dbo].[Guzergah] ([Guzergah_Id], [Guzergah_Adi], [Gidis_Donus], [Status], [Date]) VALUES (13, N'sdf', 1, 1, N'10-07-18 10:41:37')
INSERT [dbo].[Guzergah] ([Guzergah_Id], [Guzergah_Adi], [Gidis_Donus], [Status], [Date]) VALUES (14, N'dfsd', 1, 1, N'10-07-18 10:46:46')
INSERT [dbo].[Guzergah] ([Guzergah_Id], [Guzergah_Adi], [Gidis_Donus], [Status], [Date]) VALUES (15, N'sdf', 0, 1, N'10-07-18 10:59:11')
INSERT [dbo].[Guzergah] ([Guzergah_Id], [Guzergah_Adi], [Gidis_Donus], [Status], [Date]) VALUES (17, N'Uzun Yol', 1, 1, N'10-07-18 11:08:34')
INSERT [dbo].[Guzergah] ([Guzergah_Id], [Guzergah_Adi], [Gidis_Donus], [Status], [Date]) VALUES (18, N'KısaYol', 0, 1, N'10-07-18 11:24:46')
INSERT [dbo].[Guzergah] ([Guzergah_Id], [Guzergah_Adi], [Gidis_Donus], [Status], [Date]) VALUES (19, N'bbbb', 1, 1, N'10-07-18 11:27:31')
INSERT [dbo].[Guzergah] ([Guzergah_Id], [Guzergah_Adi], [Gidis_Donus], [Status], [Date]) VALUES (20, N'Efe', 1, 1, N'10-07-18 11:43:37')
INSERT [dbo].[Guzergah] ([Guzergah_Id], [Guzergah_Adi], [Gidis_Donus], [Status], [Date]) VALUES (21, N'Text', 0, 1, N'11-07-18 08:18:52')
SET IDENTITY_INSERT [dbo].[Guzergah] OFF
SET IDENTITY_INSERT [dbo].[GuzergahDurak] ON 

INSERT [dbo].[GuzergahDurak] ([GuzergahDurak_Id], [Guzergah_Id], [Id], [Siralama]) VALUES (39, 20, 22, 1)
INSERT [dbo].[GuzergahDurak] ([GuzergahDurak_Id], [Guzergah_Id], [Id], [Siralama]) VALUES (40, 20, 13, 2)
INSERT [dbo].[GuzergahDurak] ([GuzergahDurak_Id], [Guzergah_Id], [Id], [Siralama]) VALUES (41, 20, 20, 3)
INSERT [dbo].[GuzergahDurak] ([GuzergahDurak_Id], [Guzergah_Id], [Id], [Siralama]) VALUES (42, 20, 11, 4)
INSERT [dbo].[GuzergahDurak] ([GuzergahDurak_Id], [Guzergah_Id], [Id], [Siralama]) VALUES (43, 21, 12, 1)
INSERT [dbo].[GuzergahDurak] ([GuzergahDurak_Id], [Guzergah_Id], [Id], [Siralama]) VALUES (44, 21, 8, 2)
INSERT [dbo].[GuzergahDurak] ([GuzergahDurak_Id], [Guzergah_Id], [Id], [Siralama]) VALUES (45, 21, 21, 3)
SET IDENTITY_INSERT [dbo].[GuzergahDurak] OFF
INSERT [dbo].[Users] ([id], [username], [pwd]) VALUES (1, N'efe', N'efe')
INSERT [dbo].[Users] ([id], [username], [pwd]) VALUES (2, N'admin', N'admin')
INSERT [dbo].[Users] ([id], [username], [pwd]) VALUES (3, N'a', N'a')
ALTER TABLE [dbo].[GuzergahDurak]  WITH CHECK ADD FOREIGN KEY([Guzergah_Id])
REFERENCES [dbo].[Guzergah] ([Guzergah_Id])
GO
ALTER TABLE [dbo].[GuzergahDurak]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[BusStops] ([Id])
GO
