using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DataAccessLayer;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class Business
    {
        public static DataAccess objUserDAL = new DataAccess();
        public static string InsertKBDetails(params object[] values)
        {
            string message = string.Empty;
            try
            {

                SqlParameter[] collections ={
                                                    new SqlParameter("@CognizantId",values[0]),
                                                    new SqlParameter("@ApplicationName",values[1]),
                                                    new SqlParameter("@CollectionName",values[2]),
                                                    new SqlParameter("@TagName  ",values[3]),
                                                    new SqlParameter("@priority",values[4]),
                                                    new SqlParameter("@Title ",values[5]),
                                                    new SqlParameter("@details",values[6]),
                                                    // new SqlParameter("@attachment ",values[7])
                                                   
                                            };
                // DAL dataObj = new DAL();
                message = objUserDAL.ExecuteKB(collections);
                return message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
           
        }
        public static string InsertExceptionDetails(params object[] values)
        {
            string message = string.Empty;
            try
            {

                SqlParameter[] collections ={
                                                     new SqlParameter("@CognizantId",values[0]),
                                                    new SqlParameter("@ApplicationName",values[1]),
                                                    new SqlParameter("@CollectionName",values[2]),
                                                    new SqlParameter("@TagName  ",values[3]),
                                                    new SqlParameter("@priority",values[4]),
                                                    new SqlParameter("@ProblemStatement ",values[5]),
                                                    new SqlParameter("@Resolution",values[6]),
                                                     new SqlParameter("@AddtionalInformation",values[7]),
                                                      new SqlParameter("@Title",values[8]),

                                                   
                                            };
                // DAL dataObj = new DAL();
                message = objUserDAL.ExecuteException(collections);
                return message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
         
        }

    }
}
