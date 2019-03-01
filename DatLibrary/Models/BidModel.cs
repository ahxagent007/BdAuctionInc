using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLibrary.Models
{
    public class BidModel
    {
        public int BidID { get; set; }
        public int cID { get; set; }
        public int pID { get; set; }
        public int auctionID { get; set; }
        public int BidAmount { get; set; }
        public string BidTime { get; set; }
    }
}