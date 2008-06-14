using System;

public class TinhToan
{
	public static Boolean ktdang2k(int n)
	{
		for (;n!=1;n/=3)
			if (n%3!=0)
				return false;
		return true;
	}
}