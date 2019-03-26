﻿using BD_Auction_inc.Models;
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

                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + extension;

                model.MainPicture = "~/img/upload/products/" + fileName;

                fileName = Path.Combine(Server.MapPath("~/img/upload/products/"), fileName);

                model.ImageFile.SaveAs(fileName);

                /*<img src="@Url.Content(Model.MainPicture)"/>*/

                int recordCreated = AuctionProccessor.RequestProductForAuction(model);

                return RedirectToAction("Index");

            }

            return View();
        }
    }
}