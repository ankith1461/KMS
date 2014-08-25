using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace DataAccessLayer
{
    
    public class DataUserPublished
    {
       
        public static DataSet DataUserGetPublishedArticleDetails(string Status,int PageIndex,int PageSize,string CognizantId, out int TotalRows )
        {
            
            
            DataSet ds = new DataSet();
           
            string ConnectionString = ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString;
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {

                // if published button is clicked the respective data is copied to datset

                if (Status.Equals("published"))
                {
                    try
                    {
                        SqlCommand Cmd = new SqlCommand("uspGetUserPublishedArticles", Con);
                        Cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter ParamStartIndex = new SqlParameter();
                        ParamStartIndex.ParameterName = "@PageIndex";
                        ParamStartIndex.Value = PageIndex;
                        Cmd.Parameters.Add(ParamStartIndex);

                        SqlParameter ParamMaximumRows = new SqlParameter();
                        ParamMaximumRows.ParameterName = "@PageSize";
                        ParamMaximumRows.Value = PageSize;
                        Cmd.Parameters.Add(ParamMaximumRows);

                        SqlParameter ParamCognizantId = new SqlParameter();
                        ParamCognizantId.ParameterName = "@CognizantId";
                        ParamCognizantId.Value = CognizantId;
                        Cmd.Parameters.Add(ParamCognizantId);

                        SqlParameter ParamOutPutTotalRows = new SqlParameter();
                        ParamOutPutTotalRows.ParameterName = "@TotalRows";
                        ParamOutPutTotalRows.Direction = ParameterDirection.Output;
                        ParamOutPutTotalRows.SqlDbType = SqlDbType.Int;
                        Cmd.Parameters.Add(ParamOutPutTotalRows);


                        SqlDataAdapter da = new SqlDataAdapter(Cmd);

                        da.Fill(ds);


                        TotalRows = (int)Cmd.Parameters["@TotalRows"].Value;
                        return ds;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }

                // if pending button is clicked the respective data is copied to datset

                else if (Status.Equals("pending"))
                {
                    try
                    {
                        SqlCommand Cmd = new SqlCommand("uspGetUserPendingArticles", Con);
                        Cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter ParamStartIndex = new SqlParameter();
                        ParamStartIndex.ParameterName = "@PageIndex";
                        ParamStartIndex.Value = PageIndex;
                        Cmd.Parameters.Add(ParamStartIndex);

                        SqlParameter ParamMaximumRows = new SqlParameter();
                        ParamMaximumRows.ParameterName = "@PageSize";
                        ParamMaximumRows.Value = PageSize;
                        Cmd.Parameters.Add(ParamMaximumRows);

                        SqlParameter ParamCognizantId = new SqlParameter();
                        ParamCognizantId.ParameterName = "@CognizantId";
                        ParamCognizantId.Value = CognizantId;
                        Cmd.Parameters.Add(ParamCognizantId);

                        SqlParameter ParamOutPutTotalRows = new SqlParameter();
                        ParamOutPutTotalRows.ParameterName = "@TotalRows";
                        ParamOutPutTotalRows.Direction = ParameterDirection.Output;
                        ParamOutPutTotalRows.SqlDbType = SqlDbType.Int;
                        Cmd.Parameters.Add(ParamOutPutTotalRows);


                        SqlDataAdapter da = new SqlDataAdapter(Cmd);

                        da.Fill(ds);


                        TotalRows = (int)Cmd.Parameters["@TotalRows"].Value;
                        return ds;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }


                // if Rejected button is clicked the respective data is copied to datset

                else 
                {
                    try
                    {
                        SqlCommand Cmd = new SqlCommand("uspGetUserRejectedArticles", Con);
                        Cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter ParamStartIndex = new SqlParameter();
                        ParamStartIndex.ParameterName = "@PageIndex";
                        ParamStartIndex.Value = PageIndex;
                        Cmd.Parameters.Add(ParamStartIndex);

                        SqlParameter ParamMaximumRows = new SqlParameter();
                        ParamMaximumRows.ParameterName = "@PageSize";
                        ParamMaximumRows.Value = PageSize;
                        Cmd.Parameters.Add(ParamMaximumRows);

                        SqlParameter ParamCognizantId = new SqlParameter();
                        ParamCognizantId.ParameterName = "@CognizantId";
                        ParamCognizantId.Value = CognizantId;
                        Cmd.Parameters.Add(ParamCognizantId);

                        SqlParameter ParamOutPutTotalRows = new SqlParameter();
                        ParamOutPutTotalRows.ParameterName = "@TotalRows";
                        ParamOutPutTotalRows.Direction = ParameterDirection.Output;
                        ParamOutPutTotalRows.SqlDbType = SqlDbType.Int;
                        Cmd.Parameters.Add(ParamOutPutTotalRows);


                        SqlDataAdapter da = new SqlDataAdapter(Cmd);

                        da.Fill(ds);


                        TotalRows = (int)Cmd.Parameters["@TotalRows"].Value;
                        return ds;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }

                


                
            }

        }
    }
}
