using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using log4net;


namespace KMS
{
    public partial class Admin : System.Web.UI.Page
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(_Default));
         
         BlAdminManageApps adminAccess;
         BlAdminManageTags adminAccessTags;
         BlAdminManageUsers manageUsers;
         BlAdminManageCollections adminAccessCollections;
         BlAdminManageArticles manageArt;
       
        public Admin()
        {
            
            adminAccess = new BlAdminManageApps();
            adminAccessTags = new BlAdminManageTags();
            manageUsers = new BlAdminManageUsers();
            adminAccessCollections = new BlAdminManageCollections();
            manageArt = new BlAdminManageArticles();
        }
             
                
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["role"] == "" || (string)Session["role"] != "ROLE001")
            {
                Session.Abandon();
                Response.Redirect("SessionExpired.aspx");
            }
            LoadingMenu();

            if (!IsPostBack)
            {
                LoadApplication();
                LoadTag();
                LoadUsers();
                LoadCollection();
                LoadArticles();
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
                logger.Info(e.Message);
                System.Windows.Forms.MessageBox.Show("Sorry Session has been expired...");
                Response.Redirect("startpage.aspx");
            }
        }

        //code for managing applications----- by swathi-----------------------------
        private void LoadApplication()
        {            
            try
            {
                DataSet dataSet = adminAccess.LoadCollection();
                ApplicationData.DataSource = dataSet;
                ApplicationData.DataBind();
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                logger.Info(ex.Message);
            }


        }
        protected void lb_Click(object sender, EventArgs e)
        {
            string ApplicationName = ((TextBox)ApplicationData.FooterRow.FindControl("TxtAppName")).Text;
            Int64 CognizantId = Convert.ToInt64(Session["CognizantId"].ToString());
            if (ApplicationName == "")
                System.Windows.Forms.MessageBox.Show("The field cannot be blank");
            else
            {
                try
                {
                   string msg= adminAccess.InsertApplications(ApplicationName,CognizantId);
                   Response.Write("<script>alert('" + msg + "');</script>");
                    ApplicationData.EditIndex = -1;
                    LoadApplication();
                }
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show(ex.Message);
                    logger.Info(ex.Message);
                }
            }
        }
        protected void ApplicationData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ApplicationData.EditIndex = e.NewEditIndex;
            LoadApplication();
        }

        protected void ApplicationData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ApplicationData.EditIndex = -1;
            LoadApplication();

        }

        protected void ApplicationData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt32(ApplicationData.DataKeys[e.RowIndex].Value.ToString());            
            try
            {
               string msg= adminAccess.DeleteApplications(Id);
                Response.Write("<script>alert('" + msg + "');</script>");
                ApplicationData.EditIndex = -1;
                
                LoadApplication();
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                logger.Info(ex.Message);
            }                      

        }

        protected void ApplicationData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int Id = Convert.ToInt32(ApplicationData.DataKeys[e.RowIndex].Value.ToString());
            string ApplicationName = ((TextBox)ApplicationData.Rows[e.RowIndex].FindControl("txtName")).Text;
            if (ApplicationName == "")
                Response.Write("<script>alert('field cannot be blank');</script>");
            else
            {
                try
                {
                   string msg= adminAccess.UpdateApplications(Id, ApplicationName);
                   Response.Write("<script>alert('" + msg + "');</script>");
                    ApplicationData.EditIndex = -1;
                    LoadApplication();
                }
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show(ex.Message);
                    logger.Info(ex.Message);
                }

            }
        }

        protected void ApplicationData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ApplicationData.PageIndex = e.NewPageIndex;
            LoadApplication();
        }

 private void LoadTag()
        {            
            try
            {
                DataSet dataSet = adminAccessTags.LoadData();
                TagData.DataSource = dataSet;
                TagData.DataBind();
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                logger.Info(ex.Message);
            }


        }
       
        protected void TagData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            TagData.EditIndex = e.NewEditIndex;
            LoadTag();
        }

        protected void TagData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            TagData.EditIndex = -1;
            LoadTag();

        }

        protected void TagData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt32(TagData.DataKeys[e.RowIndex].Value.ToString());            
            try
            {
               string msg=adminAccessTags.DeleteTags(Id);
               Response.Write("<script>alert('"+msg+"');</script>");
                TagData.EditIndex = -1;
                LoadTag();
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                logger.Info(ex.Message);
            }                      

        }

        protected void TagData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            int Id = Convert.ToInt32(TagData.DataKeys[e.RowIndex].Value.ToString());            
            string TagName = ((TextBox)TagData.Rows[e.RowIndex].FindControl("txtName")).Text;
            if (TagName == "")
                Response.Write("<script>alert('field cannot be blank');</script>");
            else
            {
                try
                {
                  string msg= adminAccessTags.UpdateTags(Id, TagName);
                  Response.Write("<script>alert('" + msg + "');</script>");
                    TagData.EditIndex = -1;
                    LoadTag();
                }
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show(ex.Message);
                    logger.Info(ex.Message);
                }

            }
        }

        protected void TagData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TagData.PageIndex = e.NewPageIndex;
            LoadTag();
        }



        //Code for users updation------ by Avinash-------------------------------------------------------------

        private void LoadUsers()
        {
            try
            {
             DataSet dataSet = manageUsers.LoadUsers();
            ManageUsersView.DataSource = dataSet;
            ManageUsersView.DataBind();   
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                logger.Info(ex.Message);
            }
        }
        
        protected void ManageUsersView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ManageUsersView.EditIndex = e.NewEditIndex;
            Label lblUsers = (Label)ManageUsersView.Rows[e.NewEditIndex].FindControl("LblAccess");
            string Role = lblUsers.Text;
            ViewState["Role"] = Role;
            LoadUsers();
        }

        protected void ManageUsersView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ManageUsersView.EditIndex = -1;

            LoadUsers();

        }

        protected void ManageUsersView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int CognizantId = Convert.ToInt32(ManageUsersView.DataKeys[e.RowIndex].Value.ToString());
            try
            {
               string msg= manageUsers.DeleteUsers(CognizantId);
               Response.Write("<script>alert('" + msg + "');</script>");
                ManageUsersView.EditIndex = -1;
                LoadUsers();
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                logger.Info(ex.Message);
            }

        }

        protected void ManageUsersView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int CognizantId = Convert.ToInt32(ManageUsersView.DataKeys[e.RowIndex].Value.ToString());
            string Role = ((DropDownList)ManageUsersView.Rows[e.RowIndex].FindControl("ddlAccess")).SelectedValue;
            string Rolechanged = (string)ViewState["Role"].ToString();
            if (Role == "")
                Response.Write("<script>alert('Field cannot be blank');</script>");
            else if (Role == Rolechanged)
            { }
            else
            {
                try
                {
                    string msg = manageUsers.UpdateUsers(CognizantId, Role);
                    Response.Write("<script>alert('" + msg + "');</script>");
                    ManageUsersView.EditIndex = -1;
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show(ex.Message);
                    logger.Info(ex.Message);
                }

            }
        }

        protected void ManageUsersView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ManageUsersView.PageIndex = e.NewPageIndex;
            LoadUsers();
        }    


       

        //--------code for Articles by avinash-----------------------------------------

        private void LoadArticles()
        {
            try
            {
                DataSet dataSet = manageArt.LoadArticles();
                ManageArticleView.DataSource = dataSet;
                ManageArticleView.DataBind();
            }
            catch (Exception ex)
            {
               // System.Windows.Forms.MessageBox.Show(ex.Message);
                logger.Info(ex.Message);
            }


        }
        protected void ManageArticleView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ArtId = Convert.ToInt32(ManageArticleView.DataKeys[e.RowIndex].Value.ToString());
            try
            {
         string msg= manageArt.DeleteArticle(ArtId);
         Response.Write("<script>alert('" + msg + "');</script>");
                ManageArticleView.EditIndex = -1;
                LoadArticles();
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                logger.Info(ex.Message);
            }

        }
        protected void ManageArticleView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ManageArticleView.PageIndex = e.NewPageIndex;
            LoadArticles();
        }



        //code for collections by avinash----------------------------

        private void LoadCollection()
        {
            
            try
            {
                DataSet dataSet = adminAccessCollections.LoadCollection();
                CollectionData.DataSource = dataSet;
                CollectionData.DataBind();
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                logger.Info(ex.Message);
            }


        }
        protected void lb_InsertCollections(object sender, EventArgs e)
        {
            string CollectionName = ((TextBox)CollectionData.FooterRow.FindControl("TxtColName")).Text;
            Int64 CognizantId = Convert.ToInt64(Session["CognizantId"].ToString());
            if (CollectionName == "")
                Response.Write("<script>alert('Field cannot be blank');</script>");
            else
            {
                try
                {
                  string msg= adminAccessCollections.InsertCollections(CollectionName,CognizantId);
                  Response.Write("<script>alert('" + msg + "');</script>");
                    CollectionData.EditIndex = -1;
                    LoadCollection();
                }
                catch (Exception ex)
                {
                   // System.Windows.Forms.MessageBox.Show(ex.Message);
                    logger.Info(ex.Message);
                }
            }
        }
        protected void CollectionData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            CollectionData.EditIndex = e.NewEditIndex;
            LoadCollection();
        }

        protected void CollectionData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            CollectionData.EditIndex = -1;
            LoadCollection();

        }

        protected void CollectionData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt32(CollectionData.DataKeys[e.RowIndex].Value.ToString());
            try
            {
               string msg= adminAccessCollections.DeleteCollections(Id);
               Response.Write("<script>alert('" + msg + "');</script>");
                CollectionData.EditIndex = -1;
                LoadCollection();
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                logger.Info(ex.Message);
            }

        }

        protected void CollectionData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int Id = Convert.ToInt32(CollectionData.DataKeys[e.RowIndex].Value.ToString());
            string CollectionName = ((TextBox)CollectionData.Rows[e.RowIndex].FindControl("txtName")).Text;
            if (CollectionName == "")
                Response.Write("<script>alert('Field cannot be blank');</script>");
            else
            {
                try
                {
                   string msg= adminAccessCollections.UpdateCollections(Id, CollectionName);
                   Response.Write("<script>alert('" + msg + "');</script>");
                    CollectionData.EditIndex = -1;
                    LoadCollection();
                }
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show(ex.Message);
                    logger.Info(ex.Message);
                }

            }
        }

        protected void CollectionData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CollectionData.PageIndex = e.NewPageIndex;
            LoadCollection();
        }

       protected void DllPageSizeUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(DllPageSizeUsers.SelectedValue) != ManageUsersView.PageSize)
            {
                ManageUsersView.PageSize = Convert.ToInt16(DllPageSizeUsers.SelectedValue);
                LoadUsers();
            }

        }

       protected void DllPageSizeApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(DllPageSizeApps.SelectedValue) != ApplicationData.PageSize)
            {
                ApplicationData.PageSize = Convert.ToInt16(DllPageSizeApps.SelectedValue);
                LoadApplication();
            }
        }

        protected void DllPageSizeArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(DllPageSizeArticles.SelectedValue) != ManageArticleView.PageSize)
            {
                ManageArticleView.PageSize = Convert.ToInt16(DllPageSizeArticles.SelectedValue);
                LoadArticles();
            }
        }

        protected void DllPageSizeCollections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(DllPageSizeCollections.SelectedValue) != CollectionData.PageSize)
            {
                CollectionData.PageSize = Convert.ToInt16(DllPageSizeCollections.SelectedValue);
                LoadCollection();
            }
        }

       protected void DllPageSizeTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(DllPageSizeTag.SelectedValue) != TagData.PageSize)
            {
                TagData.PageSize = Convert.ToInt16(DllPageSizeTag.SelectedValue);
                LoadTag();
            }
        }
    }
}