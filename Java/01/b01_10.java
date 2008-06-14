/*
 * Author: Nguyen Dang Khoa
 * Created: 03 tha´ng ta´m 2004 10:56:38 CH
 * Modified: 03 tha´ng ta´m 2004 10:56:38 CH
 */

/* Viet chuong nhap toa do x, y, z cua 1 vecto 3 chieu, 
 * sau do tinh roi in ra man hinh do dai cua vecto nay.
 */

import javax.swing.JOptionPane;
import java.text.NumberFormat;
public class b01_10
{
	public static void main(String[] args)
	{
		String x=JOptionPane.showInputDialog("x = ");
		String y=JOptionPane.showInputDialog("y = ");
		String z=JOptionPane.showInputDialog("z = ");
		double dd=Math.sqrt(Math.pow(Double.parseDouble(x),2)+Math.pow(Double.parseDouble(y),2)+Math.pow(Double.parseDouble(z),2));
		NumberFormat nf=NumberFormat.getNumberInstance();
		nf.setMaximumFractionDigits(2);
		String s=nf.format(dd);
		System.out.println("Do dai cua vec to = "+s);
		System.exit(0);
	}
}
