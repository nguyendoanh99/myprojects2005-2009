using System;

public class TinhToan
{
	public static float Tinh(int n)
	{
		float s=0;
		for (int i=n;i>=1;i--)
			s=(float) Math.Sqrt(i+s);
		return s;
	}
}
