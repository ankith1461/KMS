using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using EntityLayer;
using BusinessLayer;
using System.Data;

namespace KMS
{
    public partial class ListArticles : System.Web.UI.Page
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(_Default));
        SearchEntityLayer ael = null;
        SearchLogicLayer abl = null;
        DataSet dt5 = new DataSet();
        //int count = 0;
        Boolean men = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //count++;
            if ((string)Session["role"] == "" || (string)Session["role"] != "ROLE002" && (string)Session["role"] != "ROLE003")
            {
                Session.Abandon();
                Response.Redirect("SessionExpired.aspx");
            }
            Page.Form.DefaultFocus = pnlSearch.FindControl("txtSearch").ClientID;
            pnlPageNo.Visible = false;
            lblNoResult.Visible = false;

           // System.Windows.Forms.MessageBox.Show(count.ToString());
            
            if(!men)
                    LoadingMenu();

                    

               
        }
        
        private void LoadingMenu()
        {
            men = true;
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
                Response.Redirect("startpage.aspx");

                
            }
        }

        public ListArticles()
        {
            ael = new SearchEntityLayer();
            abl = new SearchLogicLayer();
        }


     // written by Ankith for Searching the articles
        public DataSet bindGrid()
        {
            string input = txtSearch.Text;

            ael.SearchData = input;

            DataSet dt = new DataSet();
            try
            {
                dt = abl.ApplicationSearch(ael.SearchData);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                logger.Info(ex.Message);
            }
            DataSet dt1 = new DataSet();
            try
            {
                dt1 = abl.CollectionSearch(ael.SearchData);
            }
            catch (Exception ex)
            {

                logger.Info(ex.Message);
            }
            DataSet dt2 = new DataSet();
            try
            {
                dt2 = abl.TagSearch(ael.SearchData);
            }
            catch (Exception ex)
            {

                logger.Info(ex.Message);
            }
            DataSet dt3 = new DataSet();
            try
            {
                dt3 = abl.ArticleSearch(ael.SearchData);
            }
            catch (Exception ex)
            {

                logger.Info(ex.Message);
            }
            DataSet dt4 = new DataSet();
            try
            {
                dt4 = abl.DocumentSearch(ael.SearchData);
            }
            catch (Exception ex)
            {

                logger.Info(ex.Message);
            }

            dt.Tables[0].Columns["article_id"].Unique = true;
            dt.Tables[0].PrimaryKey = new DataColumn[] { dt.Tables[0].Columns["article_id"] };


            dt1.Tables[0].Columns["article_id"].Unique = true;
            dt1.Tables[0].PrimaryKey = new DataColumn[] { dt1.Tables[0].Columns["article_id"] };

            dt2.Tables[0].Columns["article_id"].Unique = true;
            dt2.Tables[0].PrimaryKey = new DataColumn[] { dt2.Tables[0].Columns["article_id"] };

            dt3.Tables[0].Columns["article_id"].Unique = true;
            dt3.Tables[0].PrimaryKey = new DataColumn[] { dt3.Tables[0].Columns["article_id"] };

            dt4.Tables[0].Columns["article_id"].Unique = true;
            dt4.Tables[0].PrimaryKey = new DataColumn[] { dt4.Tables[0].Columns["article_id"] };

            dt.Merge(dt1);
            dt.Merge(dt2);
            dt.Merge(dt3);
            dt.Merge(dt4);
            dt5.Merge(dt);
            ViewState["Search"] = dt5;
            // System.Windows.Forms.MessageBox.Show(dt5.Tables[0].Rows[0]["article_id"].ToString());

            if (dt5.Tables[0].Rows.Count >= 1)
            {

                gvResult.DataSource = dt5;
                gvResult.DataBind();
                gvResult.Visible = true;
                pnlPageNo.Visible = true;


                gridViewHyperLink();


                return dt;

            }
            else
            {
                gvResult.Visible = false;
                lblNoResult.Visible = true;
                lblNoResult.Text = "No Results Found!";
                return null;
            }
        }
        protected void gridViewHyperLink()
        {

            int n = gvResult.Rows.Count;

            string ModifyTxtTilte;
            HyperLink[] title = new HyperLink[n];

            for (int k = 0; k < n; k++)
            {
                title[k] = new HyperLink();

                title[k].ID = "title" + k.ToString();

                string titletext = gvResult.Rows[k].Cells[1].Text;


                if (titletext.Length > 7)
                {
                    ModifyTxtTilte = titletext.Substring(0, 7) + "......";
                }
                else
                {
                    ModifyTxtTilte = titletext;
                }

                title[k].Text = ModifyTxtTilte;

                gvResult.Rows[k].Cells[1].Controls.Add(title[k]);

                string strtxt = gvResult.Rows[k].Cells[0].Text;
                title[k].NavigateUrl = String.Format("ViewSearch.aspx?ArtId={0}", strtxt);
                title[k].Visible = true;

            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                bindGrid();

            }
            catch (Exception ex)
            {

                logger.Info(ex.Message);
            }

        }

        protected void gvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvResult.PageIndex = e.NewPageIndex;
            bindGrid();
        }


        public SortDirection dir
        {
            get
            {
                if (ViewState["dirState"] == null)
                {
                    ViewState["dirState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirState"];
            }
            set
            {
                ViewState["dirState"] = value;
            }

        }

        protected void gvResults_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet d = (DataSet)ViewState["Search"];

            DataTable dt6 = d.Tables[0];


            string SortDir = string.Empty;
            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                SortDir = "Desc";
            }
            else
            {
                dir = SortDirection.Ascending;
                SortDir = "Asc";
            }
            DataView sortedView = new DataView(dt6);
            sortedView.Sort = e.SortExpression + " " + SortDir;
            gvResult.DataSource = sortedView;
            gvResult.DataBind();
            gridViewHyperLink();
        }
    }
}