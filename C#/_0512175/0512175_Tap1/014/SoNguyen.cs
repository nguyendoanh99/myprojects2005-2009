using System;
using System.Collections;
using System.Text;

class SoNguyen
{
	public static Boolean LaSoNguyen(String Chuoi)
	{
		Boolean flag=true;
		try
		{
			int test=int.Parse(Chuoi);
		}
		catch (Exception e)
		{
			flag=false;
		}
		return flag;
	}
	public static int NhapSoNguyen(String GhiChu)
	{
		String Chuoi;
		do
		{
			Console.Write(GhiChu);
			Chuoi=Console.ReadLine();
		} while (!LaSoNguyen(Chuoi));
		int temp=int.Parse(Chuoi);
		return temp;
	}
	public static int NhapSoNguyenDuong(String GhiChu)
	{
		int temp;
		do
		{
			temp=NhapSoNguyen(GhiChu);
		} while (temp<=0);
		return temp;
	}
}
