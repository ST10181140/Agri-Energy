using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace AgriEnergy
{
    public partial class FarmerLogin : Page
    {
        // Database connection string
        private string connectionString = "Server=tcp:aneesaserver.database.windows.net,1433;Initial Catalog=agri-energy;Persist Security Info=False;User ID=aneesaisaacs;Password=Ai-110602;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Clear any previous error messages
                lblMessage.Text = "";

                // Check if the user is already authenticated (optional)
                if (User.Identity.IsAuthenticated)
                {
                    // Redirect to the dashboard or another authorized page
                    Response.Redirect("~/FarmerDashboard.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Perform authentication logic here
            bool isAuthenticated = AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                // Retrieve the FarmerID from the database based on the username
                string farmerID = GetFarmerID(username);

                if (!string.IsNullOrEmpty(farmerID))
                {
                    // Store the FarmerID in the session
                    Session["FarmerID"] = farmerID;

                    // Redirect to the dashboard upon successful login
                    Response.Redirect("~/FarmerDashboard.aspx");
                }
                else
                {
                    lblMessage.Text = "Failed to retrieve FarmerID. Please try again.";
                }
            }
            else
            {
                // Display error message if authentication fails
                lblMessage.Text = "Invalid username or password. Please try again.";
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Query to retrieve user information based on username and password
            string query = "SELECT COUNT(*) FROM Farmer WHERE farmerEmail = @Username AND farmerPassword = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Parameters to the command to prevent SQL injection
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();

                        int count = (int)command.ExecuteScalar();

                        // If the count is greater than 0, it means the user exists in the database
                        // and the provided username and password are correct
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        // Log any exceptions that occur during database interaction
                        lblMessage.Text = "An error occurred while authenticating user.";
                        Console.WriteLine("Error authenticating user: " + ex.Message);
                        return false; // Return false in case of any error
                    }
                }
            }
        }

        // Method to retrieve FarmerID based on username
        private string GetFarmerID(string username)
        {
            string farmerID = "";

            // Query to retrieve FarmerID based on username
            string query = "SELECT FarmerID FROM Farmer WHERE farmerEmail = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        connection.Open();

                        // Execute the query and retrieve the FarmerID
                        object result = command.ExecuteScalar();

                        // Check if FarmerID is retrieved
                        if (result != null)
                        {
                            farmerID = result.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log any exceptions that occur during database interaction
                        Console.WriteLine("Error retrieving FarmerID: " + ex.Message);
                    }
                }
            }

            return farmerID;
        }
    }
}