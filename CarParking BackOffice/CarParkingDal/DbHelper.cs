using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using CarParkingData;

namespace CarParkingDAL
{
    public class DbHelper
    {
        public static IDbConnection getSqlConnection()
        {
            IDbConnection db = null;
            try
            {
                var connectionStr = ConfigurationManager.ConnectionStrings["ParkingDBEntities"].ConnectionString;
                db = new SqlConnection(connectionStr);
            }
            catch (Exception ex)
            {

            }
            return db;
        }

        public static string getSqlConnectionStr()
        {
            string connectionStr = null;
            try
            {
                connectionStr = ConfigurationManager.ConnectionStrings["ParkingDBEntities"].ConnectionString;
            }
            catch (Exception ex)
            {

            }
            return connectionStr;
        }
    }
}
