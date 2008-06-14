/*
 * Author: Nguyen Dang Khoa
 * Created: 05 tha´ng ta´m 2004 9:59:21 SA
 * Modified: 05 tha´ng ta´m 2004 9:59:21 SA
 */

/*
 * Viet chuong trinh nhap 1 so nguyen duong n, dau do tinh tong
 * cac so nguyen tu 1 den n roi in ket qua ra man hinh.
 */

import javax.swing.JOptionPane;
public class b01_23
{
	public static void main(String[] args)
	{
		String n1=JOptionPane.showInputDialog("n = ");
		int n=Integer.parseInt(n1);
		System.out.println("Tong cac so nguyen tu 1 den n = "+(n*(n+1)/2));
		System.exit(0);
	}
}
