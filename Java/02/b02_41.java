/*
 * Author: Nguyen Dang Khoa
 * Created: 09 tha´ng ta´m 2004 10:51:24 SA
 * Modified: 09 tha´ng ta´m 2004 10:51:24 SA
 */

/* 
 * Viet chuong trinh cho phep nhap vao 1 so nguyen
 * duong, sau do in ra tong cac chu so cua no.
 */

import javax.swing.JOptionPane;
public class b02_41
{
	public static void main(String[] args)
	{
		String s=JOptionPane.showInputDialog("Nhap vao 1 so nguyen :");
		int t=0;
		for (int i=0;i<s.length();i++)
			t+=Integer.parseInt(s.substring(i,i+1));
		System.out.println(t);
		System.exit(0);
	}
}
