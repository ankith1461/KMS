using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;


namespace DataAccessLayer
{
    public class DataUserEdit
    {

        
        /// <summary>
        /// uploading files  in database
        /// </summary>
        /// <param name="DocId"></param>
        /// <param name="FileName"></param>
        /// <param name="binary"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static int DataUserUploadFiles(string DocId,string FileName, Byte[] binary, string extension)
        {
            try
            {
                SqlConnection conn = new SqlConnection(
                           ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ToString());

                SqlCommand cmd = new SqlCommand("uspUpdateDocuments", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Parameters and values 

                SqlParameter ParamStartIndex = new SqlParameter();
                ParamStartIndex.ParameterName = "@DocId";
                ParamStartIndex.Value = DocId;
                cmd.Parameters.Add(ParamStartIndex);

                //doc name
                SqlParameter paramdocname = new SqlParameter("@docname", SqlDbType.NVarChar, 50,
                         ParameterDirection.Input, false, 0, 0, "",
                         DataRowVersion.Default, FileName);
                cmd.Parameters.Add(paramdocname);



                //document data
                SqlParameter paramcontent = new SqlParameter("@Content", SqlDbType.Image);
                paramcontent.Direction = ParameterDirection.Input;
                paramcontent.Value = binary;
                cmd.Parameters.Add(paramcontent);


                //document type
                SqlParameter paramdoctype = new SqlParameter("@doctype", SqlDbType.NVarChar, 50,
                            ParameterDirection.Input, false, 0, 0, "",
                            DataRowVersion.Default, extension);
                cmd.Parameters.Add(paramdoctype);

                //Connection open and execute
                conn.Open();
                int result;

                result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                conn.Close();
                return result;
                
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }





        public static int DataUserInsertFiles(string ArtId, string FileName, Byte[] binary, string extension)
        {
            try
            {
                SqlConnection conn = new SqlConnection(
                           ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ToString());

                SqlCommand cmd = new SqlCommand("uspInsertDocuments", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Parameters and values 

                SqlParameter ParamStartIndex = new SqlParameter();
                ParamStartIndex.ParameterName = "@ArtId";
                ParamStartIndex.Value = ArtId;
                cmd.Parameters.Add(ParamStartIndex);

                //doc name
                SqlParameter paramdocname = new SqlParameter("@docname", SqlDbType.NVarChar, 50,
                         ParameterDirection.Input, false, 0, 0, "",
                         DataRowVersion.Default, FileName);
                cmd.Parameters.Add(paramdocname);



                //document data
                SqlParameter paramcontent = new SqlParameter("@Content", SqlDbType.Image);
                paramcontent.Direction = ParameterDirection.Input;
                paramcontent.Value = binary;
                cmd.Parameters.Add(paramcontent);


                //document type
                SqlParameter paramdoctype = new SqlParameter("@doctype", SqlDbType.NVarChar, 50,
                            ParameterDirection.Input, false, 0, 0, "",
                            DataRowVersion.Default, extension);
                cmd.Parameters.Add(paramdoctype);

                //Connection open and execute
                conn.Open();
                int result;

                result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                conn.Close();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        
        /// <summary>
        /// updates article details
        /// </summary>
        /// <param name="ArtDetails"></param>
        /// <returns></returns>
        public static string DataUserUpdateArticleDetails(SqlParameter[] ArtDetails)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspUpdateArticleDetails", Con);
                    Con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(ArtDetails);
                    //cmd.ExecuteNonQuery();
                    cmd.Parameters.Add("@ERROR", SqlDbType.NVarChar, 500);
                    cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    
                    Con.Close();
                    string strMessage = (string)cmd.Parameters["@ERROR"].Value;
                    return strMessage;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



       
        /// <summary>
        /// populates application dropdownlist
        /// </summary>
        /// <param name="artid"></param>
        /// <param name="appid"></param>
        /// <returns></returns>
        public static List<string> DataUserPopulateDdlApplication(string artid, string appid)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(ConnectionString))
                {
                    SqlCommand Cmd = new SqlCommand("uspddlPopulateApplicationName", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter ParamArtID = new SqlParameter();
                    ParamArtID.ParameterName = "@ArtId";
                    ParamArtID.Value = artid;
                    Cmd.Parameters.Add(ParamArtID);
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    Cmd.Parameters.Clear();
                    List<string> l = new List<string>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        l.Add(ds.Tables[0].Rows[i][0].ToString());
                    }
                    return l;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        
        /// <summary>
        /// populates priority dropdownlist
        /// </summary>
        /// <param name="artid"></param>
        /// <param name="appid"></param>
        /// <returns></returns>
        public static List<string> DataUserPopulateDdlPriority(string artid, string appid)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(ConnectionString))
                {
                    SqlCommand Cmd = new SqlCommand("uspddlPopulatePriority", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter ParamArtID = new SqlParameter();
                    ParamArtID.ParameterName = "@ArtId";
                    ParamArtID.Value = artid;
                    Cmd.Parameters.Add(ParamArtID);
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    Cmd.Parameters.Clear();
                    List<string> l = new List<string>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        l.Add(ds.Tables[0].Rows[i]["priority"].ToString());
                    }
                    return l;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        
        /// <summary>
        /// gets all details of article
        /// </summary>
        /// <param name="collections"></param>
        /// <returns></returns>
        public static DataSet getArticle(SqlParameter[] collections)
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
               // MessageBox.Show(e.ToString());
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
               // MessageBox.Show(e.ToString());
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
               // MessageBox.Show(e.ToString());
                throw e;
            } 
        }





        public static DataSet DatauserGetPublishedArticle(SqlParameter[] collections)
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
                cmd.CommandText = "uspGetEditPublishedArticle";
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
                // MessageBox.Show(e.ToString());
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
                // MessageBox.Show(e.ToString());
                throw e;
            }
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
                // MessageBox.Show(e.ToString());
                throw e;
            } 




        }






        public static DataSet DatauserGetRejectedArticle(SqlParameter[] collections)
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
                cmd.CommandText = "uspGetEditRejectedArticle";
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
                // MessageBox.Show(e.ToString());
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
                // MessageBox.Show(e.ToString());
                throw e;
            }

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
                // MessageBox.Show(e.ToString());
                throw e;
            } 




        }
       
        /// <summary>
        /// gets all attachments of article
        /// </summary>
        /// <param name="DocId"></param>
        /// <returns></returns>
        public static DataTable DownloadAttachment(string DocId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ToString());
            DataTable dt = new DataTable();

            try
            {

                SqlCommand cmdFile = new SqlCommand();
                cmdFile.CommandType = CommandType.StoredProcedure;
                cmdFile.Connection = con;
                cmdFile.CommandText = "get_DownloadAttachment";
                cmdFile.Parameters.AddWithValue("@DocumentId", SqlDbType.VarChar).Value = DocId;
                SqlDataAdapter saFile = new SqlDataAdapter(cmdFile);
                saFile.Fill(dt);
                dt.TableName = "Attachment";


                cmdFile.Parameters.Clear();
                //MessageBox.Show(d.Tables["ArticleFile"].Rows[0][0].ToString());
                return dt;


            }

            catch (Exception e)
            {
               // MessageBox.Show(e.ToString());
                throw e;
            }
        }

    }
}
