CREATE TABLE [dbo].[Seller]
(
	[SellerID] INT NOT NULL PRIMARY KEY, 
    [ShopName] VARCHAR(50) NULL, 
    [SellerName] VARCHAR(50) NULL, 
    [PhoneNumber] VARCHAR(50) NULL, 
    [Address] VARCHAR(50) NULL, 
    [Rating] FLOAT NULL, 
    [Email] VARCHAR(50) NULL, 
    [Contribution] INT NULL, 
    [Status] VARCHAR(50) NULL, 
    [NID] VARCHAR(50) NULL
)
