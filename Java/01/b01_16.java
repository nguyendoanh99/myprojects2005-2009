/*
 * Author: Nguyen Dang Khoa
 * Created: 04 tha´ng ta´m 2004 10:46:38 SA
 * Modified: 04 tha´ng ta´m 2004 10:46:38 SA
 */

/*
 * Viet chuong trinh nhap chu vi cua 1 hinh chu nhat, 
 * sau do in ra dien tich lon nhat ma hinh chu nhat do co the co duoc.
 */

import javax.swing.JOptionPane;
import java.text.NumberFormat;
public class b01_16
{
	public static void main(String[] args)
	{
		String cv1=JOptionPane.showInputDialog("Chu vi hinh chu nhat?");
		double cv=Double.parseDouble(cv1);
		NumberFormat nf=NumberFormat.getInstance();
		nf.setMaximumFractionDigits(2);
		String s=nf.format(Math.pow(cv/2.0,2));
		System.out.println("Dien tich lon nhat cua hinh chu nhat la : "+s);
		System.exit(0);
	}
}
