using System;

public class TinhToan
{
	public static float Tinh(float x,int n)
	{
		float s=01+x;
		float p=x;
		for (int i=3;i<=2*n+1;i+=2)
		{
			p*=(x*x)/(i*(i-1));
			s+=p;
		}
		return s;
	}
}