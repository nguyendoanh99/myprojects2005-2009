//import java.util.*;

public class Arrays {
	private int arr[];
	public Arrays()
	{
		arr = new int[4];
		System.out.println("Tao");
	}
	public Arrays(Arrays a)
	{		
		arr = new int[a.arr.length];
		for (int i = 0; i < a.arr.length; ++i)
			arr[i] = a.arr[i];
		System.out.println("Copy");
	}
	public void finalize()
	{
		System.out.println("Huy");
	}
	public Arrays f()
	{
		Arrays a;
		a = new Arrays(this);
		return a;
	}
	public void tang()
	{
		for (int i = 0; i < arr.length; ++i)
			++arr[i];
	}
	public void in()
	{
		for (int i = 0; i < arr.length; ++i)
			System.out.print(arr[i] + " ");
		System.out.println();
	}
	public static void main(String[] arrs)
	{
		Arrays a = new Arrays();
		System.out.println("a: ");
		a.in();
		a.tang();		
		Arrays b;//=new Arrays(a);
//		a.tang();
//		a.tang();
		b = new Arrays(a);
		b.f();
		Arrays c = new Arrays(a);
		Arrays d;
		int t[];
		{
			t = new int[4];
			d = new Arrays(a);
		}
		t[3] = 3;
		d.in();
		c.tang();
		d.tang();
//		b = a;
		a.tang();
		System.out.println("a: ");
		a.in();
		System.out.println("b: ");
		b.in();
	}
} ///:~