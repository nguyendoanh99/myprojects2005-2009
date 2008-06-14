/*
 * Author: Nguyen Dang Khoa
 * Created: 04 tha´ng ta´m 2004 8:47:22 SA
 * Modified: 04 tha´ng ta´m 2004 8:47:22 SA
 */

/*
 * Viet chuong trinh nhap 3 so nguyen duong a, b, c,
 * sau do tinh va in ra man hinh gia tri cua trung 
 * binh cong S, trung binh nhan P cua 3 so do.
 */

import javax.swing.JOptionPane;
import java.text.NumberFormat;
public class b01_12
{
	public static void main(String[] args)
	{
		String a1=JOptionPane.showInputDialog("a = ");
		String b1=JOptionPane.showInputDialog("b = ");
		String c1=JOptionPane.showInputDialog("c = ");
		int a=Integer.parseInt(a1);
		int b=Integer.parseInt(b1);
		int c=Integer.parseInt(c1);
		NumberFormat nf=NumberFormat.getNumberInstance();
		nf.setMaximumFractionDigits(2);
		String s=nf.format((a+b+c)/3.0);
		System.out.println("S = "+s);
		s=nf.format(Math.exp((1/3.0)*Math.log(a*b*c)));
		System.out.println("P = "+s);
		System.exit(0);
	}
}
