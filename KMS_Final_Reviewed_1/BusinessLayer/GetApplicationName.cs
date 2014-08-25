using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessLayer
{
 public   class GetApplicationName
    {
        public List<string> getAppName()
        {
            try
            {
                ApplicationName appName = new ApplicationName();
                return appName.getAppName();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
