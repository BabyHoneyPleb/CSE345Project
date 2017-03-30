using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Date = System.DateTime;
using System.Data.SqlClient;

namespace CSE345Website
{
    public partial class SelectedEvent : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                    SqlCommand sqlAccount = new SqlCommand();
                    sqlAccount.CommandText = "SELECT * FROM Event WHERE EVENT_ID=@value1;";
                    sqlAccount.Parameters.AddWithValue("@value1", (int)Session["EventSelected"]);
                    sqlAccount.Connection = conn;
                    SqlDataReader readerAccount = sqlAccount.ExecuteReader();
                    while (readerAccount.Read())
                    {
                        Title = readerAccount.GetString(1);
                        Response.AppendHeader("Event", Title);
                        lblTitle.Text = readerAccount.GetString(1);
                        lblLocation.Text = readerAccount.GetString(2);
                        DateTime start = readerAccount.GetDateTime(3);
                        lblDate.Text = formatDate(start);
                        lblDescription.Text = readerAccount.GetString(5);
                       
                    }
                }
                catch (Exception ex)
                {

                }
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
                hour = (dt.Hour - 12).ToString();
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