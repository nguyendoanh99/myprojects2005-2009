using System;

public class TinhToan
{
	public static float Tinh(int n)
	{
		float s=0;
		for (int i=1;i<=n;i++)
			s=(float) Math.Sqrt(2+s);
		return s;
	}
}
