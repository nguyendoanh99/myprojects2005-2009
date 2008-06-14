/*
 * Author: Nguyen Dang Khoa
 * Created: 27 tha´ng ta´m 2004 1:16:53 CH
 * Modified: 27 tha´ng ta´m 2004 1:16:53 CH
 */

package kv.DongVat;
public class Ga extends DongVat
{
	public Ga(String t)
	{
		super(t);
	}
	public String Mota()
	{
		return "Ga";
	}
	public void Hoi()
	{
		ten1="2";
		System.out.println("Hoi"+ten1);
	}
	protected String Gat="ga";
}
