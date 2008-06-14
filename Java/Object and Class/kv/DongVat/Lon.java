/*
 * Author: Nguyen Dang Khoa
 * Created: 27 tha´ng ta´m 2004 8:55:18 CH
 * Modified: 27 tha´ng ta´m 2004 8:55:18 CH
 */

package kv.DongVat;
public class Lon
{
	public Lon(String t)
	{
		ten=t;		
	}
	public void Xem()
	{
		DongVat.ten1="a1111";
		DongVat.Lay();
		Ga g=new Ga("as");
		System.out.println(DongVat.ten1+" "+g.Gat);
	}
	protected String ten="";
}
