using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace AgriEnergy
{
    public partial class FarmerDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateFarmerDetails();
                LoadFarmerProducts();
            }
        }

        // Method to populate farmer-specific information
        private void PopulateFarmerDetails()
        {
            // Check if FarmerID session variable exists
            if (Session["FarmerID"] != null)
            {
                // Retrieve FarmerID from session
                string farmerID = Session["FarmerID"].ToString();

                // Database query to fetch farmer details
                string query = "SELECT FarmerName, FarmerEmail, FarmerAddress, phone FROM Farmer WHERE FarmerID = @FarmerID";
                string connectionString = "Server=tcp:aneesaserver.database.windows.net,1433;Initial Catalog=agri-energy;Persist Security Info=False;User ID=aneesaisaacs;Password=Ai-110602;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for FarmerID
                        command.Parameters.AddWithValue("@FarmerID", farmerID);

                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();

                            // Check if data is retrieved
                            if (reader.Read())
                            {
                                // Set the retrieved data to the corresponding labels
                                lblFarmerName.Text = reader["FarmerName"].ToString();
                                lblFarmerEmail.Text = reader["FarmerEmail"].ToString();
                                lblFarmerAddress.Text = reader["FarmerAddress"].ToString();

                            }

                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception
                            lblMessage.Text = "An error occurred while retrieving farmer details.";
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                // FarmerID session variable is not set, redirect to login page
                Response.Redirect("FarmerLogin.aspx");
            }
        }

        // Method to load farmer's products
        private void LoadFarmerProducts()
        {
            // Check if FarmerID session variable exists
            if (Session["FarmerID"] != null)
            {
                string farmerID = Session["FarmerID"].ToString();

                string query = "SELECT ProductName, Category, ProductionDate, ProductDescription, Price, Quantity, ExpirationDate FROM Product WHERE FarmerID = @FarmerID";
                string connectionString = "Server=tcp:aneesaserver.database.windows.net,1433;Initial Catalog=agri-energy;Persist Security Info=False;User ID=aneesaisaacs;Password=Ai-110602;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FarmerID", farmerID);
                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();

                            gvProducts.DataSource = reader;
                            gvProducts.DataBind();

                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            lblMessage.Text = "An error occurred while loading farmer's products.";
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                // FarmerID session variable is not set, redirect to login page
                Response.Redirect("FarmerLogin.aspx");
            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Redirect the farmer to the Add Product page
            Response.Redirect("AddProduct.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear the session and redirect the farmer to the login page
            Session.Clear();
            Response.Redirect("FarmerLogin.aspx");
        }
    }
}
