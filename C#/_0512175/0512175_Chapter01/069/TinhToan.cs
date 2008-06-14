using System;

public class TinhToan
{
	public static float Tinh(float x,int n)
	{
		float s=x;
		float t=x;
		for (int i=3;i<=2*n+1;i+=2)
		{
			t=-t*x*x;
			s+=t;			
		}
		return s;
	}
}