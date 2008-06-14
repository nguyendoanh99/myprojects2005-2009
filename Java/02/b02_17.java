/*
 * Author: Nguyen Dang Khoa
 * Created: 05 tha´ng ta´m 2004 10:22:06 SA
 * Modified: 05 tha´ng ta´m 2004 10:22:06 SA
 */

/*
 * Viet chuong trinh nhap 2 so nguyen duong m, n, sau do
 * tinh trung binh cong binh phuong cac so nguyen tu m den n.
 */

import javax.swing.JOptionPane;
import java.text.NumberFormat;
public class b02_17
{
	public static void main(String[] args)
	{
		String m1=JOptionPane.showInputDialog("m =");
		String n1=JOptionPane.showInputDialog("n =");
		int m=Integer.parseInt(m1);
		int n=Integer.parseInt(n1);
		int tong=0;
		NumberFormat nf=NumberFormat.getInstance();
		nf.setMaximumFractionDigits(3);
		for (int i=m;i<=n;i++) tong+=Math.pow(i,2);
		System.out.println("Trung binh cong binh phuong cac so nguyen tu "+m+" den "+n+" = "+nf.format(tong/(double) (n-m+1)));
		System.exit(0);
	}
}
