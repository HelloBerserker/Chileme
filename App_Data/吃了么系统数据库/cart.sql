USE [WSDC]
GO

/****** Object:  Table [dbo].[cart]    Script Date: 2017/3/16 16:16:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[cart](
	[cID] [nvarchar](20) NOT NULL,
	[cTotal] [float] NULL,
	[cFood] [nvarchar](10) NULL,
	[cCount] [int] NULL,
	[cUid] [int] NULL,
 CONSTRAINT [PK_cart] PRIMARY KEY CLUSTERED 
(
	[cID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

