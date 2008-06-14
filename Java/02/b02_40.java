/*
 * Author: Nguyen Dang Khoa
 * Created: 09 tha´ng ta´m 2004 10:48:59 SA
 * Modified: 09 tha´ng ta´m 2004 10:48:59 SA
 */

/*
 * Viet chuong trinh tinh tong:
 *			 1			   1	
 * S = 1 + _____ + ... + _____
 *		 	 1!			   n!
 * voi n=17. So sanh voi exp(1)
 */
 
public class b02_40
{
	public static void main(String[] args)
	{
		double s=1;
		int t=1;
		char m;
		for (int i=1;i<=17;t*=++i) s+=1.0/t;
		System.out.println(s);
		if (s>Math.exp(1)) m='>';
		else
			if (s<Math.exp(1)) m='<';
			else m='=';
		System.out.println(s+""+m+"exp(1)="+Math.exp(1));
	}
}
