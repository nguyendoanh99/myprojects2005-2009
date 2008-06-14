/*
 * Author: Nguyen Dang Khoa
 * Created: 04 tha´ng ta´m 2004 10:02:33 SA
 * Modified: 04 tha´ng ta´m 2004 10:02:33 SA
 */

/*
 * Viet chuong trinh nhap 3 so a, b, c la so do 3 canh
 * cua 1 tam giac, tinh dien tich tam giac nay roi in 
 * ket qua ra man hinh.
 */

import javax.swing.JOptionPane;
import java.text.NumberFormat;
public class b01_13
{
	public static void main(String[] args)
	{
		String a1=JOptionPane.showInputDialog("a = ");
		String b1=JOptionPane.showInputDialog("b = ");
		String c1=JOptionPane.showInputDialog("c = ");
		double a=Double.parseDouble(a1);
		double b=Double.parseDouble(b1);
		double c=Double.parseDouble(c1);
		double p=(a+b+c)/2.0;
		NumberFormat nf=NumberFormat.getNumberInstance();
		nf.setMaximumFractionDigits(2);
		String dt=nf.format(Math.sqrt(p*(p-a)*(p-b)*(p-c)));
		System.out.println("Dien tich tam giac : "+dt);
		System.exit(0);
	}
}
