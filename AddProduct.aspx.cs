using System;
using System.Data.SqlClient;

namespace AgriEnergy
{
    public partial class AddProduct : System.Web.UI.Page
    {
        // Database connection string
        private string connectionString = "Server=tcp:aneesaserver.database.windows.net,1433;Initial Catalog=agri-energy;Persist Security Info=False;User ID=aneesaisaacs;Password=Ai-110602;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Get product details from the input fields
            string productName = txtProductName.Text;
            string category = txtCategory.Text;
            DateTime productionDate = DateTime.Parse(txtProductionDate.Text); 
            string description = txtDescription.Text;
            decimal price = decimal.Parse(txtPrice.Text);
            int quantity = int.Parse(txtQuantity.Text); 
            DateTime expirationDate = DateTime.Parse(txtExpirationDate.Text); 

            // Add the product to the database
            AddProductToDatabase(productName, category, productionDate, description, price, quantity, expirationDate);

      
            Response.Redirect("FarmerDashboard.aspx");
        }

        private void AddProductToDatabase(string productName, string category, DateTime productionDate, string description, decimal price, int quantity, DateTime expirationDate)
        {
            // Query to insert a new product into the database
            string query = "INSERT INTO Product (ProductName, Category, ProductionDate, ProductDescription, Price, Quantity, ExpirationDate) " +
                           "VALUES (@ProductName, @Category, @ProductionDate, @ProductDescription, @Price, @Quantity, @ExpirationDate)";

            // Create a SqlConnection and a SqlCommand
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command to prevent SQL injection
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@Category", category);
                    command.Parameters.AddWithValue("@ProductionDate", productionDate);
                    command.Parameters.AddWithValue("@ProductDescription", description);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@ExpirationDate", expirationDate);

                    // Open the connection, execute the command, and then close the connection
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that occur during database interaction
                        Console.WriteLine("Error adding product to database: " + ex.Message);
                        
                    }
                }
            }
        }
    }
}
