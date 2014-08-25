using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class SearchEntityLayer
    {
        private string _SearchData;
        private string _ArtId;
        private static string _con;

        public string SearchData
        {
            get
            {
                return _SearchData;
            }
            set
            {
                _SearchData = value;
            }
        }
        public string ArtId
        {
            get
            {
                return _ArtId;
            }
            set
            {
                _ArtId = value;
            }
        }
        public string con
        {
            get
            {
                return _con;
            }
            set
            {
                _con = value;
            }
        }



    }
}
