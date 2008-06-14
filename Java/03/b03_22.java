/*
 * Author: Nguyen Dang Khoa
 * Created: 17 tha´ng ta´m 2004 9:59:13 SA
 * Modified: 17 tha´ng ta´m 2004 9:59:13 SA
 */

/*
 * Viet chuong trinh nhap 1 day toi da 100 so, sau do
 * xet xem day so nay co la day tang khong.
 */

import javax.swing.JOptionPane;
public class b03_22
{
	public static void main(String[] args)
	{
		String s=JOptionPane.showInputDialog("n =");
		int n=Integer.parseInt(s);
		int[] a=new int[n+1];
		a[0]=Integer.MIN_VALUE;
		for (int i=1;i<=n;i++) 
		{
			s=JOptionPane.showInputDialog("A["+i+"]=");
			a[i]=Integer.parseInt(s);
		}
		int i=1;
		while ((i<=n)&&(a[i]>=a[i-1])) i++;
		if (i>n) System.out.println("Day tang.");
		else System.out.println("Day khong tang.");
		System.exit(0);
	}
}
