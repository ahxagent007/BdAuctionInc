using BD_Auction_inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD_Auction_Inc.BusinessLogic;

namespace BD_Auction_inc.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RequestProduct() {

            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestProduct(ProductModel model){

            model.ProductStatus = "REQUESTING";

            if (ModelState.IsValid){

                int recordCreated = AuctionProccessor.RequestProductForAuction(model);

                return RedirectToAction("Index");

            }

            return View();
        }
    }
}