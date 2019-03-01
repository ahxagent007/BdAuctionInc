using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLibrary.Models
{
    public class AuctionEventModel
    {
        public int auctionID { get; set; }
        public string auctionTitle { get; set; }
        public string auctionDescription { get; set; }
        public int totalProduct { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string auctionMainPicture { get; set; }
        public string auctionStatus { get; set; }
    }
}