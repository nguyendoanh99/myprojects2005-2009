using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _2_Doi_Ngoai_Te
{
    class LT_TAP_TIN
    {
        public static String Doc(String szTenFile)
        {
            String kq = "";
            try
            {
                StreamReader BoDoc = new StreamReader(szTenFile);
                kq = BoDoc.ReadToEnd();
                BoDoc.Close();
            }
            catch (Exception e)
            {
                ;
            }

            return kq;
        }
    }
}
