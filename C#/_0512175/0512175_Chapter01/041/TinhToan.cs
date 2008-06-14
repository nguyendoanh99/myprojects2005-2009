using System;

public class TinhToan
{
	public static float Tinh(int n)
	{
		float s=1;
		for (int i=1;i<=n;i++)
		{				
			s=(float) 1/(1+s);
		}
		return s;
	}
}
