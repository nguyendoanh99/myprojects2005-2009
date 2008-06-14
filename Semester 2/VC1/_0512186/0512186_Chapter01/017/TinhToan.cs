using System;

public class TinhToan
{
	public static float Tinh(float x,int n)
	{
		float s=0;
		float p=1;
		for (int i=1;i<=n;i++)
		{
			p*=(x/i);
			s+=p;
		}
		return s;
	}
}