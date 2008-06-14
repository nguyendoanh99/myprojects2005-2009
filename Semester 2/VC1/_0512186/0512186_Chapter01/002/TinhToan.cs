using System;

public class TinhToan
{
	public static int Tinh(int n)
	{
		int s=0;
		for (int i=1;i<=n;i++)
			s+=(int) Math.Pow(i,2);
		return s;
	}
}
