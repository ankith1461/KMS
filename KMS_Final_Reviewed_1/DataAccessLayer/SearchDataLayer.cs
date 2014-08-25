using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
    public class SearchDataLayer
    {
        string constr = string.Empty;
        string strQuery = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataAdapter sa = null;
        
       

        public SearchDataLayer()
        {
            constr = ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString;
            con = new SqlConnection(constr);  
        }

        public DataSet ApplicationSearchDL(string keyword1)
        {
            DataSet d = new DataSet();  
            string strQuery = "ApplicationSearch";
            try
            {
                cmd = new SqlCommand(strQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Search", SqlDbType.NVarChar, 30).Value = keyword1;
                sa = new SqlDataAdapter(cmd);
                sa.Fill(d);
                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }


        public DataSet CollectionSearchDL(string keyword1)
        {
            DataSet d = new DataSet();
            string strQuery = "CollectionSearch";
            try
            {
                cmd = new SqlCommand(strQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Search", SqlDbType.NVarChar, 30).Value = keyword1;
                sa = new SqlDataAdapter(cmd);
                sa.Fill(d);
                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet TagSearchDL(string keyword1)
        {

            DataSet d = new DataSet(); 
            string strQuery = "TagSearch";
            try
            {
                cmd = new SqlCommand(strQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Search", SqlDbType.NVarChar, 30).Value = keyword1;
                sa = new SqlDataAdapter(cmd);
                sa.Fill(d);
                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ArticleSearchDL(string keyword1)
        {
            DataSet d = new DataSet();
            string strQuery = "ArticleSearch";
            try
            {
                cmd = new SqlCommand(strQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Search", SqlDbType.NVarChar, 30).Value = keyword1;
                sa = new SqlDataAdapter(cmd);
                sa.Fill(d);
                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DocumentSearchDL(string keyword1)
        {
            DataSet d = new DataSet();
            string strQuery = "DocumentSearch";
            try
            {
                cmd = new SqlCommand(strQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Search", SqlDbType.NVarChar, 30).Value = keyword1;
                sa = new SqlDataAdapter(cmd);
                sa.Fill(d);
                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ViewArticleDL(string id)
        {
            DataTable d = new DataTable();
            string strQuery = "ArticleDisplay";
            
            try
            {
                cmd = new SqlCommand(strQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@articleid", SqlDbType.NVarChar, 10).Value = id;
                sa = new SqlDataAdapter(cmd);
                

                sa.Fill(d);
                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable RelatedCollections(string id)
        {
            DataTable d = new DataTable();
            string strQuery = "RELATEDCOLLECTIONS";
            try
            {
                cmd = new SqlCommand(strQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.VarChar, 6).Value = id;
                sa = new SqlDataAdapter(cmd);


                sa.Fill(d);
                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable RelatedTags(string id)
        {
            DataTable dt = new DataTable();
            string strQuery = "RELATEDTAGS";
            try
            {
                cmd = new SqlCommand(strQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.VarChar, 6).Value = id;
                sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable Download(string id)
        {
            DataTable dt = new DataTable();
            string strQuery = "DocumentDownload";
            try
            {
                cmd = new SqlCommand(strQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.VarChar, 6).Value = id;
                sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable FileDownload(string id)
        {
            DataTable d = new DataTable();
            string strQuery = "FileDownload";
            try
            {
                cmd = new SqlCommand(strQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.VarChar, 6).Value = id;
                sa = new SqlDataAdapter(cmd);
                sa.Fill(d);
                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      

    }
}
