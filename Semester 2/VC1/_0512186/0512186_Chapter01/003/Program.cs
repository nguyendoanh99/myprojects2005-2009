using System;

class Program
{
	static void Main(string[] args)
	{
		do
		{
			int n=SoNguyen.NhapSoNguyenDuong("Nhap n = ");
			float kq=TinhToan.tinh(n);
			Console.Write("S("+n+") = "+kq);
		} while (SoNguyen.NhapSoNguyen("\nTiep tuc (1.Tiep, 0.Khong)? ")!=0);
	}
}
