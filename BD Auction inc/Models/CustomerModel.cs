using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BD_Auction_inc.Models
{
    public class CustomerModel {

        public int cID { get; set; }


        //[Range(1000000000,99999999999, ErrorMessage = "Non_Valid Mobile NUmber")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "NOT_VALID")]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter your Phone number")]
        public string cNumber { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter your Name")]
        public string cName { get; set; }

        [Display(Name = "Detail Home Address")]
        [Required(ErrorMessage = "Please enter your Address")]
        public string cAddress { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter your Email Address")]
        public string cEmail { get; set; }

        [Display(Name = "Nationnal ID No.")]
        [Required(ErrorMessage = "Please enter your NID number")]
        public string cNID { get; set; }

        [Display(Name = "Rating")]
        public double cRating { get; set; }

        [Display(Name = "Bid Limit")]
        public int BidLimit { get; set; }
        public string VarificationStatus { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password doesn't match")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength =6)]
        [Display(Name ="Re-write Password")]
        public string ConfirmPassword { get; set; }


    }
}