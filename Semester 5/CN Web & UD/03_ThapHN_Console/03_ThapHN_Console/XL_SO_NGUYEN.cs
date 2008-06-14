using System;
using System.Collections.Generic;
using System.Text;

namespace _3_ThapHN_Console
{
    public class XL_SO_NGUYEN
    {
        public static long Nhap(String szGhiChu)
        {
            long kq;
            String Chuoi;
            do
            {
                Chuoi = XL_CHUOI.Nhap(szGhiChu);
            }
            while (!KiemTra(Chuoi));
            kq = long.Parse(Chuoi);
            return kq;
        }
        public static Boolean KiemTra(String Chuoi)
        {
            Boolean kq = true;
            try
            {
                long so = long.Parse(Chuoi);
            }
            catch (Exception e)
            {
                kq = false;
            }
            return kq;
        }
    }
}
