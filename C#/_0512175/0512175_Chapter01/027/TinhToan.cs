using System;

public class TinhToan
{
	public static int demuoc(int n)
	{
		int dem=0;
		for (int i=2;i<=n;i+=2)
			if (n%i==0)
				dem++;
		return dem;
	}
}
