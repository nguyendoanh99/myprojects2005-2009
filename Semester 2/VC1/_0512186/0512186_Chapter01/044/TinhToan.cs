using System;

public class TinhToan
{
	public static int tong(int n)
	{
		int s=0;
		do
		{			
			s+=n%10;
			n/=10;
		} while (n!=0);
		return s;
	}
}
