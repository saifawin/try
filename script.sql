USE [ParkingDB]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 24/02/61 12:36:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[BuildingParkId] [int] NULL,
	[TimeStamp] [datetime] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Building]    Script Date: 24/02/61 12:36:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Building](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Remark] [varchar](500) NULL,
 CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BuildingClass]    Script Date: 24/02/61 12:36:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BuildingClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuildingClassMasterId] [int] NULL,
	[BuildingId] [int] NULL,
	[Remark] [varchar](500) NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BuildingClassMaster]    Script Date: 24/02/61 12:36:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BuildingClassMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
 CONSTRAINT [PK_BuildingClassMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BuildingPark]    Script Date: 24/02/61 12:36:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BuildingPark](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuildingParkMasterId] [int] NULL,
	[BuildingClassId] [int] NULL,
	[StatusId] [int] NULL,
	[Remark] [varchar](500) NULL,
 CONSTRAINT [PK_BuildingParkNum] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BuildingParkMaster]    Script Date: 24/02/61 12:36:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BuildingParkMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
 CONSTRAINT [PK_BuildingParkMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[General]    Script Date: 24/02/61 12:36:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[General](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[TypeCode] [varchar](50) NULL,
	[Name] [varchar](100) NULL,
	[Value] [varchar](50) NULL,
 CONSTRAINT [PK_General] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 24/02/61 12:36:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Date] [datetime] NULL,
	[StatusId] [int] NULL,
	[Total] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RfidConfig]    Script Date: 24/02/61 12:36:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RfidConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RfidUid] [varchar](50) NULL,
	[CarNo] [varchar](50) NULL,
 CONSTRAINT [PK_RfidConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RfidStamp]    Script Date: 24/02/61 12:36:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RfidStamp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UID] [varchar](100) NULL,
	[Date] [datetime] NULL,
	[Status] [nchar](3) NULL,
 CONSTRAINT [PK_RfidStamp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24/02/61 12:36:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[PhoneNo] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[UserName] [varchar](20) NULL,
	[Password] [varchar](20) NULL,
	[CarNo] [varchar](20) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([Id], [UserId], [BuildingParkId], [TimeStamp]) VALUES (1, 4, 1, CAST(0x0000A89100A2A489 AS DateTime))
INSERT [dbo].[Booking] ([Id], [UserId], [BuildingParkId], [TimeStamp]) VALUES (2, 1, 3, CAST(0x0000A89100A428DB AS DateTime))
SET IDENTITY_INSERT [dbo].[Booking] OFF
SET IDENTITY_INSERT [dbo].[Building] ON 

INSERT [dbo].[Building] ([Id], [Name], [Remark]) VALUES (1, N'A', NULL)
INSERT [dbo].[Building] ([Id], [Name], [Remark]) VALUES (2, N'B', NULL)
INSERT [dbo].[Building] ([Id], [Name], [Remark]) VALUES (3, N'C', NULL)
SET IDENTITY_INSERT [dbo].[Building] OFF
SET IDENTITY_INSERT [dbo].[BuildingClass] ON 

INSERT [dbo].[BuildingClass] ([Id], [BuildingClassMasterId], [BuildingId], [Remark]) VALUES (1, 1, 1, NULL)
INSERT [dbo].[BuildingClass] ([Id], [BuildingClassMasterId], [BuildingId], [Remark]) VALUES (2, 2, 1, NULL)
INSERT [dbo].[BuildingClass] ([Id], [BuildingClassMasterId], [BuildingId], [Remark]) VALUES (3, 3, 1, NULL)
INSERT [dbo].[BuildingClass] ([Id], [BuildingClassMasterId], [BuildingId], [Remark]) VALUES (4, 1, 2, NULL)
INSERT [dbo].[BuildingClass] ([Id], [BuildingClassMasterId], [BuildingId], [Remark]) VALUES (5, 2, 2, NULL)
INSERT [dbo].[BuildingClass] ([Id], [BuildingClassMasterId], [BuildingId], [Remark]) VALUES (6, 1, 3, NULL)
INSERT [dbo].[BuildingClass] ([Id], [BuildingClassMasterId], [BuildingId], [Remark]) VALUES (7, 2, 3, NULL)
INSERT [dbo].[BuildingClass] ([Id], [BuildingClassMasterId], [BuildingId], [Remark]) VALUES (8, 3, 3, NULL)
INSERT [dbo].[BuildingClass] ([Id], [BuildingClassMasterId], [BuildingId], [Remark]) VALUES (9, 4, 3, NULL)
INSERT [dbo].[BuildingClass] ([Id], [BuildingClassMasterId], [BuildingId], [Remark]) VALUES (10, 5, 3, NULL)
SET IDENTITY_INSERT [dbo].[BuildingClass] OFF
SET IDENTITY_INSERT [dbo].[BuildingClassMaster] ON 

INSERT [dbo].[BuildingClassMaster] ([Id], [Name]) VALUES (1, N'1')
INSERT [dbo].[BuildingClassMaster] ([Id], [Name]) VALUES (2, N'2')
INSERT [dbo].[BuildingClassMaster] ([Id], [Name]) VALUES (3, N'3')
INSERT [dbo].[BuildingClassMaster] ([Id], [Name]) VALUES (4, N'4')
INSERT [dbo].[BuildingClassMaster] ([Id], [Name]) VALUES (5, N'5')
SET IDENTITY_INSERT [dbo].[BuildingClassMaster] OFF
SET IDENTITY_INSERT [dbo].[BuildingPark] ON 

INSERT [dbo].[BuildingPark] ([Id], [BuildingParkMasterId], [BuildingClassId], [StatusId], [Remark]) VALUES (1, 1, 1, 8, NULL)
INSERT [dbo].[BuildingPark] ([Id], [BuildingParkMasterId], [BuildingClassId], [StatusId], [Remark]) VALUES (2, 2, 1, 8, NULL)
INSERT [dbo].[BuildingPark] ([Id], [BuildingParkMasterId], [BuildingClassId], [StatusId], [Remark]) VALUES (3, 3, 1, 8, NULL)
INSERT [dbo].[BuildingPark] ([Id], [BuildingParkMasterId], [BuildingClassId], [StatusId], [Remark]) VALUES (4, 4, 1, 8, NULL)
INSERT [dbo].[BuildingPark] ([Id], [BuildingParkMasterId], [BuildingClassId], [StatusId], [Remark]) VALUES (5, 1, 2, 8, NULL)
INSERT [dbo].[BuildingPark] ([Id], [BuildingParkMasterId], [BuildingClassId], [StatusId], [Remark]) VALUES (6, 2, 2, 8, NULL)
INSERT [dbo].[BuildingPark] ([Id], [BuildingParkMasterId], [BuildingClassId], [StatusId], [Remark]) VALUES (7, 3, 2, 8, NULL)
INSERT [dbo].[BuildingPark] ([Id], [BuildingParkMasterId], [BuildingClassId], [StatusId], [Remark]) VALUES (8, 1, 3, 8, NULL)
INSERT [dbo].[BuildingPark] ([Id], [BuildingParkMasterId], [BuildingClassId], [StatusId], [Remark]) VALUES (9, 2, 3, 8, NULL)
INSERT [dbo].[BuildingPark] ([Id], [BuildingParkMasterId], [BuildingClassId], [StatusId], [Remark]) VALUES (10, 3, 3, 8, NULL)
INSERT [dbo].[BuildingPark] ([Id], [BuildingParkMasterId], [BuildingClassId], [StatusId], [Remark]) VALUES (11, 4, 3, 8, NULL)
INSERT [dbo].[BuildingPark] ([Id], [BuildingParkMasterId], [BuildingClassId], [StatusId], [Remark]) VALUES (15, 5, 3, 8, NULL)
INSERT [dbo].[BuildingPark] ([Id], [BuildingParkMasterId], [BuildingClassId], [StatusId], [Remark]) VALUES (16, 6, 3, 8, NULL)
SET IDENTITY_INSERT [dbo].[BuildingPark] OFF
SET IDENTITY_INSERT [dbo].[BuildingParkMaster] ON 

INSERT [dbo].[BuildingParkMaster] ([Id], [Name]) VALUES (1, N'Parking 1')
INSERT [dbo].[BuildingParkMaster] ([Id], [Name]) VALUES (2, N'Parking 2')
INSERT [dbo].[BuildingParkMaster] ([Id], [Name]) VALUES (3, N'Parking 3')
INSERT [dbo].[BuildingParkMaster] ([Id], [Name]) VALUES (4, N'Parking 4')
INSERT [dbo].[BuildingParkMaster] ([Id], [Name]) VALUES (5, N'Parking 5')
INSERT [dbo].[BuildingParkMaster] ([Id], [Name]) VALUES (6, N'Parking 6')
SET IDENTITY_INSERT [dbo].[BuildingParkMaster] OFF
SET IDENTITY_INSERT [dbo].[General] ON 

INSERT [dbo].[General] ([Id], [Code], [TypeCode], [Name], [Value]) VALUES (7, N'HOUR', N'PAY', N'20', NULL)
INSERT [dbo].[General] ([Id], [Code], [TypeCode], [Name], [Value]) VALUES (8, N'AV', N'BOOKING', N'Available', NULL)
INSERT [dbo].[General] ([Id], [Code], [TypeCode], [Name], [Value]) VALUES (9, N'NAV', N'BOOKING', N'Not Available', NULL)
INSERT [dbo].[General] ([Id], [Code], [TypeCode], [Name], [Value]) VALUES (10, N'BK', N'BOOKING', N'Reserve', NULL)
INSERT [dbo].[General] ([Id], [Code], [TypeCode], [Name], [Value]) VALUES (11, N'PY', N'PAYMENT', N'Pay', NULL)
INSERT [dbo].[General] ([Id], [Code], [TypeCode], [Name], [Value]) VALUES (12, N'NPY', N'PAYMENT', N'Not Pay', NULL)
SET IDENTITY_INSERT [dbo].[General] OFF
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([Id], [UserId], [Date], [StatusId], [Total]) VALUES (1, 3, CAST(0x0000A89001726D00 AS DateTime), 11, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[Payment] ([Id], [UserId], [Date], [StatusId], [Total]) VALUES (2, 1, CAST(0x0000A89001741177 AS DateTime), 11, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[Payment] ([Id], [UserId], [Date], [StatusId], [Total]) VALUES (3, 3, CAST(0x0000A89001742A2D AS DateTime), 11, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[Payment] ([Id], [UserId], [Date], [StatusId], [Total]) VALUES (1002, 4, CAST(0x0000A8910015F674 AS DateTime), 11, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Payment] ([Id], [UserId], [Date], [StatusId], [Total]) VALUES (1003, 4, CAST(0x0000A8910018D193 AS DateTime), 11, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Payment] ([Id], [UserId], [Date], [StatusId], [Total]) VALUES (1004, 4, CAST(0x0000A8910019188C AS DateTime), 11, CAST(876760.00 AS Decimal(18, 2)))
INSERT [dbo].[Payment] ([Id], [UserId], [Date], [StatusId], [Total]) VALUES (1005, 4, CAST(0x0000A8910084F518 AS DateTime), 11, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[Payment] ([Id], [UserId], [Date], [StatusId], [Total]) VALUES (1006, 4, CAST(0x0000A89100863616 AS DateTime), 11, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Payment] ([Id], [UserId], [Date], [StatusId], [Total]) VALUES (1007, 4, CAST(0x0000A8910092D8D7 AS DateTime), 11, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[Payment] ([Id], [UserId], [Date], [StatusId], [Total]) VALUES (1008, 1, CAST(0x0000A89100B738FA AS DateTime), 12, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[Payment] ([Id], [UserId], [Date], [StatusId], [Total]) VALUES (1009, 1, CAST(0x0000A89100B75706 AS DateTime), 12, CAST(40.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Payment] OFF
SET IDENTITY_INSERT [dbo].[RfidConfig] ON 

INSERT [dbo].[RfidConfig] ([Id], [RfidUid], [CarNo]) VALUES (1, N'2814516089', N'5กต5178')
INSERT [dbo].[RfidConfig] ([Id], [RfidUid], [CarNo]) VALUES (2, N'144444', N'ขธ1546')
INSERT [dbo].[RfidConfig] ([Id], [RfidUid], [CarNo]) VALUES (1002, N'433332', N'ขธ8844')
SET IDENTITY_INSERT [dbo].[RfidConfig] OFF
SET IDENTITY_INSERT [dbo].[RfidStamp] ON 

INSERT [dbo].[RfidStamp] ([Id], [UID], [Date], [Status]) VALUES (1, N'125677', CAST(0x0000A890015789FE AS DateTime), N'IN ')
INSERT [dbo].[RfidStamp] ([Id], [UID], [Date], [Status]) VALUES (3, N'144444', CAST(0x0000A89001656266 AS DateTime), N'IN ')
INSERT [dbo].[RfidStamp] ([Id], [UID], [Date], [Status]) VALUES (5, N'125677', CAST(0x0000A89001740A2D AS DateTime), N'OUT')
INSERT [dbo].[RfidStamp] ([Id], [UID], [Date], [Status]) VALUES (6, N'144444', CAST(0x0000A89001742A18 AS DateTime), N'OUT')
INSERT [dbo].[RfidStamp] ([Id], [UID], [Date], [Status]) VALUES (1002, N'144444', CAST(0x0000A890017EE198 AS DateTime), N'IN ')
INSERT [dbo].[RfidStamp] ([Id], [UID], [Date], [Status]) VALUES (1008, N'433332', CAST(0x0000A16E00BDCB8C AS DateTime), N'IN ')
INSERT [dbo].[RfidStamp] ([Id], [UID], [Date], [Status]) VALUES (1009, N'433332', CAST(0x0000A89100191888 AS DateTime), N'OUT')
INSERT [dbo].[RfidStamp] ([Id], [UID], [Date], [Status]) VALUES (1010, N'433332', CAST(0x0000A8910063614B AS DateTime), N'IN ')
INSERT [dbo].[RfidStamp] ([Id], [UID], [Date], [Status]) VALUES (1015, N'433332', CAST(0x0000A8910092D314 AS DateTime), N'OUT')
INSERT [dbo].[RfidStamp] ([Id], [UID], [Date], [Status]) VALUES (1016, N'2814516089', CAST(0x0000A89100B71170 AS DateTime), N'IN ')
INSERT [dbo].[RfidStamp] ([Id], [UID], [Date], [Status]) VALUES (1017, N'2814516089', CAST(0x0000A89100B738C4 AS DateTime), N'OUT')
INSERT [dbo].[RfidStamp] ([Id], [UID], [Date], [Status]) VALUES (1018, N'2814516089', CAST(0x0000A89100B748DC AS DateTime), N'IN ')
INSERT [dbo].[RfidStamp] ([Id], [UID], [Date], [Status]) VALUES (1019, N'2814516089', CAST(0x0000A89100B75701 AS DateTime), N'OUT')
SET IDENTITY_INSERT [dbo].[RfidStamp] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [PhoneNo], [Email], [UserName], [Password], [CarNo]) VALUES (1, N'สิริวัฒน์', N'มูลทิทา', N'0808575249', N'osiriwat@gmail.com', N'Admin', N'1234', N'5กต5178')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [PhoneNo], [Email], [UserName], [Password], [CarNo]) VALUES (3, N'OOP', N'MATITN|OOM', NULL, NULL, N'AA', N'AA', N'ขธ1546')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [PhoneNo], [Email], [UserName], [Password], [CarNo]) VALUES (4, N'Warisra', N'Lapto', N'0665432211', N'osiriwat@gmail.com', N'mam', N'1234', N'ขธ8844')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_BuildingPark] FOREIGN KEY([BuildingParkId])
REFERENCES [dbo].[BuildingPark] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_BuildingPark]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_User]
GO
ALTER TABLE [dbo].[BuildingClass]  WITH CHECK ADD  CONSTRAINT [FK_BuildingClass_Building] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Building] ([Id])
GO
ALTER TABLE [dbo].[BuildingClass] CHECK CONSTRAINT [FK_BuildingClass_Building]
GO
ALTER TABLE [dbo].[BuildingClass]  WITH CHECK ADD  CONSTRAINT [FK_BuildingClass_BuildingClassMaster] FOREIGN KEY([BuildingClassMasterId])
REFERENCES [dbo].[BuildingClassMaster] ([Id])
GO
ALTER TABLE [dbo].[BuildingClass] CHECK CONSTRAINT [FK_BuildingClass_BuildingClassMaster]
GO
ALTER TABLE [dbo].[BuildingPark]  WITH CHECK ADD  CONSTRAINT [FK_BuildingPark_BuildingClass] FOREIGN KEY([BuildingClassId])
REFERENCES [dbo].[BuildingClass] ([Id])
GO
ALTER TABLE [dbo].[BuildingPark] CHECK CONSTRAINT [FK_BuildingPark_BuildingClass]
GO
ALTER TABLE [dbo].[BuildingPark]  WITH CHECK ADD  CONSTRAINT [FK_BuildingPark_BuildingParkMaster] FOREIGN KEY([BuildingParkMasterId])
REFERENCES [dbo].[BuildingParkMaster] ([Id])
GO
ALTER TABLE [dbo].[BuildingPark] CHECK CONSTRAINT [FK_BuildingPark_BuildingParkMaster]
GO
ALTER TABLE [dbo].[BuildingPark]  WITH CHECK ADD  CONSTRAINT [FK_BuildingPark_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[General] ([Id])
GO
ALTER TABLE [dbo].[BuildingPark] CHECK CONSTRAINT [FK_BuildingPark_Status]
GO
