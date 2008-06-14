using System;

public class TinhToan
{
	public static Boolean ktdang2k(int n)
	{
		for (;n!=1;n/=2)
			if (n%2!=0)
				return false;
		return true;
	}
}