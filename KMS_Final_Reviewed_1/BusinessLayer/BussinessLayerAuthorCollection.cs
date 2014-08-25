using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
namespace BusinessLayer
{
   public class BussinessLayerAuthorCollection
    {
        public DataSet GetCollections()
        {
            try
            {
                DataLayerAuthorCollection obj = new DataLayerAuthorCollection();
                return obj.GetCollection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ChangeCollectionStatus(string CollectionId, string Status)
        {
            try
            {
            DataLayerAuthorCollection objcol = new DataLayerAuthorCollection();
            return objcol.ChangeCollectionStatus(CollectionId, Status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
