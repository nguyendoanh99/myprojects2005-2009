using System;

public class TinhToan
{
	public static int tim(int n)
	{
		int min=n%10;
		for (;n!=0;n/=10)
		{
			int dv=n%10;
			if (dv<min)
				min=dv;
		}
        return min;
	}
}
