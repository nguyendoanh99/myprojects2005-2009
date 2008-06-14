/*
 * Author: Nguyen Dang Khoa
 * Created: 26 tha´ng ta´m 2004 9:26:19 SA
 * Modified: 26 tha´ng ta´m 2004 9:26:19 SA
 */
package kv.PS;

public class PhanSo1 extends PhanSo
{
	// Contructors
	public PhanSo1(int t,int m)
	{
		super(t,m);
	}
	public PhanSo1(PhanSo ps)
	{
		super(ps);
	}
	// Set
	public void CongPS(PhanSo other)
	{
		int m=getMau()*other.getMau();
		int t=m/getMau()*getTu()+m/other.getMau()*other.getTu();
		setPhanSo(t,m);
	}
	public void Ve()
	{
		System.out.println("1");
	}
	private int pp=0;
}
