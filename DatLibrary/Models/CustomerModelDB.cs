using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class CustomerModelDB
    {

        public int cID { get; set; }
        public string cNumber { get; set; }
        public string cName { get; set; }
        public string cAddress { get; set; }
        public string cEmail { get; set; }
        public string cNID { get; set; }
        public double cRating { get; set; }
        public int BidLimit { get; set; }
        public string VarificationStatus { get; set; }


    }
}
