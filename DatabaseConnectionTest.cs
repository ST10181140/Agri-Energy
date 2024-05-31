using System;
using System.Data.SqlClient;

namespace AgriEnergy
{
    public class DatabaseConnectionTest
    {
        private readonly string connectionString;

        public DatabaseConnectionTest(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool TestConnection()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    return true; // Connection successful
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error testing database connection: " + ex.Message);
                return false; // Connection failed
            }
        }
    }
}
