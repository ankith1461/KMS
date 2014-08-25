using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
   public class BlAdminManageUsers
    {
       DalAdminManageUsers manageUsers;

       public BlAdminManageUsers()
        {
            manageUsers = new DalAdminManageUsers();
        }
        public DataSet LoadUsers()
        {
            try
            {
                return manageUsers.LoadUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteUsers(int CognizantId)
        {
            try
            {
                return manageUsers.DeleteUsers(CognizantId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateUsers(int CognizantId, string Role)
        {
            try
            {
                return manageUsers.UpdateUsers(CognizantId, Role);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
