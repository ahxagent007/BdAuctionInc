using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BD_Auction_Inc.DataAccess
{
    public static class SqlDataAccess
    {
        public static string getConnectionString(string connectionName = "AuctionDB") {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql) {

            using (IDbConnection cnn = new SqlConnection(getConnectionString())) {
                return cnn.Query<T>(sql).ToList();
            }

        }

        public static int SaveData<T>(string sql, T data) {

            using (IDbConnection cnn = new SqlConnection(getConnectionString()))
            {
                return cnn.Execute(sql, data);
            }

        }

      

    }
}
