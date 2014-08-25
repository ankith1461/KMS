using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessLayer
{
   public class BusinessUserPublishedEdit
    {

        public static int BusinessUserUploadFiles(string FileName, Byte[] binary, string extension)
        {

            return DataUserPublishedEdit.DataUserUploadFiles(FileName, binary, extension);
        }
    }
}
