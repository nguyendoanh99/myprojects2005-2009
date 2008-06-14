using System;


public class TinhToan
{
	public static int Tong(int n)
	{
        int S = 0;
		for (int i=1;i<=n;i++)
			S+=i;
		return S;
	}
}
