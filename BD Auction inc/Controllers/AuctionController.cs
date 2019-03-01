using BD_Auction_inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BD_Auction_inc.Controllers
{
    public class AuctionController : Controller
    {
        // GET: Auction
        public ActionResult Index()
        {

            AuctionViewModel AVM = new AuctionViewModel {
                
            };
            return View(AVM);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateAuction(){

            
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateAuction(AuctionEventModel AEM)
        {


            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RequestedProducts()
        {


            return View();
        }

    }
}