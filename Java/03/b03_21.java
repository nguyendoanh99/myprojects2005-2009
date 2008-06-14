/*
 * Author: Nguyen Dang Khoa
 * Created: 11 tha´ng ta´m 2004 7:50:21 SA
 * Modified: 11 tha´ng ta´m 2004 7:50:21 SA
 */

/*
 * Viet chuong trinh nhap mot day toi da 100 so,
 * sau do in ra man hinh cac so trung nhau.
 */

import javax.swing.JOptionPane;
public class b03_21
{
	public static void main(String[] args)
	{
		String s=JOptionPane.showInputDialog("n =");
		int n=Integer.parseInt(s);
		int[] a=new int[n];
		for (int i=0;i<a.length;i++)
		{
			a[i]=(int) (Math.random()*10);
			System.out.print(a[i]+" ");
		}
		System.out.println();
		for (int i=0;i<a.length;i++)
		{
			int j=0;
			while ((j<i)&&(a[i]!=a[j])) j++;
			if (j<i) System.out.print(a[i]+" ");
		}
		System.exit(0);
	}
}
