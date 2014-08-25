using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BlUserLogin
    {
        public static string ValidateUserLogin(Int64 Username, string Password)
        {
            string Message = string.Empty;
            try
            {
                Int64 Uname = Username;
                string Pwd = Password;
                Message = DalUserLogin.Validate(Uname, Pwd);

            }
            catch(Exception e)
            {
                Message = e.Message;
            }
            return Message;
        }
    }
}
