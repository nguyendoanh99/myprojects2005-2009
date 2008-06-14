using System;

public class TinhToan
{
	public static int tim(int n)
	{
		int s=0;
		int i=0;
		for (;s<n;)
		{				
			i++;
			s+=i;
		}
		return i;
	}
}
