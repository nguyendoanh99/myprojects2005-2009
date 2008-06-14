using System;

class Program
{
	static void Main(string[] args)
	{
		do
		{
			int n=SoNguyen.NhapSoNguyenDuong("Nhap n = ");
			Console.Write("S("+n+") = "+TinhToan.Tinh(n));
		} while (SoNguyen.NhapSoNguyen("\nTiep tuc (1.Tiep, 0.Khong) ?")!=0);
	}
}