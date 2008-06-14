using System;

public class TinhToan
{
	public static float Tinh(int n)
	{
		int t=1;
		int s=0;
		for (int i=1;i<=n;i++)
		{
			t*=i;
			s+=t;
		}
		return s;
	}
}