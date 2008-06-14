using System;

public class TinhToan
{
	public static int tim(int n)
	{
		int max=n%10;
		for (;n!=0;n/=10)
		{
			int dv=n%10;
			if (dv>max)
				max=dv;
		}
        return max;
	}
}
