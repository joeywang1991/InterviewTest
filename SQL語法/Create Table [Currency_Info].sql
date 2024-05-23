USE [master]
GO

/****** Object:  Table [dbo].[Currency_Info]    Script Date: 2024/5/22 ¤U¤È 09:43:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Currency_Info](
	[CurrencyID] [bigint] IDENTITY(1,1) NOT NULL,
	[CurrencyName] [varchar](10) NOT NULL,
	[Symbol] [varchar](10) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Currency_Info] PRIMARY KEY CLUSTERED 
(
	[CurrencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


