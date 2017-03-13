using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Date = System.DateTime;
namespace CSE345Website
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblDateSelected.Text = "&nbsp&nbsp&nbsp&nbsp&nbspDate Selected: " + Date.Today.ToShortDateString();
            }
        }
        protected void On_Click_Events (object sender, EventArgs e)
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
    }
}