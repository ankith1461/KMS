using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DataAccessLayer
{
   public class DalAdminManageCollections
    {
       string ConnectionString;
        SqlConnection Connection;
        string Command;
        DataSet dataSet;
        SqlCommand sqlCommand;
        string Message;
        public DalAdminManageCollections()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString;
            Connection = new SqlConnection(ConnectionString);
            Command = string.Empty;
            Message = string.Empty;

        }
        public DataSet Loadcollection()
        {         
            
            Command = "select * from GetCollections";
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
        public string InsertCollections(string CollectionName,Int64 CognizantId )
        {
            sqlCommand = new SqlCommand("add_collections", Connection);
            try
            {
                Connection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@CollectionName", SqlDbType.NVarChar, 25).Value = CollectionName;
                sqlCommand.Parameters.Add("@CognizantId", SqlDbType.BigInt, 25).Value = CognizantId;
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
        public string DeleteCollections(int Id)
        {
            sqlCommand = new SqlCommand("delete_collections", Connection);
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

        public string UpdateCollections(int Id,string CollectionName)
        {
            sqlCommand = new SqlCommand("update_collections", Connection);
            try
            {
                Connection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                sqlCommand.Parameters.Add("@CollectionName", SqlDbType.NVarChar,25).Value = CollectionName;
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
