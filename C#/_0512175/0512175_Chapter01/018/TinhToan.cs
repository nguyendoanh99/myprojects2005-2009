using System;

public class TinhToan
{
	public static float Tinh(float x,int n)
	{
		float s=01;
		float p=1;
		for (int i=2;i<=2*n;i+=2)
		{
			p*=(x*x)/(i*(i-1));
			s+=p;
		}
		return s;
	}
}