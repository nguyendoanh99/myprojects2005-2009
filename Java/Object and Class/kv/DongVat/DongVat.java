/*
 * Author: Nguyen Dang Khoa
 * Created: 27 tha´ng ta´m 2004 1:13:44 CH
 * Modified: 27 tha´ng ta´m 2004 1:13:44 CH
 */

package kv.DongVat;
public abstract class DongVat
{
	public DongVat(String t)
	{
		ten=t;
	}
	public void Get()
	{
		System.out.println(ten);
	}
	protected static void Lay()
	{
		System.out.println("Nguyen Dang Khoa");
	}
	public String toString()
	{
		return getClass().getName()+" "+ten;
	}
	public abstract String Mota();
	public abstract void Hoi();
	private String ten="";
	protected static String ten1="1";
}
