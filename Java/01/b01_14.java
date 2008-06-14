/*
 * Author: Nguyen Dang Khoa
 * Created: 04 tha´ng ta´m 2004 10:13:41 SA
 * Modified: 04 tha´ng ta´m 2004 10:13:41 SA
 */

/*
 * Viet chuong trinh tinh the tich hinh cau neu dien tich
 * cua no duoc nhap tu ban phim.
 */

import javax.swing.JOptionPane;
import java.text.NumberFormat;
public class b01_14
{
	public static void main(String[] args)
	{
		String dt1=JOptionPane.showInputDialog("Nhap dien tich cua hinh cau?");
		double dt=Double.parseDouble(dt1);
		double r=Math.sqrt(dt/(4*Math.PI));
		double tt=(4*Math.PI*Math.pow(r,3))/3;
		NumberFormat nf=NumberFormat.getInstance();
		nf.setMaximumFractionDigits(2);
		System.out.println("The tich hing cau = "+nf.format(tt));
		System.exit(0);
	}
}
