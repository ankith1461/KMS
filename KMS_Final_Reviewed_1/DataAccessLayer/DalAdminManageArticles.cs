using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DataAccessLayer
{
   public class DalAdminManageArticles
    {
        string ConnectionString;
        SqlConnection Connection;
        string Command;
        DataSet dataSet;
        SqlCommand sqlCommand;
        string Message;
        public DalAdminManageArticles()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString;
            Connection = new SqlConnection(ConnectionString);
            Command = string.Empty;
            Message = string.Empty;

        }
        public DataSet LoadArticles()
        {         
            
            Command = "select * FROM GetArticles";
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
        public string DeleteArticle(int ArtId)
        {
            sqlCommand = new SqlCommand("delete_articles", Connection);
            try
            {
                Connection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@ArtId", SqlDbType.Int).Value = ArtId;
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
