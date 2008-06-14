using System;

public class TinhToan
{
	public static float Tinh(float x,int n)
	{
		float s=0;
		float t=1;
		int p=0;		
		for (int i=1;i<=n;i++)
		{
			p+=i;
			t=-t*x;			
			s+=t/p;
		}
		return s;
	}
}