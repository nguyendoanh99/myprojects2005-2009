using System;
using System.Collections.Generic;
using System.Text;

namespace _3_ThapHN_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            XL_THAP_HN THN;
            do
            {
                n = (int)XL_SO_NGUYEN.Nhap("Nhap so dia n (n > 0): ");
                THN = new XL_THAP_HN(n, 1, 3);             
            }
            while (THN.XemLoi() != "");
            XL_TRANG_THAI trangthai;
            Console.WriteLine("----------Qua trinh di chuyen dia------------");
            while ((trangthai = THN.LayCachDoiDiaKeTiep()) != null)
            {
                Console.WriteLine("Chuyen dia " + trangthai.N + " tu cot " + trangthai.CotNguon + " sang cot " + trangthai.CotDich);
            }

        }
    }
}
