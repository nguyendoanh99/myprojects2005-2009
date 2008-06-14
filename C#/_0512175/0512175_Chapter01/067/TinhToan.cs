using System;

public class TinhToan
{
	public static float Tinh(float x,int n)
	{
		float s=0;
		float t=-1;
		for (int i=1;i<=n;i++)
		{
			t=-t*x;			
			s+=t;			
		}
		return s;
	}
}