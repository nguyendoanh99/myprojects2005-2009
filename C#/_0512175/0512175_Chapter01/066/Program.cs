using System;

class Program
{
	static void Main(string[] args)
	{
		do
		{
			float a=SoThuc.NhapSoThuc("Nhap a = ");
			float b=SoThuc.NhapSoThuc("Nhap b = ");			
			float c=SoThuc.NhapSoThuc("Nhap c = ");			
			TinhToan.giapt(a,b,c);
		} while (SoNguyen.NhapSoNguyen("\nTiep tuc (1.Tiep, 0.Khong) ?")!=0);
	}
}