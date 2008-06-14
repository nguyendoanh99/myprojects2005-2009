/*
 * Author: Nguyen Dang Khoa
 * Created: 06 tha´ng ta´m 2004 8:27:05 SA
 * Modified: 06 tha´ng ta´m 2004 8:27:05 SA
 */

/*
 * Lai suat ngan hang la 1,5% moi thang. Viet chuong trinh 
 * de tinh xem neu goi 1.000.000$ trong vong 2 nam thi ca von
 * lan loi se la bao nhieu.
 */

import java.text.NumberFormat;
public class b02_22
{
	public static void main(String[] args)
	{
		NumberFormat nf=NumberFormat.getInstance();
		nf.setMaximumFractionDigits(4);
		double t=1000000f;
		for (int i=1;i<=2*12;i++) t+=t*0.015;
		System.out.println("So tien gom ca von lan lai sau 2 nam la : "+nf.format(t));
	}
}
