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
    public partial class AuthorEditKBPendingArticle : System.Web.UI.Page
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(_Default));
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["role"] == "" || (string)Session["role"] != "ROLE003")
            {
                Session.Abandon();
                Response.Redirect("SessionExpired.aspx");
            }
            if (!IsPostBack)
            {
                try
                {
                    pnlRejectReason.Visible = false;
                    LoadData();
                    LoadAttachment();
                    ViewState["RefUrl"] = Request.UrlReferrer.ToString();
                    lblArticleStatus.Visible = false;

                    Session["CognizantId"] = 361054;
                }
                catch (Exception ex)
                {
                    logger.Info(ex.Message);
                }
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
                    System.Windows.Forms.Label l = new System.Windows.Forms.Label();
                    lblArticleTitle.Text = d.Tables[0].Rows[0]["Title"].ToString();


                    if (d.Tables[0].Rows[0]["Details"].ToString().Length > 1000)
                    {
                        Label1.Width = 500;
                        Label1.Height = 200;
                        Label1.BorderWidth = 0;

                        Label1.Text = d.Tables[0].Rows[0]["Details"].ToString();
                    }
                    else
                    {
                        Label1.Text = d.Tables[0].Rows[0]["Details"].ToString();
                    }


                    //Label1.Text =  d.Tables[0].Rows[0]["Details"].ToString();
                    //txtArticleDetails.Text = l.Text;
                    lblArticleDateOfReg.Text = d.Tables[0].Rows[0]["DateOfRegistration"].ToString().Substring(0, 9);
                    lblArticleDateOfLastAccess.Text = d.Tables[0].Rows[0]["DateOfLastAcess"].ToString().Substring(0, 9);
                    lblArticlePriority.Text = d.Tables[0].Rows[0]["Priority"].ToString();
                    lblArticleApplication.Text = d.Tables[0].Rows[0]["AppName"].ToString();


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
                logger.Info(ex.Message);
            }

        }



        protected void LoadAttachment()
        {
            DataSet d = (DataSet)ViewState["ArticleData"];
            DataTable dt = d.Tables["ArticleFile"];
            if (dt.Rows.Count > 0)
            {
                lblKBPendingArticleAttachments.Visible = true;
                gvAttachment.Visible = true;
                gvAttachment.DataSource = dt;
                gvAttachment.DataBind();
            }
            else
            {
                gvAttachment.Visible = false;
                lblKBPendingArticleAttachments.Visible = false;
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
                logger.Info(ex.Message);
            }

        }


        //reject article
        protected void btnArticleReject_Click(object sender, EventArgs e)
        {
            pnlRejectReason.Visible = true;
            btnArticleAccept.Visible = false;
            btnArticleReject.Visible = false;
            btnPreviousPage.Visible = false;

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
                logger.Info(ex.Message);
            }



        } 
        
        
    }
}