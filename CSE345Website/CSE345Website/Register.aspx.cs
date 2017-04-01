using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace CSE345Website
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Register_Clicked(object sender, EventArgs e)
        {
            // string error = "";
            try
            {
                
                if (!string.IsNullOrEmpty(txtUser.Text) || !string.IsNullOrEmpty(txtPass.Text) || !string.IsNullOrEmpty(txtConfirm.Text) 
                    || !string.IsNullOrEmpty(txtFName.Text) || !string.IsNullOrEmpty(txtLName.Text) || !string.IsNullOrEmpty(txtPhoneNumber.Text))
                {
                    if (txtUser.Text.StartsWith("G") && txtUser.Text.Length == 9)
                    {
                        int id_num = int.Parse(txtUser.Text.Replace("G", ""));
                        SqlConnection conn = new SqlConnection();
                        conn.ConnectionString = "Server = tcp:cit345.database.windows.net,1433;" +
                                                "Initial Catalog = CSE345;" +
                                                "Persist Security Info = False;" +
                                                "User ID = afdanaj;" +
                                                "Password = Temp12345;" +
                                                "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                        conn.Open();
                        SqlCommand sqlAccount = new SqlCommand();
                        sqlAccount.CommandText = "INSERT INTO Account WHERE STUD_ID=@value1 AND ACC_PASSWORD=@value2;";
                        sqlAccount.Parameters.AddWithValue("@value1", id_num);
                        sqlAccount.Parameters.AddWithValue("@value2", txtPass.Text);
                        sqlAccount.Connection = conn;
                        SqlDataReader readerAccount = sqlAccount.ExecuteReader();
                        int count = 0;
                        while (readerAccount.Read())
                        {
                            count++;
                        }
                        readerAccount.Close();
                        if (count == 1)
                        {
                            Session["ID"] = id_num;
                            SqlCommand sqlStudent = new SqlCommand();
                            sqlStudent.CommandText = "SELECT * FROM Student WHERE STUD_ID=@value1;";
                            sqlStudent.Parameters.AddWithValue("@value1", id_num);
                            sqlStudent.Connection = conn;
                            SqlDataReader readerStudent = sqlStudent.ExecuteReader();
                            while (readerStudent.Read())
                            {
                                string fName = readerStudent.GetString(1);
                                string lName = readerStudent.GetString(2);
                                Session["User"] = fName + " " + lName;
                                Session["UserStatus"] = "Sign Out";
                                Response.Redirect("~/Default");
                            }
                            readerStudent.Close();
                        }
                        else
                        {

                        }

                        conn.Close();
                    }
                    else
                    {

                    }
                }
                else
                {

                }

            }
            catch (Exception ex)
            {

            }
        }
    }
       
    }
