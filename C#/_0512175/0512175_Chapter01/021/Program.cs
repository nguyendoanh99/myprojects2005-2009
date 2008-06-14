using System;

class Program
{
	static void Main(string[] args)
	{			
		do
		{
			int n;
			n=SoNguyen.NhapSoNguyenDuong("Nhap n = ");			
            Console.Write("Tong tat cac uoc so cua so nguyen duong "+n+" la "+TinhToan.tonguoc(n));			
		} while (SoNguyen.NhapSoNguyen("\nTiep tuc (1.Tiep, 0.Khong) ? ")!=0);
	}
}
