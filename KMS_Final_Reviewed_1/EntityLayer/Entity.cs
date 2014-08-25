using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class Entity
    {
        private string _ApplicationName;
        private string _CollectionName;
        private string _TagName;
        private string _Priority;
        private string _Title;
        private string _Details;
        private string _Attachment;
        private string _ProblemStatement;
        private string _Resolution;
        private string _AdditionalInformation;
        private string _SessionIno;
        private string _SessionInfo;
        
        
        public string ApplicationName
        {
            get
            {
                return _ApplicationName;
            }
            set
            {
               _ApplicationName = value;
            }
        }

        public string CollectionName
        {
            get
            {
                return _CollectionName;
            }
            set
            {
                _CollectionName = value;
            }
        }

        public string  TagName
        {
            get
            {
                return _TagName;
            }
            set
            {
                _TagName = value;
            }
        }
        public string Priority
        {
            get
            {
                return _Priority;
            }
            set
            {
                _Priority = value;
            }
        }



        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }



        public string Details
        {
            get
            {
                return _Details;
            }
            set
            {
                _Details = value;
            }
        }



        public string Attachment
        {
            get
            {
                return _Attachment;
            }
            set
            {
                _Attachment = value;
            }

        }


        public string ProblemStatement
        {
            get
            {
                return _ProblemStatement;
            }
            set
            {
                _ProblemStatement = value;
            }

        }
        public string Resolution
        {
            get
            {
                return _Resolution;
            }
            set
            {
                _Resolution = value;
            }

        }
        public string AdditionalInformation
        {
            get
            {
                return _AdditionalInformation;
            }
            set
            {
                _AdditionalInformation = value;
            }
        }
             public string session
        {
            get
            {
                return _SessionInfo;
            }
            set
            {
                _SessionInfo = value;
            }

        }
    }
}

 