using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DataAccess
    {
        public  string ExecuteKB(SqlParameter[] collections)
        {
            string strMessage = "";
            try
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("KBArticle", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(collections);
                //cmd.ExecuteNonQuery();
                cmd.Parameters.Add("@ERROR", SqlDbType.NVarChar, 500);
                cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
             //    strMessage = (string)cmd.Parameters["@ERROR"].Value;
                con.Close();
                return strMessage;
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public string ExecuteException(SqlParameter[] collections)
        {
            string strMessage = "";
            try
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("ExceptionKnowledge", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(collections);
                //cmd.ExecuteNonQuery();
                cmd.Parameters.Add("@ERROR", SqlDbType.NVarChar, 500);
                cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
          //      strMessage = (string)cmd.Parameters["@ERROR"].Value;
                con.Close();
                return strMessage;
            }
            catch (Exception e)
            {
               
                throw e;
            }


        }


       
    }
}
