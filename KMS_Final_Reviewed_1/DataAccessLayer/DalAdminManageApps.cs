using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DataAccessLayer
{
   public class DalAdminManageApps
    {
      
        private string ConnectionString;
        private SqlConnection Connection;
        private string Command;
        private DataSet dataSet;
        private SqlCommand sqlCommand;
        private string Message;
        public DalAdminManageApps()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString;
            Connection = new SqlConnection(ConnectionString);
            Command = string.Empty;
            Message = string.Empty;

        }
        public DataSet Loadapplication()
        {

            Command = "select * FROM GetApplications";
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
        public string InsertApplications(string ApplicationName,Int64 CognizantId)
        {
            sqlCommand = new SqlCommand("add_applications", Connection);
            try
            {
                Connection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@ApplicationName", SqlDbType.NVarChar, 25).Value = ApplicationName;
                sqlCommand.Parameters.Add("@CognizantId", SqlDbType.BigInt).Value = CognizantId;
                sqlCommand.Parameters.Add("@Error", SqlDbType.Char, 500).Value = CognizantId;
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
        public string DeleteApplications(int Id)
        {
            sqlCommand = new SqlCommand("delete_applications", Connection);
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

        public string UpdateApplications(int Id, string ApplicationName)
        {
            sqlCommand = new SqlCommand("update_applications", Connection);
            try
            {
                Connection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                sqlCommand.Parameters.Add("@ApplicationName", SqlDbType.NVarChar, 25).Value = ApplicationName;
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
