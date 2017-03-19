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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblDateSelected.Text = "&nbsp&nbsp&nbsp&nbsp&nbspDate Selected: " + Date.Today.ToShortDateString();
                populateUpcomingEvents();
            }
        }
        protected void On_Click_Events(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string)Session["User"]))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please sign in first!')", true);
                return;
            }
            Response.Redirect("~/Events");

        }
        protected void On_Click_Classifieds(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string)Session["User"]))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please sign in first!')", true);
                return;
            }
            Response.Redirect("~/Classifieds");
        }

        protected void cldEvents_SelectionChanged(object sender, EventArgs e)
        {
            lblDateSelected.Text = "&nbsp&nbsp&nbsp&nbsp&nbspDate Selected: " + cldEvents.SelectedDate.ToShortDateString();
        }
        public void populateUpcomingEvents()
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
                sqlAccount.CommandText = "SELECT * FROM Event ORDER BY EVENT_START_TIME;";

                sqlAccount.Connection = conn;
                SqlDataReader readerAccount = sqlAccount.ExecuteReader();
                int count = 0;
                DateTime start;
                //DateTime end;
                string description;
               
                Label[] lblDate = { lblP1Date, lblP2Date, lblP3Date };
                Label[] lblDescription = { lblP1Descrip, lblP2Descrip, lblP3Descrip };
                Label[] lblLocation = { lblP1Location, lblP2Location, lblP3Location };
                Label[] lblTitle = { lblP1Title, lblP2Title, lblP3Title };


                while (readerAccount.Read())
                {
                    Session["Event" + (count + 1).ToString()] = readerAccount.GetValue(0);
                    lblTitle[count].Text = readerAccount.GetString(1);
                    lblLocation[count].Text = readerAccount.GetString(2);
                    start = readerAccount.GetDateTime(3);                    
                    lblDate[count].Text = formatDate(start);
                    // end = readerAccount.GetDateTime(4);

                    description = readerAccount.GetString(5);

                    if (description.Length > 96)
                    {
                        string temp = description.Substring(0, 93);
                        int lastSpace = temp.LastIndexOf(" ");
                        temp = temp.Substring(0, lastSpace);
                        temp += "...";
                        lblDescription[count].Text = temp;
                    }
                    else
                    {
                        lblDescription[count].Text = description;
                    }
                   
                   
                
                    count++;
                    if (count == 3)
                    {
                        break;
                    }
                }
                readerAccount.Close();

                conn.Close();


            }
            catch (Exception ex)
            {

            }
        }
        public string formatDate(DateTime newStart)
        {
            string dayOfWeek = newStart.DayOfWeek.ToString();
            string month = newStart.ToString("MMMM");
            string year = newStart.ToString("yyyy");
            string day = newStart.Day.ToString("d");


            return (dayOfWeek + ", " + month + " " + formatDay(newStart) +", " + year + " at " + formatTime(newStart));

        }
      
        public string formatDay(DateTime dt)
        {
            string suffix;
            if( new[] { 11, 12, 13 }.Contains(dt.Day))
            {
                suffix = "th";
            }else if(dt.Day % 10 == 1)
            {
                suffix = "st";
            }else if(dt.Day % 10 == 2)
            {
                suffix = "nd";
            }else if(dt.Day % 10 == 3)
            {
                suffix = "rd";
            }else
            {
                suffix = "th";
            }
            return dt.Day.ToString("d") + suffix;
        }
        public string formatTime(DateTime dt)
        {
            string suffix;
            string hour;
            if(dt.Hour >= 12)
            {
                hour = (dt.Hour - 12).ToString();
                suffix = "PM";
            }else
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

        protected void btnP2View_Click(object sender, EventArgs e)
        {
            Session["EventSelected"] = Session["Event2"];
            Response.Redirect("~/SelectedEvent?id=" + ((int)Session["Event2"]).ToString(), true);

        }

        protected void btP1View_Click(object sender, EventArgs e)
        {
            Session["EventSelected"] = Session["Event1"];
            Response.Redirect("~/SelectedEvent?id=" + ((int)Session["Event1"]).ToString(), true);
        }

        protected void btnP3View_Click(object sender, EventArgs e)
        {
            Session["EventSelected"] = Session["Event3"];
            Response.Redirect("~/SelectedEvent?id=" + ((int)Session["Event3"]).ToString(), true);
        }
    }
        
    
}