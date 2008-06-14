using System;

public class SoNguyen
{
	public static Boolean LaSoNguyen(String chuoi)
	{
		Boolean flag=true;
		try 
		{
			int test=int.Parse(chuoi);
		}
		catch (Exception e)
		{
			flag=false;
		}
		return flag;
	}
	public static int NhapSoNguyen(String GhiChu)
	{
		String chuoi;
		do
		{
			Console.Write(GhiChu);
			chuoi=Console.ReadLine();
		} while (!LaSoNguyen(chuoi));
		int temp=int.Parse(chuoi);
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