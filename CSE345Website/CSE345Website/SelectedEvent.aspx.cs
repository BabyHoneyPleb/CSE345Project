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
        protected void enrollClicked(object sender, EventArgs e)
        {
            if(btnDelete.Visible == false)
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
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO Participant (PART_STUD_ID, PART_EVENT_ID, PART_DATE_REG, PART_IS_ORGANIZER) " +
                                                    "VALUES (@studID, @eventID, @date, @organizer);", conn);
                    cmd2.Parameters.AddWithValue("@studID", (int)Session["ID"]);
                    cmd2.Parameters.AddWithValue("@eventID", Request.QueryString["Id"]);
                    cmd2.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd2.Parameters.AddWithValue("@organizer", 0);
                    cmd2.ExecuteNonQuery();
              
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
        protected void deleteEvent(object sender, EventArgs e)
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
                SqlCommand cmd2 = new SqlCommand("DELETE FROM Participant WHERE PART_EVENT_ID=@eventID;", conn);
                cmd2.Parameters.AddWithValue("@eventID", Request.QueryString["Id"]);
                cmd2.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("DELETE FROM Event WHERE EVENT_ID=@eventID;", conn);
                cmd1.Parameters.AddWithValue("@eventID", Request.QueryString["Id"]);
                cmd1.ExecuteNonQuery();
                Response.Redirect("~/Events");
             
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
                    if((int)ds.Tables[0].Rows[i]["EVENT_ENROLL_REQUIRED"] == 1 && !string.IsNullOrEmpty((string)Session["User"]))
                    {
                        btnEnroll.Visible = true;
                    }
                    ds.Tables[0].Rows[i]["FormDate"] = formatDate(date);
                }
                DetailsView1.DataSource = ds;
                DetailsView1.DataBind();
                cmd.Dispose();
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Participant WHERE PART_STUD_ID=@studID AND PART_EVENT_ID=@eventID AND PART_IS_ORGANIZER=@organ", conn);
                cmd2.Parameters.AddWithValue("@studID", (int)Session["ID"]);
                cmd2.Parameters.AddWithValue("@eventID", Request.QueryString["Id"]);
                cmd2.Parameters.AddWithValue("@organ", 1);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    btnDelete.Visible = true;
                }
                reader.Close();
                cmd2.Dispose();
            }
            catch (Exception k)
            {
              //  Response.Write(k.Message);
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