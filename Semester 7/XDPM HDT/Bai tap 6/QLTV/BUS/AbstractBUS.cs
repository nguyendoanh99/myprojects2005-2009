using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DAO;
namespace BUS
{
    public class AbstractBUS
    {
        protected DataProvider dp = null;
        public IList GetAll()
        {            
            return dp.GetAll();
        }
        public IList GetByProperties(List<string> lstKey, List<object> Values, List<bool> Exact)
        {
            return dp.GetByProperties(lstKey, Values, Exact);
        }
    }
}
