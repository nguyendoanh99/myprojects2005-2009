/*
 * Author: Nguyen Dang Khoa
 * Created: 27 tha´ng ta´m 2004 1:26:58 CH
 * Modified: 27 tha´ng ta´m 2004 1:26:58 CH
 */

import kv.DongVat.*;
public class DongVatTest
{
	public static void main(String[] args)
	{
		DongVat[] g=new DongVat[3];
		g[0]=new Ga("Ga 1");
		g[1]=new GaCon("Ga Con 2");
		g[2]=new Bo("Bo111 ");
		DongVat t=g[1];
		Lon l=new Lon("Lon");
		l.Xem();
		System.out.println(t);
		System.out.println(t.Mota());
//		DongVat.Lay();
		g[1].Get();
		g[1].Hoi();
		g[2].Mota();
		g[2].Hoi();
	}
}