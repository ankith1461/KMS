using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using log4net;



namespace KMS
{
    public partial class Author : System.Web.UI.Page
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
            try
            {
                if (!IsPostBack)
                {
                    GetPendingArticle();
                    getPendingTag();
                    getPendingCollection();

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
            }

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
               // System.Windows.Forms.MessageBox.Show("Sorry Session has been expired...");
                logger.Info(e.Message);
                Response.Redirect("startpage.aspx");
            }
        }




        //code from kranthi
        protected void GetPendingArticle()
        {
            try
            {
                DataSet d = new DataSet();
                BussinessLayerAuthorPendingArticle objArticle = new BussinessLayerAuthorPendingArticle();
                d = objArticle.GetPendingArticleAuthor();
                if (d.Tables[0].Rows.Count > 0)
                {
                    ViewState["SearchPendingArticle"] = d;
                    gvPendingArticleAuthor.DataSource = d;
                    gvPendingArticleAuthor.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Records not found');</script>");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
            }
        }









        //getting pending tags

        protected void getPendingTag()
        {
            try
            {
                BussinessLayerAuthorTag obj = new BussinessLayerAuthorTag();
                DataSet d = obj.GetTags();
                if (d.Tables[0].Rows.Count > 0)
                {
                    ViewState["SearchPendingTags"] = d;
                    gvPendingTag.DataSource = d;
                    gvPendingTag.DataBind();
                }
                else
                {
                    //MessageBox.Show("No data");
                    Response.Write("<script>alert('no data');</script>");
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
            }
        }


        //navigating to the edit kb article page
        protected void gv_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "KBArticle")
            {

                //MessageBox.Show(e.CommandArgument.ToString());

                Response.Redirect("AuthorEditKBPendingArticle.aspx?Id=" + e.CommandArgument.ToString());
            }

            else if (e.CommandName.ToString() == "Exception Knowledge")
            {
                Response.Redirect("AuthorEditExceptionPendingArticle.aspx?Id=" + e.CommandArgument.ToString());
            }
            //else
            //{
            //    MessageBox.Show("unknown Article Type");
            //}
        }



        //navigating to the edit kb article page
        //protected void gv_OnRowCommandException(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName.ToString() == "check")
        //    {

        //        MessageBox.Show(e.CommandArgument.ToString());

        //        Response.Redirect("AuthorEditExceptionPendingArticle.aspx?Id=" + e.CommandArgument.ToString());
        //    }
        //}





        //accceting or rejecting the tag
        protected void Accept_Reject_Tag(object sender, GridViewCommandEventArgs e)
        {
            // ViewState["command"] = e.CommandName.ToString();
            if (e.CommandName.ToString() == "accept")
            {
                ChangeTagStatus(e.CommandArgument.ToString(), e.CommandName.ToString());
            }
            else if (e.CommandName.ToString() == "reject")
            {
                ChangeTagStatus(e.CommandArgument.ToString(), e.CommandName.ToString());
            }

        }


        //changing the status  of the tags
        protected void ChangeTagStatus(string TagId, string status)
        {
            try
            {
                BussinessLayerAuthorTag ob = new BussinessLayerAuthorTag();
                int i;
                string message = string.Empty;
                if (status == "accept")
                {
                    //MessageBox.Show(status);
                    //MessageBox.Show(TagId);
                    i = ob.ChangeTagStatus(TagId, "S002");

                    if (i > 0)
                    {
                        Response.Write("<script>alert('Tag Accepted');</script>");
                        getPendingTag();
                    }
                    else
                    {
                        Response.Write("<script>alert('Check Again');</script>");
                    }

                }
                else if (status == "reject")
                {
                    //MessageBox.Show(status);
                    //MessageBox.Show(TagId);
                    i = ob.ChangeTagStatus(TagId, "S003");
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Tag Rejected');</script>");
                        getPendingTag();
                    }
                    else
                    {
                        Response.Write("<script>alert('check again');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
            }

        }












        //Collections
        protected void getPendingCollection()
        {
            try
            {
                BussinessLayerAuthorCollection obj = new BussinessLayerAuthorCollection();
                DataSet d = obj.GetCollections();
                if (d.Tables[0].Rows.Count > 0)
                {
                    ViewState["SearchPendingCollections"] = d;
                    gvPendingCollection.DataSource = d;
                    gvPendingCollection.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('no data');</script>");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
            }
        }





        //accceting or rejecting the collections
        protected void Accept_Reject_Collection(object sender, GridViewCommandEventArgs e)
        {
            // ViewState["command"] = e.CommandName.ToString();
            if (e.CommandName.ToString() == "accept")
            {
                ChangeCollectionStatus(e.CommandArgument.ToString(), e.CommandName.ToString());
            }
            else if (e.CommandName.ToString() == "reject")
            {
                ChangeCollectionStatus(e.CommandArgument.ToString(), e.CommandName.ToString());
            }

        }


        //changing the status  of the collection
        protected void ChangeCollectionStatus(string CollectionId, string status)
        {
            try
            {
                BussinessLayerAuthorCollection obj = new BussinessLayerAuthorCollection();
                int i;
                string message = string.Empty;

                if (status == "accept")
                {
                    //MessageBox.Show(status);
                    //MessageBox.Show(TagId);
                    i = obj.ChangeCollectionStatus(CollectionId, "S002");

                    if (i > 0)
                    {
                        Response.Write("<script>alert('Collection accepted');</script>");
                        getPendingCollection();
                    }
                    else
                    {
                        Response.Write("<script>alert('check again');</script>");
                    }

                }
                else if (status == "reject")
                {
                    //MessageBox.Show(status);
                    //MessageBox.Show(TagId);
                    i = obj.ChangeCollectionStatus(CollectionId, "S003");
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Collection rejected');</script>");
                        getPendingCollection();
                    }
                    else
                    {
                        Response.Write("<script>alert('check again');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
            }

        }

        //method for article paging
        protected void gv_PendingArticle_Paging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                gvPendingArticleAuthor.PageIndex = e.NewPageIndex;
                GetPendingArticle();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
            }
        }


        //method for tag paging
        protected void gvPendingTag_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvPendingTag.PageIndex = e.NewPageIndex;
                getPendingTag();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
            }
        }


        //method for collection paging
        protected void gvPendingCollection_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvPendingCollection.PageIndex = e.NewPageIndex;
                getPendingCollection();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
            }
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




        //method for pending article sorting
        protected void gvPendingArticleAuthor_OnSorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DataSet d = (DataSet)ViewState["SearchPendingArticle"];

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
                gvPendingArticleAuthor.DataSource = sortedView;
                gvPendingArticleAuthor.DataBind();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
            }
        }



        //method for sorting pending tags

        protected void gvPendingTag_OnSorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DataSet d = (DataSet)ViewState["SearchPendingTags"];

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
                gvPendingTag.DataSource = sortedView;
                gvPendingTag.DataBind();

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
            }
        }





        //Method for collection sorting

        protected void gvPendingCollection_OnSorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DataSet d = (DataSet)ViewState["SearchPendingCollections"];

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
                gvPendingCollection.DataSource = sortedView;
                gvPendingCollection.DataBind();

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
            }
        }

    }
}