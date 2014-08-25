using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using BusinessLayer;

using System.Data;
namespace KMS
{
    public partial class WorkList : System.Web.UI.Page
    {
        string CognizantId = string.Empty;
        ILog logger = log4net.LogManager.GetLogger(typeof(_Default));
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["role"] == "" || (string)Session["role"] != "ROLE002" && (string)Session["role"] != "ROLE003")
            {
                Session.Abandon();
                Response.Redirect("SessionExpired.aspx");
            }
            CognizantId = Session["CognizantId"].ToString();
            LoadingMenu();
        }
        public void GridViewDisplayStatus()
        {
            gvUserPublished.Visible = false;
            gvUserPending.Visible = false;
            gvUserRejected.Visible = false;


            repeaterUserPendingPaging.Visible = false;
            repeaterUserPublishedPaging.Visible = false;
            repeaterUserRejectedPaging.Visible = false;
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


        //code by haneef and rambabu-----------------------
        protected void btnUserPublishedArticles_Click(object sender, EventArgs e)
        {
            GridViewDisplayStatus();
            gvUserPublished.Visible = true;

            repeaterUserPublishedPaging.Visible = true;

            string Status = "published";
            int TotalRows = 0;
            DataSet ds = BusinessUserPublished.BusinessUserGetPublishedArticleDetails(Status, gvUserPublished.PageIndex, gvUserPublished.PageSize, CognizantId, out TotalRows);
            if (ds.Tables[0].Rows.Count > 0)
            {


                gvUserPublished.DataSource = ds;

                gvUserPublished.DataBind();

                DatabindRepeater(0, gvUserPublished.PageSize, TotalRows);
            }
            else
            {
                Response.Write("<script>alert('NO PUBLISHED RECORDS FOUND')</script>");
            }

        }



        // on pressing paging buttons the the respective data is displayed in gridview

        protected void lnkbtnUserPublished_Click(object sender, EventArgs e)
        {
            String Status = "published";
            int totalRows = 0;
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            gvUserPublished.PageIndex = pageIndex;
            DataSet ds = BusinessUserPublished.BusinessUserGetPublishedArticleDetails(Status, pageIndex, gvUserPublished.PageSize, CognizantId, out totalRows);

            gvUserPublished.DataSource = ds;

            gvUserPublished.DataBind();
            DatabindRepeater(pageIndex, gvUserPublished.PageSize, totalRows);
        }


        //paging logic and binding no. of pages to links

        private void DatabindRepeater(int pageIndex, int pageSize, int totalRows)
        {
            int totalPages = totalRows / pageSize;
            if ((totalRows % pageSize) != 0)
            {
                totalPages += 1;
            }

            List<ListItem> pages = new List<ListItem>();
            if (totalPages > 1)
            {
                for (int i = 1; i <= totalPages; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != (pageIndex + 1)));
                }
            }
            repeaterUserPublishedPaging.DataSource = pages;
            repeaterUserPublishedPaging.DataBind();
        }


        //code to redirect to UserPublishedEdit by capturing the article,application ids

        protected void gvUserPublished_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UserPublished Edit Details")
            {
                string[] CommandArgs = e.CommandArgument.ToString().Split(',');
                string ArtId = CommandArgs[0];
                string AppId = CommandArgs[1];
                string ArtStatus = CommandArgs[2];
                Response.Redirect("~/UserPublishedEdit.aspx?ArticleId=" + Server.UrlPathEncode(ArtId) + "&ApplicationId=" + Server.UrlPathEncode(AppId) + "&ArticleStatus=" + Server.UrlPathEncode(ArtStatus));

            }
        }


        // on pressing pending articles button the data is bindes to gridview

        protected void btnPendingArticles_Click(object sender, EventArgs e)
        {
            GridViewDisplayStatus();
            gvUserPending.Visible = true;
            repeaterUserPendingPaging.Visible = true;

            string Status = "pending";
            int TotalRows = 0;
            DataSet ds1 = BusinessUserPublished.BusinessUserGetPublishedArticleDetails(Status, gvUserPending.PageIndex, gvUserPending.PageSize, CognizantId, out TotalRows);
            //System.Windows.Forms.MessageBox.Show(ds1.Tables[0].Rows[0]["AppId"].ToString());
            if (ds1.Tables[0].Rows.Count > 0)
            {
                gvUserPending.DataSource = ds1;
                gvUserPending.DataBind();
                UserPendingDatabindRepeater(0, gvUserPending.PageSize, TotalRows);
            }
            else
            {
                Response.Write("<script>alert('NO PENDING RECORDS FOUND')</script>");
            }

        }


        // on pressing paging buttons the the respective data is displayed in gridview

        protected void lnkbtnUserPending_Click(object sender, EventArgs e)
        {
            String Status = "pending";
            int totalRows = 0;
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            gvUserPending.PageIndex = pageIndex;
            gvUserPending.DataSource = BusinessUserPublished.BusinessUserGetPublishedArticleDetails(Status, pageIndex, gvUserPending.PageSize, CognizantId, out totalRows);
            gvUserPending.DataBind();
            UserPendingDatabindRepeater(pageIndex, gvUserPending.PageSize, totalRows);
        }


        //paging logic and binding no. of pages to links

        private void UserPendingDatabindRepeater(int pageIndex, int pageSize, int totalRows)
        {
            int totalPages = totalRows / pageSize;
            if ((totalRows % pageSize) != 0)
            {
                totalPages += 1;
            }

            List<ListItem> pages = new List<ListItem>();
            if (totalPages > 1)
            {
                for (int i = 1; i <= totalPages; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != (pageIndex + 1)));
                }
            }
            repeaterUserPendingPaging.DataSource = pages;
            repeaterUserPendingPaging.DataBind();
        }



        //code to redirect to UserPublishedEdit by capturing the article,application ids

        protected void gvUserPending_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UserPending Edit Details")
            {
                string[] CommandArgs = e.CommandArgument.ToString().Split(',');
                string ArtId = CommandArgs[0];
                string AppId = CommandArgs[1];
                string ArtStatus = CommandArgs[2];
                Response.Redirect("~/UserPublishedEdit.aspx?ArticleId=" + Server.UrlPathEncode(ArtId) + "&ApplicationId=" + Server.UrlPathEncode(AppId) + "&ArticleStatus=" + Server.UrlPathEncode(ArtStatus));

            }
        }



        // on pressing rejected articles button the data is bindes to gridview

        protected void btnRejectedArticles_Click(object sender, EventArgs e)
        {
            GridViewDisplayStatus();
            gvUserRejected.Visible = true;
            repeaterUserRejectedPaging.Visible = true;
            string Status = "rejected";
            int TotalRows = 0;
            DataSet ds2 = BusinessUserPublished.BusinessUserGetPublishedArticleDetails(Status, gvUserRejected.PageIndex, gvUserRejected.PageSize, CognizantId, out TotalRows);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                gvUserRejected.DataSource = ds2;
                gvUserRejected.DataBind();
                DatabindRepeater(0, gvUserRejected.PageSize, TotalRows);
            }
            else
            {
                Response.Write("<script>alert('NO REJECTED RECORDS FOUND')</script>");
            }
        }


        // on pressing paging buttons the the respective data is displayed in gridview


        protected void lnkbtnUserRejected_Click(object sender, EventArgs e)
        {
            String Status = "rejected";
            int totalRows = 0;
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            gvUserRejected.PageIndex = pageIndex;
            gvUserRejected.DataSource = BusinessUserPublished.BusinessUserGetPublishedArticleDetails(Status, pageIndex, gvUserRejected.PageSize, CognizantId, out totalRows);
            gvUserRejected.DataBind();
            UserRejectedDatabindRepeater(pageIndex, gvUserRejected.PageSize, totalRows);
        }



        //paging logic and binding no. of pages to links

        private void UserRejectedDatabindRepeater(int pageIndex, int pageSize, int totalRows)
        {
            int totalPages = totalRows / pageSize;
            if ((totalRows % pageSize) != 0)
            {
                totalPages += 1;
            }

            List<ListItem> pages = new List<ListItem>();
            if (totalPages > 1)
            {
                for (int i = 1; i <= totalPages; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != (pageIndex + 1)));
                }
            }
            repeaterUserRejectedPaging.DataSource = pages;
            repeaterUserRejectedPaging.DataBind();
        }


        //code to redirect to UserPublishedEdit by capturing the article,application ids

        protected void gvUserRejected_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UserRejected Edit Details")
            {
                string[] CommandArgs = e.CommandArgument.ToString().Split(',');
                string ArtId = CommandArgs[0];
                string AppId = CommandArgs[1];
                string ArtStatus = CommandArgs[2];
                Response.Redirect("~/UserPublishedEdit.aspx?ArticleId=" + Server.UrlPathEncode(ArtId) + "&ApplicationId=" + Server.UrlPathEncode(AppId) + "&ArticleStatus=" + Server.UrlPathEncode(ArtStatus));

            }
        }
    }
}