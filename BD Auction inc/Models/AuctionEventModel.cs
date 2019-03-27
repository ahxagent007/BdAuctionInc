using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BD_Auction_inc.Models
{
    public class AuctionEventModel
    {
        public int AuctionID { get; set; }
        [Display(Name = "Title")]
        public string AuctionTitle { get; set; }

        [Display(Name = "Description")]
        public string AuctionDescription { get; set; }

        [Display(Name = "Total Products")]
        public int TotalProducts { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        [Display(Name = "End Time")]
        public string EndTime { get; set; }

        [Display(Name = "Main Picture")]
        public string AuctionMainPicture { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public string AuctionStatus { get; set; }
    }
}