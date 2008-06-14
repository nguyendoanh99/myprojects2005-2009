/*
 * Author: Nguyen Dang Khoa
 * Created: 06 tha´ng ta´m 2004 11:02:10 SA
 * Modified: 06 tha´ng ta´m 2004 11:02:10 SA
 */

/*
 * Viet chuong trinh ve hinh chu nhat dac bang cac dau *,
 * co so do 2 canh nhap tu ban phim.
 */

import javax.swing.JOptionPane;
public class b02_29
{
	public static void main(String[] args)
	{
		String a1=JOptionPane.showInputDialog("Nhap chieu dai?");
		String b1=JOptionPane.showInputDialog("Nhap chieu rong?");
		for (int i=1;i<=Integer.parseInt(a1);i++)
		{
			for (int j=1;j<=Integer.parseInt(b1);j++) System.out.print('*');
			System.out.println();
		}
		System.exit(0);
	}
}
