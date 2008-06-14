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
				if (m1<0 && m2<0)
					Console.Write("Vo nghiem");
				else
				{
					if (m1>=0)
						Console.Write(Math.Sqrt(m1)+" "+ -Math.Sqrt(m1)+"\n");
					else
						Console.Write(Math.Sqrt(m2)+" "+ -Math.Sqrt(m2)+"\n");
				}				
			}
			else
			{
				m0=-y/(2*x);
				if (m0>=0)
					Console.Write(Math.Sqrt(m0)+" "+ -Math.Sqrt(m0)+"\n");
				else
					Console.Write("Vo nghiem");                
			}
		else
			Console.Write("Vo nghiem");
	}
}