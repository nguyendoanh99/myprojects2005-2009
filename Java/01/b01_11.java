/*
 * Author: Nguyen Dang Khoa
 * Created: 04 tha´ng ta´m 2004 8:28:08 SA
 * Modified: 04 tha´ng ta´m 2004 8:28:08 SA
 */

/*
 * Viet chuong trinh nhap phuong trinh duong thang
 * co dang: Ax+By+C=0 va toa do mot diem P(x,y). 
 * Sau do tinh va in ra man hinh khoang cach tu diem 
 * A den duong thang nay. Yeu cau: lay 6 so le.
 */

import javax.swing.JOptionPane;
import java.text.NumberFormat;
public class b01_11
{
	public static void main(String[] args)
	{
		String a1=JOptionPane.showInputDialog("A = ");
		String b1=JOptionPane.showInputDialog("B = ");
		String c1=JOptionPane.showInputDialog("C = ");
		String x1=JOptionPane.showInputDialog("x = ");
		String y1=JOptionPane.showInputDialog("y = ");
		double a=Double.parseDouble(a1);
		double b=Double.parseDouble(b1);
		double c=Double.parseDouble(c1);
		double x=Double.parseDouble(x1);
		double y=Double.parseDouble(y1);
		NumberFormat nf=NumberFormat.getNumberInstance();
		nf.setMaximumFractionDigits(6);
		double kc=Math.abs(a*x+b*y+c)/Math.sqrt(Math.pow(a,2)+Math.pow(b,2));
		String s=nf.format(kc);
		System.out.println("Khoang cach = "+s);
		System.exit(0);
	}
}
