using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Mail;
using DataAccessLayer;

namespace BusinessLayer
{
  public  class SendMail
    {
        public string DeliverEmail(long userId,string appId)
        {
            GetMailAddress mailAddress = new GetMailAddress();
            string message = "User with user id="+appId+" has uploaded a new article. Please check";
            List<string> toAddress = mailAddress.getEmailId(userId, appId);
            string fromAddress="";
            int i=0;
            string subject="New article has been uploaded by " + userId.ToString();
           try
           {
            for(i=0;i<toAddress.Count;i++)
            {
            MailMessage Message = new MailMessage(); 
            Message.IsBodyHtml = true; 
            Message.To.Add(new MailAddress(toAddress[i]));
            Message.From = new MailAddress(fromAddress); 
            Message.Subject = subject; 
            Message.Body = message; 
           // Message.ReplyToList.Add(this.fromEmail);
            SmtpClient sc = new SmtpClient();
            sc.EnableSsl = true; 
            sc.Send(Message);
            }
        } 
        catch (Exception e) 
        {
            throw e;
        }
         return "Email sent successfully!!!"; 
         
        }
    }
}
