using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using EntityLayer;
using log4net;


namespace KMS
{
    public partial class AddKnowledge : System.Web.UI.Page
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(_Default));
        protected void Page_Load(object sender, EventArgs e)
        {
            panKbArticle.Enabled = false;
            panExceptionKnowledge.Enabled = false;

            panExceptionKnowledge.Visible = false;
            panKbArticle.Visible = false;

            if ((string)Session["role"] == "" || (string)Session["role"] != "ROLE002" && (string)Session["role"] != "ROLE003")
            {
                Session.Abandon();
                Response.Redirect("SessionExpired.aspx");
            }
            LoadingMenu();
            if (!(IsPostBack))
            {
                try
                {

                    GetApplicationName appName = new GetApplicationName();
                    List<string> l1 = new List<string>();
                    l1 = appName.getAppName();
                    int j = 0;
                    ddlApplicationName.Items.Insert(0, new ListItem("Select Application", "NA"));
                    ddlApplicationName2.Items.Insert(0, new ListItem("Select Application", "NA"));
                    foreach (var i in l1)
                    {
                        j++;
                        ddlApplicationName.Items.Insert(j, i);
                        ddlApplicationName2.Items.Insert(j, i);
                    }
                }
                catch (Exception ex)
                {
                    logger.Info(ex.Message);
                }
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
              
                Response.Write("<script>alert('Sorry Session has been expired...');</script>");
                Response.Redirect("startpage.aspx");
            }
        }

        protected void ddlApplicationName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void exceptionButton_Click(object sender, EventArgs e)
        {
            panKbArticle.Visible = false;
            btnExceptionKnowledge.Visible = false;
            btnKbArticle.Visible = false;
            panKbArticle.Enabled = false;

            panExceptionKnowledge.Enabled = true;
            panExceptionKnowledge.Visible = true;
        }

        protected void kbButton_Click(object sender, EventArgs e)
        {
           
            panExceptionKnowledge.Visible = false;
            btnExceptionKnowledge.Visible = false;
            btnKbArticle.Visible = false;
            panExceptionKnowledge.Enabled = false;

            panKbArticle.Enabled = true;
            panKbArticle.Visible = true;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (edtDetails.Content.ToString().Trim() == "" || ddlApplicationName.SelectedIndex==0)
            {
                if (edtDetails.Content.ToString().Trim() == "")
                    Response.Write("<script>alert('Please enter some Details');</script>");
                else
                    Response.Write("<script>alert('Please select an application');</script>");
                panKbArticle.Enabled = true;
                panKbArticle.Visible = true;
            }
            else
            {
                try
                {
                    FileUploads upload = new FileUploads();
                    long uid = Convert.ToInt64(Session["CognizantId"]);
                    SendMail sendMail = new SendMail();
                    Entity ob = new Entity();
                    ob.ApplicationName = ddlApplicationName.Text;
                    ob.CollectionName = txtCollectionName.Text;
                    ob.TagName = txtTagName.Text;
                    ob.Priority = ddlPriority.Text;
                    ob.Title = txtTitle.Text;
                    ob.Details = edtDetails.Content.ToString();


                    string Message = Business.InsertKBDetails(uid, ob.ApplicationName, ob.CollectionName, ob.TagName, ob.Priority, ob.Title, ob.Details);
                    //sendMail.DeliverEmail(uid,ddlApplicationName.SelectedValue);
                    Response.Write("<script>alert('Article submitted successfully');</script>");
                    //upload.ValidateUpload(Request.Files, Server.MapPath("~/Files/"));
                    string mymsg = upload.ValidateUpload(Request.Files, Server.MapPath("~/Files/")).ToString();
                                   

                    if (mymsg != "")
                    {
                        Response.Write("<script>alert('" + mymsg + "');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Document submitted successfully');</script>");
                    }



                    panKbArticle.Visible = true;
                    panKbArticle.Enabled = true;
                }
                catch (Exception ex)
                {
                    logger.Info(ex.Message);
                }
            }
        }

        protected void btnSubmit2_Click(object sender, EventArgs e)
        {
          if (edtResolution.Content.ToString().Trim() == "" || ddlApplicationName2.SelectedIndex==0||edtAdditionalInformation.Content.ToString().Length>100)
            {
                if (edtResolution.Content.ToString().Trim() == "")
                    Response.Write("<script>alert('Please enter some Details');</script>");
                else if(edtAdditionalInformation.Content.ToString().Length>100)
                {
                 Response.Write("<script>alert('Additional info support maximum 100 character');</script>");
                }
                else
                    Response.Write("<script>alert('Please select an application');</script>");
                Response.Write("<script>alert('Please enter some Resolution');</script>");
                panExceptionKnowledge.Enabled = true;
                panExceptionKnowledge.Visible = true;
            }
            else
            {
                try
                {
                    FileUploads uploads = new FileUploads();


                    long uid = Convert.ToInt64(Session["CognizantId"]);
                    Entity ob = new Entity();
                    SendMail sendMail = new SendMail();
                    ob.ApplicationName = ddlApplicationName2.Text;
                    ob.CollectionName = txtCollectionName2.Text;
                    ob.TagName = txtTagName2.Text;
                    ob.Priority = ddlPriority2.Text;
                    ob.Title = txtTitle2.Text;
                    ob.ProblemStatement = txtProblemStatement.Text;
                    ob.Resolution = edtResolution.Content.ToString();
                    ob.AdditionalInformation = edtAdditionalInformation.Content.ToString();

                    string Message = Business.InsertExceptionDetails(uid, ob.ApplicationName, ob.CollectionName, ob.TagName, ob.Priority, ob.ProblemStatement, ob.Resolution, ob.AdditionalInformation, ob.Title);
                    Response.Write("<script>alert('Article submitted successfully');</script>");
                    //sendMail.DeliverEmail(uid,ddlApplicationName.SelectedValue);   
                    string mymsg= uploads.ValidateUpload(Request.Files, Server.MapPath("~/Files/")).ToString();

                    if (mymsg != "")
                    {
                        Response.Write("<script>alert('"+mymsg+"');</script>");
                    }
                    else 
                    {
                        Response.Write("<script>alert('Document submitted successfully');</script>");
                    }
                    
                    panExceptionKnowledge.Visible = true;
                    panExceptionKnowledge.Enabled = true;
                }
                catch (Exception ex)
                {
                    logger.Info(ex.Message);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Page_Load(sender, e);

                ddlApplicationName.SelectedIndex = 0;
                txtCollectionName.Text = "";
                txtTagName.Text = "";
                ddlPriority.SelectedIndex = 0;
                txtTitle.Text = "";
                edtDetails.Content = "";
                panKbArticle.Visible = true;
                panKbArticle.Enabled = true;

                btnKbArticle.Visible = false;
                btnExceptionKnowledge.Visible = false;
                
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
        protected void btnCancel2_Click(object sender, EventArgs e)
        {
            try
            {
                Page_Load(sender, e);

                ddlApplicationName2.SelectedIndex = 0;
                txtCollectionName2.Text = "";
                txtTagName2.Text = "";
                ddlPriority2.SelectedIndex = 0;
                txtTitle2.Text = "";
                txtProblemStatement.Text = "";
                edtResolution.Content = "";
                edtAdditionalInformation.Content = "";
                panExceptionKnowledge.Visible = true;
                panExceptionKnowledge.Enabled = true;
                btnKbArticle.Visible = false;
                panKbArticle.Visible = false;
                btnExceptionKnowledge.Visible = false;
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void btnBackKb_Click(object sender, EventArgs e)
        {
            //Response.Redirect("AddKnowledge.aspx");
            btnKbArticle.Visible = true;
            btnExceptionKnowledge.Visible = true;

            panKbArticle.Visible = false;
            panKbArticle.Enabled = false;

            panExceptionKnowledge.Visible = false;
            panExceptionKnowledge.Enabled = false;

        }

        protected void btnBackEx_Click(object sender, EventArgs e)
        {
           //Response.Redirect("AddKnowledge.aspx");
            btnKbArticle.Visible = true;
            btnExceptionKnowledge.Visible = true;

            panKbArticle.Visible = false;
            panKbArticle.Enabled = false;

            panExceptionKnowledge.Visible = false;
            panExceptionKnowledge.Enabled = false;
        }
    }
}