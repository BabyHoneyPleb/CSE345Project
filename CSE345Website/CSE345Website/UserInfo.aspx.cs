using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CSE345Website
{
    public partial class UserInfo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string)Session["User"])){
                Response.Redirect("~/SignIn");
            }
            else if (!IsPostBack)
            {
                populateTextBoxs();
            }
        }
        public void populateTextBoxs()
        {
            // string error = "";
            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Server = tcp:cit345.database.windows.net,1433;" +
                                        "Initial Catalog = CSE345;" +
                                        "Persist Security Info = False;" +
                                        "User ID = afdanaj;" +
                                        "Password = Temp12345;" +
                                        "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                conn.Open();

                SqlCommand sqlStudent = new SqlCommand();
                sqlStudent.CommandText = "SELECT * FROM Student WHERE STUD_ID=@id";
                sqlStudent.Parameters.AddWithValue("@id", (int)Session["Id"]);
              

                sqlStudent.Connection = conn;
                SqlDataReader reader = sqlStudent.ExecuteReader();

                while (reader.Read())
                {
                    gID.Text = "G" + ((int)Session["Id"]).ToString().PadLeft(8,'0');
                    fName.Text = reader.GetString(1);
                    lName.Text = reader.GetString(2);
                    areaCode.Text = reader.GetValue(3).ToString();
                    phone.Text = reader.GetValue(4).ToString();
                    email.Text = reader.GetString(11);
                 
                    street.Text = reader.GetString(5);
                    
                  
                    city.Text = reader.GetString(6);
                    state.Text = reader.GetString(7);
                    zipcode.Text = reader.GetValue(8).ToString();
                    standing.Text = reader.GetString(9);
                    major.Text = reader.GetString(10);
                   

                }

                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
        protected void Contact_Clicked (object sender, EventArgs e)
        {

            // string error = "";
            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Server = tcp:cit345.database.windows.net,1433;" +
                                        "Initial Catalog = CSE345;" +
                                        "Persist Security Info = False;" +
                                        "User ID = afdanaj;" +
                                        "Password = Temp12345;" +
                                        "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                conn.Open();

                SqlCommand sqlStudent = new SqlCommand();
                sqlStudent.CommandText = "UPDATE Student SET STUD_FNAME=@fname, STUD_LNAME=@lname, STUD_AREA_CODE=@area, STUD_PHONE=@phone, STUD_EMAIL=@email " +
                                           "WHERE STUD_ID=@id;";
                sqlStudent.Parameters.AddWithValue("@id", (int)Session["Id"]);
                sqlStudent.Parameters.AddWithValue("@fname", fName.Text);
                sqlStudent.Parameters.AddWithValue("@lname", lName.Text);
                sqlStudent.Parameters.AddWithValue("@area", areaCode.Text);
                sqlStudent.Parameters.AddWithValue("@phone", phone.Text);
                sqlStudent.Parameters.AddWithValue("@email", email.Text);
    
                sqlStudent.Connection = conn;
                sqlStudent.ExecuteNonQuery();

              

                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
        protected void About_Clicked(object sender, EventArgs e)
        {
            // string error = "";
            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Server = tcp:cit345.database.windows.net,1433;" +
                                        "Initial Catalog = CSE345;" +
                                        "Persist Security Info = False;" +
                                        "User ID = afdanaj;" +
                                        "Password = Temp12345;" +
                                        "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                conn.Open();

                SqlCommand sqlStudent = new SqlCommand();
                sqlStudent.CommandText = "UPDATE Student SET STUD_STREET=@street, STUD_CITY=@city, STUD_STATE=@state, STUD_ZIPCODE=@zip, STUD_STANDING=@standing, STUD_MAJOR=@major " +
                                           "WHERE STUD_ID=@id;";
                sqlStudent.Parameters.AddWithValue("@id", (int)Session["Id"]);
                sqlStudent.Parameters.AddWithValue("@street", street.Text);
                sqlStudent.Parameters.AddWithValue("@city", city.Text);
                sqlStudent.Parameters.AddWithValue("@state", state.Text);
                sqlStudent.Parameters.AddWithValue("@zip", zipcode.Text);
                sqlStudent.Parameters.AddWithValue("@standing", standing.Text);
                sqlStudent.Parameters.AddWithValue("@major", major.Text);

                sqlStudent.Connection = conn;
                sqlStudent.ExecuteNonQuery();



                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

            }
        }


    }
}