/*
 * Author: Nguyen Dang Khoa
 * Created: 08 tha´ng ta´m 2004 9:53:56 SA
 * Modified: 08 tha´ng ta´m 2004 9:53:56 SA
 */

/*
 * Viet chuong trinh nhap 2 so nguyen duong m, n, sau do
 * tinh roi in ra man hinh gia tri cua:
 * 				n!
 *C(m,n)=_________________
 *			  m!(n-m)!
 */

import javax.swing.*;
import java.text.*;
public class b02_35
{
	public static void main(String[] args)
	{
		NumberFormat nf=NumberFormat.getInstance();
		String s=JOptionPane.showInputDialog("n =");
		int n=Integer.parseInt(s);
		s=JOptionPane.showInputDialog("m =");
		int m=Integer.parseInt(s);
		long tu=1,mau=1;
		for (int i=m+1;i<=n;i++) tu*=i;
		for (int i=2;i<=(n-m);i++) mau*=i;
		System.out.println("C("+m+","+n+") = "+nf.format(tu)+"/"+nf.format(mau)
			+" = "+nf.format(tu/mau));
		System.exit(0);
	}
}
