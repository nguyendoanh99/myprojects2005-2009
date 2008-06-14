/*
 * Author: Nguyen Dang Khoa
 * Created: 19 tha´ng ta´m 2004 10:12:43 SA
 * Modified: 19 tha´ng ta´m 2004 10:12:43 SA
 */
import kv.PS.*;
public class PhanSoTest
{
	public static void main(String[] args)
	{
		System.out.println("count = "+PhanSo1.getCount());	
		
		System.out.println("Truoc khi sua");
		PhanSo ps1=new PhanSo();
		System.out.print("ps1 ");
		ps1.DisplayPhanSo();
		PhanSo ps2=ps1;
		System.out.print("ps2 ");
		ps2.DisplayPhanSo();
		
		System.out.println("Sau khi sua");
		ps1.setPhanSo(4,5);
		System.out.print("ps1 ");
		ps1.DisplayPhanSo();
		System.out.print("ps2 ");
		ps2.DisplayPhanSo();
		PhanSo ps3=new PhanSo(ps2);
		System.out.print("ps3 ");
		ps3.DisplayPhanSo();
		System.out.println();
		ps3.setPhanSo(1,10);
		System.out.print("ps3 ");
		ps3.DisplayPhanSo();
		ps2=ps3.getPhanSo();
		ps3.getPhanSo(ps1);
		System.out.print("ps1 ");
		ps1.DisplayPhanSo();
		System.out.print("ps2 ");
		ps2.DisplayPhanSo();
		System.out.println("ps3 "+ps3.getTu()+"/"+ps3.getMau());
		System.out.println("count = "+PhanSo.getCount());
		PhanSo1 ps4=new PhanSo1(10,4);
		System.out.print("ps4 ");
		ps4.DisplayPhanSo();
		ps3=ps4;
		ps4.Ve();
//		if (ps3 instanceof PhanSo1) 
			PhanSo1 ps6=(PhanSo1) ps3;
		System.out.print("ps6 ");
		ps6.DisplayPhanSo();
		System.out.print("ps3 ");
		ps3.DisplayPhanSo();
		ps4.CongPS(ps3);
		System.out.print("ps4 ");
		ps4.DisplayPhanSo();
		PhanSo1 ps5=new PhanSo1(2,3);
		System.out.print("ps5 ");
		ps5.DisplayPhanSo();
		ps4.CongPS(ps5);
		System.out.print("ps4 ");
		ps4.DisplayPhanSo();
		System.out.println("count "+PhanSo1.getCount());
		System.out.println("ps2 "+ps2);
		System.out.println(ps3.equals(ps4));
	}
}
