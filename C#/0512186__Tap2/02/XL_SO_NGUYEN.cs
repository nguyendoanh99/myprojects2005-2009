using System;
using System.Collections.Generic;
using System.Text;

namespace _2
{
    class XL_SO_NGUYEN
    {
        public static Boolean Kiem_tra(String Chuoi)
        {
            Boolean Kq = true;
            try
            {
                long So = long.Parse(Chuoi);
            }
            catch (Exception loi)
            {
                Kq = false;
            }
            return Kq;
        }
        public static long Nhap(String Ghi_chu)
        {
            long Kq;
            String Chuoi;
            do
            {
                Chuoi = XL_CHUOI.Nhap(Ghi_chu);
            } while (!Kiem_tra(Chuoi));
            Kq = long.Parse(Chuoi);
            return Kq;
        }
    }
}
