using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class CustomerProcessor
    {

        public static int CreateCustomer(string name, string number, string address, string email, string NID, double rating,int bidLimit, string varificationStatus)
        {

            CustomerModelDB data = new CustomerModelDB
            {
                cName = name,
                cNumber = number,
                cAddress = address,
                cEmail = email,
                cNID = NID,
                cRating = rating,
                BidLimit = bidLimit,
                VarificationStatus = varificationStatus
            };

            string sql = @"INSERT INTO dbo.Customer (cName, cNumber, cAddress, cEmail, cNID, cRating, BidLimit, VarificationStatus)
                VALUES(@cName, @cNumber, @cAddress, @cEmail, @cNID, @cRating,@BidLimit, @VarificationStatus)";

            return SqlDataAccess.SaveData(sql, data);

        }

        public static List<CustomerModelDB> LoadCustomers() {

            string sql = @"SELECT cID, cName, cAddress, cNID, cEmail, cRating, VarificationStatus FROM dbo.Customer";

            return SqlDataAccess.LoadData<CustomerModelDB>(sql); //VDO 59.36

        }

    }
}
