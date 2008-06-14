using System;

class Program
{
	static void Main(string[] args)
	{			
		do
		{
			int n;
			n=SoNguyen.NhapSoNguyenDuong("Nhap n=");
			if (TinhToan.ktdx(n))
				Console.Write(n+" la so doi xung");
			else
				Console.Write(n+" khong la so doi xung");
		} while (SoNguyen.NhapSoNguyen("\nTiep tuc (1.Tiep, 0.Khong)")!=0);
	}
}
