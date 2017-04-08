using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE345Website
{
    public partial class Classifieds : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTable();

                if (string.IsNullOrEmpty((string)Session["User"]))
                {
                    createPosting.Visible = false;
                }
            }
        }

        void BindTable()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = "Server = tcp:cit345.database.windows.net,1433;" +
                                    "Initial Catalog = CSE345;" +
                                    "Persist Security Info = False;" +
                                    "User ID = afdanaj;" +
                                    "Password = Temp12345;" +
                                    "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT POST_CATEGORY,POST_TITLE,POST_DESCRIPTION,POST_DATE_POSTED,POST_CONTACT_INFO FROM POSTING;", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                ClassifiedsGrid.DataSource = ds;
                ClassifiedsGrid.DataBind();
            }
            finally
            {
                con.Close();
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = "Server = tcp:cit345.database.windows.net,1433;" +
                                    "Initial Catalog = CSE345;" +
                                    "Persist Security Info = False;" +
                                    "User ID = afdanaj;" +
                                    "Password = Temp12345;" +
                                    "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO POSTING (POST_CATEGORY, POST_TITLE, POST_DESCRIPTION, POST_CONTACT_INFO, POST_DATE_POSTED, POST_EXPIRE_DATE, POST_STATE, POST_STUD_ID)" +
                    "VALUES (@category, @title, @descrip, @contact, @createDate, @expireDate, @state, @studId);", con);
                cmd.Parameters.AddWithValue("@category", CategorySelector.SelectedValue);
                cmd.Parameters.AddWithValue("@title", TitleInput.Text);
                cmd.Parameters.AddWithValue("@descrip", DescripInput.Text);
                cmd.Parameters.AddWithValue("@contact", ContactInput.Text);
                cmd.Parameters.AddWithValue("@createDate", DateTime.Today);
                cmd.Parameters.AddWithValue("@expireDate", DateTime.Today.AddDays(90));
                cmd.Parameters.AddWithValue("@state", 0);
                cmd.Parameters.AddWithValue("@studId", Session["ID"]);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
    }
}