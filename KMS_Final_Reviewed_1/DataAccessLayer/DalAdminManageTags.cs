using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
   public class DalAdminManageTags
    {
        private string ConnectionString;
        private SqlConnection Connection;
        private string Command;
        private DataSet dataSet;
        private SqlCommand sqlCommand;
        private string Message;
        public DalAdminManageTags()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString;
            Connection = new SqlConnection(ConnectionString);
            Command = string.Empty;
            Message = string.Empty;

        }
        public DataSet LoadTag()
        {         
            
            Command = "select * FROM  GetTags";
            try
            {
                SqlDataAdapter Adapter = new SqlDataAdapter(Command, Connection);
                dataSet = new DataSet();
                Adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public string DeleteTags(int Id)
        {
            sqlCommand = new SqlCommand("delete_tags", Connection);
            try
            {
                Connection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                sqlCommand.Parameters.Add("@Error", SqlDbType.Char, 500);
                sqlCommand.Parameters["@Error"].Direction = ParameterDirection.Output;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();                
            }
            Message = (string)sqlCommand.Parameters["@Error"].Value;
            return Message;  
        }

        public string UpdateTags(int Id,string TagName)
        {
            sqlCommand = new SqlCommand("update_tags", Connection);
            try
            {
                Connection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                sqlCommand.Parameters.Add("@TagName", SqlDbType.NVarChar,25).Value = TagName;
                sqlCommand.Parameters.Add("@Error", SqlDbType.Char, 500);
                sqlCommand.Parameters["@Error"].Direction = ParameterDirection.Output;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            Message = (string)sqlCommand.Parameters["@Error"].Value;
            return Message;
        }
    }
}
