using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
   public class BlAdminManageCollections
    {
       DalAdminManageCollections adminAccess;
       public BlAdminManageCollections()
        {
            adminAccess = new DalAdminManageCollections(); 
        }
        public DataSet LoadCollection()
        {
            try
            {               
                return adminAccess.Loadcollection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string InsertCollections(string CollectionName, Int64 CognizantId)
        {
            try
            {
                return adminAccess.InsertCollections(CollectionName,CognizantId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string DeleteCollections(int Id)
        {
            try
            {
                return adminAccess.DeleteCollections(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string UpdateCollections(int Id,string CollectionName)
        {
            try
            {
                return adminAccess.UpdateCollections(Id,CollectionName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
