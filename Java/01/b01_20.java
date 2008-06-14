/*
 * Author: Nguyen Dang Khoa
 * Created: 04 tha´ng ta´m 2004 8:09:05 CH
 * Modified: 04 tha´ng ta´m 2004 8:09:05 CH
 */

/*
 * Viet chuong trinh nhap 1 string gom co 3 tu cach nhau 
 * boi 1 khoang trong, sau do in ra tung tu.
 */

import javax.swing.JOptionPane;
public class b01_20
{
	public static void main(String[] args)
	{
		String s=JOptionPane.showInputDialog("Nhap vao 1 chuoi : ");
		String[] t=s.split(" ");
/*
		String[] t=new String[3];
		int i=s.indexOf(" ");
		t[0]=s.substring(0,i);
		s=s.substring(i+1,s.length());
		i=s.indexOf(" ");
		t[1]=s.substring(0,i);
		t[2]=s.substring(i+1,s.length());
*/
		System.out.println("Tu thu nhat: "+t[0]);
		System.out.println("Tu thu hai: "+t[1]);
		System.out.println("Tu thu ba: "+t[2]);
		System.exit(0);
	}
}
