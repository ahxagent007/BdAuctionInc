using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLibrary.Models
{
    public class ProductModel
    {

        public int pID { get; set; }
        public string pName { get; set; }
        public string pDescription { get; set; }
        public string pcatagory { get; set; }
        public string pStartingPrice { get; set; }
        public string pCurrentBid { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string PictureID { get; set; }
        public string MainPicture { get; set; }
        public int SellerID { get; set; }
        public string status { get; set; }

    }
}