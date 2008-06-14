/*
 * Author: Nguyen Dang Khoa
 * Created: 06 tha´ng ta´m 2004 11:40:46 SA
 * Modified: 06 tha´ng ta´m 2004 11:40:46 SA
 */

/* 
 * Viet chuong trinh nhap gia gao cua 12 ky lien tiep, sau do
 * tinh gia gao trung binh va cho biet ky nao gao cao nhat, thap nhat.
 */

import javax.swing.JOptionPane;
import java.text.NumberFormat;
public class b02_32
{
	public static void main(String[] args)
	{
		NumberFormat nf=NumberFormat.getInstance();
		nf.setMaximumFractionDigits(3);
		String s;
		double[] a=new double[12];
		System.out.println("Ban hay nhap gia gao cua 12 ky lien tiep...");
		for (int i=1;i<=12;i++)
		{
			s=JOptionPane.showInputDialog("Gia gao ky "+i);
			a[i-1]=Double.parseDouble(s);
			System.out.println("Gia gao ky "+i+" la "+a[i-1]);
		}
		double max=a[0],min=a[0];
		double tong=a[0];
		int dmax=0,dmin=0;
		for (int i=1;i<12;i++)
		{
			if (a[i]>max) 
			{
				max=a[i];
				dmax=i;
			}
			else
				if (a[i]<min)
				{
					min=a[i];
					dmin=i;
				}
			tong+=a[i];
		}
		System.out.println("Gia gao trung binh trong 12 ky lien tiep la: "+nf.format(tong/12));
		System.out.println("Gia gao ky "+(dmax+1)+" la cao nhat.");
		System.out.println("Gia gao ky "+(dmin+1)+" la thap nhat.");
		System.exit(0);
	}
}
