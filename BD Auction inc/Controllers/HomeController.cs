using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD_Auction_inc.Models;
using DataLibrary;
using DataLibrary.BusinessLogic;

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

            return RedirectToAction("Index","Action");
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
            model.cID = 69;
            model.BidLimit = 50000;
            model.VarificationStatus = "NEW";
            model.cRating = 0.0;

            if (ModelState.IsValid) {

                int recordCreated = CustomerProcessor.CreateCustomer(model.cName,model.cNumber, model.cAddress, model.cEmail,model.cNID, model.cRating,model.BidLimit,model.VarificationStatus);

                return RedirectToAction("Index");
                
            }

            return View();
        }
    }
}