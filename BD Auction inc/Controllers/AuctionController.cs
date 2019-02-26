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
    }
}