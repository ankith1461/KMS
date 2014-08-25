using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace DataAccessLayer
{
   public class DalAdminManageUsers
    {
       string ConnectionString;
        SqlConnection Connection;
        string Command;
        DataSet dataSet;
        SqlCommand sqlCommand;
        string Message;
        public DalAdminManageUsers()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString;
            Connection = new SqlConnection(ConnectionString);
            Command = string.Empty;
            Message = string.Empty;

        }
        public DataSet LoadUsers()
        {         
            
            Command = "select * FROM KmsGetUsers";
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
        public string DeleteUsers(int CognizantId)
        {
            sqlCommand = new SqlCommand("delete_users", Connection);
            try
            {
                Connection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@CognizantId", SqlDbType.Int).Value = CognizantId;
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
        public string UpdateUsers(int CognizantId, string Role)
        {
            sqlCommand = new SqlCommand("update_role", Connection);
            try
            {
                Connection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@CognizantId", SqlDbType.BigInt).Value = CognizantId;
                sqlCommand.Parameters.Add("@Role", SqlDbType.NVarChar, 30).Value = Role;
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
