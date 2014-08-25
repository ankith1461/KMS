using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DalUserLogin
    {
        
       
       
        public static string Validate(Int64 Username, string Password)
        {
            String Message=string.Empty;
            string ConnectionString = ConfigurationManager.ConnectionStrings["DB_KMS_DevelopmentConnectionString"].ConnectionString;
            SqlConnection Connection = new SqlConnection(ConnectionString);

            try
            {
                Connection.Open();
                string CommandString="select * from Login where CognizantId=@Uname and Password=@Pwd"; 
                SqlCommand Command = new SqlCommand(CommandString, Connection);
                Command.Parameters.AddWithValue("@Uname", Username);
                Command.Parameters.AddWithValue("@Pwd", Password);
                SqlDataReader ObjReader = null;
            ObjReader = Command.ExecuteReader();

            if (ObjReader.HasRows)
            {
                Connection.Close();

                string CommandString2 = "select RoleId from Login where CognizantId=" + Username + " and Password='" + Password + "'";
                
                SqlDataAdapter Data = new SqlDataAdapter(CommandString2,Connection);
                DataSet Ds = new DataSet();
                Data.Fill(Ds);
               string Role = Ds.Tables[0].Rows[0][0].ToString();
               Message = Role;

                
            }
           
            }
            catch (SqlException e)
            {
                Message = e.Message;
            }
            return Message;
        }
    }
}
