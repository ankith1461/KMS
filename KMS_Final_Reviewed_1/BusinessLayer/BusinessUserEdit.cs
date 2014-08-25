using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace BusinessLayer
{
   public class BusinessUserEdit
    {
       
       
       /// <summary>
       ///  Uploading Files 
       /// </summary>
       /// <param name="DocId"></param>
       /// <param name="FileName"></param>
       /// <param name="binary"></param>
       /// <param name="extension"></param>
       /// <returns></returns>
        public static int BusinessUserUploadFiles(string DocId,string FileName, Byte[] binary, string extension)
        {
            try
            {
                return DataUserEdit.DataUserUploadFiles(DocId, FileName, binary, extension);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


       /// <summary>
       /// Inserting new file if no documents are there previously
       /// </summary>
       /// <param name="ArtId"></param>
       /// <param name="FileName"></param>
       /// <param name="binary"></param>
       /// <param name="extension"></param>
       /// <returns></returns>
        public static int BusinessUserInsertFiles(string ArtId, string FileName, Byte[] binary, string extension)
        {
            try
            {
                return DataUserEdit.DataUserInsertFiles(ArtId, FileName, binary, extension);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


       
       /// <summary>
        /// populating application name dropdownlist
       /// </summary>
       /// <param name="artid"></param>
       /// <param name="appid"></param>
       /// <returns></returns>
        public static List<string> BusinessUserDdlApplication(string artid, string appid)
        {
            try
            {
                return DataUserEdit.DataUserPopulateDdlApplication(artid, appid);
             }
            catch(Exception e)
            {
                throw e;
            }
        }


        
       /// <summary>
        /// populating priority dropdownlist
       /// </summary>
       /// <param name="artid"></param>
       /// <param name="appid"></param>
       /// <returns></returns>
        public static List<string> BusinessUserPopulateDdlPriority(string artid, string appid)
        {
            try
            {
                return DataUserEdit.DataUserPopulateDdlPriority(artid, appid);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


       
       /// <summary>
        /// getting article datils
       /// </summary>
       /// <param name="values"></param>
       /// <returns></returns>
        public static  DataSet GetKBArticle(params object[] values)
        {
            try
            {

                SqlParameter[] p = { new SqlParameter("@ArticleId", values[0]) };

                return DataUserEdit.getArticle(p);
            }
            catch(Exception e)
            {
                throw e;
            }

        }
        public static DataSet BusinessUserGetPublishedArticle(params object[] values)
        {
            try
            {

                SqlParameter[] p = { new SqlParameter("@ArticleId", values[0]) };

                return DataUserEdit.DatauserGetPublishedArticle(p);
            }
            catch (Exception e)
            {
                throw e;
            }

        }




        public static DataSet BusinessUserGetRejectedArticle(params object[] values)
        {
            try
            {

                SqlParameter[] p = { new SqlParameter("@ArticleId", values[0]) };

                return DataUserEdit.DatauserGetRejectedArticle(p);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
      
       /// <summary>
        /// documents related to articles are returned 
       /// </summary>
       /// <param name="DocId"></param>
       /// <returns></returns>
        public static DataTable GetArticleAttachment(string DocId)
        {
            try
            {
                return DataUserEdit.DownloadAttachment(DocId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


       
       /// <summary>
        /// updating articles details
       /// </summary>
       /// <param name="values"></param>
       /// <returns></returns>
        public static string BusinessUserUpdateArticleDetails(params object[] values)
        {

            string message;
           try
           {

               SqlParameter[] ArtDetails ={
                                                    new SqlParameter("@ArtId",values[0]),
                                                    new SqlParameter("@AppId",values[1]),
                                                    new SqlParameter("@Title",values[2]),
                                                    new SqlParameter("@ApplicationName",values[3]),
                                                    new SqlParameter("@Collection",values[4]),
                                                    new SqlParameter("@TagName",values[5]),
                                                    new SqlParameter("@Priority",values[6]),
                                                    new SqlParameter("@Details",values[7])
                                                    
                                               };
               message = DataUserEdit.DataUserUpdateArticleDetails(ArtDetails);

           }
           catch (Exception ex)
           {
               throw ex;
           }
           
           return message;
        }



    }
}
