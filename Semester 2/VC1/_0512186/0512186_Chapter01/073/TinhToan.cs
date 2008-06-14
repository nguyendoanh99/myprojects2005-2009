using System;

public class TinhToan
{
	public static float Tinh(float x,int n)
	{
		float s=-1;
		float t=-1;
		for (int i=2;i<=2*n;i+=2)
		{
			t=-t*(x*x)/(i*(i-1));
			s+=t;
		}
		return s;
	}
}