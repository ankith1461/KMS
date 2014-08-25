using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class DalBulkUpload
    {
        string ConnectionString = "";
        public DalBulkUpload()
        {
        }
        public bool InsertArtInformation(SqlParameter[] ObjParams, out String artid, out String collid)
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ToString();
            SqlConnection c = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand objCommand = new SqlCommand("ArtInformation", c);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddRange(ObjParams);
                c.Open();
                SqlDataReader dr = objCommand.ExecuteReader();
                artid = Convert.ToString(objCommand.Parameters["@Artid"].Value);
                collid = Convert.ToString(objCommand.Parameters["@colid"].Value);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }
        }

        public bool InsertSuppDoc(SqlParameter[] ObjParams)
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ToString();
            SqlConnection c = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand objCommand = new SqlCommand("InsertSuppDoc", c);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddRange(ObjParams);
                c.Open();
                SqlDataReader dr = objCommand.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }
        }

        public bool InsertTagData(SqlParameter[] ObjParams)
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ToString();
            SqlConnection c = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand objCommand = new SqlCommand("InsertTag", c);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddRange(ObjParams);
                c.Open();
                int flag = objCommand.ExecuteNonQuery();
                if (flag > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }
        }

    }
}