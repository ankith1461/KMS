using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KMS
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        // written by vamsee
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome " + Session["CognizantId"].ToString();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("startpage.aspx");
        }

       
    }
}
