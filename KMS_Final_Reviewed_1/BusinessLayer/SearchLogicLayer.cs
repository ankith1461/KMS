using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class SearchLogicLayer
    {
        SearchDataLayer adl = new SearchDataLayer();

        public DataSet ApplicationSearch(string Keyword)
        {
            try
            {
                return adl.ApplicationSearchDL(Keyword);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet CollectionSearch(string Keyword)
        {
            try
            {
                return adl.CollectionSearchDL(Keyword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet TagSearch(string Keyword)
        {
            try
            {
                return adl.TagSearchDL(Keyword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ArticleSearch(string Keyword)
        {
            try
            {
                return adl.ArticleSearchDL(Keyword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DocumentSearch(string Keyword)
        {
            try
            {
                return adl.DocumentSearchDL(Keyword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable ArticleView(string id)
        {
            try
            {
                return adl.ViewArticleDL(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CollectionsRelated(string id)
        {
            try
            {
                return adl.RelatedCollections(id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable TagsRelated(string id)
        {
            try
            {
                return adl.RelatedTags(id);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DocumentDownload(string id)
        {
            try
            {
                return adl.Download(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable FileDownload(string id)
        {
            try
            {
                return adl.FileDownload(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
