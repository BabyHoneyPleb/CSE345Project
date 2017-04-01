using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Date = System.DateTime;
using System.Data.SqlClient;
using System.Data;

namespace CSE345Website
{
    public partial class SelectedEvent : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (Request.QueryString.Get("Id") != null)
                {
                    DetailsView1.DefaultMode = DetailsViewMode.ReadOnly;
                    detail();
                }
             
            }
        }
        void detail()
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Event WHERE EVENT_ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["Id"]);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                ds.Tables[0].Columns.Add("FormDate", typeof(string));
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DateTime date = (DateTime)ds.Tables[0].Rows[i]["EVENT_START_TIME"];
                
                    ds.Tables[0].Rows[i]["FormDate"] = formatDate(date);
                }
                DetailsView1.DataSource = ds;
                DetailsView1.DataBind();
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
                if (dt.Hour > 12)
                {
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
    }
}