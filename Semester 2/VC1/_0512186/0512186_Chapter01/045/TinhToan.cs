using System;

public class TinhToan
{
	public static int tich(int n)
	{
		int s=1;
		do
		{			
			s*=n%10;
			n/=10;
		} while (n!=0);
		return s;
	}
}
