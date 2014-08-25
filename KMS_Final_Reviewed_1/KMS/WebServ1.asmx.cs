using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace KnowledgeManagementSystem
{
    /// <summary>
    /// Summary description for WebServ1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class WebServ1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<string> Collections(string prefixText)
        {

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("get_collection_name", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Colname", SqlDbType.NVarChar, 25).Value = prefixText;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            List<string> ColumnName = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ColumnName.Add(dt.Rows[i][0].ToString());

            }

            return ColumnName;

        }
        [WebMethod]
        public List<string> Tags(string prefixText)
        {

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("get_tag_name", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tagname", SqlDbType.NVarChar, 25).Value = prefixText;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            List<string> ColumnName = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ColumnName.Add(dt.Rows[i][0].ToString());

            }

            return ColumnName;


        }


        //autocomplte by Ankith-------------

        [WebMethod]
        public List<String> autocomplete(string prefixText)
        {

            String constr = System.Configuration.ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);


            DataSet dt = new DataSet();


            List<string> lt = new List<string>();



            string strQuery = "AutoCompleteSearch";
            SqlCommand cmd = new SqlCommand(strQuery, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tname", SqlDbType.NVarChar, 30).Value = prefixText;
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);

            for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            {
               lt.Add(dt.Tables[0].Rows[i]["keyword"].ToString());


            }

            


            return lt;
        }
    }
}
