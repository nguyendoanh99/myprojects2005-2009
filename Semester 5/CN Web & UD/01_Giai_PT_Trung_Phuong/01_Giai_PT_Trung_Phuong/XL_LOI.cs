using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Giai_PT_Trung_Phuong
{
    class XL_LOI
    {
        public static String Loi(String szHesoA, String szHesoB, String szHesoC)
        {
            String kq = "";
            float temp;
            // Kiem tra he so A
            try
            {
                temp = float.Parse(szHesoA);
                if (temp == 0)
                    kq += "\nHệ số A phải khác 0";
            }
            catch (Exception e)
            {
                kq += "\nHệ số A phải là số thực";
            }
            // Kiem tra he so B
            try
            {
                temp = float.Parse(szHesoB);
            }
            catch (Exception e)
            {
                kq += "\nHệ số B phải là số thực";
            }
            // Kiem tra he so C
            try
            { 
                temp = float.Parse(szHesoC);
            }
            catch (Exception e)
            {
                kq += "\nHệ số C phải là số thực";
            }

            return kq;
        }
    }
}
