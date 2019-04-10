using BD_Auction_inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD_Auction_Inc.BusinessLogic;
using System.IO;

namespace BD_Auction_inc.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RequestProduct() {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult RequestProduct(ProductModel model){

            model.ProductStatus = "REQUESTING";
            model.pID = 0;
            model.CurrentBid = 0;
            model.StartTime = null;
            model.EndTime = null;
            model.PictureID = null;
            model.SellerID = 1; //SELLER ID           

            if (ModelState.IsValid){

                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + extension;

                model.ProductMainPicture = "~/img/upload/products/" + fileName;

                fileName = Path.Combine(Server.MapPath("~/img/upload/products/"), fileName);

                model.ImageFile.SaveAs(fileName);

                /*<img src="@Url.Content(Model.ProductMainPicture)"/>*/

                int recordCreated = AuctionProccessor.RequestProductForAuction(model);

                return RedirectToAction("Index");

            }

            return View();
        }



    }
}