using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD_Auction_inc.Models;

namespace BD_Auction_Inc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(){
            return View();
        }

        public ActionResult About(){
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Auctions(){

            return View();
        }


        public ActionResult Seller(){

            return View();
        }


        public ActionResult News()
        {

            return View();
        }


        public ActionResult SignUp()
        {
            ViewBag.Message = "USER SIGN UP";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(CustomerModel model)
        {
            if (ModelState.IsValid) {
                return RedirectToAction("Index");
                //VDO 33.12 min
            }

            return View();
        }
    }
}