using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD_Auction_inc.Models
{
    public class RunningAuctionViewModel
    {
        public List<AuctionEventModel> AuctionEventList = new List<AuctionEventModel>();
        public List<ProductModel> PoductList = new List<ProductModel>();
    }
}