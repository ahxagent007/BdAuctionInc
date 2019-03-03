CREATE TABLE [dbo].[AuctionEvent]
(
	[AuctionID] INT NOT NULL IDENTITY(13,7) PRIMARY KEY, 
	[AuctionTitle] VARCHAR(255) NULL, 
	[StartTime] VARCHAR(50) NULL, 
	[EndTime] VARCHAR(50) NULL, 
	[TotalProducts] INT NULL, 
	[AuctionDescription] TEXT NULL, 
	[AuctionStatus] VARCHAR(50) NULL, 
	[AuctionMainPicture] TEXT NULL
)
