using System;

public class TinhToan
{
	public static int dem(int n)
	{
		int d=0,min=n%10;		
		for (;n!=0;n/=10)
		{
			int dv=n%10;
			if (dv<min)
			{
				min=dv;
				d=1;
			}
			else
				if (min==dv)
				d++;
		}
        return d;
	}
}
