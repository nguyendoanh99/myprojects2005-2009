/*
 * Author: Nguyen Dang Khoa
 * Created: 04 tha´ng ta´m 2004 7:21:25 CH
 * Modified: 04 tha´ng ta´m 2004 7:21:25 CH
 */

/*
 * Neu biet so giay tinh tu nua dem, hay viet chuong trinh tinh
 * gio, phut, giay hien tai.
 */

import javax.swing.JOptionPane;
public class b01_17
{
	public static void main(String[] args)
	{
		String s1=JOptionPane.showInputDialog("Nhap so giay :");
		int s=Integer.parseInt(s1);
		int h=s/3600;
		s=s%3600;
		int m=s/60;
		s=s%60;
		System.out.println("Bay gio la "+h+" gio "+m+" phut "+s+" giay.");
		System.exit(0);
	}
}
