/*
 * Author: Nguyen Dang Khoa
 * Created: 23 tha´ng ta´m 2004 7:18:43 SA
 * Modified: 23 tha´ng ta´m 2004 7:18:43 SA
 */
package kv.PS;
// Lop Phan so
public class PhanSo
{
	// Contructors
	public PhanSo()
	{
	}
	public PhanSo(int t,int m)
	{
		setPhanSo(t,m);
	}
	public PhanSo(PhanSo ps)
	{
		setPhanSo(ps);
	}
	// Display
	public final void DisplayPhanSo()
	{
		System.out.println(tu+"/"+mau);
	}
	// Set
	public void setPhanSo(int t,int m)
	{
		mau=m;
		tu=t;
	}
	public void setPhanSo(PhanSo ps)
	{
		mau=ps.mau;
		tu=ps.tu;
	}
	// Get
	public int getTu()
	{
		return tu;
	}
	public int getMau()
	{
		return mau;
	}
	public PhanSo getPhanSo()
	{
		PhanSo t=new PhanSo();
		getPhanSo(t);
		return t;
	}
	public void getPhanSo(PhanSo t)
	{
		t.tu=tu;
		t.mau=mau;
	}
	// static Get
	public static int getCount()
	{
		return count;
	}
	public String toString()
	{
		return getClass().getName()+"["+tu+", "+mau+"]";
	}
	public boolean equals(Object other)
	{
		if (this==other) return true;
		if (other==null) return false;
		if (getClass()!=other.getClass()) return false;
		PhanSo t=(PhanSo) other;
		return tu==t.tu && mau==t.mau;
	}
	// Instance fields
	private int tu=0;
	private int mau=1;
	private static int count;
	
	// object initialization block
	{
		count++;
	}
}