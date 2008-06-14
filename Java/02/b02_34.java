/*
 * Author: Nguyen Dang Khoa
 * Created: 08 tha´ng ta´m 2004 8:31:32 SA
 * Modified: 08 tha´ng ta´m 2004 8:31:32 SA
 */

/*
 * Xet bai toan sau: 1 ban co gom 64 o co. Tren o thu nhat dat
 * 1 hat thoc, o thu 2 gap doi o thu nhat, o thu gap doi o thu 
 * n-1. Viet chuong trinh de tinh toan bo ban co co bao nhieu 
 * hat thoc. Ngoai ra, neu 1000 hat thoc nang 63 gr thi  so thoc 
 * do can nang bao nhieu tan.
 */

import java.text.NumberFormat;
import java.math.*;
public class b02_34
{
	public static void main(String[] args)
	{
		NumberFormat nf=NumberFormat.getInstance();
		BigInteger d=BigInteger.valueOf(0);
		BigInteger a=BigInteger.valueOf(2);
		for (int i=0;i<64;i++) d=d.add(a.pow(i));
		System.out.println("Toan bo ban co co "+nf.format(d)+" hat thoc.");
		d=d.divide(BigInteger.valueOf(1000000)).multiply(BigInteger.valueOf(63));
		System.out.println("So thoc tren nang "+nf.format(d)+" kg");
//		System.out.println(nf.format(Math.pow(2,10)-1));
	}
}
