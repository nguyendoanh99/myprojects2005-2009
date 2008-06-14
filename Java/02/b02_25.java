/*
 * Author: Nguyen Dang Khoa
 * Created: 06 tha´ng ta´m 2004 10:15:55 SA
 * Modified: 06 tha´ng ta´m 2004 10:15:55 SA
 */

/* 
 * Viet chuong trinh giai phuong trinh bac 2 voi nghiem phuc.
 */

import javax.swing.JOptionPane;
import java.text.NumberFormat;
public class b02_25
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
		if (delta<0)
		{
		}
		System.exit(0);
	}
}
