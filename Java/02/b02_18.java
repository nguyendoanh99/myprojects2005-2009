/*
 * Author: Nguyen Dang Khoa
 * Created: 05 tha´ng ta´m 2004 10:38:28 SA
 * Modified: 05 tha´ng ta´m 2004 10:38:28 SA
 */

/*
 * Viet chuong trinh nhap 1 string, sau do dem so khoang trong
 * co trong string nay.
 */

import javax.swing.JOptionPane;
public class b02_18
{
	public static void main(String[] args)
	{
		String s=JOptionPane.showInputDialog("Nhap vao chuoi :");
		int d=0; // Bien dem
		int i=s.indexOf(" ",0);
		while (i>=0)
		{
			d++;
			i=s.indexOf(" ",i+1);
		}
/*
		for (int i=0;i<s.length();i++)
			if (s.charAt(i)==' ') d++;
*/
		System.out.println("Trong chuoi s co "+d+" khoang trang.");
		System.exit(0);
	}
}
