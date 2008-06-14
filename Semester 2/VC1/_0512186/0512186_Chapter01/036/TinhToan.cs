using System;

public class TinhToan
{
	public static float Tinh(int n)
	{
		float s=0;
		int t=1;
		for (int i=1;i<=n;i++)
		{
			t*=i;
			s=(float) Math.Sqrt(t+s);
		}
		return s;
	}
}
