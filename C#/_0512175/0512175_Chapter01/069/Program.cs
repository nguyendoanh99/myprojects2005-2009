using System;

class Program
{
	static void Main(string[] args)
	{
		do
		{
			float x=SoThuc.NhapSoThuc("Nhap x = ");
			int n=SoNguyen.NhapSoNguyenDuong("Nhap n = ");
			Console.Write("S("+x+","+n+") = "+TinhToan.Tinh(x,n));
		} while (SoNguyen.NhapSoNguyen("\nTiep tuc (1.Tiep, 0.Khong) ?")!=0);
	}
}