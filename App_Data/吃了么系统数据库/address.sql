USE [WSDC]
GO

/****** Object:  Table [dbo].[uAddress]    Script Date: 2017/3/16 16:18:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[uAddress](
	[aId] [int] IDENTITY(1,1) NOT NULL,
	[uId] [int] NOT NULL,
	[uPhone] [nvarchar](11) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[uName] [nchar](10) NULL,
 CONSTRAINT [PK_uAddress] PRIMARY KEY CLUSTERED 
(
	[aId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

