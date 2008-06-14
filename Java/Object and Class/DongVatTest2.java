/*
 * Author: Nguyen Dang Khoa
 * Created: 29 tha´ng ta´m 2004 8:34:54 CH
 * Modified: 29 tha´ng ta´m 2004 8:34:54 CH
 */

import kv.DongVat.*;
import java.util.ArrayList;
public class DongVatTest2
{
	public static void main(String[] args)
	{
		ArrayList t=new ArrayList();
		int n=5;
		t.ensureCapacity(1);
		for (int i=0;i<n;i++) t.add(new Ga(String.valueOf(i)));
		try
		{
			t.set(0,new Ga("lll"));
			t.remove(5);
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
		t.add(4,new Ga("Ga1"));
		t.add(4,new Ga("Ga2"));		
		System.out.println(t.size());
		for (int i=1;i<=t.size();i++) 
			System.out.println((DongVat)t.get(i-1));
		Class cl=t.getClass();
		System.out.println(cl.getName());
		System.out.println(Double[].class.getName());
		System.out.println(Double[].class);
		System.out.println(int[].class.getName());
		System.out.println(DongVat[].class.getName());
		cl=((DongVat) t.get(0)).getClass();
		System.out.println(cl.getName());
		try
		{
			cl=Class.forName("kv.DongVat.Bo");
			System.out.println(cl);
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
		int[] to=new int[10];
		System.out.println(to.length);
		System.out.println(Object.class);
	}
}
