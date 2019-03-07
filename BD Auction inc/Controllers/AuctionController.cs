using BD_Auction_inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD_Auction_Inc.BusinessLogic;


namespace BD_Auction_inc.Controllers
{
    public class AuctionController : Controller
    {
        // GET: Auction
        public ActionResult Index()
        {

            AuctionViewModel AVM = new AuctionViewModel {
                runningAuctions = AuctionProccessor.GetAuctionByStatus("RUNNING"),
                pastAuctions = AuctionProccessor.GetAuctionByStatus("FINISHED"),
                upcommingAuctions = AuctionProccessor.GetAuctionByStatus("UPCOMING")
            };
            return View(AVM);
        }

       // [Authorize(Roles = "Admin")]
        public ActionResult CreateAuction(){

            
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateAuction(AuctionEventModel AEM)
        {
            int row = AuctionProccessor.createAuction(AEM.AuctionTitle, AEM.AuctionDescription, AEM.StartTime, AEM.EndTime, AEM.TotalProducts, AEM.AuctionStatus, AEM.AuctionMainPicture);

            return View();
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult RequestedProducts()
        {


            return View();
        }

        //$qry = "SELECT * FROM fanciers ORDER BY FancierName ASC LIMIT ".$rowFrom.", ".$rowTo.";";

    }
}