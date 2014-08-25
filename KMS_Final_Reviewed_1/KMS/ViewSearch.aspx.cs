using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using EntityLayer;
using BusinessLayer;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace KMS
{
    public partial class ViewSearch : System.Web.UI.Page
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(_Default));
        SearchEntityLayer ael = new SearchEntityLayer();
        SearchLogicLayer abl = new SearchLogicLayer();
        String id = string.Empty;
        DataTable display = null;
        DataTable collect = null;
        DataTable download = null;
        DataTable tag = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["role"] == "" || (string)Session["role"] != "ROLE002" && (string)Session["role"] != "ROLE003")
            {
                Session.Abandon();
                Response.Redirect("SessionExpired.aspx");
            }
            LoadingMenu();
            DisplayArticle();

        }
        

        public ViewSearch()
        {
            display = new DataTable();
            collect = new DataTable();
            download = new DataTable();
            tag = new DataTable();

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

        protected void DisplayArticle()
        {
            id = Request.QueryString["ArtId"];

            lblViewId.Text = id;
            ael.ArtId = id;
            //To dispaly article information based on query string by ankith
            try
            {
                display = abl.ArticleView(ael.ArtId);
                lblHead.Text = display.Rows[0]["ArtType"].ToString();
                lblViewArtName.Text = display.Rows[0]["Title"].ToString();
                if ((lblHead.Text).ToLower() == "kbarticle" || (lblHead.Text).ToLower() == "kb article")
                {
                    pnlProblemSolution.Visible = false;
                    pnlDetail.Visible = true;

                    lblDisplayDetail.Text = Server.HtmlDecode(display.Rows[0]["Details"].ToString());
                }
                else
                {
                    pnlDetail.Visible = false;
                    pnlProblemSolution.Visible = true;

                    lblDisplayProblem.Text = Server.HtmlDecode(display.Rows[0]["ProblemStatement"].ToString());
                    lblDisplaySolution.Text = Server.HtmlDecode(display.Rows[0]["Resolution"].ToString());
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                logger.Info(ex.Message);
            }
            // To create download file
            try
            {

                download = abl.DocumentDownload(ael.ArtId);
                //gvDownload.DataSource = download;
                //gvDownload.DataBind();
                ListView3.DataSource = download;
                ListView3.DataBind();

            }
            catch (Exception ex)
            {
               // System.Windows.Forms.MessageBox.Show(ex.Message);
                logger.Info(ex.Message);
            }



            // To display article tags

            try
            {
                tag = abl.TagsRelated(id);
                int m = tag.Rows.Count;
                Button[] l = new Button[m];
                for (int j = 0; j < m; j++)
                {

                    l[j] = new Button();
                    l[j].Text = tag.Rows[j]["Tname"].ToString() + " " + " ";
                    l[j].ForeColor = Color.Black;
                    l[j].BackColor = System.Drawing.Color.LightSteelBlue;
                    l[j].Attributes.Add("onclick", "return false;");

                    pnlTag.Controls.Add(l[j]);

                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                logger.Info(ex.Message);

            }
        }

        protected void DownloadFile(object sender, CommandEventArgs e)
        {

            string s = e.CommandArgument.ToString();
            //System.Windows.Forms.MessageBox.Show(s);
            DataTable dt = abl.FileDownload(s);
            //System.Windows.Forms.MessageBox.Show(dt.Rows[1]["DocName"].ToString());
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    DocDownload(dt, i);
                }
            }
        }



        private void DocDownload(DataTable dt, int n)
        {

            Byte[] bytes = (Byte[])dt.Rows[n]["DocData"];

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = dt.Rows[n]["DocType"].ToString();

            Response.AddHeader("content-disposition", "attachment;filename="
            + dt.Rows[n]["DocName"].ToString());

            Response.BinaryWrite(bytes);

            Response.Flush();
            Response.End();
        }

        protected void btnSearchAgain_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListArticles.aspx");
        }

    }
}