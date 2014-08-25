using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
  public  class ApplicationName
    {
        public List<string> getAppName()
        {
            List<string> appName = new List<string>();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("get_application_names", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                appName.Add(dt.Rows[i][0].ToString());

            }
            return appName;
        }
    }
}
