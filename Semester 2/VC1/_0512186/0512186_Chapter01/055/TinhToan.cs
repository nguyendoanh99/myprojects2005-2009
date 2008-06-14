using System;

public class TinhToan
{
	public static int dautien(int n)
	{
		for (;n>=10;n/=10);
		return n;
	}
	public static int dem(int n)
	{
		int m=dautien(n);
		int d=0;		
		for (;n!=0;n/=10)
		{
			int dv=n%10;
			if (dv==m)
				d++;
		}
        return d;
	}
}
