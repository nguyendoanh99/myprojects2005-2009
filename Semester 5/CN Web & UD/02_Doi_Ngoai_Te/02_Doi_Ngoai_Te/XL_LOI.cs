using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Doi_Ngoai_Te
{
    class XL_LOI
    {
        public static String Loi(String szSoTien)
        {
            String kq = "";

            try
            {
                double temp = double.Parse(szSoTien);
                if (temp <= 0)
                    kq = "Số tiền cần đổi phải lớn hơn 0";
            }
            catch (Exception e)
            {
                kq = "Số tiền phải là số thực";
            }
            return kq;
        }
    }
}
