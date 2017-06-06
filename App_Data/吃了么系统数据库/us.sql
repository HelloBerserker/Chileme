USE [WSDC]
GO

/****** Object:  Table [dbo].[us]    Script Date: 2017/3/16 16:19:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[us](
	[uName] [nvarchar](20) NOT NULL,
	[uPassword] [nvarchar](20) NOT NULL,
	[uPhone] [nvarchar](13) NOT NULL,
	[uMail] [nvarchar](20) NULL,
	[uId] [int] IDENTITY(1,1) NOT NULL,
	[uAddress] [int] NULL,
 CONSTRAINT [PK_us] PRIMARY KEY CLUSTERED 
(
	[uId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'us', @level2type=N'COLUMN',@level2name=N'uName'
GO

