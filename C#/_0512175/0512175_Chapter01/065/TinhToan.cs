using System;

public class TinhToan
{
	public static void giapt(float x,float y,float z)
	{
		float m0,m1,m2,d=y*y-4*x*z;
		if (d>=0)
			if (d>0)
			{
				m1=(float) (-y+Math.Sqrt(d))/(2*x);
				m2=(float) (-y-Math.Sqrt(d))/(2*x);
				Console.Write("Co 2 nghiem :"+m1+" "+m2);
			}
			else
			{
				m0=-y/(2*x);
                Console.Write("Co 1 nghiem kep : "+m0);
			}
		else
			Console.Write("Vo nghiem");
	}
}