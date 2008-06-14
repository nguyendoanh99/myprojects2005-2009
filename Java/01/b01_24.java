/*
 * Author: Nguyen Dang Khoa
 * Created: 05 tha´ng ta´m 2004 10:03:22 SA
 * Modified: 05 tha´ng ta´m 2004 10:03:22 SA
 */

/*
 * Viet chuong trinh nhap 2 so nguyen duong a, b truyen
 * tu dong lenh, sau do in ra man hinh gia tri a luy thua b.
 */

public class b01_24
{
	public static void main(String[] args)
	{
		int a=Integer.parseInt(args[0]);
		int b=Integer.parseInt(args[1]);
		System.out.println(a+"^"+b+" = "+Math.pow(a,b));		
		System.out.println(a+"^"+b+" = "+Math.exp(b*Math.log(a)));
	}
}
