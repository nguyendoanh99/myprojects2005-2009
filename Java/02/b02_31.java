/*
 * Author: Nguyen Dang Khoa
 * Created: 06 tha´ng ta´m 2004 11:29:43 SA
 * Modified: 06 tha´ng ta´m 2004 11:29:43 SA
 */

/*
 * Viet chuong trinh nhap toi da 255 so thuc, sau do
 * tinh va in ra man hinh so nho nhat.
 */

import javax.swing.JOptionPane;
public class b02_31
{
	public static void main(String[] args)
	{
		
		String n1=JOptionPane.showInputDialog("Ban muon nhap bao nhieu so?");
		int n=Integer.parseInt(n1);
		double[] a=new double[n];
		String s;
		for (int i=1;i<=n;i++)
		{
			s=JOptionPane.showInputDialog("a["+i+"] =");
			a[i-1]=Double.parseDouble(s);
		}
		double min=a[0];
		for (int i=1;i<a.length;i++)
			if (min>a[i]) min=a[i];
		System.out.println("Min="+min);
		System.exit(0);
	}
}
