using System;

public class TinhToan
{
	public static int dem(int n)
	{
		int d=0;
		do
		{			
			d++;
			n/=10;
		} while (n!=0);
		return d;
	}
}
