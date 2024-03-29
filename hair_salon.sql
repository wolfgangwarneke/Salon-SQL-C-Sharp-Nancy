USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 7/15/2016 4:57:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stylists]    Script Date: 7/15/2016 4:57:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (4, N'Jimminy Cricket', 3)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (2, N'Kermit the Frog', 0)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (3, N'Hannah Montana', 3)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([id], [name]) VALUES (3, N'Chazzy Chaz')
INSERT [dbo].[stylists] ([id], [name]) VALUES (2, N'Ralphie Wiggum')
SET IDENTITY_INSERT [dbo].[stylists] OFF
