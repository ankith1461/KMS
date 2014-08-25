using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using DataAccessLayer;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class BussinessLayerAuthorPendingArticle
    {

        //method for pending kb articles
        public DataSet GetPendingArticleAuthor()
        {
            try
            {
            DataLayerAuthorPendingArticle objGetArticle = new DataLayerAuthorPendingArticle();
            return objGetArticle.GetPendingArticleAuthor();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //method for pending exception articles
        //public DataSet GetExceptionPendingArticleAuthor()
        //{
        //    try
        //    {
        //        DataLayerAuthorPendingArticle obj = new DataLayerAuthorPendingArticle();
        //        return obj.GetExceptionPendingArticleAuthor();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}




        public DataSet GetKBArticle(params object[] values)
        {
            try
            {
        DataLayerAuthorPendingArticle obj = new DataLayerAuthorPendingArticle();

        SqlParameter[] p = { new SqlParameter("@ArticleId",values[0]) };

        return obj.getArticle(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }


         }

        public DataTable GetArticleAttachment(string DocId)
        {
            try
            {
            DataLayerAuthorPendingArticle obj = new DataLayerAuthorPendingArticle();
            return obj.DownloadAttachment(DocId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //autherAcceptArticle

        public int AuthorAcceptArticle(string ArticleId,string Status)
        {
            try
            {
            DataLayerAuthorPendingArticle obj = new DataLayerAuthorPendingArticle();
            return obj.ArticleAcceptReject(ArticleId,Status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //reasonforRejection
        public int ArticleRejectReason(string IteamId,Int64 AuthorId, string Reason)
        {
            try
            {
            DataLayerAuthorPendingArticle obj = new DataLayerAuthorPendingArticle();
            return obj.IteamRejectReason(IteamId, AuthorId, Reason);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
