using System;

class Program
{
	static void Main(string[] args)
	{			
		do
		{
			int n;
			n=SoNguyen.NhapSoNguyenDuong("Nhap n=");
			if (TinhToan.toanchan(n))
		        Console.Write(n+" toan chan");
			else
				Console.Write(n+" khong toan chan");
		} while (SoNguyen.NhapSoNguyen("\nTiep tuc (1.Tiep, 0.Khong)")!=0);
	}
}
