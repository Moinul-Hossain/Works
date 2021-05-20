USE [RetailDB]
GO

/****** Object:  Table [dbo].[Retailers]    Script Date: 06-Oct-20 2:21:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Retailers](
	[Retailer_ID] [int] IDENTITY(1,1) NOT NULL,
	[Retailer_Code] [nchar](10) NULL,
	[Retailer_Name] [nvarchar](50) NULL,
	[Retailer_Location] [nchar](10) NULL,
	[image_url] [nvarchar](50) NULL,
 CONSTRAINT [PK_Retailers] PRIMARY KEY CLUSTERED 
(
	[Retailer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


