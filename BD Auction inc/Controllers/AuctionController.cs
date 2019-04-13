using BD_Auction_inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD_Auction_Inc.BusinessLogic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using BD_Auction_Inc.Models;
using System.Diagnostics;

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
            if (PM[0].CurrentBid <= BID && DateTime.Now.Ticks < AuctionProccessor.ConvertToMiliSeconds(PM[0].EndTime)) {
                MakeBid( PID, BID);
            }

            return Redirect("/Auction/SingleAuction?AID=" + Session["AUCTION_ID"]);
        }

        public void MakeBid(int P, int B) {
            string userID = User.Identity.GetUserId();
            List<CustomerModelDB> customer = CustomerProcessor.getCustomersViaNetID(userID);
            AuctionProccessor.makebid(Convert.ToInt32(Session["AUCTION_ID"]), P, B, customer[0].cID);
        }




        public void checkedAuctions(AuctionViewModel AVM) {
            foreach (AuctionEventModel AEM in AVM.runningAuctions){
                // AuctionProccessor.ChangeStatus();
                long aucTime = AuctionProccessor.ConvertToMiliSeconds(AEM.EndTime); //AEM.EndTime;    
                long nowTIme = DateTime.Now.Ticks;

                Debug.WriteLine("aucTime = "+ aucTime+" && nowTime = "+ nowTIme);
                Console.WriteLine("aucTime = " + aucTime + " && nowTime = " + nowTIme);
                System.Diagnostics.Debug.WriteLine("aucTime = " + aucTime + " && nowTime = " + nowTIme);

                if (aucTime > nowTIme) {
                    AuctionProccessor.ChangeStatus(AEM.AuctionID, "FINISHED");
                }
            }

            foreach (AuctionEventModel AEM in AVM.upcommingAuctions)
            {
                // AuctionProccessor.ChangeStatus();
                long aucTime = AuctionProccessor.ConvertToMiliSeconds(AEM.StartTime);
                long nowTIme = DateTime.Now.Ticks;
                if (aucTime >= nowTIme)
                {
                    AuctionProccessor.ChangeStatus(AEM.AuctionID, "RUNNING");
                }
            }
        }



    }
}