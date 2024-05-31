using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgriEnergy
{
   
        public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
            }

            protected void btnFarmer_Click(object sender, EventArgs e)
            {
                // Redirect to Farmer login page
                Response.Redirect("FarmerLogin.aspx");
            }

            protected void btnEmployee_Click(object sender, EventArgs e)
            {
                // Redirect to Employee login page
                Response.Redirect("EmployeeLogin.aspx");
            }
        }
    }

