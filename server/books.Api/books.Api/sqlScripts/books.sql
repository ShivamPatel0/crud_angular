USE [BooksDetails]
GO

/****** Object:  Table [dbo].[Books]    Script Date: 21/10/2020 11:18:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[book] [varchar](100) NULL,
	[author] [varchar](100) NULL,
	[isDeleted] [int] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


