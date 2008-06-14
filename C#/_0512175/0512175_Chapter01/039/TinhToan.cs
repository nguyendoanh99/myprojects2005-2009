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
			s=(float) Math.Pow(t+s,(float)1/(i+1));
		}
		return s;
	}
}
