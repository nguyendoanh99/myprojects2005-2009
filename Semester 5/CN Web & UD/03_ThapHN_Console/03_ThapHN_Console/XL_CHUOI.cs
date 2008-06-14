using System;
using System.Collections.Generic;
using System.Text;

namespace _3_ThapHN_Console
{
    public class XL_CHUOI
    {
        public static void Xuat(String Ghi_Chu)
        {
            Console.Write(Ghi_Chu);
        }
        public static String Nhap(String Ghi_Chu)
        {
            String kq;
            Xuat(Ghi_Chu);
            kq = Console.ReadLine();
            return kq;
        }
    }
}
