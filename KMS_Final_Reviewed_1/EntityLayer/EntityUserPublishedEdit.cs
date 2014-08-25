using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class EntityUserPublishedEdit
    {
        private string _Title;
        private string _ApplicationName ;
        private string _Collection ;
        private string _TagName;
        private string _Priority;
        private string _Details;
        


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


        /// <summary>
        /// Gets or sets the <b>ApplicationName</b> attribute value.
        /// </summary>
        /// <value>The <b>_ApplicationName</b> attribute value.</value>
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


        /// <summary>
        /// Gets or sets the <b>Collection</b> attribute value.
        /// </summary>
        /// <value>The <b>_Collection</b> attribute value.</value>
        public string Collection
        {
            get
            {
                return _Collection;
            }
            set
            {
                _Collection = value;
            }
        }
        /// <summary>
        /// Gets or sets the <b>TagName</b> attribute value.
        /// </summary>
        /// <value>The <b>_TagName</b> attribute value.</value>
        public string TagName
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


        /// <summary>
        /// Gets or sets the <b>_Priority</b> attribute value.
        /// </summary>
        /// <value>The <b>_Priority</b> attribute value.</value>
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


        /// <summary>
        /// Gets or sets the <b>Details</b> attribute value.
        /// </summary>
        /// <value>The <b>Details</b> attribute value.</value>
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


       
    }
}
