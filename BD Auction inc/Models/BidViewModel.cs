using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD_Auction_inc.Models
{
    public class BidViewModel
    {

        public string cName { get; set; }
        public int BidAmount { get; set; }
        public string BidTime { get; set; }
    }
}