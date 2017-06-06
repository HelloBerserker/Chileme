USE [WSDC]
GO

/****** Object:  Table [dbo].[uDetails]    Script Date: 2017/3/16 16:19:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[uDetails](
	[uID] [int] NOT NULL,
	[uAddress] [nvarchar](50) NULL,
	[uCash] [float] NULL
) ON [PRIMARY]

GO

