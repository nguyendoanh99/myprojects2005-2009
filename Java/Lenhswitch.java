/*
 * Author: Nguyen Dang Khoa
 * Created: 29 tha´ng ba?y 2004 10:45:51 SA
 * Modified: 29 tha´ng ba?y 2004 10:45:51 SA
 */

// Vi du ve lenh switch

public class Lenhswitch
{
  //Chuong trinh chinh
	public static void main(String[] args)
	{
		Integer a=new Integer(args[0]);
		switch (a.intValue())
		{
		case 0: 
		case 1:
		case 2:
		case 3:
			System.out.println("Hom nay toi om");
			break;
		case 4: 
		case 5:
		case 6:
			System.out.println("Hom nay toi di hoc.");
			break;
		default:
			System.out.println("Khong phai la ngay trong tuan.");
		}
	}
}
