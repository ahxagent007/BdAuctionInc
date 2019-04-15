using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD_Auction_inc.Models;
using BD_Auction_Inc.BusinessLogic;
using BD_Auction_Inc.Models;

namespace BD_Auction_inc.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult AllProducts()
        {

            AllProductsLoad APL = new AllProductsLoad
            {
                productList = AuctionProccessor.LoadAllProduct()
            };

            return View(APL);
        }
        public ActionResult RequestedProducts()
        {

            RequestedProductsViewModel RPVM = new RequestedProductsViewModel
            {
                productList = AuctionProccessor.LoadAllRequestedProduct(),
                upcommingAuctions = AuctionProccessor.GetAuctionByStatus("UPCOMING")
            };

            return View(RPVM);
        }

        [HttpPost]
        public ActionResult RequestedProducts(RequestedProductsViewModel RPVM)
        {
            string AuctionID = RPVM.SelectedAuctionAndProduct;

            string[] tokens = AuctionID.Split(':');

            int PID = Convert.ToInt32(tokens[0]);
            int AID = Convert.ToInt32(tokens[1]);

            System.Diagnostics.Debug.WriteLine("AUCTION ID = "+AuctionID);

            AuctionProccessor.addProductToAuction(AID, PID);
            List<AuctionEventModel> Auction = AuctionProccessor.GetAuctionByID(AID);

            AuctionProccessor.updateProductData(Auction[0].StartTime, Auction[0].EndTime, PID);


            return Redirect("/Admin/RequestedProducts");

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
                    PoductList = AuctionProccessor.GetProductsByAuctionID(ID)
                };
                
                return View(RAM);

            }
            else {
                return View();
            }

            
        }

        // [Authorize(Roles = "Admin")]
        public ActionResult CreateAuction()
        {


            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAuction(AuctionEventModel AEM)
        {
            AEM.AuctionMainPicture = "-__-";
            AEM.AuctionID = 0;
            AEM.TotalProducts = 0;
            

            if (ModelState.IsValid)
            {

                string fileName = Path.GetFileNameWithoutExtension(AEM.ImageFile.FileName);
                string extension = Path.GetExtension(AEM.ImageFile.FileName);
                fileName = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + extension;

                AEM.AuctionMainPicture = "~/img/upload/auction/" + fileName;

                fileName = Path.Combine(Server.MapPath("~/img/upload/auction/"), fileName);

                AEM.ImageFile.SaveAs(fileName);

                AEM.StartTime = dateTimeCorrection(AEM.StartTime);
                AEM.EndTime = dateTimeCorrection(AEM.EndTime);

                int row = AuctionProccessor.createAuction(AEM.AuctionTitle, AEM.AuctionDescription, AEM.StartTime, AEM.EndTime, AEM.TotalProducts, AEM.AuctionStatus, AEM.AuctionMainPicture);
            }
                

            return View();
        }


        public string dateTimeCorrection(string dateTime) {

            return dateTime.Replace('T', ' '); ;


        }


        //$qry = "SELECT * FROM fanciers ORDER BY FancierName ASC LIMIT ".$rowFrom.", ".$rowTo.";";
    }
}