﻿
using System.Collections.Generic;
using BD_Auction_Inc.DataAccess;
using BD_Auction_inc.Models;
using BD_Auction_Inc.Models;
using System;

namespace BD_Auction_Inc.BusinessLogic
{
    public class AuctionProccessor
    {
        public static int createAuction(string title, string description, string startTime, string endTime, int totalProducts, string status,string mainPic)
        {

            AuctionEventModel data = new AuctionEventModel
            {
                AuctionTitle = title,
                AuctionDescription = description,
                StartTime = startTime,
                EndTime = endTime,
                TotalProducts = totalProducts,
                AuctionStatus = status,
                AuctionMainPicture = mainPic

            };

            string sql = @"INSERT INTO dbo.AuctionEvent (AuctionTitle, AuctionDescription, StartTime, EndTime, TotalProducts, AuctionStatus, AuctionMainPicture)
                VALUES(@AuctionTitle, @AuctionDescription, @StartTime, @EndTime, @TotalProducts, @AuctionStatus, @AuctionMainPicture)";

            return SqlDataAccess.SaveData(sql, data);

        }

        public static List<AuctionEventModel> LoadAllAuctions()
        {

            string sql = @"SELECT * FROM dbo.AuctionEvent";

            return SqlDataAccess.LoadData<AuctionEventModel>(sql); //VDO 59.36

        }
                                       
        public static List<CustomerModelDB> GetAllMembers() {
            string sql = @"SELECT * FROM dbo.Customer";

            return SqlDataAccess.LoadData<CustomerModelDB>(sql); //VDO 59.36
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       

        public static List<AuctionEventModel> GetAuctionByStatus(string AuctionStatus)
        {

            string sql = "SELECT * FROM dbo.AuctionEvent WHERE AuctionStatus = '" + AuctionStatus + "';" ;

            return SqlDataAccess.LoadData<AuctionEventModel>(sql); //VDO 59.36

        }

        public static List<ProductModel> GetProductsByAuctionID(int ID)
        {

            string sql = @"SELECT *
                            FROM dbo.Product
                            JOIN dbo.ProductsInAuction 
                            ON dbo.Product.pID = dbo.ProductsInAuction.pID
                            WHERE AuctionID = " + ID + "; ";

            return SqlDataAccess.LoadData<ProductModel>(sql); //VDO 59.36

        }

        public static List<ProductModel> GetProductsByPID(int ID)
        {

            string sql = @"SELECT *
                            FROM dbo.Product
                            WHERE PID = " + ID + "; ";

            return SqlDataAccess.LoadData<ProductModel>(sql); //VDO 59.36

        }

        public static List<AuctionEventModel> GetAuctionByID(int ID)
        {

            string sql = @"SELECT TOP 50 * FROM dbo.AuctionEvent WHERE AuctionID = '" + ID + "';";

            return SqlDataAccess.LoadData<AuctionEventModel>(sql); //VDO 59.36

        }

        public static List<BidModel> Get50Bids()
        {

            string sql = @"SELECT * FROM dbo.Bids ORDER BY BidID DESC;";

            return SqlDataAccess.LoadData<BidModel>(sql); //VDO 59.36

        }


        public static int addProductToAuction(int aID, int pID) {
            string sts = "ENTRY";
            string sql = @"INSERT INTO dbo.ProductsInAuction (pID, AuctionID, Status)
                        VALUES (@pID, @AuctionID, @Status );
                        UPDATE dbo.Product SET ProductStatus = @Status WHERE pID = @pID;
                        UPDATE dbo.AuctionEvent SET TotalProducts = TotalProducts + 1 WHERE AuctionID = @AuctionID; 
                        
";

            return SqlDataAccess.SaveData(sql,new { pID = pID, AuctionID = aID, Status = sts});
        }

        public static int makebid(int aID, int pID, int BID, string UID)
        {
            string curTime = DateTime.Now.ToString("h:mm:ss tt");
            string sql = @"INSERT INTO dbo.Bids (productID, AuctionID, cID, BidAmount, BidTime )
                        VALUES (@productID, @AuctionID, @cID, @BidAmount, @BidTime );
                        UPDATE dbo.Product SET CurrentBid = @BidAmount WHERE pID = @productID;                        
                        
";

            return SqlDataAccess.SaveData(sql, new { productID = pID, AuctionID = aID, cID = UID, BidAmount = BID, BidTime = curTime });
        }

        public static int ChangeStatus(int aID, string Status){

            string sql = @"UPDATE dbo.AuctionEvent SET AuctionStatus = @Status WHERE AuctionID = @AuctionID;";

            return SqlDataAccess.SaveData(sql, new {AuctionID = aID, Status = Status });
        }
        
        public static int updateProductData(string sTime, string eTime, int pID)
        {

            string sql = @"UPDATE dbo.Product SET StartTime = @StartTime, EndTime = @EndTime WHERE pID = @pID;";

            return SqlDataAccess.SaveData(sql, new { StartTime = sTime, EndTime = eTime, pID = pID });
        }


        public static int RequestProductForAuction(ProductModel p) {

            string sql = @"INSERT INTO dbo.Product (pName, pDescription, pCatagory, pStartingPrice, StartTime, EndTime, PictureID, SellerID, ProductMainPicture, ProductStatus)
                        VALUES (@pName, @pDescription, @pCatagory, @pStartingPrice, @StartTime, @EndTime, @PictureID, @SellerID, @MainPicture, @ProductStatus)";

            return SqlDataAccess.SaveData(sql, p);
        }


        public static List<ProductModel> LoadAllProduct()
        {

            string sql = @"SELECT * FROM dbo.Product";

            return SqlDataAccess.LoadData<ProductModel>(sql);

        }

        public static List<ProductModel> LoadAllRequestedProduct()
        {

            string sql = @"SELECT * FROM dbo.Product WHERE ProductStatus = 'REQUESTING'";

            return SqlDataAccess.LoadData<ProductModel>(sql);

        }

        //Database theke object ber korbo then oi object er id diye onno operation chalabo THATS IT

    }
}
