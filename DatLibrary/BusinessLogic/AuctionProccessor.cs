using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD_Auction_inc.Models;
using DataLibrary.DataAccess;


namespace DatLibrary.BusinessLogic
{
    public class AuctionProccessor
    {
        public static int CreateAuction(string title, string description, string startTime, string endTime, int totalProducts, string status,string mainPic)
        {

            AuctionEventModel data = new AuctionEventModel
            {
                auctionTitle = title,
                auctionDescription = description,
                StartTime = startTime,
                EndTime = endTime,
                totalProduct = totalProducts,
                auctionStatus = status,
                auctionMainPicture = mainPic

            };

            string sql = @"INSERT INTO dbo.AuctionEvent (AuctionTitle, Description, StartTime, EndTime, TotalProducts, AuctionStatus, AuctionMainPicture)
                VALUES(@title, @description, @startTime, @endTime, @totalProducts, @status, @mainPic)";

            return SqlDataAccess.SaveData(sql, data);

        }

        public static List<AuctionEventModel> LoadAuctionByStatus(string status)
        {

            string sql = @"SELECT * FROM dbo.AuctionEvent WHERE AuctionStatus = @status";

            return SqlDataAccess.LoadData<AuctionEventModel>(sql); //VDO 59.36

        }

        public static List<AuctionEventModel> GetAuctionByID(int ID)
        {

            string sql = @"SELECT * FROM dbo.AuctionEvent WHERE AuctionID = @ID";

            return SqlDataAccess.LoadData<AuctionEventModel>(sql); //VDO 59.36

        }

        public static int requestProductForAuction(ProductModel p) {

            string sql = @"INSERT INTO dbo.Product (pName, pDescription, pCatagory, pStartingPrice, StartTime, EndTime, PictureID, SellerID, ProductMainPicture, ProductStatus)
                        VALUES (@p.pName, @p.pDescription, @p.pcatagory, @p.pStartingPrice, @p.StartTime, @p.EndTime, @p.PictureID, @p.SellerID, @p.MainPicture, @p.status)";

            return SqlDataAccess.SaveData(sql, p);
        }

        public static List<ProductModel> GetProductByAuctionID(int ID)
        {

            string sql = @""; //Join SQL 

            return SqlDataAccess.LoadData<ProductModel>(sql); //VDO 59.36

        }

    }
}
