/*
 * Author: Nguyen Dang Khoa
 * Created: 10 tha´ng ta´m 2004 7:43:13 SA
 * Modified: 10 tha´ng ta´m 2004 7:43:13 SA
 */

/*
 * Mot to giay co do day 0,1 mm. Phai gap doi to giay do bao 
 * nhieu lan de do day cua no hon 1m. Ban co gap doi 1 to giay 
 * 32 lan duoc khong.
 */

import java.text.NumberFormat;
public class b03_18
{
	public static void main(String[] args)
	{
		NumberFormat nf=NumberFormat.getInstance();
		nf.setMaximumFractionDigits(3);
		int i=0;
		float dd=0.1f;
		while (dd<=1000)
		{
			i++;
			dd*=2;
		}
		System.out.println("Phai gap doi to giay do "+i+" lan de do day cua no hon 1m.");
		System.out.println("Khong the gap doi 32 lan vi do day luc do la "+nf.format(0.1*Math.pow(2,32)/1000.0)+"m.");
	}
}
