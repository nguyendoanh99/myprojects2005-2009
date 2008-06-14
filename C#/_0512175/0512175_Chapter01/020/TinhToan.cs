using System;

public class TinhToan
{
	public static void lietke(int n)
	{
		for (int i=1;i<=n;i++)
			if (n%i==0)
				Console.Write(i+" ");
	}
}
