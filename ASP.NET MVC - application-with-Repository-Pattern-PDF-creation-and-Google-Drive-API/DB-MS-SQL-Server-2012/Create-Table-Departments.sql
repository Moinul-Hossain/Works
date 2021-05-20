USE [RetailDB]
GO

/****** Object:  Table [dbo].[Departments]    Script Date: 06-Oct-20 2:26:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Departments](
	[Department_ID] [int] IDENTITY(1,1) NOT NULL,
	[Retailer_ID] [int] NOT NULL,
	[Department_Name] [nchar](50) NULL,
	[Department_Code] [nchar](10) NULL,
	[image_url] [nchar](50) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Department_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Retailers] FOREIGN KEY([Retailer_ID])
REFERENCES [dbo].[Retailers] ([Retailer_ID])
GO

ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Retailers]
GO


