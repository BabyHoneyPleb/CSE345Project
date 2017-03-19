using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE345Website
{
    public partial class SelectedEvent : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = (string)Session["SelectedEvent"];
        }
    }
}