using System;

public class TinhToan
{
	public static float Tinh(float x,int n)
	{
		float s=0;
		float p=x;
		for (int i=1;i<=2*n+1;i+=2)
		{
			s+=p;
			p*=x*x;			
		}
		return s;
	}
}