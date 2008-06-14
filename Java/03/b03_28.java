/*
 * Author: Nguyen Dang Khoa
 * Created: 17 tha´ng ta´m 2004 10:19:08 SA
 * Modified: 17 tha´ng ta´m 2004 10:19:08 SA
 */


/*
 * Nhap vao mot chuoi, sau do bo di tat ca cac khoang
 * trong, neu co, phia ben phai cua chuoi nay.
 */

import javax.swing.JOptionPane;
public class b03_28
{
	public static void main(String[] args)
	{
		String s=JOptionPane.showInputDialog("Nhap vao 1 chuoi");
		int i=s.length()-1;
		while ((i>=0)&&(s.charAt(i)==' ')) 
		{
			s=s.substring(0,i);
			i--;
		}
		System.out.println(s);
		System.exit(0);
	}
}
