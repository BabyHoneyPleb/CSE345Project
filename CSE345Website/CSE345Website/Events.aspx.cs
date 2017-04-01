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
    public partial class Events : Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                BindBlog();

                if (string.IsNullOrEmpty((string)Session["User"]))
                {
                    creatEvent.Visible = false;
                }
            }
        }
        void BindBlog()
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Event WHERE EVENT_START_TIME >= @value1 ORDER BY EVENT_START_TIME;", conn);
                cmd.Parameters.AddWithValue("@value1", DateTime.Now);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
            
                DataSet ds = new DataSet();
                adp.Fill(ds);
                ds.Tables[0].Columns.Add("FormDate", typeof(string));
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DateTime date = (DateTime)ds.Tables[0].Rows[i]["EVENT_START_TIME"];

                    ds.Tables[0].Rows[i]["FormDate"] = formatDate(date);
                }
               
                GridView1.DataSource = ds;
                GridView1.DataBind();
                cmd.Dispose();
            }
            catch (Exception k)
            {
                Response.Write(k.Message);
                //throw;
            }
            finally
            {
                conn.Close();
            }

        }
        public string formatDate(DateTime newStart)
        {
            string dayOfWeek = newStart.DayOfWeek.ToString();
            string month = newStart.ToString("MMMM");
            string year = newStart.ToString("yyyy");
            string day = newStart.Day.ToString("d");


            return (dayOfWeek + ", " + month + " " + formatDay(newStart) + ", " + year + " at " + formatTime(newStart));

        }

        public string formatDay(DateTime dt)
        {
            string suffix;
            if (new[] { 11, 12, 13 }.Contains(dt.Day))
            {
                suffix = "th";
            }
            else if (dt.Day % 10 == 1)
            {
                suffix = "st";
            }
            else if (dt.Day % 10 == 2)
            {
                suffix = "nd";
            }
            else if (dt.Day % 10 == 3)
            {
                suffix = "rd";
            }
            else
            {
                suffix = "th";
            }
            return dt.Day.ToString("d") + suffix;
        }
        public string formatTime(DateTime dt)
        {
            string suffix;
            string hour;

            if (dt.Hour >= 12)
            {
                if (dt.Hour > 12) { 
                     hour = (dt.Hour - 12).ToString();
                }
                else
                {
                    hour = dt.Hour.ToString();
                }
                suffix = "PM";
            }
            else
            {
                if (dt.Hour == 0)
                {
                    hour = "12";
                }
                hour = dt.Hour.ToString();
                suffix = "AM";
            }
            return hour + ":" + dt.ToString("mm") + suffix;

        }
        protected void didSelectNewDate(object sender, EventArgs e)
        {
            txtSelectedDate.Text = cldEvents.SelectedDate.ToShortDateString();
        }
        protected void Submit_Clicked (object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("INSERT INTO Event (EVENT_NAME, EVENT_LOCATION, EVENT_START_TIME, EVENT_DESCRIPT, EVENT_ENROLL_REQUIRED)" +
                                                "VALUES (@name, @loc, @stime, @desc, @enroll);", conn);
                cmd.Parameters.AddWithValue("@name", txtEventName.Text);
                cmd.Parameters.AddWithValue("@loc", txtEventLoc.Text);
                DateTime date = DateTime.Parse(txtSelectedDate.Text + " " + txtTime.Text);
                cmd.Parameters.AddWithValue("@stime", date);
                cmd.Parameters.AddWithValue("@desc", txtEventDescript.Text);
                int checkState = 0;
                if (chkEnroll.Checked)
                {
                    checkState = 1;
                }
                cmd.Parameters.AddWithValue("@enroll", checkState);

                cmd.ExecuteNonQuery();

             
                cmd.Dispose();
            }
            catch (Exception k)
            {
                Response.Write(k.Message);
                //throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}