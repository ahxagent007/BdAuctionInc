using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD_Auction_inc.Models
{
    public class AuctionEventModel
    {
        public int AuctionID { get; set; }
        public string AuctionTitle { get; set; }
        public string AuctionDescription { get; set; }
        public int TotalProducts { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string AuctionMainPicture { get; set; }
        public string AuctionStatus { get; set; }
    }
}