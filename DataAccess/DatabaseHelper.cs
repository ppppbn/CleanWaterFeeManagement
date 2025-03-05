using System;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace CleanWaterFeeManagement.DataAccess
{
    public class DatabaseHelper
    {
        // Read the connection string from App.config
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Method to get a SQL connection
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
