using System;
using System.Collections.Generic;
using System.Text;

namespace _2
{
    class XL_CHUOI
    {
        public static void Xuat(String Ghi_Chu)
        {
            Console.Write(Ghi_Chu);
        }

        public static String Nhap(String Ghi_chu)
        {
            String Kq;
            Xuat(Ghi_chu);
            Kq = Console.ReadLine();
            return Kq;
        }
    }
}
