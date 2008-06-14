using System;

class Program
{
	static void Main(string[] args)
	{			
		do
		{
			int n;
			n=SoNguyen.NhapSoNguyenDuong("Nhap n = ");			
			if (TinhToan.ktht(n))
				Console.Write(n+" la so hoan thien");
			else
				Console.Write(n+" khong la so hoan thien");			
		} while (SoNguyen.NhapSoNguyen("\nTiep tuc (1.Tiep, 0.Khong) ? ")!=0);
	}
}
