using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace KMS
{
    public partial class UserView : System.Web.UI.Page
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(_Default));
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["role"] == "" || (string)Session["role"] != "ROLE003")
            {
                Session.Abandon();
                Response.Redirect("SessionExpired.aspx");
            }
            LoadingMenu();
        }
        private void LoadingMenu()
        {
            
            try
            {
                string role = Session["role"].ToString();

                Menu m = (Menu)Master.FindControl("NavigationMenu");
                if (role.Equals("ROLE001"))
                {
                    MenuItem mi2 = new MenuItem();
                    mi2.NavigateUrl = "Home.aspx";
                    mi2.Text = "Home";
                    m.Items.Add(mi2);
                    MenuItem mi = new MenuItem();
                    mi.NavigateUrl = "Admin.aspx";
                    mi.Text = "Manage";
                    m.Items.Add(mi);
                }
                if (role.Equals("ROLE002"))
                {
                    MenuItem mi = new MenuItem();
                    mi.NavigateUrl = "Home.aspx";
                    mi.Text = "Home";
                    m.Items.Add(mi);

                    MenuItem mi2 = new MenuItem();
                    mi2.Text = "Knowledge Management";
                    m.Items.Add(mi2);
                    MenuItem cm = new MenuItem();
                    cm.Text = "Add Knowledge";
                    cm.NavigateUrl = "AddKnowledge.aspx";
                    mi2.ChildItems.Add(cm);
                    MenuItem cm1 = new MenuItem();
                    cm1.Text = "Bulk Upload";
                    cm1.NavigateUrl = "BulkUpload.aspx";
                    mi2.ChildItems.Add(cm1);
                    MenuItem cm2 = new MenuItem();
                    cm2.Text = "Search Articles";
                    cm2.NavigateUrl = "ListArticles.aspx";
                    mi2.ChildItems.Add(cm2);


                    MenuItem mi3 = new MenuItem();
                    mi3.Text = "My WorkList";
                    mi3.NavigateUrl = "WorkList.aspx";
                    m.Items.Add(mi3);
                }
                if (role.Equals("ROLE003"))
                {
                    MenuItem mi = new MenuItem();
                    mi.NavigateUrl = "Home.aspx";
                    mi.Text = "Home";
                    m.Items.Add(mi);

                    MenuItem mi2 = new MenuItem();
                    mi2.Text = "Knowledge Management";
                    m.Items.Add(mi2);
                    MenuItem cm = new MenuItem();
                    cm.Text = "Add Knowledge";
                    cm.NavigateUrl = "AddKnowledge.aspx";
                    mi2.ChildItems.Add(cm);
                    MenuItem cm1 = new MenuItem();
                    cm1.Text = "Bulk Upload";
                    cm1.NavigateUrl = "BulkUpload.aspx";
                    mi2.ChildItems.Add(cm1);
                    MenuItem cm2 = new MenuItem();
                    cm2.Text = "Search Articles";
                    cm2.NavigateUrl = "ListArticles.aspx";
                    mi2.ChildItems.Add(cm2);


                    MenuItem mi3 = new MenuItem();
                    mi3.Text = "User Tasks";
                    m.Items.Add(mi3);
                    MenuItem cm3 = new MenuItem();
                    cm3.Text = "My WorkList";
                    cm3.NavigateUrl = "WorkList.aspx";
                    mi3.ChildItems.Add(cm3);

                    MenuItem mi4 = new MenuItem();
                    mi4.Text = "Author Tasks";
                    m.Items.Add(mi4);
                    MenuItem cm4 = new MenuItem();
                    cm4.Text = "Pending Approvals";
                    cm4.NavigateUrl = "AuthorView.aspx";
                    mi4.ChildItems.Add(cm4);
                }
            }
            catch (NullReferenceException e)
            {
                logger.Info(e.Message);
                Response.Redirect("SessionExpired.aspx");
            }
        }
    }
}