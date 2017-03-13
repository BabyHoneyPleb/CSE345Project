using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace CSE345Website
{
    public partial class SignIn : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SignIn_Clicked(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost;Initial Catalog=afdanaj;User id=afdanaj;Password=temp12345;";
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM CSE345_Students;";
                command.Connection = conn;
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch( Exception ex)
            {

            }

        }
    }
}