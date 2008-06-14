using System;

public class TinhToan
{
	public static float Tinh(int n)
	{
		float kq=0;
		for (int i=1;i<=2*n+1;i+=2)
			kq+=(float)1/i;
		return kq;
	}
}
