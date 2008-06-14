/*
 * Author: Nguyen Dang Khoa
 * Created: 16 tha´ng ta´m 2004 10:41:41 CH
 * Modified: 16 tha´ng ta´m 2004 10:41:41 CH
 */

public class Vidu1
{
	public static void main(String[] args)
	{
		Integer s=new Integer(100);
		Integer s1=s;
		System.out.println(s.intValue());
		System.out.println(s1.intValue());
		s=Integer.valueOf("100000");
		System.out.println(s.intValue());
		System.out.println(s1.intValue());
	}
}
