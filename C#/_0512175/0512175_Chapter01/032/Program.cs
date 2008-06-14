using System;

class Program
{
	static void Main(string[] args)
	{			
		do
		{
			int n;
			n=SoNguyen.NhapSoNguyenDuong("Nhap n = ");			
			if (TinhToan.ktcp(n))
				Console.Write(n+" la so chinh phuong");
			else
				Console.Write(n+" khong la so chinh phuong");			
		} while (SoNguyen.NhapSoNguyen("\nTiep tuc (1.Tiep, 0.Khong) ? ")!=0);
	}
}
