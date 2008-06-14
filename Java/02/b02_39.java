/*
 * Author: Nguyen Dang Khoa
 * Created: 09 tha´ng ta´m 2004 10:46:20 SA
 * Modified: 09 tha´ng ta´m 2004 10:46:20 SA
 */

/*
 * Viet chuong trinh nhap 1 so nguyen duong viet duoi dang 
 * nhi phan (toi da 16 chu so), sau do doi ra so thap phan
 * roi in ket qua ra man hinh.
 */

import javax.swing.JOptionPane;
public class b02_39
{
	public static void main(String[] args)
	{
		String s=JOptionPane.showInputDialog("Nhap 1 so nguyen duoi dang nhi phan :");
		int t=0;
		for (int i=s.length()-1;i>=0;i--)
			if (s.charAt(i)=='1') 
//				t+=Integer.parseInt(Character.toString(s.charAt(i)))*Math.pow(2,s.length()-i-1);
				t+=1<<(s.length()-i-1);
		System.out.println(t);
		System.exit(0);
	}
}
