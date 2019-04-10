using BD_Auction_inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD_Auction_Inc.BusinessLogic;
using System.Threading.Tasks;

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

            /*Task.Factory.StartNew(() => {
                //Do an advanced looging here which takes a while
                int i = 0;
                while (true) {
                    AVM.runningAuctions[0].AuctionDescription = "Xian "+i;
                    i++;
                     }
            });*/

            return View(AVM);
        }



        public long datetimeToMilis(DateTime yourDateTime) {

            long milis = (long)(yourDateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            return milis;
        }
       

    }
}