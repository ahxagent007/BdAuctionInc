using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD_Auction_inc.Models
{
    public class NewsModel
    {
        public int Id { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public String pnews_date { get; set; }
    }
}