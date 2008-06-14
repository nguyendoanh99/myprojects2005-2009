using System;

public class TinhToan
{
	public static float Tinh(int n)
	{
		float s=0;
		int p=0;
		for (int i=1;i<=n;i++)
		{
			p+=i;
			s+=(float)1/p;			
		}
		return s;
	}
}