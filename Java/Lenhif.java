/*
 * Author: Nguyen Dang Khoa
 * Created: 29 tha´ng ba?y 2004 10:21:26 SA
 * Modified: 29 tha´ng ba?y 2004 10:21:26 SA
 */

// Vi du ve lenh if

public class Lenhif
{
  //Chuong trinh chinh	
	public static void main(String[] args)
	{
		Integer x=new Integer(args[0]);
		int a=x.intValue();
		if (a==0) System.out.println("It is Sunday.");
		else
			if (a==1) System.out.println("It is Monday.");
			else 
				if (a==2) System.out.println("It is Tuesday.");
				else System.out.println("Oh no!!!");
	}
}
