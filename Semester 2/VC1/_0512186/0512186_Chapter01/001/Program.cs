using System;

class program
{
	public static void Main(string[] args)
	{
		do 
		{
			int n;				
			n=SoNguyen.NhapSoNguyenDuong("Nhap so n:");
			Console.Write("\nS("+n+")="+TinhToan.Tong(n));
		} while (SoNguyen.NhapSoNguyen("\nTiep tuc (1.Tiep, 0.Khong)")!=0);
	}
}