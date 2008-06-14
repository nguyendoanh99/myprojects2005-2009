using System;

public class TinhToan
{
	public static Boolean kttangdan(int n)
	{
		int x=10;
		for (;n!=0;n/=10)
		{
			int dv=n%10;
			if (x>dv)
				x=dv;
			else
				return false;
		}
		return true;
	}
}
