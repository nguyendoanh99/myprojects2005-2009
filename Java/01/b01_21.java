/*
 * Author: Nguyen Dang Khoa
 * Created: 05 tha´ng ta´m 2004 8:34:57 SA
 * Modified: 05 tha´ng ta´m 2004 8:34:57 SA
 */

/*
 * Viet chuong trinh nhap 1 ky tu, sau do in ra ma ASCII cua no.
 */

import javax.swing.JOptionPane;
public class b01_21
{
	public static void main(String[] args)
	{
		String s=JOptionPane.showInputDialog("Nhap vao 1 ky tu:");
		byte a[]=s.getBytes();
		System.out.println(a[0]);
		System.exit(0);
	}
}
