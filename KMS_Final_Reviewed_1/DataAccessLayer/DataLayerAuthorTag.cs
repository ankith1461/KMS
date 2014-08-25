using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
namespace DataAccessLayer
{
    public class DataLayerAuthorTag
    {

        public DataSet GetTag()
        {
            DataSet d = new DataSet();

            try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandText = "get_PendingTags";
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(d);
                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public int ChangeTagStatus(string TagId,string Status)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ToString());
            int i = 0;
            try
            {

                con.Open();
                SqlCommand cmdFile = new SqlCommand();
                cmdFile.CommandType = CommandType.StoredProcedure;
                cmdFile.Connection = con;
                cmdFile.CommandText = "TagStatusChange";
                cmdFile.Parameters.AddWithValue("TagId", SqlDbType.VarChar).Value = TagId;
                cmdFile.Parameters.AddWithValue("@Status", SqlDbType.VarChar).Value = Status;
                i = cmdFile.ExecuteNonQuery();
                con.Close();
                return i;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
