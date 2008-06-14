using System;

class Program
{
	static void Main(string[] args)
	{			
		do
		{
			int a,b;
			a=SoNguyen.NhapSoNguyenDuong("Nhap a = ");
			b=SoNguyen.NhapSoNguyenDuong("Nhap b = ");
			Console.Write("BCNN("+a+","+b+") = "+TinhToan.bcnn(a,b));
		} while (SoNguyen.NhapSoNguyen("\nTiep tuc (1.Tiep, 0.Khong)")!=0);
	}
}
