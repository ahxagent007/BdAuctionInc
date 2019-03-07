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


        public void AddProductToAuction(int AucID, int ProID) {
            int res = AuctionProccessor.addProductToAuction(AucID, ProID);
            
        }

        public ActionResult MemberList() {

            MemberViewModel MVM = new MemberViewModel {
                customerList = AuctionProccessor.GetAllMembers()
            };

            return View(MVM);
        }

        public ActionResult RunningAuction(int ID) {

            if (AuctionProccessor.GetAuctionByID(ID).Count > 0)
            {
                RunningAuctionViewModel RAM = new RunningAuctionViewModel {
                    AuctionEventList = AuctionProccessor.GetAuctionByID(ID),
                    PoductList = AuctionProccessor.GetProductByAuctionID(ID)
                };
                
                return View(RAM);

            }
            else {
                return View();
            }

            
        }
    }
}