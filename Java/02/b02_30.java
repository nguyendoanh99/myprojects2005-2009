/*
 * Author: Nguyen Dang Khoa
 * Created: 06 tha´ng ta´m 2004 11:15:09 SA
 * Modified: 06 tha´ng ta´m 2004 11:15:09 SA
 */

/*
 * Viet chuong trinh ve tam giac can rong bang cac dau *,
 * co chieu cao nhap tu ban phim.
 */

import javax.swing.JOptionPane;
public class b02_30
{
	public static void main(String[] args)
	{
		String h1=JOptionPane.showInputDialog("Nhap chieu cao cua tam giac muon ve?");
		int h=Integer.parseInt(h1);
		for (int i=1;i<=h-1;i++)
		{
			for (int j=1;j<=h-i;j++) System.out.print(' ');
			for (int j=1;j<=2*i-1;j++)
				if ((j==1)||(j==2*i-1)) System.out.print('*');
				else System.out.print(' ');
			System.out.println();
		}
		for (int j=1;j<=2*h-1;j++) System.out.print('*');
		System.out.println();
		System.exit(0);
	}
}
