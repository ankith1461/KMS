using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataAccessLayer
{
  public  class GetMailAddress
    {
      public List<string> getEmailId(long userId, string appId)
      {
          List<string> mailAddress = new List<string>();
          try
          {
              SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString);
              SqlCommand cmd = new SqlCommand("get_email_address", con);
              con.Open();
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.Add("@userid", SqlDbType.BigInt).Value = userId;
              cmd.Parameters.Add("@appid", SqlDbType.NVarChar, 25).Value = appId;
              SqlDataAdapter da = new SqlDataAdapter(cmd);

              DataTable dt = new DataTable();

              da.Fill(dt);



              for (int i = 0; i < dt.Rows.Count; i++)
              {

                  mailAddress.Add(dt.Rows[i][0].ToString());

              }
              return mailAddress;
          }
          catch (Exception e)
          {
              throw e;

          }
          
      }
    }
}
