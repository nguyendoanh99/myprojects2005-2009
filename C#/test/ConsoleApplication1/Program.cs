/*using System;
using System.Collections.Generic;
using System.Text;

/*namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int m, n;
                m = SoNguyen.NhapSoNguyenDuong("Nhap so thu nhat:");
                n = SoNguyen.NhapSoNguyenDuong("Nhap so thu hai:");
                int kq = SoNguyen.BoiChungNhoNhat(m, n);
                Console.Write("\nBoiChungNhoNhat:" + kq);
            } while (SoNguyen.NhapSoNguyen("\nTiep tuc(1.Tiep,0.Khong)") != 0);
        }
    }
}
