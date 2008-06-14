/*using System;
using System.Collections.Generic;
using System.Text;

/*namespace ConsoleApplication1
{
    class SoNguyen
    {
        public static Boolean LaSoNguyen(String Chuoi)
        {
            Boolean flag = true;
            try
            {
                int test = int.Parse(Chuoi);
            }
            catch (Exception k)
            {
                flag = false;
            }
            return flag;
        }
        public static int NhapSoNguyen(String GhiChu)
        {
            String Chuoi;
            do
            {
                Console.Write(GhiChu);
                Chuoi = Console.ReadLine();
            } while (!LaSoNguyen(Chuoi));
            int temp = int.Parse(Chuoi);
            return temp;
        }
        public static int NhapSoNguyenDuong(String GhiChu)
        {
            int temp;
            do
            {
                temp = NhapSoNguyen(GhiChu);
            } while (temp <= 0);
            return temp;
        }
        public static int BoiChungNhoNhat(int a, int b)
        {
            int kq = Math.Abs(a * b);
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a * b != 0)
            {
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            }
            return kq / (a + b);
        }
    }
}
