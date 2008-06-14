/*
 * Author: Nguyen Dang Khoa
 * Created: 04 tha´ng ta´m 2004 10:32:32 SA
 * Modified: 04 tha´ng ta´m 2004 10:32:32 SA
 */

/*
 * Viet chuong trinh tich luc hut giua 2 vat the co khoi luong
 * m1, m2, cach nhau 1 doan la d. (don vi tinh CGS)
 */

import javax.swing.JOptionPane;
import java.text.NumberFormat;
public class b01_15
{
	final static double G=6.672E-8;
	public static void main(String[] args)
	{
		String m11=JOptionPane.showInputDialog("m1 = ");
		String m21=JOptionPane.showInputDialog("m2 = ");
		String d1=JOptionPane.showInputDialog("d = ");
		double m1=Double.parseDouble(m11);
		double m2=Double.parseDouble(m21);
		double d=Double.parseDouble(d1);
		double f=G*m1*m2/Math.pow(d,2);
		NumberFormat nf=NumberFormat.getInstance();
		nf.setMaximumFractionDigits(10);
		System.out.println("F = "+nf.format(f));
		System.exit(0);
	}
}
