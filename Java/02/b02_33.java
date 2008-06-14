/*
 * Author: Nguyen Dang Khoa
 * Created: 06 tha´ng ta´m 2004 7:19:38 CH
 * Modified: 06 tha´ng ta´m 2004 7:19:38 CH
 */

/*
 * Viet chuong trinh nhap 1 string tuy y, sau do doi cac ky 
 * tu cua string do ra chu truong roi in ket qua ra man hinh.
 */

import javax.swing.JOptionPane;
public class b02_33
{
	public static void main(String[] args)
	{
		String s=JOptionPane.showInputDialog("Nhap vao 1 chuoi :");
		String s1="";
		for (int i=0;i<s.length();i++) s1+=Character.toLowerCase(s.charAt(i));
		System.out.println("Chuoi sau khi chuyen doi: "+s1);
//		System.out.println("Chuoi sau khi chuyen doi: "+s.toLowerCase());
		System.exit(0);
	}
}
