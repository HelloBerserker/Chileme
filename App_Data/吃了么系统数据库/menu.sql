USE [WSDC]
GO

/****** Object:  Table [dbo].[menu]    Script Date: 2017/3/16 16:17:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[menu](
	[mID] [int] NOT NULL,
	[mName] [nvarchar](10) NOT NULL,
	[mImage] [nvarchar](20) NULL,
	[mInfo] [nvarchar](50) NULL,
	[mStatus] [nchar](4) NULL,
	[mPrice] [float] NOT NULL,
 CONSTRAINT [PK_menu] PRIMARY KEY CLUSTERED 
(
	[mID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

