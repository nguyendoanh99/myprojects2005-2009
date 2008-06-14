using System;

public class TinhToan
{
	public static float Tinh(int n)
	{
		float s=0;
		int t=-1;
		int p=0;
		for (int i=1;i<=n;i++)
		{
			t=-t;
			p+=i;
			s+=(float)t/p;			
		}
		return s;
	}
}