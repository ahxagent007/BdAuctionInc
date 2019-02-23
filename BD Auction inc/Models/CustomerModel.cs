using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD_Auction_inc.Models
{
    public class CustomerModel{

        private int cID { get; set; }
        private string cNumber { get; set; }
        private string cName { get; set; }
        private string cAddress { get; set; }
        private string cEmail { get; set; }
        private string cNID { get; set; }
        private int cRating { get; set; }
        private int BidLimit { get; set; }
        private string VarificationStatus { get; set; }

    }
}