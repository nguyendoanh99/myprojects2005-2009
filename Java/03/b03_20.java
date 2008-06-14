/*
 * Author: Nguyen Dang Khoa
 * Created: 11 tha´ng ta´m 2004 6:59:55 SA
 * Modified: 11 tha´ng ta´m 2004 6:59:55 SA
 */

/*
 * Viet chuong trinh nhap 1 day toi da 100 so, sau do
 * in ra man hinh cac so khac nhau.
 */

import javax.swing.JOptionPane;
public class b03_20
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
			while ((j<i)&&(a[j]!=a[i])) j++;
			if (j==i) System.out.print(a[i]+" ");
		}
		System.exit(0);
	}
}
