using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE345Website
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void On_Click_Events (object sender, EventArgs e)
        {
            Response.Redirect("~/Events");
        }
        protected void On_Click_Classifieds(object sender, EventArgs e)
        {
            Response.Redirect("~/Classifieds");
        }
    }
}