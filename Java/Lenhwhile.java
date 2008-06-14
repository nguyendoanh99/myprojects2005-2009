/*
 * Author: Nguyen Dang Khoa
 * Created: 29 tha´ng ba?y 2004 10:56:00 SA
 * Modified: 29 tha´ng ba?y 2004 10:56:00 SA
 */

// Vi du ve lenh While

public class Lenhwhile
{
  //Chuong trinh chinh	
	public static void main(String[] args)
	{
		Integer x=new Integer(args[0]);
		System.out.println("While");
		int i=1;
		while (i<=x.intValue())
		{
			System.out.println(i);
			i++;
		}
		System.out.println("Do..While");
		i=1;
		do
		{
			System.out.println(i);
			i++;
		}
		while (i<=x.intValue());
	}
}
