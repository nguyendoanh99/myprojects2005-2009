using System;

public class TinhToan
{
	public static int demuoc(int n)
	{
		int dem=0;
		for (int i=1;i<=n;i++)
			if (n%i==0)
				dem++;
		return dem;
	}
}
