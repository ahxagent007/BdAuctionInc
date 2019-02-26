using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD_Auction_inc.Models
{
    public class ProductsInAuctionModel
    {
        public int pID { get; set; }
        public int acutionID { get; set; }
        public string status { get; set; }
    }
}