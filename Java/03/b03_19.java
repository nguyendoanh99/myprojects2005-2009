/*
 * Author: Nguyen Dang Khoa
 * Created: 10 tha´ng ta´m 2004 7:56:31 SA
 * Modified: 10 tha´ng ta´m 2004 7:56:31 SA
 */

/*
 * Co san mot day so. Hay viet chuong trinh nhap 1 so
 * x roi tim xem co phan tu nao trong day lon hon x hay khong.
 */

import javax.swing.JOptionPane;
public class b03_19
{
	public static void main(String[] args)
	{
		int[] a=new int[11];
		a[a.length-1]=Integer.MAX_VALUE;
		for (int i=0;i<a.length-1;i++) a[i]=(int) (Math.random()*100);
		for (int i=0;i<a.length-1;i++) System.out.print(a[i]+"  ");
		System.out.println();
		String s=JOptionPane.showInputDialog("x =");
		int x=Integer.parseInt(s);
		int i=0;
		while (a[i]<=x) i++;
		if (i==a.length-1) System.out.println("Khong co phan tu nao trong day so lon hon "+x);
		else System.out.println("Phan tu thu "+i+" lon hon "+x);
		System.exit(0);
	}
}
