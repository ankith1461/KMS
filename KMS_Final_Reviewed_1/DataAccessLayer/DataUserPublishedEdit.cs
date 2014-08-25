using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
    public class DataUserPublishedEdit
    {
        public static int DataUserUploadFiles(string FileName,Byte[] binary,string extension)
        {


           SqlConnection conn = new SqlConnection(
                      ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ToString());

                    SqlCommand cmd = new SqlCommand("UploadDocument", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Parameters and values 

                    //doc name
                   SqlParameter paramdocname = new SqlParameter("@docname", SqlDbType.NVarChar, 25,
                            ParameterDirection.Input, false, 0, 0, "",
                            DataRowVersion.Default, FileName);
                    cmd.Parameters.Add(paramdocname);

                    //document data
                    SqlParameter paramcontent = new SqlParameter("@docdata", SqlDbType.Image);
                    paramcontent.Direction = ParameterDirection.Input;
                    paramcontent.Value = binary;
                    cmd.Parameters.Add(paramcontent);

                    //document type
                    SqlParameter paramdoctype = new SqlParameter("@doctype", SqlDbType.NVarChar, 20,
                                ParameterDirection.Input, false, 0, 0, "",
                                DataRowVersion.Default,extension);
                    cmd.Parameters.Add(paramdoctype);

                    //Connection open and execute
                    conn.Open();
                    int result;
                    return result=cmd.ExecuteNonQuery();
        }
    }
}
