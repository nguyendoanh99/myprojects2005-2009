using System;

public class TinhToan
{
	public static int tichuoc(int n)
	{
		int kq=01;
		for (int i=1;i<=n;i++)
			if (n%i==0)
				kq*=i;
		return kq;
	}
}
