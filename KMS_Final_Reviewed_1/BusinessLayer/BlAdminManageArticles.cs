using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
   public class BlAdminManageArticles
    {
       DalAdminManageArticles artData;
       public BlAdminManageArticles()
        {
            artData = new DalAdminManageArticles();
        }
        public DataSet LoadArticles()
        {
            try
            {
                return artData.LoadArticles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteArticle(int ArtId)
        {
            try
            {
                return artData.DeleteArticle(ArtId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
