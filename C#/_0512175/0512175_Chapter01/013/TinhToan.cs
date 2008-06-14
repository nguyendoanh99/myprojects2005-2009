using System;

public class TinhToan
{
	public static float Tinh(float x,int n)
	{
		float s=0;
		float p=1;
		for (int i=2;i<=2*n;i+=2)
		{
			p*=x*x;
			s+=p;			
		}
		return s;
	}
}