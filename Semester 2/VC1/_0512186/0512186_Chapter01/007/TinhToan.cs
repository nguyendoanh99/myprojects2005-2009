using System;

public class TinhToan
{
	public static float Tinh(int n)
	{
		float kq=0;
		for (int i=1;i<=n;i++)
			kq+=(float)i/(i+1);
		return kq;
	}
}