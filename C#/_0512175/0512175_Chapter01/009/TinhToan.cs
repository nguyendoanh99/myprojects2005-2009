using System;

public class TinhToan
{
	public static int Tinh(int n)
	{
		int kq=1;
		for (int i=1;i<=n;i++)
			kq*=i;
		return kq;
	}
}