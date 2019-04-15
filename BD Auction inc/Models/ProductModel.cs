using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BD_Auction_inc.Models
{
    public class ProductModel
    {

        public int pID { get; set; }

        [Display(Name = "Product Name")]
        public string pName { get; set; }

        [Display(Name = "Product Description")]
        public string pDescription { get; set; }

        [Display(Name = "Product Catagoy")]
        public string pCatagory { get; set; }

        [Display(Name = "Starting Price")]
        public int pStartingPrice { get; set; }

        public int CurrentBid { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string PictureID { get; set; }

        public string ProductMainPicture { get; set; }

        public int SellerID { get; set; }

        public string ProductStatus { get; set; }

        public HttpPostedFileBase ImageFile {get; set;}

    }
}