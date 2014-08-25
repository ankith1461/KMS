using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using BusinessLayer;
using log4net;

namespace KMS
{
    public partial class startpage : System.Web.UI.Page
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(_Default));
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void BtnRegister_Click(object sender, EventArgs e)
        {

        }

        //By vamsee----------------------------------------------------------
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            
            ElUserLogin objLogin = new ElUserLogin();
            objLogin.UserName = Convert.ToInt64(TxtUsername.Text);
            objLogin.Password = TxtPassword.Text;
           string Message = BlUserLogin.ValidateUserLogin(objLogin.UserName, objLogin.Password);

           
            if (Message.Equals("ROLE001"))//admin role
            {
                Session["role"] = Message;
                Session["CognizantId"] = Convert.ToInt64(TxtUsername.Text);
                Response.Redirect("Home.aspx");
            }
            if (Message.Equals("ROLE002"))//user role
            {
                Session["role"] = Message;
                Session["CognizantId"] = Convert.ToInt64(TxtUsername.Text);
                Response.Redirect("Home.aspx");
            }
            if (Message.Equals("ROLE003"))//author role
            {
                Session["role"] = Message;
                Session["CognizantId"] = Convert.ToInt64(TxtUsername.Text);
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblMsg.Visible = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

       
    }
}