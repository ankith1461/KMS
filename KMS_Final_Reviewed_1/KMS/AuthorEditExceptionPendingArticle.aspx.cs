using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BusinessLayer;
using log4net;

namespace KMS
{
    public partial class AuthorEditExceptionPendingArticle : System.Web.UI.Page
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(_Default));
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["role"] == "" || (string)Session["role"] != "ROLE003")
            {
                Session.Abandon();
                Response.Redirect("SessionExpired.aspx");
            }
            try
            {
                if (!IsPostBack)
                {
                    pnlExceptionRejectReason.Visible = false;
                    LoadData();
                    LoadAttachment();
                    ViewState["RefUrl"] = Request.UrlReferrer.ToString();
                    lblArticleStatus.Visible = false;

                    Session["CognizantId"] = 361054;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
                
            }

        }
        //written by kranthi----------------------
        protected void LoadData()
        {
            try
            {
                string s = Request.QueryString["Id"];
                ViewState["ArticleId"] = s;
                BussinessLayerAuthorPendingArticle obj = new BussinessLayerAuthorPendingArticle();
                DataSet d = obj.GetKBArticle(s);

                ViewState["ArticleData"] = d;
                if (d.Tables[0].Rows.Count > 0)
                {
                    lblArticleProblemStatement.Text = d.Tables[0].Rows[0]["ProblemStatement"].ToString();
                    if (d.Tables[0].Rows[0]["Resolution"].ToString().Length > 1000)
                    {
                        lblArticleResolution.Width = 500;
                        lblArticleResolution.Height = 200;
                        lblArticleResolution.BorderWidth = 0;
                        lblArticleResolution.Text = d.Tables[0].Rows[0]["Resolution"].ToString();
                    }
                    else
                    {
                        lblArticleResolution.Text = d.Tables[0].Rows[0]["Resolution"].ToString();
                    }
                    lblArticleDateOfReg.Text = d.Tables[0].Rows[0]["DateOfRegistration"].ToString().Substring(0, 9);
                    lblArticleDateOfLastAccess.Text = d.Tables[0].Rows[0]["DateOfLastAcess"].ToString().Substring(0, 9);
                    lblArticlePriority.Text = d.Tables[0].Rows[0]["Priority"].ToString();
                    lblArticleApplication.Text = d.Tables[0].Rows[0]["AppName"].ToString();
                    lblArticleAdditionalDetail.Text = d.Tables[0].Rows[0]["AddtionalInformation"].ToString();



                    //collection
                    if (d.Tables["ArticleCollection"].Rows.Count > 0)
                    {
                        lblArticleCollection.Text = d.Tables["ArticleCollection"].Rows[0]["ColName"].ToString();
                        for (int i = 1; i < d.Tables["ArticleCollection"].Rows.Count; i++)
                        {
                            lblArticleCollection.Text += "," + d.Tables[1].Rows[i]["ColName"].ToString();
                        }
                    }
                    else
                    {
                        lblArticleCollection.Text = "No Collections are associated";
                    }




                    //tags

                    if (d.Tables["ArticleTag"].Rows.Count > 0)
                    {
                        lblArticleTag.Text = d.Tables["ArticleTag"].Rows[0]["Tname"].ToString();

                        for (int i = 1; i < d.Tables["ArticleTag"].Rows.Count; i++)
                        {
                            lblArticleTag.Text += "," + d.Tables["ArticleTag"].Rows[i]["Tname"].ToString();
                        }
                    }
                    else
                    {
                        lblArticleTag.Text = "No Tags are associated";
                    }




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



        protected void LoadAttachment()
        {
            DataSet d = (DataSet)ViewState["ArticleData"];
            DataTable dt = d.Tables["ArticleFile"];
            if (d.Tables["ArticleFile"].Rows.Count > 0)
            {
                lblExceptionAttachment.Visible = true;
                gvAttachment.DataSource = dt;
                gvAttachment.DataBind();
            }
            else
            {
                lblExceptionAttachment.Visible = false;
            }
        }

        //file downoad
        protected void LinkButtonClick(object sender, CommandEventArgs e)
        {

            DownloadAttachment(e.CommandArgument.ToString());



            //int row = Convert.ToInt32(e.CommandArgument.ToString());

        }

        protected void DownloadAttachment(string DocId)
        {
            try
            {
                BussinessLayerAuthorPendingArticle bt = new BussinessLayerAuthorPendingArticle();
                DataTable dt = bt.GetArticleAttachment(DocId);
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
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
            }

        }



        //back button
        protected void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (ViewState["RefUrl"] != null)
            {
                Response.Redirect((string)ViewState["RefUrl"]);
            }
        }




        //accepting article
        protected void btnArticleAccept_Click(object sender, EventArgs e)
        {
            try
            {
                BussinessLayerAuthorPendingArticle obj = new BussinessLayerAuthorPendingArticle();
                String message = string.Empty;
                int i;
                i = obj.AuthorAcceptArticle(ViewState["ArticleId"].ToString(), "S002");

                if (i > 0)
                {
                    //message = "The Article has be successfully Accepted";
                    //lblArticleStatus.Visible = true;
                    //lblArticleStatus.Text = message;
                    //Response.Write("<script>alert('The Article has be successfully Accepted');</script>");
                    //Response.Redirect((string)ViewState["RefUrl"]);

                    string msg = "The article is sucessfully Accepted";
                    string url = (string)ViewState["RefUrl"];
                    string script = "window.onload = function(){ alert('";
                    script += msg;
                    script += "');";
                    script += "window.location = '";
                    script += url;
                    script += "'; }";
                    ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                }
                else
                {
                    //message = "Please check again";
                    //Response.Write("<script>alert('Please check again');</script>");
                    //Response.Redirect((string)ViewState["RefUrl"]);
                    //lblArticleStatus.Visible = true;
                    //lblArticleStatus.Text = message;

                    string msg = "Please check again";
                    string url = (string)ViewState["RefUrl"];
                    string script = "window.onload = function(){ alert('";
                    script += msg;
                    script += "');";
                    script += "window.location = '";
                    script += url;
                    script += "'; }";
                    ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
            }

        }


        //reject article
        protected void btnArticleReject_Click(object sender, EventArgs e)
        {
            btnArticleReject.Visible = false;
            btnArticleAccept.Visible = false;
            btnPreviousPage.Visible = false;
            pnlExceptionRejectReason.Visible = true;

        }

        protected void btnSubmitReason_Click(object sender, EventArgs e)
        {
            try
            {
                BussinessLayerAuthorPendingArticle obj = new BussinessLayerAuthorPendingArticle();
                String message = string.Empty;
                int i, j;
                string reason = txtRejectReason.Text;
                Int64 id = Convert.ToInt64(Session["CognizantId"].ToString());
                j = obj.ArticleRejectReason(ViewState["ArticleId"].ToString(), id, reason);
                if (j > 0)
                {
                    i = obj.AuthorAcceptArticle(ViewState["ArticleId"].ToString(), "S003");
                    if (i > 0)
                    {
                        //message = "The Article has be successfully rejected";
                        //lblArticleStatus.Visible = true;
                        //lblArticleStatus.Text = message;
                        //Response.Write("<script>alert('The Article has be successfully Rejected');</script>");
                        //Response.Redirect((string)ViewState["RefUrl"]);




                        string msg = "The article is sucessfully rejected";
                        string url = (string)ViewState["RefUrl"];
                        string script = "window.onload = function(){ alert('";
                        script += msg;
                        script += "');";
                        script += "window.location = '";
                        script += url;
                        script += "'; }";
                        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                    }
                    else
                    {
                        //message = "Please check again";
                        //Response.Write("<script>alert('Please check again');</script>");
                        //Response.Redirect((string)ViewState["RefUrl"]);
                        //lblArticleStatus.Visible = true;
                        //lblArticleStatus.Text = message;

                        string msg = "Please check again";
                        string url = (string)ViewState["RefUrl"];
                        string script = "window.onload = function(){ alert('";
                        script += msg;
                        script += "');";
                        script += "window.location = '";
                        script += url;
                        script += "'; }";
                        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
                logger.Info(ex.Message);
            }
        }
       
    }
}