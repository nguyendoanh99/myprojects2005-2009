using System;

class Program
{
	static void Main(string[] args)
	{			
		do
		{
			int n;
			n=SoNguyen.NhapSoNguyenDuong("Nhap n=");
			if (TinhToan.kttangdan(n))
				Console.Write(n+" tang dan tu trai sang phai");
			else
				Console.Write(n+" khong tang dan tu trai sang phai");
		} while (SoNguyen.NhapSoNguyen("\nTiep tuc (1.Tiep, 0.Khong)")!=0);
	}
}
