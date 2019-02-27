CREATE TABLE [dbo].[Product]
(
	[pID] INT NOT NULL IDENTITY(1001,11) PRIMARY KEY, 
    [pName] VARCHAR(50) NOT NULL, 
    [pDescription] TEXT NULL, 
    [pCatagory] VARCHAR(50) NOT NULL, 
    [pStartingPrice] INT NULL DEFAULT 0, 
    [CurrentBid] INT NULL DEFAULT 0, 
    [StartTime] VARCHAR(50) NULL, 
    [EndTime] VARCHAR(50) NULL, 
    [PictureID] INT NULL, 
    [SellerID] INT NOT NULL, 
    [ProductMainPicture] TEXT NULL, 
    [ProductStatus] VARCHAR(50) NULL
)
