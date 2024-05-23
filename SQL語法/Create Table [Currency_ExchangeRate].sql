USE [master]
GO

/****** Object:  Table [dbo].[Currency_ExchangeRate]    Script Date: 2024/5/22 ¤U¤È 09:43:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Currency_ExchangeRate](
	[ExchangeID] [bigint] IDENTITY(1,1) NOT NULL,
	[CurrencyID] [bigint] NOT NULL,
	[ExchangeCurrencyID] [bigint] NOT NULL,
	[ExchangeRate] [decimal](18, 6) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Currency_ExchangeRate] PRIMARY KEY CLUSTERED 
(
	[ExchangeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


