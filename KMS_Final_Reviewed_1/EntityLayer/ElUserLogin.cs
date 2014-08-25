using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class ElUserLogin
    {
        private Int64 _UserName;
        private string _Password;

        public Int64 UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }



        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

    }
}
