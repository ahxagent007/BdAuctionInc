using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD_Auction_inc.Models
{
    public class RequestedProductsViewModel
    {

        public List<ProductModel> productList { get; set; }
        public List<AuctionEventModel> upcommingAuctions { get; set; }

        public string SelectedAuctionAndProduct {get; set;}


    }
}