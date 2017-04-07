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

                    if (txtPass.Text.Equals(txtConfirm.Text))
                    {

                        if (txtUser.Text.StartsWith("G") && txtUser.Text.Length == 9)
                        {

                            if (txtEmail.Text.Contains("@"))
                            {

                                if (txtPhoneNumber.Text.Length == 10)
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

                                    SqlCommand sqlStudent = new SqlCommand();
                                    sqlStudent.CommandText = "INSERT INTO Student (STUD_ID, STUD_FNAME, STUD_LNAME, STUD_AREA_CODE, STUD_PHONE, STUD_EMAIL) " +
                                                              "VALUES (@id, @fname, @lname, @area, @phone, @email);";
                                    sqlStudent.Parameters.AddWithValue("@id", id_num);
                                    sqlStudent.Parameters.AddWithValue("@fname", txtFName.Text);
                                    sqlStudent.Parameters.AddWithValue("@lname", txtLName.Text);
                                    sqlStudent.Parameters.AddWithValue("@area", txtPhoneNumber.Text.Substring(0, 3));
                                    sqlStudent.Parameters.AddWithValue("@phone", txtPhoneNumber.Text.Substring(3, 7));
                                    sqlStudent.Parameters.AddWithValue("@email", txtEmail.Text);

                                    sqlStudent.Connection = conn;
                                    sqlStudent.ExecuteNonQuery();


                                    SqlCommand sqlAccount = new SqlCommand();
                                    sqlAccount.CommandText = "INSERT INTO Account (STUD_ID, STUD_EMAIL, ACC_PASSWORD, ACC_DATE_REG) " +
                                                              "VALUES(@id, @email, @password, @date);";
                                    sqlAccount.Parameters.AddWithValue("@id", id_num);
                                    sqlAccount.Parameters.AddWithValue("@email", txtEmail.Text);
                                    sqlAccount.Parameters.AddWithValue("@password", txtPass.Text);
                                    sqlAccount.Parameters.AddWithValue("@date", DateTime.Now);
                                    sqlAccount.Connection = conn;
                                    sqlAccount.ExecuteNonQuery();
                                   

                                    Session["ID"] = id_num;
                                   

                                    string fName = txtFName.Text;
                                    string lName = txtLName.Text;
                                    Session["User"] = fName + " " + lName;
                                    Session["UserStatus"] = "Sign Out";
                                    conn.Close();
                                    Response.Redirect("~/Default");


                                }//Phone
                                else
                                {

                                }


                            } // Email
                            else
                            {

                            }

                        } // Grizz ID
                        else
                        {

                        }
                    } // Password Match
                    else
                    {

                    }
                } // Empty fields
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
