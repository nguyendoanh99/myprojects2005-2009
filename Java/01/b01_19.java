/*
 * Author: Nguyen Dang Khoa
 * Created: 04 tha´ng ta´m 2004 7:47:40 CH
 * Modified: 04 tha´ng ta´m 2004 7:47:40 CH
 */

/*
 * Viet chuong trinh nhap toa do x1, y1, x2, y2 cua 2 vecto
 * 2 chieu, sau do tinh roi in ra man hinh so do goc hop boi 
 * 2 vecto nay tinh theo do.
 */

import javax.swing.JOptionPane;
import java.text.NumberFormat;
public class b01_19
{
	public static void main(String[] args)
	{
		String x11=JOptionPane.showInputDialog("x1 = ");
		String y11=JOptionPane.showInputDialog("y1 = ");
		String x21=JOptionPane.showInputDialog("x2 = ");
		String y21=JOptionPane.showInputDialog("y2 = ");
		double x1=Double.parseDouble(x11);
		double y1=Double.parseDouble(y11);
		double x2=Double.parseDouble(x21);
		double y2=Double.parseDouble(y21);
		double t=Math.abs(x1*x2+y1*y2)/(Math.sqrt(Math.pow(x1,2)+Math.pow(y1,2))*Math.sqrt(Math.pow(x2,2)+Math.pow(y2,2)));
		NumberFormat nf=NumberFormat.getInstance();
		nf.setMaximumFractionDigits(3);
		System.out.println("Goc hop boi 2 vecto = "+nf.format(Math.toDegrees(Math.acos(t)))+" do.");
		System.exit(0);
	}
}
