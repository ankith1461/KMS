using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.IO;
using System.Data;
using BusinessLayer;

namespace KMS
{
    public partial class BulkUpload : System.Web.UI.Page
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(_Default));
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["role"] == "" || (string)Session["role"] != "ROLE002" && (string)Session["role"] != "ROLE003")
            {
                Session.Abandon();
                Response.Redirect("SessionExpired.aspx");
            }
            LoadingMenu();
            if (!IsPostBack)
            {
                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
                divGridViewExcp.Visible = false;
                divGridViewKB.Visible = false;
                div1.Visible = false;
                div2.Visible = false;
                //session need to be checked
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
                Response.Redirect("SessionExpired.aspx");
            }
        }



        //Bulk upload module code by Saikat, Subronil and team---------------------------------------------
        protected void BtnImgTemplateExcp_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ExcelTemplates/Template_Exceptional_Knowledge.xlsx");
        }
        protected void BtnImgTemplateKB_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ExcelTemplates/Template_KB_Article.xlsx");
        }

        protected void BtnUploadExcp_Click(object sender, EventArgs e)
        {
            
            string path = string.Empty;
            try
            {
                if (FileUploadExcp.HasFile)
                {
                    if ((Path.GetExtension(FileUploadExcp.FileName) == ".zip") && (FileUploadExcp.PostedFile.ContentLength <= (50 * 1024 * 1024)))
                    {
                        //dtExcelRecords.Clear();
                        //accept only zip file of max size 50 MB
                        int[] arr_status;
                        string filename = FileUploadExcp.FileName;
                        path = Server.MapPath("~/") + filename;
                        FileUploadExcp.SaveAs(path);// saving the file to the server
                        BlBulkUpload ob = new BlBulkUpload();
                        DataTable dtExcelRecords = ob.UploadArticle(path, out arr_status);// will return the excel sheet
                        GridViewExcp.DataSource = dtExcelRecords;
                        GridViewExcp.DataBind();
                        
                        foreach (GridViewRow myRow in GridViewExcp.Rows)
                        {
                            Image img1 = (Image)myRow.FindControl("Image1");
                            //CheckBox chkbox1 = (CheckBox)myRow.FindControl("CheckBox1");
                            int i = myRow.RowIndex;

                            if (arr_status[i] == 1)
                            {
                                img1.ImageUrl = "images/tickimg.png";
                            }

                            else
                            {
                                img1.ImageUrl = "images/crossimg.png";
                            }

                        }

                        div1.Style["display"] = "block";
                        div2.Style["display"] = "none";
                        divGridViewExcp.Visible = true;

                    }
                    else
                    {
                        logger.Info("The following error has occurred: Please select a .zip file of Maximum Size 50 MB");
                        Response.Write("<script>alert('The following error has occurred: Please select a .zip file of Maximum Size 50 MB.');</script>");

                        FileUploadExcp.Dispose();// clearing selected content              
                    }
                }                
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
                Response.Write("<script>alert('The following error has occurred: " + ex.Message.ToString() + " .');</script>");

            }
            finally
            {
                //delete the file
                if (path != "")
                {
                    File.Delete(path);
                }
                
               
            }
            

        }


        protected void BtnUploadKB_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            try
            {
                if (FileUploadKB.HasFile)
                {
                    if ((Path.GetExtension(FileUploadKB.FileName) == ".zip") && (FileUploadKB.PostedFile.ContentLength <= (50 * 1024 * 1024)))
                    {
                        int[] arr_status;
                        //accept only zip file of max size 50 MB
                        string filename = FileUploadKB.FileName;
                        path = Server.MapPath("~/") + filename;
                        FileUploadKB.SaveAs(path);// saving the file to the server
                        BlBulkUpload ob = new BlBulkUpload();
                        DataTable dtExcelRecords = ob.UploadArticle(path, out arr_status);// will return the excel sheet
                        GridViewKB.DataSource = dtExcelRecords;
                        GridViewKB.DataBind();

                        foreach (GridViewRow myRow in GridViewKB.Rows)
                        {
                            Image img2 = (Image)myRow.FindControl("Image2");
                            //CheckBox chkbox1 = (CheckBox)myRow.FindControl("CheckBox1");
                            int i = myRow.RowIndex;

                            if (arr_status[i] == 1)
                            {
                                img2.ImageUrl = "images/tickimg.png";
                            }

                            else
                            {
                                img2.ImageUrl = "images/crossimg.png";
                            }

                        }
                        div2.Style["display"] = "block";
                        div1.Style["display"] = "none";
                        divGridViewKB.Visible = true;

                    }
                    else
                    {
                        logger.Info("The following error has occurred: Please select a .zip file of Maximum Size 50 MB");
                        Response.Write("<script>alert('The following error has occurred: Please select a .zip file of Maximum Size 50 MB');</script>");

                        FileUploadKB.Dispose();// clearing selected content              

                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
                Response.Write("<script>alert('The following errors have occurred: \n" + ex.Message.ToString() + " .');</script>");

            }
            finally
            {
                //delete the file
                if(path!="")
                File.Delete(path);
            }

        }

        protected void GridViewExcp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewExcp.PageIndex = e.NewPageIndex;
            GridViewExcp.DataBind();
        }

        protected void GridViewKB_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewKB.PageIndex = e.NewPageIndex;
            GridViewKB.DataBind();
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            div1.Visible = true;
            div2.Visible = false;
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            div2.Visible = true;
            div1.Visible = false;
        }
        //protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        //{
        //    RequiredFieldValidator1.Enabled = true;
        //    RequiredFieldValidator2.Enabled = false;
        //    
        //    divGridViewExcp.Visible = false;
        //    divGridViewKB.Visible = false;
        //}
        //protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        //{
        //    RequiredFieldValidator2.Enabled = true;
        //    RequiredFieldValidator1.Enabled = false;
        //    div2.Visible = true;
        //    div1.Visible = false;
        //    divGridViewExcp.Visible = false;
        //    divGridViewKB.Visible = false;

        //}
    }
}