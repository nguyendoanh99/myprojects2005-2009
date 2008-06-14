/*
 * Author: Nguyen Dang Khoa
 * Created: 06 tha´ng ta´m 2004 8:02:49 SA
 * Modified: 06 tha´ng ta´m 2004 8:02:49 SA
 */

/*
 * Viet chuong trinh nhap vao 1 so nguyen duong n,
 * sau do dem xem tu 1 den n co bao nhieu so chia het cho 7.
 */

import javax.swing.JOptionPane;
public class b02_20
{
	public static void main(String[] args)
	{
		String n1=JOptionPane.showInputDialog("n =");
		int n=Integer.parseInt(n1);
		int t=0;
		for (int i=1;i<=n;i++) if (i%7==0)t++; //t=i%7==0?t+1:t;
		System.out.println("Co "+t+" so chia het cho 7 trong [1,"+n+"].");
		System.exit(0);
	}
}
