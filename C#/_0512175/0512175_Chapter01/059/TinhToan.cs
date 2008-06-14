using System;

public class TinhToan
{
	public static Boolean ktdx(int n)
	{
		int t=n;
		int m=0;
		do
		{
			m=m*10+n%10;
			n/=10;
		} while (n!=0);
		return m==t;
	}
}
