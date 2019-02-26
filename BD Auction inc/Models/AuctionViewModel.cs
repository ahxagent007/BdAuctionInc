using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD_Auction_inc.Models
{
    public class AuctionViewModel
    {

        public List<AuctionEventModel> upcommingAuctions { get; set; }
        public List<AuctionEventModel> runningAuctions { get; set; }
        public List<AuctionEventModel> pastAuctions { get; set; }

    }
}