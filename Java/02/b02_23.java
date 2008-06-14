/*
 * Author: Nguyen Dang Khoa
 * Created: 06 tha´ng ta´m 2004 8:44:34 SA
 * Modified: 06 tha´ng ta´m 2004 8:44:34 SA
 */

/*
 * Viet chuong trinh in ra man hinh gia tri SIN cua tung
 * goc tu 1 den 45 do. Moi gia tri cach nhau 1 do va co
 * 5 gia tri tren moi dong.
 */

import java.text.NumberFormat;
public class b02_23
{
	public static void main(String[] args)
	{
		NumberFormat nf=NumberFormat.getInstance();
		nf.setMinimumFractionDigits(6);
		System.out.println("Gia tri SIN cua tung goc tu 1 den 45 do la (tinh bang do):");
		for (int i=1, d=1;i<=45;i++,d++)
		{
			if (d>5)
			{
				d=1;
				System.out.println();
			}
			System.out.print(nf.format(Math.sin(Math.toRadians(i)))+"  ");
		}
	}
}
