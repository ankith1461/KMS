using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
   public class BlAdminManageTags
    {
        private DalAdminManageTags adminAccessTags;
        public BlAdminManageTags()
        {
            adminAccessTags = new DalAdminManageTags(); 
        }
        public DataSet LoadData()
        {
            try
            {               
                return adminAccessTags.LoadTag();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        public string DeleteTags(int Id)
        {
            try
            {
                return adminAccessTags.DeleteTags(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string UpdateTags(int Id,string TagName)
        {
            try
            {
                return adminAccessTags.UpdateTags(Id,TagName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
