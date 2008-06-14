using System;

class Program
{
	static void Main(string[] args)
	{			
		do
		{
			int n;
			n=SoNguyen.NhapSoNguyenDuong("Nhap n = ");			
            Console.Write("Tich tat cac uoc so cua so nguyen duong "+n+" la "+TinhToan.tichuoc(n));
		} while (SoNguyen.NhapSoNguyen("\nTiep tuc (1.Tiep, 0.Khong) ? ")!=0);
	}
}
