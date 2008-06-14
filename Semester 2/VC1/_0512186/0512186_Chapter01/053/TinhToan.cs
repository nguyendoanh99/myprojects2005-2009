using System;

public class TinhToan
{
	public static int dem(int n)
	{
		int d=0,max=n%10;		
		for (;n!=0;n/=10)
		{
			int dv=n%10;
			if (max<dv)
			{
				max=dv;
				d=1;
			}
			else
				if (max==dv)
				d++;
		}
        return d;
	}
}
