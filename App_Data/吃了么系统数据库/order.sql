USE [WSDC]
GO

/****** Object:  Table [dbo].[orders]    Script Date: 2017/3/16 16:17:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[orders](
	[oNo] [nvarchar](20) NULL,
	[oID] [int] IDENTITY(1,1) NOT NULL,
	[cID] [nvarchar](20) NULL,
	[cFood] [nvarchar](10) NULL,
	[cCount] [int] NULL,
	[cUid] [int] NULL,
	[oMemo] [nvarchar](50) NULL,
	[oAddress] [nvarchar](50) NULL,
	[odate] [nvarchar](30) NULL,
 CONSTRAINT [PK_neworder] PRIMARY KEY CLUSTERED 
(
	[oID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

