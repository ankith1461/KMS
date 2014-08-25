using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BlAdminManageApps
    {
         private DalAdminManageApps  adminAccess;
        public BlAdminManageApps()
        {
            adminAccess = new DalAdminManageApps();
        }
        public DataSet LoadCollection()
        {
            try
            {               
                return adminAccess.Loadapplication();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string InsertApplications(string ApplicationName, Int64 CognizantId )
        {
            try
            {
                return adminAccess.InsertApplications(ApplicationName,CognizantId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string DeleteApplications(int Id)
        {
            try
            {
                return adminAccess.DeleteApplications(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string UpdateApplications(int Id, string ApplicationName)
        {
            try
            {
                return adminAccess.UpdateApplications(Id, ApplicationName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
