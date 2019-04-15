
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

        public static int updateProduectStatusByAuctionID(int ID, String sstatus)
        {

            string sql = @"UPDATE dbo.Product
                            SET dbo.Product.ProductStatus = @productStatus
                            FROM dbo.Product
                            JOIN dbo.ProductsInAuction 
                            ON dbo.Product.pID = dbo.ProductsInAuction.pID
                            WHERE AuctionID = @aID; ";

            return SqlDataAccess.SaveData(sql, new { aID = ID, productStatus = sstatus });

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

        public static int makebid(int aID, int pID, int BID, int UID)
        {
            string curTime = DateTime.Now.ToString("yyyy-mm:dd hh:mm:ss"); //2019-04-01T02:31
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
                        VALUES (@pName, @pDescription, @pCatagory, @pStartingPrice, @StartTime, @EndTime, @PictureID, @SellerID, @ProductMainPicture, @ProductStatus)";

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


        public static long ConvertToMiliSeconds(String dateTime) //0:yyyy-MM-ddThh:mm:ss FORMAT 2019-04-01T02:31
        {

            int year = Convert.ToInt32(dateTime.Substring(0, 4));
            int month = Convert.ToInt32(dateTime.Substring(5, 2));
            int day = Convert.ToInt32(dateTime.Substring(8, 2));
            int hour = Convert.ToInt32(dateTime.Substring(11, 2));
            int minute = Convert.ToInt32(dateTime.Substring(14, 2));
            //int second = Convert.ToInt32(dateTime.Substring(17, 2));
            int second = 0;
            int milisec = 0;


            //Console.WriteLine(year + " " + month + " "+ day + " "+ hour +" "+ minute +" "+ second);

            System.DateTime moment = new System.DateTime(
                                year, month, day, hour, minute, second, milisec);


            // Millisecond gets long.
            long millisecond = moment.Ticks;

            Console.WriteLine(millisecond);
            //Console.WriteLine(Environment.TickCount);
            Console.WriteLine("NOW " + DateTime.UtcNow.Ticks);

            return millisecond;


        }

    }
}
