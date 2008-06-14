using System;

public class TinhToan
{
	public static int ucln(int x,int y)
	{		
		for (;y!=0;)
		{
			int t=x%y;
			x=y;
			y=t;
		}
		return x;
	}
	public static int bcnn(int x,int y)
	{
		return (x*y)/ucln(x,y);
	}
}
