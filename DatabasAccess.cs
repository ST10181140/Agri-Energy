using System;
using System.Data;
using System.Data.SqlClient;

namespace AgriEnergy
{
    public class DatabasAccess
    {
        private readonly string connectionString;

        public DatabasAccess(string connectionString)
        {
            // Initialize the connection string
            this.connectionString = connectionString;
        }

        // Method to retrieve products for a specific farmer from the database
        public DataTable GetProductsForFarmer(int farmerId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products WHERE FarmerId = @FarmerId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FarmerId", farmerId);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Method to add a new product to the database
        public void AddProduct(int farmerId, string productName, string category, DateTime productionDate)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Products (FarmerId, ProductName, Category, ProductionDate) VALUES (@FarmerId, @ProductName, @Category, @ProductionDate)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FarmerId", farmerId);
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@ProductionDate", productionDate);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
