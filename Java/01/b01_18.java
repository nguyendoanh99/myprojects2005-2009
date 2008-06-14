/*
 * Author: Nguyen Dang Khoa
 * Created: 04 tha´ng ta´m 2004 7:29:18 CH
 * Modified: 04 tha´ng ta´m 2004 7:29:18 CH
 */

/*
 * Viet chuong trinh nhap mot cung bat ky do bang do, 
 * sau do tinh roi in ra man hinh SIN cua cung do.
 */

import javax.swing.JOptionPane;
import java.text.NumberFormat;
public class b01_18
{
	public static void main(String[] args)
	{
		String g1=JOptionPane.showInputDialog("Nhap vao so do goc cua 1 cung (tinh bang do)?");
		double g=Double.parseDouble(g1);
		NumberFormat nf=NumberFormat.getInstance();
		nf.setMaximumFractionDigits(3);
		String s=nf.format(Math.sin(Math.PI*g/180));
//		String s=nf.format(Math.sin(Math.toRadians(g)));
		System.out.println("SIN("+nf.format(g)+") = "+s);
		System.exit(0);
	}
}
