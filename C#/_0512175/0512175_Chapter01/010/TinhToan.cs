using System;

public class TinhToan
{
	public static float Tinh(float x,int n)
	{
		float t=1;
		for (int i=1;i<=n;i++)
			t*=x;
		return t;
	}
}