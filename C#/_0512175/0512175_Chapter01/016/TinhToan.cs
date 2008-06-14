using System;

public class TinhToan
{
	public static float Tinh(float x,int n)
	{
		float s=0;
		float t=1;
		int m=0;		
		for (int i=1;i<=n;i++)
		{
			t*=x;
			m+=i;
			s+=t/m;
		}
		return s;
	}
}