/*
 * Author: Nguyen Dang Khoa
 * Created: 06 tha´ng ta´m 2004 9:54:25 SA
 * Modified: 06 tha´ng ta´m 2004 9:54:25 SA
 */

/*
 * Viet chuong trinh giai phuong trinh bac 2 voi nghiem thuc.
 */

import javax.swing.JOptionPane;
import java.text.NumberFormat;
public class b02_24
{
	public static void main(String[] args)
	{
		NumberFormat nf=NumberFormat.getInstance();
		nf.setMaximumFractionDigits(3);
		String a1=JOptionPane.showInputDialog("a =");
		String b1=JOptionPane.showInputDialog("b =");
		String c1=JOptionPane.showInputDialog("c =");
		double a=Double.parseDouble(a1);
		double b=Double.parseDouble(b1);
		double c=Double.parseDouble(c1);
		double delta=Math.pow(b,2)-4*a*c;
		if (delta<0) System.out.println("Phuong trinh vo nghiem.");
		else
			if (delta==0) System.out.println("Phuong trinh co nghiem kep x="
						  +nf.format(-b/(2*a)));
			else
			{
				double x1=(-b+Math.sqrt(delta))/(2*a);
				double x2=(-b-Math.sqrt(delta))/(2*a);
				System.out.println("Phuong trinh co 2 nghiem: x1="+nf.format(x1)
				+", x2="+nf.format(x2));
			}
		System.exit(0);
	}
}
