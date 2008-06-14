using System;

public class TinhToan
{
	public static void giapt(float x,float y)
	{
		if (x==0)
			if (y==0)
				Console.Write("Vo so nghiem");
			else
				Console.Write("Vo nghiem");
		else
		{
			float m=-y/x;
			Console.Write(m);
		}
	}
}