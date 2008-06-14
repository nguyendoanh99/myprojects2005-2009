/*
 * Author: Nguyen Dang Khoa
 * Created: 06 tha´ng ta´m 2004 8:12:16 SA
 * Modified: 06 tha´ng ta´m 2004 8:12:16 SA
 */

/*
 * Viet chuong trinh nhap 1 so nguyen duong roi in ra man hinh
 * tat ca cac uoc so la so chan cua no.
 */

import javax.swing.JOptionPane;
public class b02_21
{
	public static void main(String[] args)
	{
		String n1=JOptionPane.showInputDialog("n =");
		int n=Integer.parseInt(n1);
		System.out.println("Tat ca cac uoc so la so chan cua "+n+" la :");
		for (int i=1;i<=n/2;i++)
//			if ((n%i==0)&&(i%2==0)) System.out.print(i+" ");
			if (n%(i*2)==0) System.out.print(i*2+" ");
		System.exit(0);
	}
}
