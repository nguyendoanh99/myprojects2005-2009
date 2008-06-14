using System;

public class TinhToan
{
	public static Boolean toanle(int n)
	{
		do
		{
			int dv=n%10;
			if (dv%2==0)
				return false;
			n/=10;
		} while (n!=0);
		return true;
	}
}
