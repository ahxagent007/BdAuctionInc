CREATE TABLE [dbo].[AuctionEvent]
(
	[AcutionID] INT NOT NULL IDENTITY(13,7) PRIMARY KEY, 
	[AuctionTitle] VARCHAR(255) NULL, 
	[StartTime] VARCHAR(50) NULL, 
	[EndTime] VARCHAR(50) NULL, 
	[TotalProducts] INT NULL, 
	[Description] TEXT NULL, 
	[AuctionStatus] VARCHAR(50) NULL, 
	[AuctionMainPicture] TEXT NULL
)
