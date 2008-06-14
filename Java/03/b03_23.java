/*
 * Author: Nguyen Dang Khoa
 * Created: 17 tha´ng ta´m 2004 10:12:18 SA
 * Modified: 17 tha´ng ta´m 2004 10:12:18 SA
 */

/*
 * Viet chuong trinh nhap 1 day toi da 100 so, sau do
 * xet xem day so nay co la day doi xung hay khong.
 */

import javax.swing.JOptionPane;
public class b03_23
{
	public static void main(String[] args)
	{
		String s=JOptionPane.showInputDialog("n=");
		int n=Integer.parseInt(s);
		int[] a=new int[n];
		for (int i=0;i<n;i++)
		{
			s=JOptionPane.showInputDialog("A["+i+"]=");
			a[i]=Integer.parseInt(s);
		}
		int i=0;
		while ((i<=n/2)&&(a[i]==a[n-i-1])) i++;
		if (i>n/2) System.out.println("Day doi xung.");
		else System.out.println("Doi bat doi xung.");
		System.exit(0);
	}
}
