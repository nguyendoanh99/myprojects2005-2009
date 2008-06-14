using System;

public class TinhToan
{
	public static Boolean ktcp(int n)
	{		
		for (int i=0;i<=n;i++)
			if (i*i==n)
				return true;
		return false;
	}
}
