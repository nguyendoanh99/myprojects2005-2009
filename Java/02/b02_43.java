/*
 * Author: Nguyen Dang Khoa
 * Created: 09 tha´ng ta´m 2004 10:52:43 SA
 * Modified: 09 tha´ng ta´m 2004 10:52:43 SA
 */

/*
 * Tim cac so nguyen a, b, c, d, m, n khac nhau tronh khoang tu
 * 2 den 19, thoa cac dieu kien:
 * (1) c*c=b*d
 * (2) b*c=a*d*d
 * (3) m+n=c*d+3
 * (4) m, n la 2 so nguyen lien tiep
 */


public class b02_43
{
	final static int min=2;
	final static int max=17;
	public static void main(String[] args)
	{
		for (int a=min;a<=max;a++)
			for (int b=min;b<=max;b++)
				for (int c=min;c<=max;c++)
					if (c%2==0)
						for (int d=min;d<=max;d++)
							if ((c*c==b*d)&&(b*c==a*d*d))
								for (int n=min;n<max;n++)
									if ((n+n+1==c*d+3)&&((a-b)*(c-d)!=0)) 
										System.out.println(a+" "+b+" "+c+" "+d+" "+(n+1)+" "+n);
	}
}
