using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD_Auction_inc.Models;
using BD_Auction_Inc.BusinessLogic;

namespace BD_Auction_inc.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult AllProducts() {

            AllProductsLoad APL = new AllProductsLoad
            {
                productList = AuctionProccessor.LoadAllProduct()
            };



            return View(APL);
        }

        public ActionResult AllAuction() {

            AllAuctionLoad AAL = new AllAuctionLoad
            {
                AuctionList = AuctionProccessor.LoadAllAuctions()
            };

            return View(AAL);
        }
    }
}