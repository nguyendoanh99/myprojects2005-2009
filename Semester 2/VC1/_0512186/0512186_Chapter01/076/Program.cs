using System;

class Program
{

	static void Main(string[] args)
	{
		do
		{
			int n=SoNguyen.NhapSoNguyenDuong("Nhap n = ");
			if (TinhToan.ktdang2k(n))
				Console.Write(n+" co dang 3^k");
			else
				Console.Write(n+" khong co dang 3^k");
		} while (SoNguyen.NhapSoNguyen("\nTiep tuc (1.Tiep, 0.Khong)?")!=0);
	}
}
