using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE345Website
{
    public partial class UserInfo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (((string)Session["User"]).Equals("Register"))
                {
                    registerBlock.Visible = true;
                }
                else
                {
                    registerBlock.Visible = false;
                }
            }
        }
        protected void Register_Clicked(object sender, EventArgs e)
        {

        }

    }
}