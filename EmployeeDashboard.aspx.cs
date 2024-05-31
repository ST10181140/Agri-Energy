using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace AgriEnergy
{
    public partial class EmployeeDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFarmers();
            }
        }

        protected void btnAddFarmer_Click(object sender, EventArgs e)
        {
            // Retrieve farmer details from form inputs
            string farmerName = txtFarmerName.Text;
            string farmerSurname = txtFarmerSurname.Text;
            string farmerEmail = txtFarmerEmail.Text;
            string farmerAddress = txtFarmerAddress.Text;
            string farmerPhone = txtFarmerPhone.Text;
            string farmerPassword = txtFarmerPassword.Text;
            DateTime dateOfBirth = DateTime.Parse(txtDateOfBirth.Text); 
            DateTime joinDate = DateTime.Parse(txtJoinDate.Text); 

            // Add the farmer to the database
            AddFarmerToDatabase(farmerName, farmerSurname, farmerEmail, farmerAddress, farmerPhone, farmerPassword, dateOfBirth, joinDate);
        }

        protected void ddlFarmers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int farmerID = Convert.ToInt32(ddlFarmers.SelectedValue);
            LoadFarmerProducts(farmerID);
        }

        private void LoadFarmers()
        {
            // Connection string
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AgriconnectionString"].ConnectionString;
            // SQL query to retrieve farmers
            string query = "SELECT farmerID, farmerName FROM Farmer";

            // Create connection and command objects
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    // Bind farmers to dropdown list
                    ddlFarmers.DataSource = reader;
                    ddlFarmers.DataTextField = "farmerName";
                    ddlFarmers.DataValueField = "farmerID";
                    ddlFarmers.DataBind();
                    ddlFarmers.Items.Insert(0, new ListItem("-- Select Farmer --", "0"));
                    reader.Close();
                }
            }
        }

        private void LoadFarmerProducts(int farmerID)
        {
            // Connection string
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AgriconnectionString"].ConnectionString;
            // SQL query to retrieve products for the selected farmer
            string query = "SELECT ProductName, Category, ProductionDate, ProductDescription, Price, Quantity, ExpirationDate, FarmerID FROM Product WHERE FarmerID = @FarmerID";

            // Create connection and command objects
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FarmerID", farmerID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        // Fill data table with product data
                        da.Fill(dt);
                        gvFarmerProducts.DataSource = dt;
                        gvFarmerProducts.DataBind();
                    }
                }
            }
        }

        private void AddFarmerToDatabase(string farmerName, string farmerSurname, string farmerEmail, string farmerAddress, string farmerPhone, string farmerPassword, DateTime dateOfBirth, DateTime joinDate)
        {
            // Connection string
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AgriconnectionString"].ConnectionString;
            // SQL INSERT statement to add a new farmer to the database
            string query = "INSERT INTO Farmer (FarmerName, FarmerSurname, FarmerEmail, FarmerPassword, FarmerAddress, Phone, DateOfBirth, JoinDate) VALUES (@FarmerName, @FarmerSurname, @FarmerEmail, @FarmerPassword, @FarmerAddress, @Phone, @DateOfBirth, @JoinDate)";

            // Create connection and command objects
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@FarmerName", farmerName);
                    cmd.Parameters.AddWithValue("@FarmerSurname", farmerSurname);
                    cmd.Parameters.AddWithValue("@FarmerEmail", farmerEmail);
                    cmd.Parameters.AddWithValue("@FarmerPassword", farmerPassword);
                    cmd.Parameters.AddWithValue("@FarmerAddress", farmerAddress);
                    cmd.Parameters.AddWithValue("@Phone", farmerPhone);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@JoinDate", joinDate);

                    try
                    {
                        // Open connection
                        con.Open();
                        // Execute INSERT query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Farmer added successfully
                            lblAddFarmerMessage.Text = "Farmer added successfully!";
                        }
                        else
                        {
                            // Failed to add farmer
                            lblAddFarmerMessage.Text = "Failed to add farmer!";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        lblAddFarmerMessage.Text = "An error occurred while adding farmer: " + ex.Message;
                    }
                }
            }
        }
    }
}