using System;

public class TinhToan
{
	public static int tonguoc(int n)
	{
		int kq=0;
		for (int i=2;i<=n;i+=2)
			if (n%i==0)
				kq+=i;
		return kq;
	}
}
