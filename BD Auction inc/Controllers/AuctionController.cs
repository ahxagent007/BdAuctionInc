using BD_Auction_inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD_Auction_Inc.BusinessLogic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace BD_Auction_inc.Controllers
{
    public class AuctionController : Controller
    {
        
        // GET: Auction
        public ActionResult Index(){

            
            AuctionViewModel AVM = new AuctionViewModel {
                runningAuctions = AuctionProccessor.GetAuctionByStatus("RUNNING"),
                pastAuctions = AuctionProccessor.GetAuctionByStatus("FINISHED"),
                upcommingAuctions = AuctionProccessor.GetAuctionByStatus("UPCOMING")
            };

            checkedAuctions(AVM);

            return View(AVM);
        }

        [HttpGet]
        [Authorize]
        public ActionResult SingleAuction(int AID)
        {
            Session["AUCTION_ID"] = AID;
            List<AuctionEventModel> AWM = AuctionProccessor.GetAuctionByID(AID);
            AllProductsLoad APL = new AllProductsLoad
            {
                productList = AuctionProccessor.GetProductsByAuctionID(AID)
            };

            return View(APL);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Bid(int PID, int BID) {

            List <ProductModel> PM = AuctionProccessor.GetProductsByPID(PID);
            if (PM[0].CurrentBid <= BID) {
                MakeBid( PID, BID);
            }

            return Redirect("/Auction/SingleAuction?AID=" + Session["AUCTION_ID"]);
        }

        public void MakeBid(int P, int B) {
            var userID = User.Identity.GetUserId();
            AuctionProccessor.makebid(Convert.ToInt32(Session["AUCTION_ID"]), P, B, userID);
        }



        public long datetimeToMilis(DateTime yourDateTime) {

            long milis = (long)(yourDateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            return milis;
        }

        public void checkedAuctions(AuctionViewModel AVM) {
            foreach (AuctionEventModel AEM in AVM.runningAuctions){
                // AuctionProccessor.ChangeStatus();
                long aucTime = datetimeToMilis(Convert.ToDateTime(AEM.EndTime));
                long nowTIme = DateTime.Now.Millisecond;
                if (aucTime > nowTIme) {
                    AuctionProccessor.ChangeStatus(AEM.AuctionID, "FINISHED");
                }
            }

            foreach (AuctionEventModel AEM in AVM.upcommingAuctions)
            {
                // AuctionProccessor.ChangeStatus();
                long aucTime = datetimeToMilis(Convert.ToDateTime(AEM.StartTime));
                long nowTIme = DateTime.Now.Millisecond;
                if (aucTime >= nowTIme)
                {
                    AuctionProccessor.ChangeStatus(AEM.AuctionID, "RUNNING");
                }
            }
        }



    }
}