using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace CSE345Website
{
    public partial class UserInfo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateTables();
            }
        }
        protected void Register_Clicked(object sender, EventArgs e)
        {

        }
        public void populateTables()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = "Server = tcp:cit345.database.windows.net,1433;" +
                                        "Initial Catalog = CSE345;" +
                                        "Persist Security Info = False;" +
                                        "User ID = afdanaj;" +
                                        "Password = Temp12345;" +
                                        "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                conn.Open();
                SqlCommand sqlStudent = new SqlCommand();
                sqlStudent.CommandText = "SELECT * FROM Student WHERE STUD_ID=@id;";
                sqlStudent.Parameters.AddWithValue("@id", (int)Session["Id"]);


                sqlStudent.Connection = conn;
                SqlDataReader reader = sqlStudent.ExecuteReader();
                while (reader.Read())
                {

                }
                reader.Close();
                sqlStudent.Dispose();
            }
            catch (Exception k)
            {
                // Response.Write(k.Message);
                //throw;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}