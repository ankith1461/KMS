using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
namespace BusinessLayer
{
    public class BussinessLayerAuthorTag
    {
        public DataSet GetTags()
        {
            try
            {
            DataLayerAuthorTag obj = new DataLayerAuthorTag();
            return obj.GetTag();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ChangeTagStatus(string TagId, string Status)
        {
            try
            {
            DataLayerAuthorTag obj =  new DataLayerAuthorTag();
            return obj.ChangeTagStatus(TagId, Status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
