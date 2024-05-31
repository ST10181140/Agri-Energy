using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace AgriEnergy
{
    public partial class EmployeeLogin : Page
    {
        // Database connection string
        private string connectionString = "Server=tcp:aneesaserver.database.windows.net,1433;Initial Catalog=agri-energy;Persist Security Info=False;User ID=aneesaisaacs;Password=Ai-110602;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // Authenticate method to check credentials against the database
        private bool Authenticate(string username, string password)
        {
            // Query to retrieve user information based on username and password
            string query = "SELECT COUNT(*) FROM Employee WHERE employeeUsername = @Username AND employeePassword = @Password";

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

                     
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                       
                        Console.WriteLine("Error authenticating user: " + ex.Message);
                        return false; 
                    }
                }
            }

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Get the username and password from the input fields
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Authenticate the user
            bool isAuthenticated = Authenticate(username, password);

            // Redirect based on authentication result
            if (isAuthenticated)
            {
                // Redirect to the employee dashboard page upon successful login
                Response.Redirect("EmployeeDashboard.aspx");
            }
            else
            {
                // Display error message if authentication fails
                lblMessage.Text = "Invalid username or password";
            }
        }


    }
}
