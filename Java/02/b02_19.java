/*
 * Author: Nguyen Dang Khoa
 * Created: 05 tha´ng ta´m 2004 10:53:23 SA
 * Modified: 05 tha´ng ta´m 2004 10:53:23 SA
 */

/*
 * Viet chuong trinh nhap 2 so nguyen x, y, sau do kiem tra
 * xem x co la uoc so cua y hay co la uoc so cua x khong roi
 * in ket qua ra man hinh.
 */

import javax.swing.JOptionPane;
public class b02_19
{
	public static void main(String[] args)
	{
		String x1=JOptionPane.showInputDialog("x =");
		String y1=JOptionPane.showInputDialog("y =");
		int x=Integer.parseInt(x1);
		int y=Integer.parseInt(y1);
		if (y%x==0) System.out.println(x+"(x) la uoc so cua "+y+"(y).");
		else 
			if (x%y==0) System.out.println(y+"(y) la uoc so cua "+x+"(x).");
			else System.out.println(x+" va "+y+" khong phai la uoc so cua nhau.");
				
		System.exit(0);
	}
}
