/*
 * Author: Nguyen Dang Khoa
 * Created: 18 tha´ng ta´m 2004 10:28:39 SA
 * Modified: 18 tha´ng ta´m 2004 10:28:39 SA
 */

/*
 * Viet chuong trinh nhap 2 so m, n sau do tim boi so chung 
 * nho nhat cua 2 so do.
 */

import javax.swing.JOptionPane;
public class b03_31
{
	public static void main(String[] args)
	{
		String s=JOptionPane.showInputDialog("m =");
		int m=Integer.parseInt(s);
		s=JOptionPane.showInputDialog("n =");
		int n=Integer.parseInt(s);
		int a=m;
		int b=n;
		while (a%b!=0)
		{
			int t=a%b;
			a=b;
			b=t;
		}
		System.out.println("BCNN("+m+","+n+") = "+(m*n/b));
		System.exit(0);
	}
}
