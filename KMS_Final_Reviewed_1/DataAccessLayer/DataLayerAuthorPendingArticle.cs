using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
    public class DataLayerAuthorPendingArticle
    {

        public DataSet GetPendingArticleAuthor()
        {


            DataSet dt = new DataSet();
            try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandText = "get_PendingArticle_Author";
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                
                sa.Fill(dt);
               // MessageBox.Show(dt.Tables[0].Rows[0][5].ToString());
                return dt;
            }
            catch (Exception e)
            {
               
                throw e;
            }


        }




        //getKBArticles

        //public DataSet GetExceptionPendingArticleAuthor()
        //{


        //    DataSet dt = new DataSet();
        //    try
        //    {

        //        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ToString());
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = con;
        //        cmd.CommandText = "get_ExceptionPendingArticle_Author";
        //        SqlDataAdapter sa = new SqlDataAdapter(cmd);
        //        sa.Fill(dt);
        //        return dt;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
               
        //    }


        //}

        public DataSet getArticle(SqlParameter[] collections)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ToString());
            DataSet d = new DataSet();

            //article details
            try
            {



                //article details
                DataTable dtArticle = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandText = "get_KBArticle";
                cmd.Parameters.AddRange(collections);
                SqlDataAdapter sa = new SqlDataAdapter(cmd);

                //DataTable 
                sa.Fill(dtArticle);
                dtArticle.TableName = "Article";
                d.Tables.Add(dtArticle);
                cmd.Parameters.Clear();
            }

            catch (Exception e)
            {
                
                throw e;
            }




            //collections of article
            try
            {


                DataTable dtColl = new DataTable();
                SqlCommand cmdCol = new SqlCommand();
                cmdCol.CommandType = CommandType.StoredProcedure;
                cmdCol.Connection = con;
                cmdCol.CommandText = "get_ArticleCollection";
                cmdCol.Parameters.AddRange(collections);
                SqlDataAdapter saCol = new SqlDataAdapter(cmdCol);
                saCol.Fill(dtColl);
                dtColl.TableName = "ArticleCollection";
                d.Tables.Add(dtColl);
                cmdCol.Parameters.Clear();
                //MessageBox.Show(d.Tables[1].Rows[0][0].ToString());


            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                throw e;

            }



            //article tags
            try
            {


                DataTable dtTag = new DataTable();
                SqlCommand cmdTag = new SqlCommand();
                cmdTag.CommandType = CommandType.StoredProcedure;
                cmdTag.Connection = con;
                cmdTag.CommandText = "get_ArticleTag";
                cmdTag.Parameters.AddRange(collections);
                SqlDataAdapter saTag = new SqlDataAdapter(cmdTag);
                saTag.Fill(dtTag);
                dtTag.TableName = "ArticleTag";
                d.Tables.Add(dtTag);
                cmdTag.Parameters.Clear();
                //MessageBox.Show(d.Tables["ArticleTag"].Rows[0][0].ToString());
               

            }
            catch (Exception e)
            {
                
                throw e;
                
            }



            ////attachmants



            try
            {
                DataTable dtFile = new DataTable();
                SqlCommand cmdFile = new SqlCommand();
                cmdFile.CommandType = CommandType.StoredProcedure;
                cmdFile.Connection = con;
                cmdFile.CommandText = "get_DocumentData";
                cmdFile.Parameters.AddRange(collections);
                SqlDataAdapter saFile = new SqlDataAdapter(cmdFile);
                saFile.Fill(dtFile);
                dtFile.TableName = "ArticleFile";
                d.Tables.Add(dtFile);
                cmdFile.Parameters.Clear();
                //MessageBox.Show(d.Tables["ArticleFile"].Rows[0][0].ToString());
                return d;


            }

            catch (Exception e)
            {
               
                throw e;
            }
        }

        public DataTable DownloadAttachment(string DocId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ToString());
            DataTable dt = new DataTable();

            try
            {
             
                SqlCommand cmdFile = new SqlCommand();
                cmdFile.CommandType = CommandType.StoredProcedure;
                cmdFile.Connection = con;
                cmdFile.CommandText = "get_DownloadAttachment";
                cmdFile.Parameters.AddWithValue("@DocumentId",SqlDbType.VarChar).Value=DocId;
                SqlDataAdapter saFile = new SqlDataAdapter(cmdFile);
                saFile.Fill(dt);
                dt.TableName = "Attachment";
           

                cmdFile.Parameters.Clear();
                //MessageBox.Show(d.Tables["ArticleFile"].Rows[0][0].ToString());
                return dt;


            }

            catch (Exception e)
            {
                
                throw e;
            }
        }


        //modifying the table with return value string
        public int ArticleAcceptReject(string ArticleId,string Status)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ToString());
            int i = 0;
            try
            {
                
                con.Open();
                SqlCommand cmdFile = new SqlCommand();
                cmdFile.CommandType = CommandType.StoredProcedure;
                cmdFile.Connection = con;
                cmdFile.CommandText = "AuthorArticleStatusChange";
                cmdFile.Parameters.AddWithValue("@ArticleId", SqlDbType.VarChar).Value = ArticleId;
                cmdFile.Parameters.AddWithValue("@ArticleStatus", SqlDbType.VarChar).Value = Status;
                i = cmdFile.ExecuteNonQuery();
                con.Close();
                return i;

            }

            catch (Exception e)
            {
                
                throw e;
                
            }
        }


        public int IteamRejectReason(string IteamId,Int64 AuthorId,string Reason)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ToString());
            int i = 0;
            try
            {

                con.Open();
                SqlCommand cmdFile = new SqlCommand();
                cmdFile.CommandType = CommandType.StoredProcedure;
                cmdFile.Connection = con;
                cmdFile.CommandText = "AuthorRejectReason";
                cmdFile.Parameters.AddWithValue("@IteamId", SqlDbType.VarChar).Value = IteamId;
                cmdFile.Parameters.AddWithValue("@AuthorId", SqlDbType.Int).Value = AuthorId;
                cmdFile.Parameters.AddWithValue("@Reason", SqlDbType.NVarChar).Value = Reason;
                i = cmdFile.ExecuteNonQuery();
                con.Close();
                return i;

            }

            catch (Exception e)
            {
                
                throw e;

            }
        }
    }
}
