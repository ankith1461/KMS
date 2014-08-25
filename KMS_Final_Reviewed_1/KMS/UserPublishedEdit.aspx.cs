using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;
using System.Windows.Forms;
using Ionic.Zip;
using System.IO;
using EntityLayer;
using log4net;

namespace KMS
{
    public partial class UserPublishedEdit : System.Web.UI.Page
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(_Default));
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["role"] == "" || (string)Session["role"] != "ROLE002" && (string)Session["role"] != "ROLE003")
            {
                Session.Abandon();
                Response.Redirect("SessionExpired.aspx");
            }


   //Complete code by Haneef and ramababu-----------------------------------------
            if (!IsPostBack)
            {


                string artid = Request.QueryString["ArticleId"];
                string appid = Request.QueryString["ApplicationId"];



                //getting ApplicationName from database  related to artid and populating in ddl

                ddlApplicationName.Items.Insert(0, new ListItem("Select Application", "NA"));

                List<string> l = BusinessUserEdit.BusinessUserDdlApplication(artid, appid);
                int k = 0;
                foreach (var item in l)
                {

                    ddlApplicationName.Items.Insert(k, item);
                    k++;
                }



                //getting Priority from database  related to artid and populating in ddl

                ddlPriority.Items.Insert(0, new ListItem("Select Priority", "NA"));

                List<string> Priorty = BusinessUserEdit.BusinessUserPopulateDdlPriority(artid, appid);
                int j = 0;
                foreach (var item in Priorty)
                {


                    ddlPriority.SelectedValue = item;
                    j++;
                }

                LoadData();
                LoadAttachment();
                ViewState["RefUrl"] = Request.UrlReferrer.ToString();

            }

        }



        protected void LoadData()
        {
            // retrieving ArticleId based on click event from previous page  

            string s = Request.QueryString["ArticleId"];
            ViewState["ArticleId"] = s;


            try
            {
                string ArticleStatus = Request.QueryString["ArticleStatus"];
                if (ArticleStatus.Equals("S001"))
                {
                    DataSet d = BusinessUserEdit.GetKBArticle(s);

                    ViewState["ArticleData"] = d;
                    if (d.Tables[0].Rows.Count > 0)
                    {
                        txtTitle.Text = d.Tables[0].Rows[0]["Title"].ToString();
                        editorDetails.Content = d.Tables[0].Rows[0]["Details"].ToString();
                        // lblArticleDateOfReg.Text = d.Tables[0].Rows[0]["DateOfRegistration"].ToString();
                        // lblArticleDateOfLastAccess.Text = d.Tables[0].Rows[0]["DateOfLastAcess"].ToString();
                        ddlPriority.SelectedValue = d.Tables[0].Rows[0]["Priority"].ToString();
                        //lblArticleApplication.Text = d.Tables[0].Rows[0]["AppName"].ToString();



                        txtCollectionName.Text = d.Tables["ArticleCollection"].Rows[0]["ColName"].ToString();
                        for (int i = 1; i < d.Tables["ArticleCollection"].Rows.Count; i++)
                        {
                            txtCollectionName.Text += "," + d.Tables[1].Rows[i]["ColName"].ToString();
                        }


                        txtTagName.Text = d.Tables["ArticleTag"].Rows[0]["Tname"].ToString();

                        for (int i = 1; i < d.Tables["ArticleTag"].Rows.Count; i++)
                        {
                            txtTagName.Text += "," + d.Tables["ArticleTag"].Rows[i]["Tname"].ToString();
                        }




                    }
                    else
                    {
                        Response.Write("<script>alert('No data found for your article')</script>");
                    }
                }
                else if (ArticleStatus.Equals("S002"))
                {
                    DataSet d = BusinessUserEdit.BusinessUserGetPublishedArticle(s);

                    ViewState["ArticleData"] = d;
                    if (d.Tables[0].Rows.Count > 0)
                    {
                        txtTitle.Text = d.Tables[0].Rows[0]["Title"].ToString();
                        editorDetails.Content = d.Tables[0].Rows[0]["Details"].ToString();
                        // lblArticleDateOfReg.Text = d.Tables[0].Rows[0]["DateOfRegistration"].ToString();
                        // lblArticleDateOfLastAccess.Text = d.Tables[0].Rows[0]["DateOfLastAcess"].ToString();
                        ddlPriority.SelectedValue = d.Tables[0].Rows[0]["Priority"].ToString();
                        //lblArticleApplication.Text = d.Tables[0].Rows[0]["AppName"].ToString();



                        txtCollectionName.Text = d.Tables["ArticleCollection"].Rows[0]["ColName"].ToString();
                        for (int i = 1; i < d.Tables["ArticleCollection"].Rows.Count; i++)
                        {
                            txtCollectionName.Text += "," + d.Tables[1].Rows[i]["ColName"].ToString();
                        }


                        txtTagName.Text = d.Tables["ArticleTag"].Rows[0]["Tname"].ToString();

                        for (int i = 1; i < d.Tables["ArticleTag"].Rows.Count; i++)
                        {
                            txtTagName.Text += "," + d.Tables["ArticleTag"].Rows[i]["Tname"].ToString();
                        }




                    }
                    else
                    {
                        Response.Write("<script>alert('No data found for your article')</script>");
                    }
                }
                else
                {
                    DataSet d = BusinessUserEdit.BusinessUserGetRejectedArticle(s);

                    ViewState["ArticleData"] = d;
                    if (d.Tables[0].Rows.Count > 0)
                    {
                        txtTitle.Text = d.Tables[0].Rows[0]["Title"].ToString();
                        editorDetails.Content = d.Tables[0].Rows[0]["Details"].ToString();
                        // lblArticleDateOfReg.Text = d.Tables[0].Rows[0]["DateOfRegistration"].ToString();
                        // lblArticleDateOfLastAccess.Text = d.Tables[0].Rows[0]["DateOfLastAcess"].ToString();
                        ddlPriority.SelectedValue = d.Tables[0].Rows[0]["Priority"].ToString();
                        //lblArticleApplication.Text = d.Tables[0].Rows[0]["AppName"].ToString();



                        txtCollectionName.Text = d.Tables["ArticleCollection"].Rows[0]["ColName"].ToString();
                        for (int i = 1; i < d.Tables["ArticleCollection"].Rows.Count; i++)
                        {
                            txtCollectionName.Text += "," + d.Tables[1].Rows[i]["ColName"].ToString();
                        }


                        txtTagName.Text = d.Tables["ArticleTag"].Rows[0]["Tname"].ToString();

                        for (int i = 1; i < d.Tables["ArticleTag"].Rows.Count; i++)
                        {
                            txtTagName.Text += "," + d.Tables["ArticleTag"].Rows[i]["Tname"].ToString();
                        }




                    }
                    else
                    {
                        Response.Write("<script>alert('No data found for your article')</script>");
                    }
                }



            }
            catch (Exception e)
            {
                logger.Info(e.Message);
            }

        }


        // binding documents  data to attachment gridview
        /// <summary>
        /// gets all attachments of articles
        /// </summary>
        protected void LoadAttachment()
        {
            DataSet d = (DataSet)ViewState["ArticleData"];
            DataTable dt = d.Tables["ArticleFile"];
            gvAttachment.DataSource = dt;
            gvAttachment.DataBind();
        }

        //file downoad
        // protected void LinkButtonClick(object sender, CommandEventArgs e)
        // {

        //  DownloadAttachment(e.CommandArgument.ToString());



        //int row = Convert.ToInt32(e.CommandArgument.ToString());

        //  }

        // protected void lnkbtnDownload_Click(object sender, EventArgs e)
        // {
        // DownloadAttachment(e. ToString());
        //}





        /// <summary>
        /// capturing click event on gridview and calling download attachment() method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvAttachment_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            DownloadAttachment(e.CommandArgument.ToString());

        }




        /// <summary>
        /// code to download attachments
        /// </summary>
        /// <param name="DocId"></param>
        protected void DownloadAttachment(string DocId)
        {
            try
            {
                DataTable dt = BusinessUserEdit.GetArticleAttachment(DocId);
                Byte[] bytes = (Byte[])dt.Rows[0]["DocData"];

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["DocType"].ToString();

                Response.AddHeader("content-disposition", "attachment;filename="
                + dt.Rows[0]["DocName"].ToString());

                Response.BinaryWrite(bytes);

                Response.Flush();
                Response.End();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }




        /// <summary>
        /// //on clicking update button article datails are updated 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUserPublishedUpdate_Click(object sender, EventArgs e)
        {
            //getting all values from entity layer

            EntityUserPublishedEdit ArtDetails = new EntityUserPublishedEdit();
            ArtDetails.Title = txtTitle.Text;
            ArtDetails.ApplicationName = ddlApplicationName.Text;
            ArtDetails.Collection = txtCollectionName.Text; ;
            ArtDetails.TagName = txtTagName.Text;
            ArtDetails.Priority = ddlPriority.Text;
            ArtDetails.Details = editorDetails.Content;
            string AppId = Request.QueryString["ApplicationId"];
            string ArtId = Request.QueryString["ArticleId"];

            // calling business layer
            try
            {





                DataSet d = (DataSet)ViewState["ArticleData"];
                DataTable dt = d.Tables["ArticleFile"];
                int TotalDocs = d.Tables["ArticleFile"].Rows.Count;


                for (int i = 0; i < Request.Files.Count; i++)
                {

                    if (TotalDocs > 0 && i < TotalDocs)
                    {



                        UpdateFiles(d, i);

                    }
                    else
                    {
                        InsertFiles(ArtId, i);
                    }
                }
                string message = BusinessUserEdit.BusinessUserUpdateArticleDetails(ArtId, AppId, ArtDetails.Title, ArtDetails.ApplicationName, ArtDetails.Collection, ArtDetails.TagName, ArtDetails.Priority, ArtDetails.Details);
                Response.Write("<script>alert('" + message + "')</script>");
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }



        /// <summary>
        /// inserts new if no  files are existing previously
        /// </summary>
        /// <param name="ArtId"></param>
        /// <param name="i"></param>
        private void InsertFiles(string ArtId, int i)
        {
            HttpPostedFile PostedFile = Request.Files[i];
            if (PostedFile.ContentLength > 0)
            {
                string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                PostedFile.SaveAs(Server.MapPath("~/Files/") + FileName);

                //MessageBox.Show(PostedFile.FileName+"sud");
                string extension = FileName.Substring(FileName.LastIndexOf(".") + 1);
                string extractPath = Server.MapPath("~/Files/");
                //MessageBox.Show(extractPath + " hello");
                int no_Of_File = 0;
                string[] allowdFile = { ".pdf", ".txt", "text", ".doc", ".rtf", ".ppt", "ppt", "pptx", ".jpg", ".bmp", ".rar", ".zip", ".xls", ".xlsx", ".docx" };
                //•	rtf, doc, xls, ppt, pdf, jpg, bmp, zip, rar and txt. 
                string FileExt = "." + extension;
                //MessageBox.Show(FileExt + " hello");
                bool isValidFile = allowdFile.Contains(FileExt);
                int sizeFlag = 0;
                if (!isValidFile)
                {
                    string msg = "Please upload only rtf, doc, xls, ppt, pdf, jpg, bmp, zip, rar and txt. ";
                    Response.Write("<script>alert('" + msg + "'); </Script>");

                }
                else if (PostedFile.ContentLength > 10485760)//10485760 byte = 10MB
                {
                    sizeFlag = 1;
                    string msg = "size>10mb";
                    Response.Write("<script>alert('" + msg + "'); </Script>");
                }

                else if (FileExt.Equals(".zip"))
                {
                    // code when user uplaoding a zip file

                    bool validZip = true;
                    int zipHasDirectoryFlag = 0;
                    using (var zip = ZipFile.Read(PostedFile.FileName))
                    {
                        int totalEntries = zip.Entries.Count;
                        foreach (ZipEntry zz in zip.Entries)
                        {
                            // MessageBox.Show(zz.FileName);
                            if (zz.IsDirectory == true)
                            {
                                zipHasDirectoryFlag = 1;
                                break;
                            }
                            else
                            {
                                //MessageBox.Show(zz.FileName.Substring(zz.FileName.LastIndexOf(".")));
                                validZip = allowdFile.Contains(zz.FileName.Substring(zz.FileName.LastIndexOf(".")));
                                if (validZip == false)
                                    break;
                                else
                                    no_Of_File++;
                            }

                        }
                        if (validZip == false)
                            Response.Write("<script>alert('zip contain unsupported file'); </Script>");
                        else if (zipHasDirectoryFlag == 1)
                        {
                            Response.Write("<script>alert('zip contain subdirectory cant upload  file'); </Script>");

                        }
                        else if (no_Of_File > 3)
                        {
                            Response.Write("<script>alert('u cannot upload more than3 file'); </Script>");

                        }

                        else
                        {
                            string fname = PostedFile.FileName.Substring(PostedFile.FileName.LastIndexOf("\\") + 1, PostedFile.FileName.LastIndexOf(".") - (PostedFile.FileName.LastIndexOf("\\")) - 1);

                            // MessageBox.Show("fname is " + fname);
                            string path = Path.Combine(extractPath, fname);
                            //MessageBox.Show(path + " hi");
                            Directory.CreateDirectory(path);

                            foreach (ZipEntry zz in zip.Entries)
                            {

                                byte[] binary = new byte[PostedFile.ContentLength];
                                PostedFile.InputStream.Read(binary, 0, PostedFile.ContentLength);
                                BusinessUserEdit.BusinessUserUploadFiles(ArtId, zz.FileName, binary, zz.FileName.Substring(zz.FileName.LastIndexOf(".") + 1));

                            }

                            zip.ExtractAll(path, ExtractExistingFileAction.DoNotOverwrite);


                            Response.Write("<script>alert('zip documents uploaded');</script>");


                        }

                        // MessageBox.Show(no_Of_File.ToString());
                    }



                }
                else
                {
                    //when uploading documents individually

                    byte[] binary = new byte[PostedFile.ContentLength];
                    PostedFile.InputStream.Read(binary, 0, PostedFile.ContentLength);
                    BusinessUserEdit.BusinessUserInsertFiles(ArtId, FileName, binary, extension);
                    Response.Write("<script>alert('normal documents uploaded');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('cant upload empty file'); </Script>");
            }
        }




        /// <summary>
        /// updates artcle documents already existing ones
        /// </summary>
        /// <param name="d"></param>
        /// <param name="i"></param>
        private void UpdateFiles(DataSet d, int i)
        {
            string DocId = d.Tables["ArticleFile"].Rows[i]["DocId"].ToString();
            if (DocId != null)
            {
                HttpPostedFile PostedFile = Request.Files[i];
                if (PostedFile.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                    PostedFile.SaveAs(Server.MapPath("~/Files/") + FileName);

                    //MessageBox.Show(PostedFile.FileName+"sud");
                    string extension = FileName.Substring(FileName.LastIndexOf(".") + 1);
                    string extractPath = Server.MapPath("~/Files/");
                    //MessageBox.Show(extractPath + " hello");
                    int no_Of_File = 0;
                    string[] allowdFile = { ".pdf", ".txt", "text", ".doc", ".rtf", ".ppt", "ppt", "pptx", ".jpg", ".bmp", ".rar", ".zip", ".xls", ".xlsx", ".docx" };
                    //•	rtf, doc, xls, ppt, pdf, jpg, bmp, zip, rar and txt. 
                    string FileExt = "." + extension;
                    //MessageBox.Show(FileExt + " hello");
                    bool isValidFile = allowdFile.Contains(FileExt);
                    int sizeFlag = 0;
                    if (!isValidFile)
                    {
                        string msg = "Please upload only rtf, doc, xls, ppt, pdf, jpg, bmp, zip, rar and txt. ";
                        Response.Write("<script>alert('" + msg + "'); </Script>");

                    }
                    else if (PostedFile.ContentLength > 10485760)//10485760 byte = 10MB
                    {
                        sizeFlag = 1;
                        string msg = "size>10mb";
                        Response.Write("<script>alert('" + msg + "'); </Script>");
                    }

                    else if (FileExt.Equals(".zip"))
                    {
                        // code when user uplaoding a zip file

                        bool validZip = true;
                        int zipHasDirectoryFlag = 0;
                        using (var zip = ZipFile.Read(PostedFile.FileName))
                        {
                            int totalEntries = zip.Entries.Count;
                            foreach (ZipEntry zz in zip.Entries)
                            {
                                // MessageBox.Show(zz.FileName);
                                if (zz.IsDirectory == true)
                                {
                                    zipHasDirectoryFlag = 1;
                                    break;
                                }
                                else
                                {
                                    //MessageBox.Show(zz.FileName.Substring(zz.FileName.LastIndexOf(".")));
                                    validZip = allowdFile.Contains(zz.FileName.Substring(zz.FileName.LastIndexOf(".")));
                                    if (validZip == false)
                                        break;
                                    else
                                        no_Of_File++;
                                }

                            }
                            if (validZip == false)
                                Response.Write("<script>alert('zip contain unsupported file'); </Script>");

                            else if (zipHasDirectoryFlag == 1)
                            {

                                Response.Write("<script>alert('zip contain subdirectory cant upload  file'); </Script>");
                            }
                            else if (no_Of_File > 3)
                            {
                                Response.Write("<script>alert('u cannot upload more than3 file'); </Script>");

                            }

                            else
                            {
                                string fname = PostedFile.FileName.Substring(PostedFile.FileName.LastIndexOf("\\") + 1, PostedFile.FileName.LastIndexOf(".") - (PostedFile.FileName.LastIndexOf("\\")) - 1);

                                // MessageBox.Show("fname is " + fname);
                                string path = Path.Combine(extractPath, fname);
                                //MessageBox.Show(path + " hi");
                                Directory.CreateDirectory(path);

                                foreach (ZipEntry zz in zip.Entries)
                                {

                                    byte[] binary = new byte[PostedFile.ContentLength];
                                    PostedFile.InputStream.Read(binary, 0, PostedFile.ContentLength);
                                    BusinessUserEdit.BusinessUserInsertFiles(DocId, zz.FileName, binary, zz.FileName.Substring(zz.FileName.LastIndexOf(".") + 1));

                                }

                                zip.ExtractAll(path, ExtractExistingFileAction.DoNotOverwrite);





                            }

                            // MessageBox.Show(no_Of_File.ToString());
                        }



                    }
                    else
                    {
                        //when uploading documents individually

                        byte[] binary = new byte[PostedFile.ContentLength];
                        PostedFile.InputStream.Read(binary, 0, PostedFile.ContentLength);
                        BusinessUserEdit.BusinessUserUploadFiles(DocId, FileName, binary, extension);

                    }

                }
                else
                {
                    Response.Write("<script>alert('cant upload empty file'); </Script>");
                }
            }
        }


        /// <summary>
        /// enabling controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        protected void btnUserPublishedEdit_Click(object sender, EventArgs e)
        {
            if (ViewState["RefUrl"] != null)
            {
                Response.Redirect((string)ViewState["RefUrl"]);
            }
        }
    }
}