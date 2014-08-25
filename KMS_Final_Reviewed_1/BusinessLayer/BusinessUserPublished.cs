using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
   
    public class BusinessUserPublished
    {

        //method to get data by calling method in data access layer  

        public static DataSet BusinessUserGetPublishedArticleDetails(string Status,int PageIndex, int PageSize,string CognizantId, out int TotalRows)
        {
            try
            {

                return DataUserPublished.DataUserGetPublishedArticleDetails(Status, PageIndex, PageSize, CognizantId, out TotalRows);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}


