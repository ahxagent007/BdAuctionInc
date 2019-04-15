CREATE TABLE [dbo].[Bids]
(
	[BidID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [cID] INT NOT NULL, 
    [ProductID] INT NOT NULL, 
    [AuctionID] INT NOT NULL, 
    [BidAmount] INT NOT NULL, 
    [BidTime] VARCHAR(50) NOT NULL
)
