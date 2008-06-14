using System;

public class SoThuc
{
	public static Boolean LaSoThuc(String chuoi)
	{
		Boolean flag=true;
		try
		{
			float test=float.Parse(chuoi);
		}
		catch (Exception e)
		{
			flag=false;
		}
		return flag;
	}
	public static float NhapSoThuc(String GhiChu)
	{
		String chuoi;
		do
		{
			Console.Write(GhiChu);
			chuoi=Console.ReadLine();
		} while (!LaSoThuc(chuoi));
		return float.Parse(chuoi);
	}
	public static float NhapSoThucDuong(String GhiChu)
	{
		float temp;
		do
		{
			temp=NhapSoThuc(GhiChu);
		} while (temp<=0);
		return temp;
	}
}